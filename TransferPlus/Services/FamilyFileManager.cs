using System;
using System.IO;
using System.Security;

namespace TransferPlus.Services
{
    /// <summary>
    /// Gestor seguro de archivos de familias locales y temporales.
    /// Extrae la lógica de gestión de archivos de Bim.FamilyManager_Source adaptándola a los estándares
    /// de seguridad de TransferPlus: prevención de Path Traversal (Path.GetFullPath) y sanitización PII mediante TelemetryLogger.
    /// </summary>
    public static class FamilyFileManager
    {
        private static readonly string BaseTempDirectory = Path.GetFullPath(Path.Combine(Path.GetTempPath(), "TransferPlus_Families"));

        static FamilyFileManager()
        {
            try
            {
                if (!Directory.Exists(BaseTempDirectory))
                {
                    Directory.CreateDirectory(BaseTempDirectory);
                }
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogError("Error al crear directorio temporal seguro de familias", ex);
            }
        }

        /// <summary>
        /// Crea un archivo .rfa local temporal a partir de un Stream de datos,
        /// aplicando validación estricta de Path Traversal con Path.GetFullPath.
        /// </summary>
        public static string CreateFamilyLocalFile(Stream familyStream, string rawFamilyName)
        {
            if (familyStream == null) throw new ArgumentNullException(nameof(familyStream));
            if (string.IsNullOrWhiteSpace(rawFamilyName)) throw new ArgumentException("Nombre de familia no válido.", nameof(rawFamilyName));

            // Sanitizar el nombre del archivo eliminando caracteres no válidos o separadores de directorio
            string safeFileName = string.Join("_", rawFamilyName.Split(Path.GetInvalidFileNameChars()));
            if (!safeFileName.EndsWith(".rfa", StringComparison.OrdinalIgnoreCase))
            {
                safeFileName += ".rfa";
            }

            // Construir y resolver la ruta absoluta estricta
            string combinedPath = Path.Combine(BaseTempDirectory, safeFileName);
            string fullPath = Path.GetFullPath(combinedPath);

            // Validación estricta de Path Traversal: la ruta completa debe residir dentro del directorio base
            if (!fullPath.StartsWith(BaseTempDirectory, StringComparison.OrdinalIgnoreCase))
            {
                TelemetryLogger.LogWarning($"Intento de Path Traversal interceptado para la ruta: '{fullPath}'");
                throw new SecurityException("Acceso Denegado: Se ha detectado una violación de Path Traversal al intentar escribir el archivo temporal.");
            }

            using (var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                familyStream.CopyTo(fileStream);
            }

            TelemetryLogger.LogInfo($"Archivo local de familia creado de forma segura en: {fullPath}");
            return fullPath;
        }

        private static readonly string BaseCadTempDirectory = Path.GetFullPath(Path.Combine(Path.GetTempPath(), "TransferPlus_CADCache"));

        /// <summary>
        /// Crea un archivo CAD local temporal (.dwg, .dxf, .sat, etc.) a partir de un Stream de datos,
        /// preservando su extensión original y aplicando validación estricta de Path Traversal.
        /// </summary>
        public static string CreateCadLocalFile(Stream cadStream, string rawCadFileName)
        {
            if (cadStream == null) throw new ArgumentNullException(nameof(cadStream));
            if (string.IsNullOrWhiteSpace(rawCadFileName)) throw new ArgumentException("Nombre de archivo CAD no válido.", nameof(rawCadFileName));

            if (!Directory.Exists(BaseCadTempDirectory))
            {
                Directory.CreateDirectory(BaseCadTempDirectory);
            }

            // Sanitizar el nombre del archivo eliminando caracteres no válidos
            string safeFileName = string.Join("_", rawCadFileName.Split(Path.GetInvalidFileNameChars()));

            // Construir y resolver la ruta absoluta estricta
            string combinedPath = Path.Combine(BaseCadTempDirectory, safeFileName);
            string fullPath = Path.GetFullPath(combinedPath);

            // Validación estricta de Path Traversal: la ruta completa debe residir dentro del directorio base
            if (!fullPath.StartsWith(BaseCadTempDirectory, StringComparison.OrdinalIgnoreCase))
            {
                TelemetryLogger.LogWarning($"Intento de Path Traversal interceptado para la ruta CAD: '{fullPath}'");
                throw new SecurityException("Acceso Denegado: Se ha detectado una violación de Path Traversal al intentar escribir el archivo CAD temporal.");
            }

            using (var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                cadStream.CopyTo(fileStream);
            }

            TelemetryLogger.LogInfo($"Archivo local CAD creado de forma segura en: {fullPath}");
            return fullPath;
        }

        /// <summary>
        /// Copia un archivo .rfa local existente a la carpeta de trabajo temporal de forma segura.
        /// </summary>
        public static string CopyFamilyLocalFile(string sourceFilePath)
        {
            if (string.IsNullOrWhiteSpace(sourceFilePath)) throw new ArgumentException("Ruta fuente no válida.", nameof(sourceFilePath));

            string fullSourcePath = Path.GetFullPath(sourceFilePath);
            if (!File.Exists(fullSourcePath))
            {
                TelemetryLogger.LogWarning($"El archivo fuente no existe: '{fullSourcePath}'");
                throw new FileNotFoundException("El archivo de familia fuente no existe.", fullSourcePath);
            }

            string fileName = Path.GetFileName(fullSourcePath);
            using var sourceStream = File.OpenRead(fullSourcePath);
            return CreateFamilyLocalFile(sourceStream, fileName);
        }

        /// <summary>
        /// Elimina un archivo temporal comprobando los límites de seguridad de directorio.
        /// </summary>
        public static void RemoveFamilyLocalFile(string localFilePath)
        {
            if (string.IsNullOrWhiteSpace(localFilePath)) return;

            try
            {
                string fullPath = Path.GetFullPath(localFilePath);
                // Validar que la ruta está en la carpeta de temporales permitida antes de borrar
                if (fullPath.StartsWith(BaseTempDirectory, StringComparison.OrdinalIgnoreCase) && File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    TelemetryLogger.LogInfo($"Archivo de familia temporal eliminado: {fullPath}");
                }
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogError($"Error al eliminar archivo temporal de familia", ex);
            }
        }
    }
}
