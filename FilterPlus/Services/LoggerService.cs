using System;
using System.Collections.ObjectModel;
using System.Windows;
using Autodesk.Revit.UI;

namespace FilterPlus.Services;

/// <summary>
/// Secure logging service that supports real-time UI updates even if Application.Current is null.
/// </summary>
public static class LoggerService
{
    public static ObservableCollection<string> Logs { get; } = new ObservableCollection<string>();
    private static System.Windows.Threading.Dispatcher _uiDispatcher;

    public static void SetDispatcher(System.Windows.Threading.Dispatcher dispatcher)
    {
        _uiDispatcher = dispatcher;
    }

    public static void LogInfo(string message)
    {
        string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
        string entry = $"[{timestamp}] INFO: {message}";
        
        var dispatcher = _uiDispatcher ?? System.Windows.Application.Current?.Dispatcher ?? System.Windows.Threading.Dispatcher.CurrentDispatcher;
        if (dispatcher != null)
        {
            dispatcher.BeginInvoke(new Action(() => {
                Logs.Insert(0, entry);
            }));
        }
        
        System.Diagnostics.Debug.WriteLine(entry);
    }

    public static void LogError(string context, Exception ex)
    {
        string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
        string entry = $"[{timestamp}] ERROR in {context}: {ex.Message}";
        
        var dispatcher = _uiDispatcher ?? System.Windows.Application.Current?.Dispatcher;
        if (dispatcher != null)
        {
            dispatcher.BeginInvoke(new Action(() => Logs.Insert(0, entry)));
        }

        System.Diagnostics.Debug.WriteLine(entry);
        System.Diagnostics.Debug.WriteLine(ex.StackTrace);

        // Security Hardened TaskDialog
        string userMessage = $"An error occurred in {context}. Please contact support.";
        TaskDialog mainDialog = new TaskDialog("FilterPlus Error")
        {
            MainInstruction = "Unexpected Error",
            MainContent = userMessage,
            CommonButtons = TaskDialogCommonButtons.Close,
            DefaultButton = TaskDialogResult.Close,
            FooterText = "Check Debug Log for details"
        };
        mainDialog.Show();
    }
}
