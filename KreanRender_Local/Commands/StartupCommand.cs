using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Nice3point.Revit.Toolkit.External;
using KreanRenderLocal.Views;
using JetBrains.Annotations;

namespace KreanRenderLocal.Commands;

/// <summary>
///     External command entry point for KreanRender
/// </summary>
[UsedImplicitly]
[Transaction(TransactionMode.Manual)]
public class StartupCommand : ExternalCommand
{
    public override void Execute()
    {
        try 
        {
            if (UiDocument == null)
            {
                Autodesk.Revit.UI.TaskDialog.Show("KreanRender", "No hay ningún documento activo en Revit.");
                return;
            }

            var doc = UiDocument.Document;
            var activeView = UiDocument.ActiveView; // Usar el del UIDocument es más fiable

            if (doc == null || activeView == null)
            {
                Autodesk.Revit.UI.TaskDialog.Show("KreanRender", "No se ha podido acceder a la vista activa.");
                return;
            }

            if (activeView is not View3D && activeView.ViewType != ViewType.Elevation && activeView.ViewType != ViewType.Section)
            {
                Autodesk.Revit.UI.TaskDialog.Show("KreanRender", "Por favor, sitúate en una vista 3D, de Alzado o Sección para renderizar.");
                return;
            }

        // 1. Export Active View to Image
        string exportDirectory = Path.Combine(Path.GetTempPath(), "KreanRenderTemp");
        if (!Directory.Exists(exportDirectory))
        {
            Directory.CreateDirectory(exportDirectory);
        }
        
        // Clean old files
        foreach (var f in Directory.GetFiles(exportDirectory, "*.jpg")) { try { File.Delete(f); } catch { } }

        string tempPath = Path.Combine(exportDirectory, "RenderData");

        var exportOptions = new ImageExportOptions
        {
            ExportRange = ExportRange.CurrentView,
            FilePath = tempPath,
            HLRandWFViewsFileType = ImageFileType.JPEGLossless,
            ShadowViewsFileType = ImageFileType.JPEGLossless,
            ImageResolution = ImageResolution.DPI_300,
            ZoomType = ZoomFitType.FitToPage,
            PixelSize = 1024
        };

        try
        {
            doc.ExportImage(exportOptions);
        }
        catch (Exception ex)
        {
            Autodesk.Revit.UI.TaskDialog.Show("Error Export", ex.Message);
            return;
        }

        // Find the actual file (Revit appends the view name)
        string actualFilePath = "";
        var files = Directory.GetFiles(exportDirectory, "*.jpg");
        if (files.Length > 0)
        {
            actualFilePath = files.OrderByDescending(f => File.GetLastWriteTime(f)).First();
        }

        // 2. Extract Visible Materials
        var materialsList = new HashSet<string>();
        
        var collector = new FilteredElementCollector(doc, activeView.Id)
            .WhereElementIsNotElementType()
            .WhereElementIsViewIndependent();

        foreach (var element in collector)
        {
            try 
            {
                var matIds = element.GetMaterialIds(false);
                foreach (var mId in matIds)
                {
                    var material = doc.GetElement(mId) as Material;
                    if (material != null)
                    {
                        materialsList.Add(material.Name);
                    }
                }
            } 
            catch { }
        }
        
        string materialsText = string.Join(", ", materialsList);
        if (string.IsNullOrEmpty(materialsText)) 
        {
            materialsText = "Hormigón, Cristal, Elementos de fachada genéricos";
        }

        // 3. Launch UI
        var window = new RenderWindow(activeView.Name, materialsText, actualFilePath);
        window.ShowDialog();
        }
        catch (Exception ex)
        {
            Autodesk.Revit.UI.TaskDialog.Show("Error Fatal", $"Se ha producido un error inesperado:\n\n{ex.Message}\n\n{ex.StackTrace}");
        }
    }
}
