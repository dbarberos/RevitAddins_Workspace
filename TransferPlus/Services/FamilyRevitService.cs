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
        public Autodesk.Revit.ApplicationServices.Application? RevitApp { get; set; }

        private static void ExecuteWithWarningSuppression(Document doc, Action action)
        {
            if (doc?.Application == null)
            {
                action();
                return;
            }

            var app = doc.Application;
            var uiApp = new Autodesk.Revit.UI.UIApplication(app);

            EventHandler<Autodesk.Revit.DB.Events.FailuresProcessingEventArgs> failureHandler = (sender, e) =>
            {
                try
                {
                    var accessor = e.GetFailuresAccessor();
                    var failures = accessor.GetFailureMessages();
                    foreach (var f in failures)
                    {
                        if (f.GetSeverity() == FailureSeverity.Warning)
                        {
                            accessor.DeleteWarning(f);
                        }
                    }
                }
                catch { }
            };

            EventHandler<Autodesk.Revit.UI.Events.DialogBoxShowingEventArgs> dialogHandler = (sender, e) =>
            {
                try
                {
                    TelemetryLogger.LogInfo($"[DialogBoxShowing] Interceptado: DialogId={e.DialogId}");
                    if (e is Autodesk.Revit.UI.Events.TaskDialogShowingEventArgs taskArgs)
                    {
                        TelemetryLogger.LogInfo($"[TaskDialogShowing] DialogId='{taskArgs.DialogId}', Message='{taskArgs.Message}'");
                        taskArgs.OverrideResult((int)Autodesk.Revit.UI.TaskDialogResult.Ok);
                    }
                    else
                    {
                        // En diálogos nativos de Revit (ej. DialogBox 1001), 1 = Aceptar / OK.
                        e.OverrideResult(1);
                    }
                }
                catch { }
            };

            try
            {
                app.FailuresProcessing += failureHandler;
                uiApp.DialogBoxShowing += dialogHandler;
                action();
            }
            finally
            {
                app.FailuresProcessing -= failureHandler;
                uiApp.DialogBoxShowing -= dialogHandler;
            }
        }

        /// <summary>
        /// Intenta cargar una familia (.rfa) en el documento destino.
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
                string resolvedPath = Path.GetFullPath(rfaFilePath);
                if (!File.Exists(resolvedPath))
                {
                    TelemetryLogger.LogWarning($"El archivo de familia no existe en la ruta validada: '{resolvedPath}'");
                    return false;
                }

                var fileInfo = new FileInfo(resolvedPath);
                if (fileInfo.Length == 0)
                {
                    TelemetryLogger.LogWarning($"El archivo de familia descargado está vacío (0 bytes): '{resolvedPath}'");
                    return false;
                }

                var overwriteOptions = new SilentOverwriteFamilyOption();
                Family? loadedFamily = null;
                bool loadSuccess = false;

                TelemetryLogger.LogInfo($"Iniciando document.LoadFamily('{resolvedPath}'). TargetDoc='{document.Title}', IsFamilyDoc={document.IsFamilyDocument}, IsModifiable={document.IsModifiable}...");

                ExecuteWithWarningSuppression(document, () =>
                {
                    try
                    {
                        // 1. Probar primero la sobrecarga estándar de 2 parámetros
                        loadSuccess = document.LoadFamily(resolvedPath, out loadedFamily);
                        if (!loadSuccess)
                        {
                            TelemetryLogger.LogInfo($"document.LoadFamily(path, out family) devolvió false. Intentando sobrecarga con IFamilyLoadOptions...");
                            loadSuccess = document.LoadFamily(resolvedPath, overwriteOptions, out loadedFamily);
                        }

                        // 2. Si el documento destino es un documento de familia y requiere transacción para familias anidadas
                        if (!loadSuccess && document.IsFamilyDocument && !document.IsModifiable)
                        {
                            TelemetryLogger.LogInfo($"Documento destino es de Familia. Intentando LoadFamily con Transacción explícita para anidadas...");
                            using (var tx = new Transaction(document, "Cargar Familia Anidada"))
                            {
                                tx.Start();
                                loadSuccess = document.LoadFamily(resolvedPath, overwriteOptions, out loadedFamily);
                                if (loadSuccess) tx.Commit();
                                else tx.RollBack();
                            }
                        }

                        // 3. FALLBACK DE INYECCIÓN EN MEMORIA VÍA OpenDocumentFile
                        if (!loadSuccess && document.Application != null)
                        {
                            TelemetryLogger.LogInfo($"document.LoadFamily devolvió false para ruta de disco. Probando inyección en memoria vía OpenDocumentFile...");
                            Document? tempFamilyDoc = null;
                            try
                            {
                                tempFamilyDoc = document.Application.OpenDocumentFile(resolvedPath);
                                if (tempFamilyDoc != null)
                                {
                                    loadSuccess = tempFamilyDoc.LoadFamily(document, overwriteOptions) != null;
                                    if (loadSuccess)
                                    {
                                        var famName = Path.GetFileNameWithoutExtension(resolvedPath);
                                        loadedFamily = new FilteredElementCollector(document)
                                            .OfClass(typeof(Family))
                                            .Cast<Family>()
                                            .FirstOrDefault(f => f.Name.Equals(famName, StringComparison.OrdinalIgnoreCase));
                                        TelemetryLogger.LogInfo($"Inyección en memoria exitosa vía OpenDocumentFile para la familia '{famName}'!");
                                    }
                                }
                            }
                            catch (Exception exOpen)
                            {
                                TelemetryLogger.LogWarning($"OpenDocumentFile / LoadFamily en memoria arrojó excepción: {exOpen.Message}");
                            }
                            finally
                            {
                                try
                                {
                                    tempFamilyDoc?.Close(false);
                                }
                                catch { }
                            }
                        }
                    }
                    catch (Exception exLoad)
                    {
                        TelemetryLogger.LogError($"Excepción interna al ejecutar document.LoadFamily para '{resolvedPath}'", exLoad);
                    }
                });

                TelemetryLogger.LogInfo($"Resultado de document.LoadFamily('{resolvedPath}'): loadSuccess={loadSuccess}, loadedFamily={(loadedFamily != null ? loadedFamily.Name : "null")}");

                if (loadSuccess)
                {
                    family = loadedFamily;
                    TelemetryLogger.LogInfo($"Familia cargada correctamente desde '{resolvedPath}' (Tamaño: {fileInfo.Length} bytes).");
                    return true;
                }

                var familyName = Path.GetFileNameWithoutExtension(resolvedPath);
                var existingFamily = new FilteredElementCollector(document)
                    .OfClass(typeof(Family))
                    .Cast<Family>()
                    .FirstOrDefault(f => f.Name.Equals(familyName, StringComparison.OrdinalIgnoreCase));

                if (existingFamily != null)
                {
                    family = existingFamily;
                    TelemetryLogger.LogInfo($"Referencia de familia existente reutilizada: '{familyName}'");
                    return true;
                }

                TelemetryLogger.LogWarning($"document.LoadFamily devolvió false para '{resolvedPath}' (Tamaño: {fileInfo.Length} bytes).");
                return false;
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogError($"Error al cargar la familia de Revit desde '{rfaFilePath}'", ex);
                return false;
            }
        }

        /// <summary>
        /// Intenta cargar un símbolo/tipo específico de familia (.rfa) en el documento destino.
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
                string resolvedPath = Path.GetFullPath(rfaFilePath);
                if (!File.Exists(resolvedPath))
                {
                    TelemetryLogger.LogWarning($"El archivo de familia fuente para el símbolo no existe: '{resolvedPath}'");
                    return false;
                }

                var overwriteOptions = new SilentOverwriteFamilyOption();
                FamilySymbol? loadedSymbol = null;

                ExecuteWithWarningSuppression(document, () =>
                {
                    document.LoadFamilySymbol(resolvedPath, symbolName, overwriteOptions, out loadedSymbol);
                });

                if (loadedSymbol != null)
                {
                    familySymbol = loadedSymbol;
                    if (!familySymbol.IsActive)
                    {
                        using (var tx = new Transaction(document, "Activar Símbolo"))
                        {
                            tx.Start();
                            familySymbol.Activate();
                            tx.Commit();
                        }
                    }
                    TelemetryLogger.LogInfo($"Símbolo '{symbolName}' cargado correctamente desde '{resolvedPath}'");
                    return true;
                }

                var existingSymbol = new FilteredElementCollector(document)
                    .OfClass(typeof(FamilySymbol))
                    .Cast<FamilySymbol>()
                    .FirstOrDefault(s => s.Name.Equals(symbolName, StringComparison.OrdinalIgnoreCase));

                if (existingSymbol != null)
                {
                    familySymbol = existingSymbol;
                    if (!familySymbol.IsActive)
                    {
                        using (var tx = new Transaction(document, "Activar Símbolo"))
                        {
                            tx.Start();
                            familySymbol.Activate();
                            tx.Commit();
                        }
                    }
                    TelemetryLogger.LogInfo($"Símbolo existente reutilizado: '{symbolName}'");
                    return true;
                }

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
        /// Filtra tipos no seleccionados y renombra tipos en un documento de familia en memoria mediante FamilyManager.
        /// </summary>
        private static void ProcessFamilyDocTypes(
            Document familyDoc,
            IEnumerable<string>? targetSymbolNames,
            IDictionary<string, string>? symbolRenameMap)
        {
            if (familyDoc == null || !familyDoc.IsFamilyDocument || familyDoc.FamilyManager == null)
                return;

            var familyManager = familyDoc.FamilyManager;
            var selectedNamesSet = targetSymbolNames != null ? new HashSet<string>(targetSymbolNames, StringComparer.OrdinalIgnoreCase) : null;
            var renameMap = symbolRenameMap != null ? new Dictionary<string, string>(symbolRenameMap, StringComparer.OrdinalIgnoreCase) : null;

            if ((selectedNamesSet == null || !selectedNamesSet.Any()) && (renameMap == null || !renameMap.Any()))
                return;

            try
            {
                using (var tx = new Transaction(familyDoc, "Filtrar y Renombrar Tipos de Familia"))
                {
                    tx.Start();

                    // 1. Filtrar/Eliminar tipos no seleccionados
                    if (selectedNamesSet != null && selectedNamesSet.Any())
                    {
                        var typesToDelete = new List<FamilyType>();
                        foreach (FamilyType familyType in familyManager.Types)
                        {
                            if (!selectedNamesSet.Contains(familyType.Name) && (renameMap == null || !renameMap.ContainsKey(familyType.Name)))
                            {
                                typesToDelete.Add(familyType);
                            }
                        }

                        if (typesToDelete.Any() && typesToDelete.Count < familyManager.Types.Size)
                        {
                            TelemetryLogger.LogInfo($"Filtrando {typesToDelete.Count} tipo(s) no seleccionados en la familia en memoria...");
                            foreach (var typeToDelete in typesToDelete)
                            {
                                try
                                {
                                    familyManager.CurrentType = typeToDelete;
                                    familyManager.DeleteCurrentType();
                                }
                                catch (Exception delEx)
                                {
                                    TelemetryLogger.LogWarning($"No se pudo eliminar el tipo '{typeToDelete.Name}': {delEx.Message}");
                                }
                            }
                        }
                    }

                    // 2. Duplicar tipos según symbolRenameMap (ej. sufijos para tipos duplicados)
                    if (renameMap != null && renameMap.Any())
                    {
                        var existingTypesList = familyManager.Types.Cast<FamilyType>().ToList();
                        foreach (FamilyType familyType in existingTypesList)
                        {
                            if (renameMap.TryGetValue(familyType.Name, out string? newTypeName) && !string.IsNullOrWhiteSpace(newTypeName))
                            {
                                try
                                {
                                    familyManager.CurrentType = familyType;
                                    familyManager.NewType(newTypeName);
                                    TelemetryLogger.LogInfo($"Duplicado tipo con sufijo en familyDoc: '{familyType.Name}' -> '{newTypeName}'");
                                }
                                catch (Exception exRen)
                                {
                                    TelemetryLogger.LogWarning($"No se pudo duplicar tipo '{familyType.Name}' a '{newTypeName}': {exRen.Message}");
                                }
                            }
                        }
                    }

                    tx.Commit();
                }
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogWarning($"Error procesando tipos en familyDoc: {ex.Message}");
            }
        }

        /// <summary>
        /// Carga una familia desde archivo .rfa modificando opcionalmente el nombre de la familia en memoria si se especifica overrideFamilyName.
        /// </summary>
        public bool TryLoadFileFamilyWithOverride(
            Autodesk.Revit.UI.UIApplication uiApp,
            Document targetDocument,
            string rfaFilePath,
            string? overrideFamilyName = null,
            IEnumerable<string>? targetSymbolNames = null,
            IDictionary<string, string>? symbolRenameMap = null)
        {
            if (targetDocument == null || string.IsNullOrWhiteSpace(rfaFilePath) || !File.Exists(rfaFilePath))
            {
                return false;
            }

            Document? familyDoc = null;
            string tempRfaPath = string.Empty;
            try
            {
                familyDoc = uiApp.Application.OpenDocumentFile(rfaFilePath);
                if (familyDoc == null) return false;

                ProcessFamilyDocTypes(familyDoc, targetSymbolNames, symbolRenameMap);

                string pathToLoad = rfaFilePath;
                if (!string.IsNullOrWhiteSpace(overrideFamilyName))
                {
                    string tempDir = Path.Combine(Path.GetTempPath(), "TransferPlus_TempFamilies");
                    Directory.CreateDirectory(tempDir);
                    tempRfaPath = Path.Combine(tempDir, overrideFamilyName + ".rfa");

                    var saveOptions = new SaveAsOptions { OverwriteExistingFile = true };
                    familyDoc.SaveAs(tempRfaPath, saveOptions);
                    pathToLoad = tempRfaPath;
                }

                var overwriteOptions = new SilentOverwriteFamilyOption();
                bool loaded = false;

                ExecuteWithWarningSuppression(targetDocument, () =>
                {
                    loaded = familyDoc.LoadFamily(targetDocument, overwriteOptions) != null;
                });

                if (loaded)
                {
                    TelemetryLogger.LogInfo($"Familia desde archivo '{overrideFamilyName ?? Path.GetFileNameWithoutExtension(rfaFilePath)}' cargada con éxito.");
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogError($"Error al cargar la familia desde archivo '{rfaFilePath}'", ex);
                return false;
            }
            finally
            {
                familyDoc?.Close(false);
                if (!string.IsNullOrEmpty(tempRfaPath) && File.Exists(tempRfaPath))
                {
                    try { File.Delete(tempRfaPath); } catch { }
                }
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
            string? overrideFamilyName = null,
            IDictionary<string, string>? symbolRenameMap = null)
        {
            loadedFamily = null;
            if (sourceDocument == null || sourceFamily == null || targetDocument == null)
            {
                return false;
            }

            Document? familyDoc = null;
            string tempRfaPath = string.Empty;
            try
            {
                // Abrir la familia en memoria (no crea ventana gráfica)
                familyDoc = sourceDocument.EditFamily(sourceFamily);
                if (familyDoc == null)
                {
                    TelemetryLogger.LogWarning($"No se pudo editar en memoria la familia '{sourceFamily.Name}'.");
                    return false;
                }

                ProcessFamilyDocTypes(familyDoc, targetSymbolNames, symbolRenameMap);

                var overwriteOptions = new SilentOverwriteFamilyOption();
                Family? resultFamily = null;

                // Siempre guardar en archivo temporal local antes de LoadFamily para asegurar que Revit aplique las modificaciones del EditFamily entre modelos abiertos
                string tempDir = Path.Combine(Path.GetTempPath(), "TransferPlus_TempFamilies");
                Directory.CreateDirectory(tempDir);
                string targetFileName = overrideFamilyName ?? sourceFamily.Name;
                tempRfaPath = Path.Combine(tempDir, targetFileName + "_" + Guid.NewGuid().ToString("N") + ".rfa");

                var saveOptions = new SaveAsOptions { OverwriteExistingFile = true };
                familyDoc.SaveAs(tempRfaPath, saveOptions);

                ExecuteWithWarningSuppression(targetDocument, () =>
                {
                    resultFamily = familyDoc.LoadFamily(targetDocument, overwriteOptions);
                });

                string targetCheckName = overrideFamilyName ?? sourceFamily.Name;
                var existingFamily = new FilteredElementCollector(targetDocument)
                    .OfClass(typeof(Family))
                    .Cast<Family>()
                    .FirstOrDefault(f => f.Name.Equals(targetCheckName, StringComparison.OrdinalIgnoreCase));

                if (existingFamily != null)
                {
                    loadedFamily = existingFamily;
                    TelemetryLogger.LogInfo($"Familia en memoria cargada/reutilizada: '{targetCheckName}'");
                    return true;
                }

                return resultFamily != null;
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogError($"Error al transferir en memoria la familia '{sourceFamily?.Name}'", ex);
                return false;
            }
            finally
            {
                familyDoc?.Close(false);
                if (!string.IsNullOrEmpty(tempRfaPath) && File.Exists(tempRfaPath))
                {
                    try { File.Delete(tempRfaPath); } catch { }
                }
            }
        }
    }
}
