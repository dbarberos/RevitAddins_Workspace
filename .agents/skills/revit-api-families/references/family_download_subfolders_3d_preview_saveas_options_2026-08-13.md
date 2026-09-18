# Technical Guide: Family Export & Download Operations (Category Subfolders, 3D Preview SaveAsOptions, and Export Logging)

**Domain:** Autodesk Revit API (`Autodesk.Revit.DB`) - Family API & Export Orchestration  
**Stack:** C# 12 / .NET Framework 4.8 / .NET 8  

---

## 1. Overview
When exporting or downloading `.rfa` families from host Revit models or cloud repositories (AWS S3, Azure Blob, ACC), three key features control file organization, thumbnail presentation, and auditing:

1. **Category Subfolders (`SaveInSubfoldersOnDownload`)**: Organizes exported `.rfa` files into subdirectories named after their Revit Category (`family.CategoryName`).
2. **3D Preview View Assignment (`SetDefaultView3DOnDownload`)**: Forces Revit to set a 3D isometric view as `SaveAsOptions.PreviewViewId` during `SaveAs`.
3. **Export Logging (`ExportLogOnDownload`)**: Generates structured `.txt` export logs detailing exported symbols, category names, Revit versions, and success/error tracebacks.

---

## 2. Category Subfolder Creation & Path Sanitization

Windows file system paths forbid characters like `\ / : * ? " < > |`. Category names must be sanitized before invoking `Directory.CreateDirectory`.

```csharp
private static string SanitizeFolderName(string folderName)
{
    if (string.IsNullOrWhiteSpace(folderName)) return "Uncategorized";
    
    var invalidChars = System.IO.Path.GetInvalidFileNameChars()
        .Concat(System.IO.Path.GetInvalidPathChars())
        .Distinct();
        
    foreach (var c in invalidChars)
    {
        folderName = folderName.Replace(c.ToString(), "_");
    }
    return folderName.Trim();
}

// Usage in Family Download Loop:
string targetFolderForFamily = baseDestinationFolder;
if (saveInSubfoldersOnDownload)
{
    string catName = !string.IsNullOrWhiteSpace(family.CategoryName) ? family.CategoryName : "Uncategorized";
    string safeCatFolder = SanitizeFolderName(catName);
    targetFolderForFamily = System.IO.Path.Combine(baseDestinationFolder, safeCatFolder);
    
    if (!System.IO.Directory.Exists(targetFolderForFamily))
    {
        System.IO.Directory.CreateDirectory(targetFolderForFamily);
    }
}
```

---

## 3. 3D Preview View Assignment via `SaveAsOptions.PreviewViewId`

In the Revit API, thumbnail previews for `.rfa` family files are generated from a designated view `ElementId` passed to `SaveAsOptions.PreviewViewId`.

> [!NOTE]
> The enum value for 3D views in `ViewFamily` is **`ViewFamily.ThreeDimensional`** (not `ThreeD`).

```csharp
var saveOptions = new SaveAsOptions { OverwriteExistingFile = true };

if (setDefaultView3D)
{
    try
    {
        // 1. Search for an existing 3D View in the family document
        var view3D = new FilteredElementCollector(familyDoc)
            .OfClass(typeof(View3D))
            .Cast<View3D>()
            .FirstOrDefault(v => !v.IsTemplate);

        if (view3D != null)
        {
            saveOptions.PreviewViewId = view3D.Id;
        }
        else
        {
            // 2. Dynamically create an Isometric 3D View if family geometry permits
            var viewFamilyType = new FilteredElementCollector(familyDoc)
                .OfClass(typeof(ViewFamilyType))
                .Cast<ViewFamilyType>()
                .FirstOrDefault(v => v.ViewFamily == ViewFamily.ThreeDimensional);

            if (viewFamilyType != null)
            {
                using (var t = new Transaction(familyDoc, "Create 3D View for Preview"))
                {
                    t.Start();
                    var createdView3D = View3D.CreateIsometric(familyDoc, viewFamilyType.Id);
                    if (createdView3D != null)
                    {
                        createdView3D.Name = "{3D - Preview}";
                        saveOptions.PreviewViewId = createdView3D.Id;
                    }
                    t.Commit();
                }
            }
        }
    }
    catch (Exception ex)
    {
        TelemetryLogger.LogWarning($"[SaveAsOptions] Could not set 3D preview view for '{exportFileName}': {ex.Message}");
    }
}

familyDoc.SaveAs(targetRfaPath, saveOptions);
```

---

## 4. UI Switch Control Pattern (Non-Mutually Exclusive)

To allow users to independently select multiple export options (0, 1, 2, or all 3 simultaneously), use WPF `CheckBox` controls styled with `{StaticResource SwitchStyle}` instead of `RadioButton`:

```xaml
<StackPanel VerticalAlignment="Center">
    <CheckBox Content="Save elements in subfolders (categories)" 
              Style="{StaticResource SwitchStyle}"
              IsChecked="{Binding SaveInSubfoldersOnDownload}" 
              Margin="0,0,0,6"/>

    <CheckBox Content="Set Default View as 3D" 
              Style="{StaticResource SwitchStyle}"
              IsChecked="{Binding SetDefaultView3DOnDownload}" 
              Margin="0,0,0,6"/>

    <CheckBox Content="Include Export Log when download" 
              Style="{StaticResource SwitchStyle}"
              IsChecked="{Binding ExportLogOnDownload}"/>
</StackPanel>
```
