using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace TransferPlus.Services;

/// <summary>
/// Secure logging service for TransferPlus with real-time UI updates and PII sanitization.
/// </summary>
public static class LoggerService
{
    public static ObservableCollection<string> Logs { get; } = new ObservableCollection<string>();
    private static System.Windows.Threading.Dispatcher? _uiDispatcher;

    public static void SetDispatcher(System.Windows.Threading.Dispatcher dispatcher)
    {
        _uiDispatcher = dispatcher;
    }

    private static readonly string LogFilePath = Path.Combine(Path.GetTempPath(), "TransferPlus_debug_log.txt");

    private static void WriteToFile(string entry, string? stackTrace = null)
    {
        try
        {
            string sanitizedEntry = TelemetryLogger.SanitizePath(entry);
            string content = sanitizedEntry + Environment.NewLine;
            if (!string.IsNullOrEmpty(stackTrace))
            {
                content += TelemetryLogger.SanitizePath(stackTrace) + Environment.NewLine;
            }
            File.AppendAllText(LogFilePath, content);
        }
        catch { }
    }

    public static void LogInfo(string message)
    {
        string sanitizedMsg = TelemetryLogger.SanitizePath(message);
        string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
        string entry = $"[{timestamp}] INFO: {sanitizedMsg}";
        
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
        string sanitizedContext = TelemetryLogger.SanitizePath(context);
        string sanitizedExMessage = TelemetryLogger.SanitizePath(ex.Message);
        string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
        string entry = $"[{timestamp}] ERROR in {sanitizedContext}: {sanitizedExMessage}";
        
        var dispatcher = _uiDispatcher ?? System.Windows.Application.Current?.Dispatcher;
        if (dispatcher != null)
        {
            dispatcher.BeginInvoke(new Action(() => Logs.Insert(0, entry)));
        }

        System.Diagnostics.Debug.WriteLine(entry);
        if (ex.StackTrace != null)
        {
            System.Diagnostics.Debug.WriteLine(TelemetryLogger.SanitizePath(ex.StackTrace));
        }
        WriteToFile(entry, ex.StackTrace);

        string userMessage = $"Ocurrió un error en {sanitizedContext}: {sanitizedExMessage}";
        MessageBox.Show(userMessage, "TransferPlus Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }

    public static void LogWarning(string message)
    {
        string sanitizedMsg = TelemetryLogger.SanitizePath(message);
        string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
        string entry = $"[{timestamp}] WARNING: {sanitizedMsg}";
        
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

    public static void LogExceptionSilently(string context, Exception ex)
    {
        string sanitizedContext = TelemetryLogger.SanitizePath(context);
        string sanitizedExMessage = TelemetryLogger.SanitizePath(ex.Message);
        string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
        string entry = $"[{timestamp}] EXCEPTION in {sanitizedContext}: {sanitizedExMessage}";
        
        var dispatcher = _uiDispatcher ?? System.Windows.Application.Current?.Dispatcher ?? System.Windows.Threading.Dispatcher.CurrentDispatcher;
        if (dispatcher != null)
        {
            dispatcher.BeginInvoke(new Action(() => Logs.Insert(0, entry)));
        }

        System.Diagnostics.Debug.WriteLine(entry);
        if (ex.StackTrace != null)
        {
            System.Diagnostics.Debug.WriteLine(TelemetryLogger.SanitizePath(ex.StackTrace));
        }
        WriteToFile(entry, ex.StackTrace);
    }
}
