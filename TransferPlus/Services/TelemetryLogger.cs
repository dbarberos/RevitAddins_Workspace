using System;
using System.IO;
using System.Text.RegularExpressions;

namespace TransferPlus.Services
{
    /// <summary>
    /// Componente de Telemetría y Logging seguro para TransferPlus.
    /// Garantiza la desensibilización (scrubbing) de Información de Identificación Personal (PII),
    /// enmascarando cualquier directorio de usuario o perfil de Windows por tokens anónimos (%USERPROFILE% / %TEMP%).
    /// </summary>
    public static class TelemetryLogger
    {
        private static readonly string UserProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        private static readonly string TempPath = Path.GetTempPath();

        /// <summary>
        /// Sanitiza rutas de archivos reemplazando nombres de usuario y directorios de Windows por %USERPROFILE% o %TEMP%.
        /// Evita la filtración de PII en excepciones, mensajes de log y registros de telemetría.
        /// </summary>
        public static string SanitizePath(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            string sanitized = input;

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
}
