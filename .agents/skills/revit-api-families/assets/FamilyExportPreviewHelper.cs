using System;
using System.IO;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitApiFamilies.Assets
{
    /// <summary>
    /// Reusable utility helper for sanitizing folder names and configuring SaveAs 3D Preview views.
    /// </summary>
    public static class FamilyExportPreviewHelper
    {
        /// <summary>
        /// Sanitizes a category name for illegal Windows path characters.
        /// </summary>
        public static string SanitizeFolderName(string folderName)
        {
            if (string.IsNullOrWhiteSpace(folderName)) return "Uncategorized";
            
            var invalidChars = Path.GetInvalidFileNameChars()
                .Concat(Path.GetInvalidPathChars())
                .Distinct();

            foreach (var c in invalidChars)
            {
                folderName = folderName.Replace(c.ToString(), "_");
            }
            return folderName.Trim();
        }

        /// <summary>
        /// Configures SaveAsOptions to set the default preview view of an .rfa family document to a 3D view.
        /// </summary>
        public static void ConfigureDefault3DPreviewView(Document familyDoc, SaveAsOptions saveOptions, string exportFileName)
        {
            if (familyDoc == null || saveOptions == null) return;

            try
            {
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
                System.Diagnostics.Debug.WriteLine($"[SaveAsOptions] Could not set 3D preview view for '{exportFileName}': {ex.Message}");
            }
        }
    }
}
