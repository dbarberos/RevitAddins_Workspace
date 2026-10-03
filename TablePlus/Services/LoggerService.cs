using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Threading;

namespace TablePlus.Services;

/// <summary>
/// Real-time logging service for TablePlus with UI thread synchronization,
/// file persistence in %TEMP%\TablePlus_debug_log.txt, and PII sanitization.
/// </summary>
public static class LoggerService
{
    private static readonly object _fileLock = new();
    public static ObservableCollection<string> Logs { get; } = new ObservableCollection<string>();
    private static Dispatcher? _uiDispatcher;

    public static void SetDispatcher(Dispatcher dispatcher)
    {
        _uiDispatcher = dispatcher;
    }

    private static readonly string LogFilePath = Path.Combine(Path.GetTempPath(), "TablePlus_debug_log.txt");

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

            lock (_fileLock)
            {
                File.AppendAllText(LogFilePath, content);
            }
        }
        catch
        {
            // Silently swallow file write errors to avoid crashing during logging
        }
    }

    public static void LogInfo(string message)
    {
        string sanitizedMsg = TelemetryLogger.SanitizePath(message);
        string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
        string entry = $"[{timestamp}] INFO: {sanitizedMsg}";

        DispatchLog(entry);

        System.Diagnostics.Debug.WriteLine(entry);
        WriteToFile(entry);
    }

    public static void LogWarning(string message)
    {
        string sanitizedMsg = TelemetryLogger.SanitizePath(message);
        string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
        string entry = $"[{timestamp}] WARNING: {sanitizedMsg}";

        DispatchLog(entry);

        System.Diagnostics.Debug.WriteLine(entry);
        WriteToFile(entry);
    }

    public static void LogError(string message)
    {
        string sanitizedMsg = TelemetryLogger.SanitizePath(message);
        string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
        string entry = $"[{timestamp}] ERROR: {sanitizedMsg}";

        DispatchLog(entry);

        System.Diagnostics.Debug.WriteLine(entry);
        WriteToFile(entry);
    }

    public static void LogError(string context, Exception ex)
    {
        string sanitizedContext = TelemetryLogger.SanitizePath(context);
        string sanitizedExMessage = TelemetryLogger.SanitizePath(ex.Message);
        string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
        string entry = $"[{timestamp}] ERROR in {sanitizedContext}: {sanitizedExMessage}";

        DispatchLog(entry);

        System.Diagnostics.Debug.WriteLine(entry);
        if (ex.StackTrace != null)
        {
            System.Diagnostics.Debug.WriteLine(TelemetryLogger.SanitizePath(ex.StackTrace));
        }
        WriteToFile(entry, ex.StackTrace);

        string userMessage = $"Ocurrió un error en {sanitizedContext}: {sanitizedExMessage}";
        try
        {
            var dispatcher = _uiDispatcher ?? System.Windows.Application.Current?.Dispatcher;
            if (dispatcher != null && !dispatcher.CheckAccess())
            {
                dispatcher.BeginInvoke(new Action(() =>
                {
                    MessageBox.Show(userMessage, "TablePlus Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }));
            }
            else
            {
                MessageBox.Show(userMessage, "TablePlus Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        catch
        {
            // Fallback if UI is not available
        }
    }

    public static void LogExceptionSilently(string context, Exception ex)
    {
        string sanitizedContext = TelemetryLogger.SanitizePath(context);
        string sanitizedExMessage = TelemetryLogger.SanitizePath(ex.Message);
        string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
        string entry = $"[{timestamp}] EXCEPTION in {sanitizedContext}: {sanitizedExMessage}";

        DispatchLog(entry);

        System.Diagnostics.Debug.WriteLine(entry);
        if (ex.StackTrace != null)
        {
            System.Diagnostics.Debug.WriteLine(TelemetryLogger.SanitizePath(ex.StackTrace));
        }
        WriteToFile(entry, ex.StackTrace);
    }

    private static void DispatchLog(string entry)
    {
        try
        {
            var dispatcher = _uiDispatcher ?? System.Windows.Application.Current?.Dispatcher;
            if (dispatcher != null && !dispatcher.HasShutdownStarted)
            {
                if (dispatcher.CheckAccess())
                {
                    Logs.Insert(0, entry);
                }
                else
                {
                    dispatcher.BeginInvoke(new Action(() =>
                    {
                        Logs.Insert(0, entry);
                    }));
                }
            }
            else
            {
                // Fallback for background or startup thread before WPF dispatcher exists
                lock (Logs)
                {
                    Logs.Insert(0, entry);
                }
            }
        }
        catch
        {
            // Silently ignore collection sync errors
        }
    }
}
