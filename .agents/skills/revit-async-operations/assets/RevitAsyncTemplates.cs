using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Revit.Async;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RevitAsyncTemplates
{
    // ==========================================
    // 1. INITIALIZATION TEMPLATE (App.cs)
    // ==========================================
    public class Application : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            // IMPORTANT: Initialize Revit.Async to bind it to the Revit context
            RevitTask.Initialize(application);

            // Other UI Ribbon setup...

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }

    // ==========================================
    // 2. VIEWMODEL TEMPLATES
    // ==========================================
    public partial class AsyncViewModelTemplate : ObservableObject
    {
        private readonly UIApplication _uiApp;

        public AsyncViewModelTemplate(UIApplication uiApp)
        {
            _uiApp = uiApp;
        }

        [ObservableProperty]
        private string _statusMessage = "Ready";

        /// <summary>
        /// Example: Reading data asynchronously and returning a result.
        /// </summary>
        [RelayCommand]
        private async Task FetchWallsAsync()
        {
            StatusMessage = "Fetching walls...";

            // Send execution to Revit Main Thread and await the result
            int wallCount = await RevitTask.RunAsync(app =>
            {
                var doc = app.ActiveUIDocument.Document;
                return new FilteredElementCollector(doc)
                    .OfCategory(BuiltInCategory.OST_Walls)
                    .WhereElementIsNotElementType()
                    .GetElementCount();
            });

            StatusMessage = $"Found {wallCount} walls.";
        }

        /// <summary>
        /// Example: Modifying the document (Transaction) asynchronously.
        /// </summary>
        [RelayCommand]
        private async Task DeleteElementsAsync(List<ElementId> idsToDelete)
        {
            StatusMessage = "Deleting elements...";

            // Send execution to Revit Main Thread
            await RevitTask.RunAsync(app =>
            {
                var doc = app.ActiveUIDocument.Document;
                using var tx = new Transaction(doc, "Delete Elements");
                tx.Start();
                doc.Delete(idsToDelete);
                tx.Commit();
            });

            StatusMessage = "Deletion complete.";
        }
    }
}
