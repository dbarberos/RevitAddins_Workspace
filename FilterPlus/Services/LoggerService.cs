using System;
using Autodesk.Revit.UI;

namespace FilterPlus.Services;

/// <summary>
/// Secure logging service that prevents sensitive data leaks to the UI.
/// </summary>
public static class LoggerService
{
    public static void LogError(string context, Exception ex)
    {
        // In a real environment, this would log to a file or a remote server (e.g., Application Insights)
        // For now, we'll use a secure TaskDialog that doesn't show the stack trace.
        
        string message = $"An error occurred in {context}. Please contact support.";
        
        TaskDialog mainDialog = new TaskDialog("FilterPlus Error");
        mainDialog.MainInstruction = "Unexpected Error";
        mainDialog.MainContent = message;
        mainDialog.CommonButtons = TaskDialogCommonButtons.Close;
        mainDialog.DefaultButton = TaskDialogResult.Close;
        mainDialog.FooterText = "Security Hardened Logger";
        
        mainDialog.Show();
        
        // Log details to the debugger at least
        System.Diagnostics.Debug.WriteLine($"[FilterPlus Error] {context}: {ex.Message}");
        System.Diagnostics.Debug.WriteLine(ex.StackTrace);
    }
}
