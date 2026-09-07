using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitAddins.Common.Helpers
{
    /// <summary>
    /// Reusable utility for extracting 2D detail elements/views from linked documents (RevitLinkInstance)
    /// and generating crisp in-memory preview PNGs using host document transaction delegation with rollback.
    /// </summary>
    public static class LinkedModelPreviewAndElementCopier
    {
        /// <summary>
        /// Generates an isolated preview image (PNG) for an element located in a read-only or linked document
        /// by delegating the temporary ViewDrafting placement to the active host document and rolling back the transaction.
        /// </summary>
        public static string? GenerateLinkedElementIsolatedPreview(Document sourceDoc, ElementId elementId, Document hostDoc, ElementId? ownerViewId = null)
        {
            if (sourceDoc == null || elementId == null || elementId == ElementId.InvalidElementId || hostDoc == null || hostDoc.IsReadOnly)
            {
                return null;
            }

            try
            {
                var elem = sourceDoc.GetElement(elementId);
                if (elem == null) return null;

                string tempDir = Path.Combine(Path.GetTempPath(), "RevitAddins_Previews", Guid.NewGuid().ToString("N"));
                if (!Directory.Exists(tempDir))
                {
                    Directory.CreateDirectory(tempDir);
                }

                string baseFilePath = Path.Combine(tempDir, "preview");

                var draftingType = new FilteredElementCollector(hostDoc)
                    .OfClass(typeof(ViewFamilyType))
                    .Cast<ViewFamilyType>()
                    .FirstOrDefault(vft => vft.ViewFamily == ViewFamily.Drafting);

                if (draftingType == null) return null;

                string? resultPath = null;

                using (var tx = new Transaction(hostDoc, "Temp Preview Linked Element"))
                {
                    tx.Start();

                    try
                    {
                        var tempView = ViewDrafting.Create(hostDoc, draftingType.Id);
                        tempView.Name = $"_TempPreview_{Guid.NewGuid():N}";
                        tempView.Scale = 1;

                        Element? placedElem = null;

                        if (sourceDoc == hostDoc)
                        {
                            if (elem is FamilySymbol localSym)
                            {
                                if (!localSym.IsActive) localSym.Activate();
                                placedElem = hostDoc.Create.NewFamilyInstance(XYZ.Zero, localSym, tempView);
                            }
                            else if (elem is FamilyInstance localFi && localFi.Symbol != null)
                            {
                                if (!localFi.Symbol.IsActive) localFi.Symbol.Activate();
                                placedElem = hostDoc.Create.NewFamilyInstance(XYZ.Zero, localFi.Symbol, tempView);
                            }
                            else if (ownerViewId != null && ownerViewId != ElementId.InvalidElementId && sourceDoc.GetElement(ownerViewId) is View srcView)
                            {
                                var copied = ElementTransformUtils.CopyElements(srcView, new List<ElementId> { elem.Id }, tempView, Transform.Identity, new CopyPasteOptions());
                                if (copied.Count > 0)
                                {
                                    placedElem = hostDoc.GetElement(copied.First());
                                }
                            }
                            else
                            {
                                var copied = ElementTransformUtils.CopyElements(sourceDoc, new List<ElementId> { elem.Id }, hostDoc, Transform.Identity, new CopyPasteOptions());
                                if (copied.Count > 0)
                                {
                                    placedElem = hostDoc.GetElement(copied.First());
                                }
                            }
                        }
                        else
                        {
                            // Cross-document copying from linked model into host document
                            if (elem is FamilySymbol linkedSym)
                            {
                                var copiedIds = ElementTransformUtils.CopyElements(sourceDoc, new List<ElementId> { linkedSym.Id }, hostDoc, Transform.Identity, new CopyPasteOptions());
                                if (copiedIds.Count > 0 && hostDoc.GetElement(copiedIds.First()) is FamilySymbol workSym)
                                {
                                    if (!workSym.IsActive) workSym.Activate();
                                    placedElem = hostDoc.Create.NewFamilyInstance(XYZ.Zero, workSym, tempView);
                                }
                            }
                            else if (elem is FamilyInstance linkedFi && linkedFi.Symbol != null)
                            {
                                var copiedIds = ElementTransformUtils.CopyElements(sourceDoc, new List<ElementId> { linkedFi.Symbol.Id }, hostDoc, Transform.Identity, new CopyPasteOptions());
                                if (copiedIds.Count > 0 && hostDoc.GetElement(copiedIds.First()) is FamilySymbol workSym)
                                {
                                    if (!workSym.IsActive) workSym.Activate();
                                    placedElem = hostDoc.Create.NewFamilyInstance(XYZ.Zero, workSym, tempView);
                                }
                            }
                            else if (ownerViewId != null && ownerViewId != ElementId.InvalidElementId && sourceDoc.GetElement(ownerViewId) is View linkedSrcView)
                            {
                                var copied = ElementTransformUtils.CopyElements(linkedSrcView, new List<ElementId> { elem.Id }, tempView, Transform.Identity, new CopyPasteOptions());
                                if (copied.Count > 0)
                                {
                                    placedElem = hostDoc.GetElement(copied.First());
                                }
                            }
                            else
                            {
                                var copied = ElementTransformUtils.CopyElements(sourceDoc, new List<ElementId> { elem.Id }, hostDoc, Transform.Identity, new CopyPasteOptions());
                                if (copied.Count > 0)
                                {
                                    placedElem = hostDoc.GetElement(copied.First());
                                }
                            }
                        }

                        hostDoc.Regenerate();

                        if (placedElem != null)
                        {
                            try
                            {
                                var bbox = placedElem.get_BoundingBox(tempView);
                                if (bbox != null && Math.Abs(bbox.Max.X - bbox.Min.X) > 1e-4 && Math.Abs(bbox.Max.Y - bbox.Min.Y) > 1e-4)
                                {
                                    double width = bbox.Max.X - bbox.Min.X;
                                    double height = bbox.Max.Y - bbox.Min.Y;
                                    double marginX = Math.Max(width * 0.08, 0.02);
                                    double marginY = Math.Max(height * 0.08, 0.02);

                                    var crop = tempView.CropBox;
                                    crop.Min = new XYZ(bbox.Min.X - marginX, bbox.Min.Y - marginY, crop.Min.Z);
                                    crop.Max = new XYZ(bbox.Max.X + marginX, bbox.Max.Y + marginY, crop.Max.Z);
                                    tempView.CropBox = crop;
                                    tempView.CropBoxActive = true;
                                    tempView.CropBoxVisible = false;
                                }
                            }
                            catch { }
                        }

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
                        hostDoc.ExportImage(options);

                        var generatedFiles = Directory.GetFiles(tempDir, "*.png");
                        if (generatedFiles.Length > 0)
                        {
                            resultPath = generatedFiles[0];
                        }
                    }
                    catch { }
                    finally
                    {
                        if (tx.HasStarted() && !tx.HasEnded())
                        {
                            tx.RollBack();
                        }
                    }
                }

                return resultPath;
            }
            catch
            {
                return null;
            }
        }
    }
}
