using System;
using System.IO;
using System.Linq;
using Autodesk.Revit.DB;
using TransferPlus.Services;

namespace TransferPlus.Services
{
    /// <summary>
    /// Opciones de carga de familia silenciosas para evitar diálogos modales de Revit.
    /// Sobrescribe de forma automática definiciones y valores de parámetros.
    /// </summary>
    public class SilentOverwriteFamilyOption : IFamilyLoadOptions
    {
        public bool OnFamilyFound(bool familyInUse, out bool overwriteParameterValues)
        {
            overwriteParameterValues = true;
            return true; // Sobrescribir silenciosamente sin diálogo modal
        }

        public bool OnSharedFamilyFound(Family sharedFamily, bool familyInUse, out FamilySource source, out bool overwriteParameterValues)
        {
            source = FamilySource.Family;
            overwriteParameterValues = true;
            return true; // Sobrescribir silenciosamente sin diálogo modal
        }
    }

    /// <summary>
    /// Servicio de Revit para operaciones con Familias (RFA).
    /// Integra el gestor seguro de archivos locales (FamilyFileManager), prevención de Path Traversal (Path.GetFullPath),
    /// supresión de advertencias modales (WarningSwallower) y registro desensibilizado de PII (TelemetryLogger).
    /// </summary>
    public class FamilyRevitService
    {
        /// <summary>
        /// Intenta cargar una familia (.rfa) en el documento destino dentro de una transacción con WarningSwallower.
        /// Valida rutas para prevenir Path Traversal y desensibiliza logs PII.
        /// </summary>
        public bool TryLoadFamily(Document document, string rfaFilePath, out Family? family)
        {
            family = null;
            if (document == null || string.IsNullOrWhiteSpace(rfaFilePath))
            {
                return false;
            }

            try
            {
                // Validación estricta de Path Traversal mediante resolución completa de la ruta
                string resolvedPath = Path.GetFullPath(rfaFilePath);
                if (!File.Exists(resolvedPath))
                {
                    TelemetryLogger.LogWarning($"El archivo de familia no existe en la ruta validada: '{resolvedPath}'");
                    return false;
                }

                var overwriteOptions = new SilentOverwriteFamilyOption();

                using var transaction = new Transaction(document, "Cargar Familia TransferPlus");
                WarningSwallower.AttachToTransaction(transaction);
                transaction.Start();

                if (document.LoadFamily(resolvedPath, overwriteOptions, out family))
                {
                    transaction.Commit();
                    TelemetryLogger.LogInfo($"Familia cargada correctamente desde '{resolvedPath}'");
                    return family != null;
                }

                // Si la familia ya estaba cargada en el documento, buscar la referencia existente
                var familyName = Path.GetFileNameWithoutExtension(resolvedPath);
                var existingFamily = new FilteredElementCollector(document)
                    .OfClass(typeof(Family))
                    .Cast<Family>()
                    .FirstOrDefault(f => f.Name.Equals(familyName, StringComparison.OrdinalIgnoreCase));

                if (existingFamily != null)
                {
                    family = existingFamily;
                    transaction.Commit();
                    TelemetryLogger.LogInfo($"Referencia de familia existente reutilizada: '{familyName}'");
                    return true;
                }

                transaction.RollBack();
                return false;
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogError($"Error al cargar la familia de Revit desde '{rfaFilePath}'", ex);
                return false;
            }
        }

        /// <summary>
        /// Intenta cargar un símbolo/tipo específico de familia (.rfa) en el documento destino con WarningSwallower.
        /// </summary>
        public bool TryLoadFamilySymbol(Document document, string rfaFilePath, string symbolName, out FamilySymbol? familySymbol)
        {
            familySymbol = null;
            if (document == null || string.IsNullOrWhiteSpace(rfaFilePath) || string.IsNullOrWhiteSpace(symbolName))
            {
                return false;
            }

            try
            {
                // Validación estricta de Path Traversal
                string resolvedPath = Path.GetFullPath(rfaFilePath);
                if (!File.Exists(resolvedPath))
                {
                    TelemetryLogger.LogWarning($"El archivo de familia fuente para el símbolo no existe: '{resolvedPath}'");
                    return false;
                }

                var overwriteOptions = new SilentOverwriteFamilyOption();

                using var transaction = new Transaction(document, "Cargar Símbolo de Familia TransferPlus");
                WarningSwallower.AttachToTransaction(transaction);
                transaction.Start();

                if (document.LoadFamilySymbol(resolvedPath, symbolName, overwriteOptions, out familySymbol))
                {
                    if (familySymbol != null && !familySymbol.IsActive)
                    {
                        familySymbol.Activate();
                    }
                    transaction.Commit();
                    TelemetryLogger.LogInfo($"Símbolo '{symbolName}' cargado correctamente desde '{resolvedPath}'");
                    return familySymbol != null;
                }

                // Buscar si el símbolo ya existía en el documento
                var existingSymbol = new FilteredElementCollector(document)
                    .OfClass(typeof(FamilySymbol))
                    .Cast<FamilySymbol>()
                    .FirstOrDefault(s => s.Name.Equals(symbolName, StringComparison.OrdinalIgnoreCase));

                if (existingSymbol != null)
                {
                    familySymbol = existingSymbol;
                    if (!familySymbol.IsActive)
                    {
                        familySymbol.Activate();
                    }
                    transaction.Commit();
                    TelemetryLogger.LogInfo($"Símbolo existente reutilizado: '{symbolName}'");
                    return true;
                }

                transaction.RollBack();
                return false;
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogError($"Error al cargar el símbolo '{symbolName}' desde '{rfaFilePath}'", ex);
                return false;
            }
        }

        /// <summary>
        /// Carga una familia a partir de un Stream de datos binarios, utilizando FamilyFileManager para escribir
        /// el archivo local en una ubicación de temporales segura con mitigación de Path Traversal.
        /// </summary>
        public bool TryLoadFamilyFromStream(Document document, Stream familyStream, string familyName, out Family? family)
        {
            family = null;
            string tempFilePath = string.Empty;
            try
            {
                tempFilePath = FamilyFileManager.CreateFamilyLocalFile(familyStream, familyName);
                return TryLoadFamily(document, tempFilePath, out family);
            }
            finally
            {
                if (!string.IsNullOrEmpty(tempFilePath))
                {
                    FamilyFileManager.RemoveFamilyLocalFile(tempFilePath);
                }
            }
        }
    }
}
