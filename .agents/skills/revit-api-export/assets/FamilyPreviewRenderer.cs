using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitAddin.ExportHelpers
{
    /// <summary>
    /// Utility class for generating dynamic 2D and 3D previews for any Revit Family or Title Block.
    /// Uses in-memory EditFamily inspection, dedicated ViewSheet hosting, and silent transaction rollbacks.
    /// </summary>
    public static class FamilyPreviewRenderer
    {
        public static string? GenerateFamilyPreview(Family nativeFam, Document? targetDoc = null)
        {
            if (nativeFam == null || !nativeFam.IsValidObject) return null;
            Document? doc = nativeFam.Document ?? targetDoc;
            if (doc == null) return null;

            string tempDir = Path.Combine(Path.GetTempPath(), "Revit_Previews", Guid.NewGuid().ToString("N"));
            if (!Directory.Exists(tempDir)) Directory.CreateDirectory(tempDir);
            string baseFilePath = Path.Combine(tempDir, "preview");

            // Strategy 1: EditFamily in memory
            if (nativeFam.IsEditable)
            {
                Document? famDoc = null;
                try
                {
                    famDoc = doc.EditFamily(nativeFam);
                    if (famDoc != null)
                    {
                        View? exportView = new FilteredElementCollector(famDoc)
                            .OfClass(typeof(View3D))
                            .Cast<View3D>()
                            .FirstOrDefault(v => !v.IsTemplate && !v.IsPerspective);

                        exportView ??= new FilteredElementCollector(famDoc)
                            .OfClass(typeof(ViewPlan))
                            .Cast<ViewPlan>()
                            .FirstOrDefault(v => !v.IsTemplate);

                        exportView ??= new FilteredElementCollector(famDoc)
                            .OfClass(typeof(ViewDrafting))
                            .Cast<ViewDrafting>()
                            .FirstOrDefault(v => !v.IsTemplate);

                        exportView ??= famDoc.ActiveView;

                        if (exportView != null)
                        {
                            var options = new ImageExportOptions
                            {
                                ExportRange = ExportRange.SetOfViews,
                                ZoomType = ZoomFitType.FitToPage,
                                PixelSize = 512,
                                ImageResolution = ImageResolution.DPI_72,
                                ShadowViewsFileType = ImageFileType.PNG,
                                HLRandWFViewsFileType = ImageFileType.PNG,
                                FilePath = baseFilePath,
                                FitDirection = FitDirectionType.Horizontal
                            };
                            options.SetViewsAndSheets(new List<ElementId> { exportView.Id });
                            famDoc.ExportImage(options);

                            var files = Directory.GetFiles(tempDir, "*.png");
                            if (files.Length > 0) return files[0];
                        }
                    }
                }
                catch { }
                finally
                {
                    try { famDoc?.Close(false); } catch { }
                }
            }

            // Strategy 2: Scratch View with Rollback Transaction
            var symIds = nativeFam.GetFamilySymbolIds();
            if (symIds.Count == 0) return null;
            var symbol = doc.GetElement(symIds.First()) as FamilySymbol;
            if (symbol == null) return null;

            bool isTitleBlock = false;
            if (nativeFam.FamilyCategory != null && (BuiltInCategory)nativeFam.FamilyCategory.Id.Value == BuiltInCategory.OST_TitleBlocks)
                isTitleBlock = true;

            Document workDoc = doc.IsReadOnly && targetDoc != null && !targetDoc.IsReadOnly ? targetDoc : doc;
            if (workDoc.IsReadOnly) return null;

            using (var tx = new Transaction(workDoc, "Generate Family Preview"))
            {
                tx.Start();
                try
                {
                    View? tempView = null;
                    if (isTitleBlock)
                    {
                        var tempSheet = ViewSheet.Create(workDoc, ElementId.InvalidElementId);
                        tempSheet.Name = $"_TempSheet_{Guid.NewGuid():N}";
                        tempSheet.SheetNumber = $"ZZ_{Guid.NewGuid():N}".Substring(0, 8);
                        tempView = tempSheet;

                        FamilySymbol workSym = symbol;
                        if (workDoc != doc)
                        {
                            var copiedIds = ElementTransformUtils.CopyElements(doc, new List<ElementId> { symbol.Id }, workDoc, Transform.Identity, new CopyPasteOptions());
                            if (copiedIds.Count > 0 && workDoc.GetElement(copiedIds.First()) is FamilySymbol cs) workSym = cs;
                        }
                        if (!workSym.IsActive) workSym.Activate();
                        workDoc.Create.NewFamilyInstance(XYZ.Zero, workSym, tempSheet);
                    }
                    else
                    {
                        var draftingType = new FilteredElementCollector(workDoc)
                            .OfClass(typeof(ViewFamilyType))
                            .Cast<ViewFamilyType>()
                            .FirstOrDefault(vft => vft.ViewFamily == ViewFamily.Drafting);

                        if (draftingType != null)
                        {
                            var vDraft = ViewDrafting.Create(workDoc, draftingType.Id);
                            vDraft.Name = $"_Temp2D_{Guid.NewGuid():N}";
                            tempView = vDraft;
                            FamilySymbol workSym = symbol;
                            if (workDoc != doc)
                            {
                                var copiedIds = ElementTransformUtils.CopyElements(doc, new List<ElementId> { symbol.Id }, workDoc, Transform.Identity, new CopyPasteOptions());
                                if (copiedIds.Count > 0 && workDoc.GetElement(copiedIds.First()) is FamilySymbol cs) workSym = cs;
                            }
                            if (!workSym.IsActive) workSym.Activate();
                            workDoc.Create.NewFamilyInstance(XYZ.Zero, workSym, vDraft);
                        }
                    }

                    if (tempView != null)
                    {
                        workDoc.Regenerate();
                        var options = new ImageExportOptions
                        {
                            ExportRange = ExportRange.SetOfViews,
                            ZoomType = ZoomFitType.FitToPage,
                            PixelSize = 512,
                            ImageResolution = ImageResolution.DPI_72,
                            ShadowViewsFileType = ImageFileType.PNG,
                            HLRandWFViewsFileType = ImageFileType.PNG,
                            FilePath = baseFilePath,
                            FitDirection = FitDirectionType.Horizontal
                        };
                        options.SetViewsAndSheets(new List<ElementId> { tempView.Id });
                        workDoc.ExportImage(options);

                        var files = Directory.GetFiles(tempDir, "*.png");
                        if (files.Length > 0) return files[0];
                    }
                }
                catch { }
                finally
                {
                    if (tx.HasStarted() && !tx.HasEnded()) tx.RollBack();
                }
            }

            return null;
        }

        public static string? GenerateRfaPreview(string rfaPath, Autodesk.Revit.ApplicationServices.Application app)
        {
            if (string.IsNullOrWhiteSpace(rfaPath) || !File.Exists(rfaPath) || app == null) return null;
            string tempDir = Path.Combine(Path.GetTempPath(), "Revit_Previews", Guid.NewGuid().ToString("N"));
            if (!Directory.Exists(tempDir)) Directory.CreateDirectory(tempDir);
            string baseFilePath = Path.Combine(tempDir, "preview");

            Document? rfaDoc = null;
            try
            {
                rfaDoc = app.OpenDocumentFile(rfaPath);
                if (rfaDoc == null) return null;

                View? exportView = new FilteredElementCollector(rfaDoc)
                    .OfClass(typeof(View3D))
                    .Cast<View3D>()
                    .FirstOrDefault(v => !v.IsTemplate && !v.IsPerspective)
                    ?? (View?)new FilteredElementCollector(rfaDoc).OfClass(typeof(ViewPlan)).Cast<ViewPlan>().FirstOrDefault(v => !v.IsTemplate)
                    ?? rfaDoc.ActiveView;

                if (exportView != null)
                {
                    var options = new ImageExportOptions
                    {
                        ExportRange = ExportRange.SetOfViews,
                        ZoomType = ZoomFitType.FitToPage,
                        PixelSize = 512,
                        ImageResolution = ImageResolution.DPI_72,
                        ShadowViewsFileType = ImageFileType.PNG,
                        HLRandWFViewsFileType = ImageFileType.PNG,
                        FilePath = baseFilePath,
                        FitDirection = FitDirectionType.Horizontal
                    };
                    options.SetViewsAndSheets(new List<ElementId> { exportView.Id });
                    rfaDoc.ExportImage(options);

                    var files = Directory.GetFiles(tempDir, "*.png");
                    if (files.Length > 0) return files[0];
                }
            }
            catch { }
            finally
            {
                try { rfaDoc?.Close(false); } catch { }
            }
            return null;
        }
    }
}
