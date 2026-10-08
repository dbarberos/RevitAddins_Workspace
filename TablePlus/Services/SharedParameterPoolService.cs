using System.IO;
using System.Text;
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
    public const string RowIndexParamName = "TP_Row_Index";
    public const string RowIndexParamGuid = "f9a2b1c0-3d4e-5f6a-7b8c-9d0e1f2a3b4c";
    public const int DefaultPoolSize = 20;

    private static readonly Dictionary<int, string> PredefinedParamGuids = new()
    {
        { 1, "a2c878d4-1b7d-4940-9a98-a5eb6d81ade1" },
        { 2, "d240a402-cb1b-4c1d-8a54-94d94c352b1a" },
        { 3, "9fecefdb-5b4b-4fdf-8285-b456d25fe830" },
        { 4, "f7c2b6d5-9d6e-4da4-9424-fb8ec4211b38" },
        { 5, "59347e26-d30f-4c41-8f10-cdc8e62da5c3" },
        { 6, "b3713575-54b6-4ed8-ad52-4c17d6a84674" },
        { 7, "16ca00a7-eb52-4de8-9976-1aebf55ee327" },
        { 8, "1774ecac-870c-4fe2-a9b2-bc1ae82f1b39" },
        { 9, "20211b7f-4167-4ac5-b819-baadd5e90cd2" },
        { 10, "f15d48db-db5d-47ac-82b9-4b626bd686ed" },
        { 11, "c300bfce-12b3-4762-90c2-8caae4ff6973" },
        { 12, "90f6c421-69ef-42b7-9a89-605b3a0354ba" },
        { 13, "ac46d065-0ea2-4464-883c-d593ed9139db" },
        { 14, "96b102b7-7110-49d1-a019-a2ed207e1545" },
        { 15, "521c10d4-65e1-4d00-997a-020ae98ce891" },
        { 16, "01e9032a-7d3a-4bb3-857e-5a656fde9df6" },
        { 17, "cd9b3470-bec5-49d8-9c74-12b404dc8170" },
        { 18, "251b4891-b507-43d7-bb3e-4e8fd93e5586" },
        { 19, "bacb2727-7e0d-4eaf-a34b-d0f58713c731" },
        { 20, "e5545910-2b8c-4d35-b80d-64653ae36932" },
    };

    /// <summary>
    /// Formats the parameter name for a given 1-based column index (e.g. TP_Column_01).
    /// </summary>
    public static string GetColumnParamName(int columnIndex)
    {
        return $"{ParamPrefix}{columnIndex:D2}";
    }

    /// <summary>
    /// Obtains a deterministic GUID string for a given 1-based column index.
    /// </summary>
    public static string GetColumnParamGuid(int columnIndex)
    {
        if (PredefinedParamGuids.TryGetValue(columnIndex, out var guid))
        {
            return guid;
        }
        return $"00000000-0000-4000-8000-{columnIndex:D12}";
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

        bool isRowIndexMissing = !IsParameterBoundToCategory(doc, RowIndexParamName, genericModelCat.Id);

        for (int i = 1; i <= targetCount; i++)
        {
            string paramName = GetColumnParamName(i);
            if (!IsParameterBoundToCategory(doc, paramName, genericModelCat.Id))
            {
                missingIndices.Add(i);
            }
        }

        if (missingIndices.Count == 0 && !isRowIndexMissing)
        {
            LoggerService.LogInfo($"[SharedParameterPoolService] All {targetCount} column parameters and {RowIndexParamName} are already bound to OST_GenericModel.");
            return;
        }

        LoggerService.LogInfo($"[SharedParameterPoolService] Binding {missingIndices.Count} missing column parameters (target count: {targetCount}, rowIndexMissing: {isRowIndexMissing})...");

        // 2. Open or create the TablePlus shared parameters file (strictly UTF-16 LE)
        string originalSharedParamFile = app.SharedParametersFilename;
        string tempSharedParamFile = GetOrCreateSharedParamFile(targetCount);

        bool ownsTx = !doc.IsModifiable;
        Transaction? tx = null;
        if (ownsTx)
        {
            tx = new Transaction(doc, "TablePlus: Bind Column Parameters");
            var opts = tx.GetFailureHandlingOptions();
            opts.SetFailuresPreprocessor(new WarningSwallower());
            tx.SetFailureHandlingOptions(opts);
            tx.Start();
        }

        try
        {
            app.SharedParametersFilename = tempSharedParamFile;
            DefinitionFile? defFile = null;
            try
            {
                defFile = app.OpenSharedParameterFile();
            }
            catch (Exception ex)
            {
                LoggerService.LogWarning($"[SharedParameterPoolService] OpenSharedParameterFile failed ({ex.Message}). Regenerating clean UTF-16 LE file...");
                CreateCleanSharedParamFile(tempSharedParamFile, targetCount);
                app.SharedParametersFilename = tempSharedParamFile;
                defFile = app.OpenSharedParameterFile();
            }

            if (defFile == null)
            {
                LoggerService.LogWarning("[SharedParameterPoolService] Failed to open shared parameter file after regeneration.");
                return;
            }

            var group = defFile.Groups.get_Item(GroupName) ?? defFile.Groups.Create(GroupName);

            var catSet = app.Create.NewCategorySet();
            catSet.Insert(genericModelCat);

            // Bind TP_Row_Index if missing
            if (isRowIndexMissing)
            {
                var def = group.Definitions.get_Item(RowIndexParamName);
                if (def == null)
                {
#if REVIT2024_OR_GREATER
                    var creationOpt = new ExternalDefinitionCreationOptions(RowIndexParamName, SpecTypeId.String.Text)
                    {
                        UserModifiable = true,
                        Description = "TablePlus row sorting index"
                    };
#else
                    var creationOpt = new ExternalDefinitionCreationOptions(RowIndexParamName, ParameterType.Text)
                    {
                        UserModifiable = true,
                        Description = "TablePlus row sorting index"
                    };
#endif
                    def = group.Definitions.Create(creationOpt);
                }

                if (def != null && !IsParameterBoundToCategory(doc, RowIndexParamName, genericModelCat.Id))
                {
                    var instanceBinding = app.Create.NewInstanceBinding(catSet);
#if REVIT2024_OR_GREATER
                    doc.ParameterBindings.Insert(def, instanceBinding, GroupTypeId.Data);
#else
                    doc.ParameterBindings.Insert(def, instanceBinding, BuiltInParameterGroup.PG_DATA);
#endif
                    LoggerService.LogInfo($"[SharedParameterPoolService] Bound parameter '{RowIndexParamName}' to OST_GenericModel.");
                }
            }

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

            if (ownsTx && tx != null)
            {
                tx.Commit();
            }
        }
        catch (Exception ex)
        {
            if (ownsTx && tx != null && tx.HasStarted() && !tx.HasEnded())
            {
                tx.RollBack();
            }
            LoggerService.LogError("[SharedParameterPoolService] Error ensuring shared parameters", ex);
        }
        finally
        {
            if (ownsTx && tx != null)
            {
                tx.Dispose();
            }

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
                foreach (Category cat in binding.Categories)
                {
                    if (cat.Id == categoryId)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private static string GetOrCreateSharedParamFile(int poolSize = DefaultPoolSize)
    {
        string folder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Autodesk", "Revit", "Addins", "TablePlus");

        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }

        string filePath = Path.Combine(folder, "TablePlus_SharedParameters.txt");

        // Validate existing file: Must exist, be at least 100 bytes, start with UTF-16 LE BOM (0xFF, 0xFE), and contain TP_Row_Index
        bool isValid = false;
        if (File.Exists(filePath))
        {
            try
            {
                var bytes = File.ReadAllBytes(filePath);
                if (bytes.Length >= 100 && bytes[0] == 0xFF && bytes[1] == 0xFE)
                {
                    string content = Encoding.Unicode.GetString(bytes);
                    if (content.Contains(RowIndexParamName))
                    {
                        isValid = true;
                    }
                }
            }
            catch
            {
                isValid = false;
            }
        }

        if (!isValid)
        {
            CreateCleanSharedParamFile(filePath, Math.Max(poolSize, DefaultPoolSize));
        }

        return filePath;
    }

    private static void CreateCleanSharedParamFile(string filePath, int poolSize)
    {
        var sb = new StringBuilder();
        sb.AppendLine("# This is a Revit shared parameter file for TablePlus.");
        sb.AppendLine("# Do not edit manually.");
        sb.AppendLine("*META\tVERSION\tMINVERSION");
        sb.AppendLine("META\t2\t1");
        sb.AppendLine("*GROUP\tID\tNAME");
        sb.AppendLine("GROUP\t1\tTablePlus");
        sb.AppendLine("*PARAM\tGUID\tNAME\tDATATYPE\tDATACATEGORY\tGROUP\tVISIBLE\tDESCRIPTION\tUSERMODIFIABLE");

        // Row index parameter for preserving natural Excel row order in Key Schedules
        sb.AppendLine($"PARAM\t{RowIndexParamGuid}\t{RowIndexParamName}\tTEXT\t\t1\t1\tTablePlus row sorting index\t1\t0");

        int count = Math.Max(poolSize, DefaultPoolSize);
        for (int i = 1; i <= count; i++)
        {
            string guid = GetColumnParamGuid(i);
            string paramName = GetColumnParamName(i);
            sb.AppendLine($"PARAM\t{guid}\t{paramName}\tTEXT\t\t1\t1\tTablePlus reusable column parameter\t1\t0");
        }

        // Must strictly use Unicode (UTF-16 LE with BOM 0xFF, 0xFE) for Revit's C++ readParamDatabase parser
        File.WriteAllText(filePath, sb.ToString(), Encoding.Unicode);
        LoggerService.LogInfo($"[SharedParameterPoolService] Created clean UTF-16 LE shared parameter file with {count} column definitions.");
    }
}
