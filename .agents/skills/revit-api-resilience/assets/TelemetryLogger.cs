// ==============================================================================
// SKILL: SKILL-RVT-RES (Resilience & Operations)
// PATTERN: Telemetry & Crash Analytics
// PURPOSE: Safely extracts stack traces, Revit build info, and error context 
//          while sanitizing PII (Personally Identifiable Information) before 
//          transmitting to cloud logs (e.g., Application Insights).
// DEPENDENCIES: System, Autodesk.Revit.ApplicationServices, System.Text.RegularExpressions
// ==============================================================================

using System;
using System.Text.RegularExpressions;
using Autodesk.Revit.ApplicationServices;

namespace RevitAddinBase.Resilience
{
    /// <summary>
    /// Secure logging utility for enterprise deployments.
    /// </summary>
    public static class TelemetryLogger
    {
        /// <summary>
        /// Captures an exception, sanitizes it, and prepares it for transmission.
        /// </summary>
        /// <param name="actionName">The name of the command or function that failed.</param>
        /// <param name="ex">The thrown exception.</param>
        /// <param name="app">Optional: Revit application context for version tracking.</param>
        public static void LogException(string actionName, Exception ex, Application app = null)
        {
            if (ex == null) return;

            string sanitizedStackTrace = SanitizePaths(ex.StackTrace);
            string revitVersion = app != null ? app.VersionBuild : "Unknown Build";

            // Format payload for JSON serialization (to be sent via RestApiIntegrator from SKILL-RVT-ENT)
            string logPayload = $@"
            {{
                ""Action"": ""{actionName}"",
                ""RevitBuild"": ""{revitVersion}"",
                ""Message"": ""{ex.Message}"",
                ""StackTrace"": ""{sanitizedStackTrace}"",
                ""Timestamp"": ""{DateTime.UtcNow:O}""
            }}";

            // In production, dispatch this string asynchronously to your server
            System.Diagnostics.Debug.WriteLine($"[TELEMETRY LOG] {logPayload}");
        }

        /// <summary>
        /// Removes Windows usernames from file paths to comply with GDPR/Privacy policies.
        /// Converts "C:\Users\JohnDoe\AppData\Local\..." to "C:\Users\[REDACTED]\AppData\Local\..."
        /// </summary>
        private static string SanitizePaths(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;

            // Regex to find user directory paths and mask the username
            string pattern = @"(C:\\Users\\)([^\\]+)(\\)";
            return Regex.Replace(input, pattern, "$1[REDACTED]$3", RegexOptions.IgnoreCase);
        }
    }
}
