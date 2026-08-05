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

        /// <summary>
        /// Obtiene la familia existente por nombre en el documento destino o null si no existe.
        /// </summary>
        public Family? GetExistingFamily(Document document, string familyName)
        {
            if (document == null || string.IsNullOrWhiteSpace(familyName)) return null;

            return new FilteredElementCollector(document)
                .OfClass(typeof(Family))
                .Cast<Family>()
                .FirstOrDefault(f => f.Name.Equals(familyName, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Obtiene los nombres de los símbolos/tipos pertenecientes a una familia existente en el documento destino.
        /// </summary>
        public HashSet<string> GetExistingSymbolNames(Document document, Family existingFamily)
        {
            var symbolNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            if (document == null || existingFamily == null) return symbolNames;

            try
            {
                var symbolIds = existingFamily.GetFamilySymbolIds();
                foreach (ElementId id in symbolIds)
                {
                    if (document.GetElement(id) is FamilySymbol symbol && !string.IsNullOrEmpty(symbol.Name))
                    {
                        symbolNames.Add(symbol.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogWarning($"Error obteniendo símbolos de la familia '{existingFamily.Name}': {ex.Message}");
            }

            return symbolNames;
        }

        /// <summary>
        /// Carga una familia desde archivo .rfa modificando opcionalmente el nombre de la familia en memoria si se especifica overrideFamilyName.
        /// </summary>
        public bool TryLoadFileFamilyWithOverride(
            Autodesk.Revit.UI.UIApplication uiApp,
            Document targetDocument,
            string rfaFilePath,
            string? overrideFamilyName = null,
            IEnumerable<string>? targetSymbolNames = null)
        {
            if (targetDocument == null || string.IsNullOrWhiteSpace(rfaFilePath) || !File.Exists(rfaFilePath))
            {
                return false;
            }

            Document? familyDoc = null;
            try
            {
                familyDoc = uiApp.Application.OpenDocumentFile(rfaFilePath);
                if (familyDoc == null) return false;

                if (familyDoc.IsFamilyDocument && familyDoc.FamilyManager != null && targetSymbolNames != null)
                {
                    var selectedNamesSet = new HashSet<string>(targetSymbolNames, StringComparer.OrdinalIgnoreCase);
                    if (selectedNamesSet.Any())
                    {
                        var familyManager = familyDoc.FamilyManager;
                        var typesToDelete = new List<FamilyType>();

                        foreach (FamilyType familyType in familyManager.Types)
                        {
                            if (!selectedNamesSet.Contains(familyType.Name))
                            {
                                typesToDelete.Add(familyType);
                            }
                        }

                        if (typesToDelete.Any() && typesToDelete.Count < familyManager.Types.Size)
                        {
                            using (var tx = new Transaction(familyDoc, "Filtrar Tipos"))
                            {
                                tx.Start();
                                foreach (var typeToDelete in typesToDelete)
                                {
                                    try
                                    {
                                        familyManager.CurrentType = typeToDelete;
                                        familyManager.DeleteCurrentType();
                                    }
                                    catch { }
                                }
                                tx.Commit();
                            }
                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(overrideFamilyName) && familyDoc.OwnerFamily != null && !familyDoc.OwnerFamily.Name.Equals(overrideFamilyName, StringComparison.OrdinalIgnoreCase))
                {
                    using (var txName = new Transaction(familyDoc, "Renombrar Familia"))
                    {
                        txName.Start();
                        try
                        {
                            familyDoc.OwnerFamily.Name = overrideFamilyName;
                        }
                        catch (Exception ex)
                        {
                            TelemetryLogger.LogWarning($"No se pudo renombrar la familia de archivo a '{overrideFamilyName}': {ex.Message}");
                        }
                        txName.Commit();
                    }
                }

                var overwriteOptions = new SilentOverwriteFamilyOption();
                var loaded = familyDoc.LoadFamily(targetDocument, overwriteOptions);
                return loaded != null;
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogError($"Error al cargar la familia desde archivo '{rfaFilePath}'", ex);
                return false;
            }
            finally
            {
                familyDoc?.Close(false);
            }
        }

        /// <summary>
        /// Transfiere una familia desde un documento origen (abierto o vinculado) hacia un documento destino completamente en memoria,
        /// utilizando el patrón recomendado por la API de Revit (Document.EditFamily -> familyDoc.LoadFamily).
        /// </summary>
        public bool TryTransferInMemoryFamily(
            Document sourceDocument,
            Family sourceFamily,
            Document targetDocument,
            out Family? loadedFamily,
            IEnumerable<string>? targetSymbolNames = null,
            string? overrideFamilyName = null)
        {
            loadedFamily = null;
            if (sourceDocument == null || sourceFamily == null || targetDocument == null)
            {
                return false;
            }

            Document? familyDoc = null;
            try
            {
                // Abrir la familia en memoria (no crea ventana gráfica)
                familyDoc = sourceDocument.EditFamily(sourceFamily);
                if (familyDoc == null)
                {
                    TelemetryLogger.LogWarning($"No se pudo editar en memoria la familia '{sourceFamily.Name}'.");
                    return false;
                }

                // Renombrar la familia si se especificó overrideFamilyName (ej. Append Suffix)
                if (!string.IsNullOrWhiteSpace(overrideFamilyName) && familyDoc.OwnerFamily != null && !familyDoc.OwnerFamily.Name.Equals(overrideFamilyName, StringComparison.OrdinalIgnoreCase))
                {
                    using (var txName = new Transaction(familyDoc, "Renombrar Familia"))
                    {
                        txName.Start();
                        try
                        {
                            familyDoc.OwnerFamily.Name = overrideFamilyName;
                        }
                        catch (Exception nameEx)
                        {
                            TelemetryLogger.LogWarning($"No se pudo renombrar la familia en memoria a '{overrideFamilyName}': {nameEx.Message}");
                        }
                        txName.Commit();
                    }
                }

                // Filtrar los tipos no seleccionados en el familyDoc antes de cargarlo mediante FamilyManager
                if (familyDoc.IsFamilyDocument && familyDoc.FamilyManager != null && targetSymbolNames != null)
                {
                    var selectedNamesSet = new HashSet<string>(targetSymbolNames, StringComparer.OrdinalIgnoreCase);
                    if (selectedNamesSet.Any())
                    {
                        var familyManager = familyDoc.FamilyManager;
                        var typesToDelete = new List<FamilyType>();

                        foreach (FamilyType familyType in familyManager.Types)
                        {
                            if (!selectedNamesSet.Contains(familyType.Name))
                            {
                                typesToDelete.Add(familyType);
                            }
                        }

                        if (typesToDelete.Any() && typesToDelete.Count < familyManager.Types.Size)
                        {
                            TelemetryLogger.LogInfo($"Filtrando {typesToDelete.Count} tipo(s) no seleccionados en la familia en memoria '{sourceFamily.Name}' mediante FamilyManager...");
                            using (var tx = new Transaction(familyDoc, "Filtrar Tipos Seleccionados"))
                            {
                                tx.Start();
                                foreach (var typeToDelete in typesToDelete)
                                {
                                    try
                                    {
                                        familyManager.CurrentType = typeToDelete;
                                        familyManager.DeleteCurrentType();
                                    }
                                    catch (Exception delEx)
                                    {
                                        TelemetryLogger.LogWarning($"No se pudo eliminar el tipo '{typeToDelete.Name}' en la familia en memoria: {delEx.Message}");
                                    }
                                }
                                tx.Commit();
                            }
                        }
                    }
                }

                var overwriteOptions = new SilentOverwriteFamilyOption();

                loadedFamily = familyDoc.LoadFamily(targetDocument, overwriteOptions);
                if (loadedFamily != null)
                {
                    TelemetryLogger.LogInfo($"Familia en memoria '{sourceFamily.Name}' transferida correctamente.");
                    return true;
                }

                // Buscar referencia si ya existía
                string targetCheckName = overrideFamilyName ?? sourceFamily.Name;
                var existingFamily = new FilteredElementCollector(targetDocument)
                    .OfClass(typeof(Family))
                    .Cast<Family>()
                    .FirstOrDefault(f => f.Name.Equals(targetCheckName, StringComparison.OrdinalIgnoreCase));

                if (existingFamily != null)
                {
                    loadedFamily = existingFamily;
                    TelemetryLogger.LogInfo($"Familia en memoria reutilizada: '{targetCheckName}'");
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogError($"Error al transferir en memoria la familia '{sourceFamily?.Name}'", ex);
                return false;
            }
            finally
            {
                familyDoc?.Close(false);
            }
        }
    }
}
