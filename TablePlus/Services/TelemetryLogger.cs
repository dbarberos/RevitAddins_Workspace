using System;
using System.IO;
using System.Text.RegularExpressions;

namespace TablePlus.Services;

/// <summary>
/// Telemetry and logging security component for TablePlus.
/// Sanitizes Personal Identifiable Information (PII) by masking user home directories
/// and temporary folders with standard tokens (%USERPROFILE% / %TEMP%).
/// </summary>
public static class TelemetryLogger
{
    private static readonly string UserProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    private static readonly string TempPath = Path.GetTempPath();

    /// <summary>
    /// Sanitizes file paths by replacing active user profile paths and Windows temp paths with tokens.
    /// Prevents leaking sensitive user directory structures into exception logs.
    /// </summary>
    public static string SanitizePath(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        string sanitized = input!;

        if (!string.IsNullOrEmpty(TempPath) && sanitized.Contains(TempPath, StringComparison.OrdinalIgnoreCase))
        {
            sanitized = Regex.Replace(sanitized, Regex.Escape(TempPath.TrimEnd('\\', '/')), "%TEMP%", RegexOptions.IgnoreCase);
        }

        if (!string.IsNullOrEmpty(UserProfilePath) && sanitized.Contains(UserProfilePath, StringComparison.OrdinalIgnoreCase))
        {
            sanitized = Regex.Replace(sanitized, Regex.Escape(UserProfilePath.TrimEnd('\\', '/')), "%USERPROFILE%", RegexOptions.IgnoreCase);
        }

        return sanitized;
    }

    public static void LogInfo(string message)
    {
        string sanitizedMessage = SanitizePath(message);
        LoggerService.LogInfo(sanitizedMessage);
    }

    public static void LogWarning(string message)
    {
        string sanitizedMessage = SanitizePath(message);
        LoggerService.LogWarning(sanitizedMessage);
    }

    public static void LogError(string context, Exception ex)
    {
        string sanitizedContext = SanitizePath(context);
        string sanitizedExceptionMessage = SanitizePath(ex.Message);
        LoggerService.LogError(sanitizedContext, new Exception(sanitizedExceptionMessage, ex));
    }

    public static void LogExceptionSilently(string context, Exception ex)
    {
        string sanitizedContext = SanitizePath(context);
        string sanitizedExceptionMessage = SanitizePath(ex.Message);
        LoggerService.LogExceptionSilently(sanitizedContext, new Exception(sanitizedExceptionMessage, ex));
    }
}
