// ==============================================================================
// SKILL: SKILL-RVT-ENT (Enterprise & Cloud Ecosystem)
// PATTERN: APS Design Automation Entry Point
// PURPOSE: Provides the Headless application hooks required to execute Revit 
//          Add-ins in the cloud. Strictly prohibits UI namespaces.
// DEPENDENCIES: Autodesk.Revit.ApplicationServices, Autodesk.Revit.DB, DesignAutomationFramework
// ==============================================================================

using System;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
// CRITICAL: Autodesk.Revit.UI MUST NOT BE INCLUDED HERE
using DesignAutomationFramework; 

namespace RevitAddinBase.Enterprise
{
    /// <summary>
    /// Entry point for Cloud Execution. Replaces IExternalCommand and IExternalApplication.
    /// </summary>
    public class DesignAutomationHandler : IExternalDBApplication
    {
        public ExternalDBApplicationResult OnStartup(ControlledApplication application)
        {
            // Subscribe to the Cloud execution event.
            // This event fires the moment the cloud server finishes opening the uploaded .rvt file.
            DesignAutomationBridge.DesignAutomationReadyEvent += HandleDesignAutomationReadyEvent;
            
            return ExternalDBApplicationResult.Succeeded;
        }

        public ExternalDBApplicationResult OnShutdown(ControlledApplication application)
        {
            DesignAutomationBridge.DesignAutomationReadyEvent -= HandleDesignAutomationReadyEvent;
            return ExternalDBApplicationResult.Succeeded;
        }

        /// <summary>
        /// The main execution block triggered by the cloud server.
        /// </summary>
        private void HandleDesignAutomationReadyEvent(object sender, DesignAutomationReadyEventArgs e)
        {
            // Extract the cloud document context
            e.Succeeded = true;
            DesignAutomationData data = e.DesignAutomationData;
            Document doc = data.RevitDoc;

            if (doc == null)
            {
                Console.WriteLine("[Cloud Error] No document provided by the Design Automation engine.");
                e.Succeeded = false;
                return;
            }

            try
            {
                // Execute business logic silently.
                // Console.WriteLine is captured by the cloud server and returned to the user as a log file.
                Console.WriteLine($"[Cloud Success] Document '{doc.Title}' opened successfully in headless mode.");
                
                // Example: Call your data extraction scripts here...
                
                // Save changes back to the cloud storage bucket
                doc.Save(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Cloud Fatal Error] {ex.Message}");
                e.Succeeded = false;
            }
        }
    }
}