using System.IO;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;

namespace TablePlus.Services;

/// <summary>
/// Manages a controlled, reusable pool of shared parameters (TP_Column_01 .. TP_Column_N)
/// for native Revit Key Schedules. Prevents Revit project parameter pollution by reusing
/// generic column slots whose visible labels are dynamically mapped via ScheduleField.ColumnHeading.
/// </summary>
public static class SharedParameterPoolService
{
    private const string GroupName = "TablePlus";
    public const string ParamPrefix = "TP_Column_";
    public const int DefaultPoolSize = 20;

    /// <summary>
    /// Formats the parameter name for a given 1-based column index (e.g. TP_Column_01).
    /// </summary>
    public static string GetColumnParamName(int columnIndex)
    {
        return $"{ParamPrefix}{columnIndex:D2}";
    }

    /// <summary>
    /// Ensures that parameters TP_Column_01 .. TP_Column_count exist in the project
    /// and are bound to BuiltInCategory.OST_GenericModel as instance parameters.
    /// </summary>
    public static void EnsureParametersBound(Document doc, int requiredColumnsCount)
    {
        if (doc == null) throw new ArgumentNullException(nameof(doc));
        if (requiredColumnsCount <= 0) return;

        var app = doc.Application;
        int targetCount = Math.Max(requiredColumnsCount, DefaultPoolSize);

        // 1. Check existing bindings in doc to avoid touching shared parameter file if all are already bound
        var missingIndices = new List<int>();
        var genericModelCat = doc.Settings.Categories.get_Item(BuiltInCategory.OST_GenericModel);
        if (genericModelCat == null) return;

        for (int i = 1; i <= targetCount; i++)
        {
            string paramName = GetColumnParamName(i);
            if (!IsParameterBoundToCategory(doc, paramName, genericModelCat.Id))
            {
                missingIndices.Add(i);
            }
        }

        if (missingIndices.Count == 0)
        {
            LoggerService.LogInfo($"[SharedParameterPoolService] All {targetCount} column parameters are already bound to OST_GenericModel.");
            return;
        }

        LoggerService.LogInfo($"[SharedParameterPoolService] Binding {missingIndices.Count} missing column parameters (target count: {targetCount})...");

        // 2. Open or create the TablePlus shared parameters file
        string originalSharedParamFile = app.SharedParametersFilename;
        string tempSharedParamFile = GetOrCreateSharedParamFile(app);

        try
        {
            app.SharedParametersFilename = tempSharedParamFile;
            var defFile = app.OpenSharedParameterFile();
            if (defFile == null)
            {
                LoggerService.LogWarning("[SharedParameterPoolService] Failed to open shared parameter file.");
                return;
            }

            var group = defFile.Groups.get_Item(GroupName) ?? defFile.Groups.Create(GroupName);

            var catSet = app.Create.NewCategorySet();
            catSet.Insert(genericModelCat);

            foreach (int index in missingIndices)
            {
                string paramName = GetColumnParamName(index);
                var def = group.Definitions.get_Item(paramName);

                if (def == null)
                {
#if REVIT2024_OR_GREATER
                    var creationOpt = new ExternalDefinitionCreationOptions(paramName, SpecTypeId.String.Text)
                    {
                        UserModifiable = true,
                        Description = "TablePlus reusable column parameter"
                    };
#else
                    var creationOpt = new ExternalDefinitionCreationOptions(paramName, ParameterType.Text)
                    {
                        UserModifiable = true,
                        Description = "TablePlus reusable column parameter"
                    };
#endif
                    def = group.Definitions.Create(creationOpt);
                }

                if (def != null && !IsParameterBoundToCategory(doc, paramName, genericModelCat.Id))
                {
                    var instanceBinding = app.Create.NewInstanceBinding(catSet);
#if REVIT2024_OR_GREATER
                    doc.ParameterBindings.Insert(def, instanceBinding, GroupTypeId.Data);
#else
                    doc.ParameterBindings.Insert(def, instanceBinding, BuiltInParameterGroup.PG_DATA);
#endif
                    LoggerService.LogInfo($"[SharedParameterPoolService] Bound parameter '{paramName}' to OST_GenericModel.");
                }
            }
        }
        catch (Exception ex)
        {
            LoggerService.LogError("[SharedParameterPoolService] Error ensuring shared parameters", ex);
        }
        finally
        {
            // Restore original shared parameter file to avoid altering user's Revit environment
            try
            {
                if (!string.IsNullOrWhiteSpace(originalSharedParamFile) && File.Exists(originalSharedParamFile))
                {
                    app.SharedParametersFilename = originalSharedParamFile;
                }
            }
            catch
            {
                // Ignore restoration errors
            }
        }
    }

    private static bool IsParameterBoundToCategory(Document doc, string paramName, ElementId categoryId)
    {
        var iterator = doc.ParameterBindings.ForwardIterator();
        while (iterator.MoveNext())
        {
            if (iterator.Key?.Name == paramName && iterator.Current is ElementBinding binding)
            {
                if (binding.Categories.Contains(doc.Settings.Categories.get_Item(BuiltInCategory.OST_GenericModel)))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private static string GetOrCreateSharedParamFile(Autodesk.Revit.ApplicationServices.Application app)
    {
        string folder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Autodesk", "Revit", "Addins", "TablePlus");

        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }

        string filePath = Path.Combine(folder, "TablePlus_SharedParameters.txt");
        if (!File.Exists(filePath))
        {
            var lines = new[]
            {
                "# This is a Revit shared parameter file for TablePlus.",
                "# Do not edit manually.",
                "*META\tVERSION\tMINVERSION",
                "META\t2\t1",
                "*GROUP\tID\tNAME",
                "GROUP\t1\tTablePlus",
                "*PARAM\tGUID\tNAME\tDATATYPE\tDATACATEGORY\tGROUP\tVISIBLE\tDESCRIPTION\tUSERMODIFIABLE"
            };
            File.WriteAllLines(filePath, lines);
        }

        return filePath;
    }
}
