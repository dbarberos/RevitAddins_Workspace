using System;
using System.IO;
using System.Security;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitApiExport.Assets;

/// <summary>
/// Reusable manager for secure caching and in-memory rendered preview generation of external CAD files.
/// </summary>
public static class CadCloudCacheAndPreviewManager
{
    private static readonly string BaseCadCacheDir = Path.GetFullPath(Path.Combine(Path.GetTempPath(), "Revit_CADCache"));

    static CadCloudCacheAndPreviewManager()
    {
        if (!Directory.Exists(BaseCadCacheDir))
        {
            Directory.CreateDirectory(BaseCadCacheDir);
        }
    }

    /// <summary>
    /// Saves a stream into a local CAD cache directory, preserving original extension and sanitizing against Path Traversal.
    /// </summary>
    public static string SaveCadStreamToCache(Stream cadStream, string rawFileName)
    {
        if (cadStream == null) throw new ArgumentNullException(nameof(cadStream));
        if (string.IsNullOrWhiteSpace(rawFileName)) throw new ArgumentException("Invalid CAD file name.", nameof(rawFileName));

        string safeFileName = string.Join("_", rawFileName.Split(Path.GetInvalidFileNameChars()));
        string fullPath = Path.GetFullPath(Path.Combine(BaseCadCacheDir, safeFileName));

        if (!fullPath.StartsWith(BaseCadCacheDir, StringComparison.OrdinalIgnoreCase))
        {
            throw new SecurityException($"Path traversal attempt intercepted for '{fullPath}'");
        }

        using var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None);
        cadStream.CopyTo(fileStream);
        return fullPath;
    }

    /// <summary>
    /// Generates a rendered PNG preview of a CAD file using an in-memory temporary DraftingView and immediately rolling back.
    /// </summary>
    public static string? GenerateCadPreviewImage(Document doc, string cadFilePath, int pixelSize = 512)
    {
        if (doc == null || string.IsNullOrWhiteSpace(cadFilePath) || !File.Exists(cadFilePath)) return null;

        string tempDir = Path.Combine(Path.GetTempPath(), "Revit_Previews", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(tempDir);
        string baseFilePath = Path.Combine(tempDir, "preview");

        var draftingType = new FilteredElementCollector(doc)
            .OfClass(typeof(ViewFamilyType))
            .Cast<ViewFamilyType>()
            .FirstOrDefault(vft => vft.ViewFamily == ViewFamily.Drafting);

        if (draftingType == null) return null;

        string? resultPath = null;

        using (var tx = new Transaction(doc, "Generate CAD Preview"))
        {
            tx.Start();
            try
            {
                var tempView = ViewDrafting.Create(doc, draftingType.Id);
                tempView.Name = $"_TempCadPreview_{Guid.NewGuid():N}";
                tempView.Scale = 1;

                string ext = Path.GetExtension(cadFilePath).ToLowerInvariant();
                if (ext == ".sat")
                {
                    doc.Import(cadFilePath, new SATImportOptions { Placement = ImportPlacement.Origin }, tempView);
                }
                else if (ext == ".skp")
                {
                    doc.Import(cadFilePath, new SKPImportOptions { Placement = ImportPlacement.Origin }, tempView);
                }
                else if (ext == ".dgn")
                {
                    doc.Import(cadFilePath, new DGNImportOptions { ThisViewOnly = true, Placement = ImportPlacement.Origin }, tempView, out _);
                }
                else
                {
                    doc.Import(cadFilePath, new DWGImportOptions { ThisViewOnly = true, Placement = ImportPlacement.Origin }, tempView, out _);
                }

                doc.Regenerate();

                var options = new ImageExportOptions
                {
                    ExportRange = ExportRange.SetOfViews,
                    ZoomType = ZoomFitType.FitToPage,
                    PixelSize = pixelSize,
                    ImageResolution = ImageResolution.DPI_72,
                    ShadowViewsFileType = ImageFileType.PNG,
                    HLRandWFViewsFileType = ImageFileType.PNG,
                    FilePath = baseFilePath,
                    FitDirection = FitDirectionType.Horizontal
                };

                options.SetViewsAndSheets(new List<ElementId> { tempView.Id });
                doc.ExportImage(options);

                var generatedFiles = Directory.GetFiles(tempDir, "*.png");
                if (generatedFiles.Length > 0)
                {
                    resultPath = generatedFiles[0];
                }
            }
            catch
            {
                // Fallback or logging
            }
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
}
