using System;
using System.Collections.ObjectModel;
using System.Windows;
using Autodesk.Revit.UI;

namespace TransferPlus.Services;

/// <summary>
/// Secure logging service for TransferPlus that supports real-time UI updates.
/// </summary>
public static class LoggerService
{
    public static ObservableCollection<string> Logs { get; } = new ObservableCollection<string>();
    private static System.Windows.Threading.Dispatcher _uiDispatcher;

    public static void SetDispatcher(System.Windows.Threading.Dispatcher dispatcher)
    {
        _uiDispatcher = dispatcher;
    }

    private static readonly string LogFilePath = @"c:\Users\david.barbero\Documents\DOCUMENTOS\ALTEN\Workbench\RevitAddins_Workspace\RevitAddins_Workspace\debug_log_transferplus.txt";

    private static void WriteToFile(string entry, string stackTrace = null)
    {
        try
        {
            string content = entry + Environment.NewLine;
            if (!string.IsNullOrEmpty(stackTrace))
            {
                content += stackTrace + Environment.NewLine;
            }
            System.IO.File.AppendAllText(LogFilePath, content);
        }
        catch { }
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
        WriteToFile(entry);
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
        WriteToFile(entry, ex.StackTrace);

        string userMessage = $"An error occurred in {context}: {ex.Message}\n\nCheck Debug Log for details.";
        System.Windows.MessageBox.Show(userMessage, "TransferPlus Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
    }
}
