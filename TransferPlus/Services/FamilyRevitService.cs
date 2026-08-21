using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using TransferPlus.Models;
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
            ExecuteWithWarningSuppression(new Autodesk.Revit.UI.UIApplication(doc.Application), action);
        }

        private static void ExecuteWithWarningSuppression(Autodesk.Revit.UI.UIApplication uiApp, Action action)
        {
            if (uiApp?.Application == null)
            {
                action();
                return;
            }

            var app = uiApp.Application;

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
                    WarningSwallower.AttachToTransaction(tx);

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

                    // 1.5 Eliminar tipo redundante predeterminado que coincida exactamente con el nombre de la familia si existen otros tipos
                    string familyName = familyDoc.OwnerFamily?.Name ?? string.Empty;
                    if (!string.IsNullOrWhiteSpace(familyName) && familyManager.Types.Size > 1)
                    {
                        var defaultRedundantType = familyManager.Types.Cast<FamilyType>()
                            .FirstOrDefault(t => t.Name.Equals(familyName, StringComparison.OrdinalIgnoreCase));

                        if (defaultRedundantType != null && familyManager.Types.Size > 1)
                        {
                            try
                            {
                                familyManager.CurrentType = defaultRedundantType;
                                familyManager.DeleteCurrentType();
                                TelemetryLogger.LogInfo($"Eliminado tipo redundante predeterminado con nombre de familia: '{defaultRedundantType.Name}'");
                            }
                            catch { }
                        }
                    }

                    // 2. Renombrar tipos según symbolRenameMap
                    if (renameMap != null && renameMap.Any())
                    {
                        var existingTypesList = familyManager.Types.Cast<FamilyType>().ToList();
                        foreach (FamilyType familyType in existingTypesList)
                        {
                            if (renameMap.TryGetValue(familyType.Name, out string? newTypeName) && !string.IsNullOrWhiteSpace(newTypeName) && !newTypeName.Equals(familyType.Name, StringComparison.OrdinalIgnoreCase))
                            {
                                try
                                {
                                    familyManager.CurrentType = familyType;
                                    familyManager.RenameCurrentType(newTypeName);
                                    TelemetryLogger.LogInfo($"Renombrado tipo en familyDoc: '{familyType.Name}' -> '{newTypeName}'");
                                }
                                catch (Exception exRen)
                                {
                                    TelemetryLogger.LogWarning($"No se pudo renombrar tipo '{familyType.Name}' a '{newTypeName}': {exRen.Message}");
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

                string targetFileName = overrideFamilyName ?? Path.GetFileNameWithoutExtension(rfaFilePath);
                if (!string.IsNullOrWhiteSpace(overrideFamilyName))
                {
                    string tempDir = Path.Combine(Path.GetTempPath(), "TransferPlus_TempFamilies");
                    Directory.CreateDirectory(tempDir);
                    tempRfaPath = Path.Combine(tempDir, overrideFamilyName + ".rfa");

                    var saveOptions = new SaveAsOptions { OverwriteExistingFile = true };
                    familyDoc.SaveAs(tempRfaPath, saveOptions);
                }

                var overwriteOptions = new SilentOverwriteFamilyOption();
                bool loaded = false;

                ExecuteWithWarningSuppression(targetDocument, () =>
                {
                    loaded = familyDoc.LoadFamily(targetDocument, overwriteOptions) != null;
                });

                if (loaded)
                {
                    TelemetryLogger.LogInfo($"Familia desde archivo '{targetFileName}' cargada con éxito.");
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
        /// Edita una familia en memoria. Si el documento origen es de solo lectura (Read-Only) o un vínculo
        /// donde EditFamily falla, realiza una copia temporal de una instancia/símbolo a un documento de proyecto intermedio en memoria
        /// para poder invocar EditFamily sin errores de estado de solo lectura.
        /// </summary>
        private Document? SafeEditFamily(UIApplication? uiApp, Document sourceDoc, Family sourceFamily, out Document? tempContainerDoc)
        {
            tempContainerDoc = null;
            if (sourceDoc == null || sourceFamily == null) return null;

            // Estrategia 1: Edición directa si el documento no es solo lectura
            if (!sourceDoc.IsReadOnly)
            {
                try
                {
                    var famDoc = sourceDoc.EditFamily(sourceFamily);
                    if (famDoc != null) return famDoc;
                }
                catch (Autodesk.Revit.Exceptions.InvalidOperationException ex) when (ex.Message.IndexOf("read-only", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    TelemetryLogger.LogInfo($"SafeEditFamily: Documento '{sourceDoc.Title}' es Read-Only. Activando fallback de copia temporal...");
                }
                catch (Exception ex)
                {
                    TelemetryLogger.LogExceptionSilently($"SafeEditFamily direct EditFamily on '{sourceFamily.Name}'", ex);
                }
            }

            // Estrategia 2: Copia a documento intermedio en memoria (para modelos Read-Only o Vínculos)
            try
            {
                var app = uiApp?.Application ?? sourceDoc.Application;
                tempContainerDoc = app.NewProjectDocument(UnitSystem.Metric);

                var idsToCopy = new List<ElementId>();

                // a) Buscar primero una instancia de la familia en el modelo origen
                var instanceId = new FilteredElementCollector(sourceDoc)
                    .OfClass(typeof(FamilyInstance))
                    .WhereElementIsNotElementType()
                    .Cast<FamilyInstance>()
                    .FirstOrDefault(fi => fi.Symbol != null && fi.Symbol.Family != null && fi.Symbol.Family.Id == sourceFamily.Id)?.Id;

                if (instanceId != null && instanceId != ElementId.InvalidElementId)
                {
                    idsToCopy.Add(instanceId);
                }
                else
                {
                    // b) Si no hay instancias, tomar el ID del primer tipo (FamilySymbol)
                    var symbolId = sourceFamily.GetFamilySymbolIds()?.FirstOrDefault();
                    if (symbolId != null && symbolId != ElementId.InvalidElementId)
                    {
                        idsToCopy.Add(symbolId);
                    }
                }

                if (idsToCopy.Any())
                {
                    using (Transaction t = new Transaction(tempContainerDoc, "Copy Element For Edit"))
                    {
                        t.Start();
                        WarningSwallower.AttachToTransaction(t);
                        var copyOptions = new CopyPasteOptions();
                        ElementTransformUtils.CopyElements(
                            sourceDoc,
                            idsToCopy,
                            tempContainerDoc,
                            Transform.Identity,
                            copyOptions);
                        t.Commit();
                    }

                    // Buscar la familia copiada en el documento temporal
                    var copiedFamily = new FilteredElementCollector(tempContainerDoc)
                        .OfClass(typeof(Family))
                        .Cast<Family>()
                        .FirstOrDefault(f => f.Name.Equals(sourceFamily.Name, StringComparison.OrdinalIgnoreCase));

                    if (copiedFamily != null)
                    {
                        return tempContainerDoc.EditFamily(copiedFamily);
                    }
                }
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogExceptionSilently($"SafeEditFamily fallback copy for '{sourceFamily.Name}'", ex);
            }

            return null;
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
            IDictionary<string, string>? symbolRenameMap = null,
            UIApplication? uiApp = null)
        {
            loadedFamily = null;
            if (sourceDocument == null || sourceFamily == null || targetDocument == null)
            {
                return false;
            }

            Document? familyDoc = null;
            Document? tempContainerDoc = null;
            string tempRfaPath = string.Empty;
            try
            {
                // Abrir la familia en memoria usando SafeEditFamily (soporta documentos solo lectura)
                familyDoc = SafeEditFamily(uiApp, sourceDocument, sourceFamily, out tempContainerDoc);
                if (familyDoc == null)
                {
                    TelemetryLogger.LogWarning($"No se pudo editar en memoria la familia '{sourceFamily.Name}'.");
                    return false;
                }

                ProcessFamilyDocTypes(familyDoc, targetSymbolNames, symbolRenameMap);

                var overwriteOptions = new SilentOverwriteFamilyOption();
                Family? resultFamily = null;

                if (!string.IsNullOrWhiteSpace(overrideFamilyName))
                {
                    string tempDir = Path.Combine(Path.GetTempPath(), "TransferPlus_TempFamilies");
                    Directory.CreateDirectory(tempDir);
                    tempRfaPath = Path.Combine(tempDir, overrideFamilyName + ".rfa");

                    var saveOptions = new SaveAsOptions { OverwriteExistingFile = true };
                    familyDoc.SaveAs(tempRfaPath, saveOptions);
                }

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
                TelemetryLogger.LogExceptionSilently($"Error al transferir en memoria la familia '{sourceFamily?.Name}'", ex);
                return false;
            }
            finally
            {
                if (familyDoc != null)
                {
                    try { familyDoc.Close(false); } catch { }
                }
                if (tempContainerDoc != null)
                {
                    try { tempContainerDoc.Close(false); } catch { }
                }
                if (!string.IsNullOrEmpty(tempRfaPath) && File.Exists(tempRfaPath))
                {
                    try { File.Delete(tempRfaPath); } catch { }
                }
            }
        }

        /// <summary>
        /// Exporta una familia eliminando de su interior los tipos no seleccionados en el explorador
        /// y guardando el archivo .rfa limpio en la carpeta especificada por el usuario.
        /// </summary>
        public bool ExportSelectiveFamilyToFolder(
            Autodesk.Revit.UI.UIApplication uiApp,
            Document? sourceDoc,
            FamilyItemModel familyItem,
            string outputFolderPath,
            IEnumerable<string> targetSymbolNames,
            string? overrideFamilyName = null,
            Dictionary<string, string>? symbolRenameMap = null,
            bool setDefaultView3D = false)
        {
            if (uiApp == null || familyItem == null || string.IsNullOrWhiteSpace(outputFolderPath) || !Directory.Exists(outputFolderPath))
            {
                return false;
            }

            bool success = false;
            ExecuteWithWarningSuppression(uiApp, () =>
            {
                Document? familyDoc = null;
                Document? tempContainerDoc = null;
                try
                {
                    string exportFileName = !string.IsNullOrWhiteSpace(overrideFamilyName) ? overrideFamilyName : familyItem.Name;
                    string targetRfaPath = Path.Combine(outputFolderPath, exportFileName + ".rfa");

                    // Caso 1: Origen desde modelo abierto o vinculado (NativeFamily != null)
                    if (familyItem.NativeFamily is Family nativeFam && sourceDoc != null)
                    {
                        familyDoc = SafeEditFamily(uiApp, sourceDoc, nativeFam, out tempContainerDoc);
                    }
                    // Caso 2: Origen desde archivo .rfa local o descargado (Azure / Local / ACC)
                    else if (!string.IsNullOrWhiteSpace(familyItem.ImagePreviewUrl))
                    {
                        string rfaPath = familyItem.ImagePreviewUrl;
                        if (!File.Exists(rfaPath))
                        {
                            string fileName = Path.GetFileName(rfaPath);
                            string tempFamiliesPath = Path.Combine(Path.GetTempPath(), "TransferPlus_Families", fileName);
                            string tempAzurePath = Path.Combine(Path.GetTempPath(), "TransferPlus_AzureCache", fileName);
                            string tempAccPath = Path.Combine(Path.GetTempPath(), "TransferPlus_AccCache", fileName);

                            if (File.Exists(tempFamiliesPath)) rfaPath = tempFamiliesPath;
                            else if (File.Exists(tempAzurePath)) rfaPath = tempAzurePath;
                            else if (File.Exists(tempAccPath)) rfaPath = tempAccPath;
                        }

                        if (File.Exists(rfaPath))
                        {
                            familyDoc = uiApp.Application.OpenDocumentFile(rfaPath);
                        }
                    }

                    if (familyDoc == null) return;

                    // Filtrar los tipos eliminando aquellos que no estén en targetSymbolNames y renombrando según symbolRenameMap
                    ProcessFamilyDocTypes(familyDoc, targetSymbolNames, symbolRenameMap);

                    var saveOptions = new SaveAsOptions { OverwriteExistingFile = true };

                    // Configurar vista por defecto como vista 3D si la opción está activada
                    if (setDefaultView3D)
                    {
                        try
                        {
                            var view3D = new FilteredElementCollector(familyDoc)
                                .OfClass(typeof(View3D))
                                .Cast<View3D>()
                                .FirstOrDefault(v => !v.IsTemplate);

                            if (view3D != null)
                            {
                                saveOptions.PreviewViewId = view3D.Id;
                                TelemetryLogger.LogInfo($"[SaveAsOptions] Asignada vista 3D '{view3D.Name}' (ID: {view3D.Id}) como vista previa para '{exportFileName}'.");
                            }
                            else
                            {
                                var viewFamilyType = new FilteredElementCollector(familyDoc)
                                    .OfClass(typeof(ViewFamilyType))
                                    .Cast<ViewFamilyType>()
                                    .FirstOrDefault(v => v.ViewFamily == ViewFamily.ThreeDimensional);

                                if (viewFamilyType != null)
                                {
                                    using (var t = new Transaction(familyDoc, "Create 3D View for Preview"))
                                    {
                                        t.Start();
                                        var createdView3D = View3D.CreateIsometric(familyDoc, viewFamilyType.Id);
                                        if (createdView3D != null)
                                        {
                                            createdView3D.Name = "{3D - Preview}";
                                            saveOptions.PreviewViewId = createdView3D.Id;
                                            TelemetryLogger.LogInfo($"[SaveAsOptions] Creada vista 3D '{createdView3D.Name}' como vista previa para '{exportFileName}'.");
                                        }
                                        t.Commit();
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            TelemetryLogger.LogWarning($"[SaveAsOptions] No se pudo establecer la vista 3D previa para '{exportFileName}': {ex.Message}");
                        }
                    }

                    familyDoc.SaveAs(targetRfaPath, saveOptions);

                    TelemetryLogger.LogInfo($"[Export] Familia '{exportFileName}' exportada con éxito con {targetSymbolNames.Count()} tipo(s) en '{targetRfaPath}'.");
                    success = true;
                }
                catch (Exception ex)
                {
                    TelemetryLogger.LogExceptionSilently($"[Export] Error exportando familia '{familyItem.Name}' a '{outputFolderPath}'", ex);
                    success = false;
                }
                finally
                {
                    if (familyDoc != null)
                    {
                        try { familyDoc.Close(false); } catch { }
                    }
                    if (tempContainerDoc != null)
                    {
                        try { tempContainerDoc.Close(false); } catch { }
                    }
                }
            });

            return success;
        }

        /// <summary>
        /// Transfiere una lista de Vistas de Diseño (Drafting Views) desde un documento origen hacia un documento destino de forma silenciosa.
        /// </summary>
        public int TransferDraftingViews(Document sourceDoc, Document targetDoc, List<ElementId> viewIds)
        {
            if (sourceDoc == null || targetDoc == null || viewIds == null || !viewIds.Any()) return 0;

            int transferredCount = 0;

            ExecuteWithWarningSuppression(targetDoc, () =>
            {
                using (var t = new Transaction(targetDoc, "Transfer Drafting Views"))
                {
                    var options = t.GetFailureHandlingOptions();
                    options.SetFailuresPreprocessor(new WarningSwallower());
                    options.SetClearAfterRollback(true);
                    t.SetFailureHandlingOptions(options);

                    t.Start();

                    try
                    {
                        var copyOptions = new CopyPasteOptions();
                        var copiedIds = ElementTransformUtils.CopyElements(sourceDoc, viewIds, targetDoc, Transform.Identity, copyOptions);

                        transferredCount = copiedIds.Count;
                        t.Commit();
                        TelemetryLogger.LogInfo($"[TransferDraftingViews] Transferidas {transferredCount} vistas de diseño con éxito a '{targetDoc.Title}'.");
                    }
                    catch (Exception ex)
                    {
                        TelemetryLogger.LogExceptionSilently($"[TransferDraftingViews] Error transfiriendo vistas de diseño a '{targetDoc.Title}'", ex);
                        if (t.GetStatus() == TransactionStatus.Started)
                        {
                            t.RollBack();
                        }
                    }
                }
            });

            return transferredCount;
        }

        /// <summary>
        /// Transfiere instancias CAD (DWG Links / Imports) incrustadas o vinculadas en vistas de modelo a nuevas Vistas de Diseño (Drafting Views) en el documento destino.
        /// </summary>
        public int TransferCadInstancesToDraftingViews(Document sourceDoc, Document targetDoc, List<ElementId> cadInstanceIds)
        {
            if (sourceDoc == null || targetDoc == null || cadInstanceIds == null || !cadInstanceIds.Any()) return 0;

            int transferredCount = 0;

            ExecuteWithWarningSuppression(targetDoc, () =>
            {
                using (var t = new Transaction(targetDoc, "Transfer CAD Instances to Drafting Views"))
                {
                    var options = t.GetFailureHandlingOptions();
                    options.SetFailuresPreprocessor(new WarningSwallower());
                    options.SetClearAfterRollback(true);
                    t.SetFailureHandlingOptions(options);

                    t.Start();

                    try
                    {
                        // 1. Obtener el tipo de familia de vista para Vistas de Diseño (Drafting)
                        var draftingVft = new FilteredElementCollector(targetDoc)
                            .OfClass(typeof(ViewFamilyType))
                            .Cast<ViewFamilyType>()
                            .FirstOrDefault(vft => vft.ViewFamily == ViewFamily.Drafting);

                        if (draftingVft == null)
                        {
                            TelemetryLogger.LogWarning($"[TransferCadInstances] No se encontró ViewFamilyType para Drafting en '{targetDoc.Title}'.");
                            t.RollBack();
                            return;
                        }

                        // Obtener nombres de vistas existentes en destino para evitar colisiones
                        var existingViewNames = new FilteredElementCollector(targetDoc)
                            .OfClass(typeof(View))
                            .Cast<View>()
                            .Select(v => v.Name)
                            .ToHashSet(StringComparer.OrdinalIgnoreCase);

                        var copyOptions = new CopyPasteOptions();

                        foreach (var cadId in cadInstanceIds)
                        {
                            if (sourceDoc.GetElement(cadId) is not ImportInstance cadInst) continue;

                            string cadName = string.Empty;
                            if (cadInst.GetTypeId() != ElementId.InvalidElementId && sourceDoc.GetElement(cadInst.GetTypeId()) is Element typeElem && !string.IsNullOrWhiteSpace(typeElem.Name))
                            {
                                cadName = typeElem.Name;
                            }
                            else if (cadInst.Category != null && !string.IsNullOrWhiteSpace(cadInst.Category.Name))
                            {
                                cadName = cadInst.Category.Name;
                            }
                            else
                            {
                                cadName = $"CAD_{cadInst.Id.Value}";
                            }

                            string sourceViewName = "Model";
                            View? sourceOwnerView = null;
                            if (cadInst.OwnerViewId != ElementId.InvalidElementId && sourceDoc.GetElement(cadInst.OwnerViewId) is View ownerView)
                            {
                                sourceOwnerView = ownerView;
                                sourceViewName = ownerView.Name;
                            }

                            // a. Crear una nueva ViewDrafting
                            var newDraftingView = ViewDrafting.Create(targetDoc, draftingVft.Id);
                            if (newDraftingView == null) continue;

                            // Nombrar la vista de diseño
                            string baseViewName = $"CAD - {cadName} ({sourceViewName})";
                            string uniqueViewName = baseViewName;
                            int suffix = 1;
                            while (existingViewNames.Contains(uniqueViewName))
                            {
                                uniqueViewName = $"{baseViewName}_{suffix++}";
                            }
                            newDraftingView.Name = uniqueViewName;
                            existingViewNames.Add(uniqueViewName);

                            // b. Copiar el elemento CAD en la nueva Vista de Diseño
                            try
                            {
                                if (cadInst.ViewSpecific && sourceOwnerView != null)
                                {
                                    ElementTransformUtils.CopyElements(
                                        sourceOwnerView,
                                        new List<ElementId> { cadId },
                                        newDraftingView,
                                        Transform.Identity,
                                        copyOptions);
                                }
                                else
                                {
                                    ElementTransformUtils.CopyElements(
                                        sourceDoc,
                                        new List<ElementId> { cadId },
                                        targetDoc,
                                        Transform.Identity,
                                        copyOptions);
                                }
                                transferredCount++;
                            }
                            catch (Exception copyEx)
                            {
                                TelemetryLogger.LogWarning($"[TransferCadInstances] Error copiando elemento CAD '{cadName}' a vista de diseño '{uniqueViewName}': {copyEx.Message}");
                            }
                        }

                        t.Commit();
                        TelemetryLogger.LogInfo($"[TransferCadInstances] Creadas y transferidas {transferredCount} vistas de diseño CAD con éxito en '{targetDoc.Title}'.");
                    }
                    catch (Exception ex)
                    {
                        TelemetryLogger.LogExceptionSilently($"[TransferCadInstances] Error general creando vistas de diseño CAD en '{targetDoc.Title}'", ex);
                        if (t.GetStatus() == TransactionStatus.Started)
                        {
                            t.RollBack();
                        }
                    }
                }
            });

            return transferredCount;
        }

        /// <summary>
        /// Importa o vincula un archivo de dibujo CAD externo (.dwg, .dxf, .sat, etc.) en una nueva Vista de Diseño (Drafting View) en el documento destino.
        /// </summary>
        public bool TransferExternalCadToDraftingView(Document targetDoc, string filePath, string? overrideViewName, bool isLinkMode)
        {
            if (targetDoc == null || string.IsNullOrWhiteSpace(filePath) || !System.IO.File.Exists(filePath)) return false;

            bool success = false;

            ExecuteWithWarningSuppression(targetDoc, () =>
            {
                using (var t = new Transaction(targetDoc, isLinkMode ? "Link External CAD to Drafting View" : "Import External CAD to Drafting View"))
                {
                    var options = t.GetFailureHandlingOptions();
                    options.SetFailuresPreprocessor(new WarningSwallower());
                    options.SetClearAfterRollback(true);
                    t.SetFailureHandlingOptions(options);

                    t.Start();

                    try
                    {
                        // 1. Obtener el tipo de familia de vista para Vistas de Diseño (Drafting)
                        var draftingVft = new FilteredElementCollector(targetDoc)
                            .OfClass(typeof(ViewFamilyType))
                            .Cast<ViewFamilyType>()
                            .FirstOrDefault(vft => vft.ViewFamily == ViewFamily.Drafting);

                        if (draftingVft == null)
                        {
                            TelemetryLogger.LogWarning($"[TransferExternalCad] No se encontró ViewFamilyType para Drafting en '{targetDoc.Title}'.");
                            t.RollBack();
                            return;
                        }

                        // Obtener nombres de vistas existentes en destino para evitar colisiones
                        var existingViewNames = new FilteredElementCollector(targetDoc)
                            .OfClass(typeof(View))
                            .Cast<View>()
                            .Select(v => v.Name)
                            .ToHashSet(StringComparer.OrdinalIgnoreCase);

                        // Crear una nueva ViewDrafting
                        var newDraftingView = ViewDrafting.Create(targetDoc, draftingVft.Id);
                        if (newDraftingView == null)
                        {
                            t.RollBack();
                            return;
                        }

                        string fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);
                        string baseViewName = !string.IsNullOrWhiteSpace(overrideViewName) ? overrideViewName : $"CAD - {fileName}";
                        string uniqueViewName = baseViewName;
                        int suffix = 1;
                        while (existingViewNames.Contains(uniqueViewName))
                        {
                            uniqueViewName = $"{baseViewName}_{suffix++}";
                        }
                        newDraftingView.Name = uniqueViewName;
                        existingViewNames.Add(uniqueViewName);

                        string ext = System.IO.Path.GetExtension(filePath).ToLowerInvariant();

                        if (isLinkMode)
                        {
                            // Link mode (Revit API doc.Link)
                            if (ext == ".dwg" || ext == ".dxf")
                            {
                                var linkOpt = new DWGImportOptions { ThisViewOnly = true, Placement = ImportPlacement.Origin };
                                targetDoc.Link(filePath, linkOpt, newDraftingView, out _);
                            }
                            else if (ext == ".dgn")
                            {
                                var linkOpt = new DGNImportOptions { ThisViewOnly = true, Placement = ImportPlacement.Origin };
                                targetDoc.Link(filePath, linkOpt, newDraftingView, out _);
                            }
                            else
                            {
                                var linkOpt = new DWGImportOptions { ThisViewOnly = true, Placement = ImportPlacement.Origin };
                                targetDoc.Link(filePath, linkOpt, newDraftingView, out _);
                            }
                        }
                        else
                        {
                            // Import mode (Revit API doc.Import)
                            if (ext == ".dwg" || ext == ".dxf")
                            {
                                var impOpt = new DWGImportOptions { ThisViewOnly = true, Placement = ImportPlacement.Origin };
                                targetDoc.Import(filePath, impOpt, newDraftingView, out _);
                            }
                            else if (ext == ".sat")
                            {
                                var impOpt = new SATImportOptions { Placement = ImportPlacement.Origin };
                                targetDoc.Import(filePath, impOpt, newDraftingView);
                            }
                            else if (ext == ".dgn")
                            {
                                var impOpt = new DGNImportOptions { ThisViewOnly = true, Placement = ImportPlacement.Origin };
                                targetDoc.Import(filePath, impOpt, newDraftingView, out _);
                            }
                            else if (ext == ".skp")
                            {
                                var impOpt = new SKPImportOptions { Placement = ImportPlacement.Origin };
                                targetDoc.Import(filePath, impOpt, newDraftingView);
                            }
                            else
                            {
                                var impOpt = new DWGImportOptions { ThisViewOnly = true, Placement = ImportPlacement.Origin };
                                targetDoc.Import(filePath, impOpt, newDraftingView, out _);
                            }
                        }

                        t.Commit();
                        success = true;
                        TelemetryLogger.LogInfo($"[TransferExternalCad] {(isLinkMode ? "Vinculado" : "Importado")} '{filePath}' con éxito en vista de diseño '{uniqueViewName}' en '{targetDoc.Title}'.");
                    }
                    catch (Exception ex)
                    {
                        TelemetryLogger.LogError($"[TransferExternalCad] Error al transferir CAD '{filePath}' a '{targetDoc.Title}'", ex);
                        if (t.GetStatus() == TransactionStatus.Started)
                        {
                            t.RollBack();
                        }
                    }
                }
            });

            return success;
        }

        /// <summary>
        /// Genera una imagen de previsualización (PNG) de una vista de Revit o detalle CAD utilizando ImageExportOptions de la API nativa.
        /// Exporta la imagen a una carpeta temporal sanitizada en %TEMP% y devuelve la ruta absoluta del archivo generado.
        /// </summary>
        public string? GenerateViewPreview(Document doc, ElementId viewId)
        {
            if (doc == null || viewId == null || viewId == ElementId.InvalidElementId)
            {
                return null;
            }

            try
            {
                var view = doc.GetElement(viewId) as View;
                if (view == null || view.IsTemplate)
                {
                    return null;
                }

                // Crear carpeta temporal sanitizada bajo %TEMP%\TransferPlus_Previews
                string tempDir = Path.Combine(Path.GetTempPath(), "TransferPlus_Previews", Guid.NewGuid().ToString("N"));
                tempDir = Path.GetFullPath(tempDir);
                if (!Directory.Exists(tempDir))
                {
                    Directory.CreateDirectory(tempDir);
                }

                string baseFilePath = Path.Combine(tempDir, "preview");
                baseFilePath = Path.GetFullPath(baseFilePath);

                var options = new ImageExportOptions
                {
                    ExportRange = ExportRange.SetOfViews,
                    ZoomType = ZoomFitType.FitToPage,
                    PixelSize = 512,
                    ImageResolution = ImageResolution.DPI_72,
                    ShadowViewsFileType = ImageFileType.PNG,
                    HLRandWFViewsFileType = ImageFileType.PNG,
                    FilePath = baseFilePath,
                    FitDirection = FitDirectionType.Horizontal
                };

                options.SetViewsAndSheets(new List<ElementId> { viewId });

                doc.ExportImage(options);

                var generatedFiles = Directory.GetFiles(tempDir, "*.png");
                if (generatedFiles.Length > 0)
                {
                    string targetFile = generatedFiles[0];
                    if (!(view is ViewSheet))
                    {
                        OptimizeImageFraming(targetFile);
                    }
                    TelemetryLogger.LogInfo($"[GenerateViewPreview] Vista previa generada exitosamente para '{view.Name}': {targetFile}");
                    return targetFile;
                }
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogExceptionSilently($"[GenerateViewPreview] Error exportando vista previa para ViewId={viewId.Value}", ex);
            }

            return null;
        }

        /// <summary>
        /// Genera una imagen de previsualización (PNG) renderizada exclusivamente para un elemento 2D aislado (Detail Item, Group, CAD)
        /// creando una vista de diseño temporal (DraftingView), instanciando/copiando únicamente el elemento, exportándola a %TEMP%
        /// y revirtiendo la transacción (RollBack) inmediatamente para no modificar el documento.
        /// </summary>
        public string? GenerateElementPreview(Document doc, ElementId elementId, ElementId? ownerViewId = null)
        {
            if (doc == null || elementId == null || elementId == ElementId.InvalidElementId)
            {
                return null;
            }

            try
            {
                var elem = doc.GetElement(elementId);
                if (elem == null) return null;

                // Crear carpeta temporal sanitizada bajo %TEMP%\TransferPlus_Previews
                string tempDir = Path.Combine(Path.GetTempPath(), "TransferPlus_Previews", Guid.NewGuid().ToString("N"));
                tempDir = Path.GetFullPath(tempDir);
                if (!Directory.Exists(tempDir))
                {
                    Directory.CreateDirectory(tempDir);
                }

                string baseFilePath = Path.Combine(tempDir, "preview");
                baseFilePath = Path.GetFullPath(baseFilePath);

                // Buscar el ViewFamilyType para DraftingView
                var draftingType = new FilteredElementCollector(doc)
                    .OfClass(typeof(ViewFamilyType))
                    .Cast<ViewFamilyType>()
                    .FirstOrDefault(vft => vft.ViewFamily == ViewFamily.Drafting);

                if (draftingType == null) return null;

                string? resultPath = null;

                using (var tx = new Transaction(doc, "Generate Isolated Element Preview"))
                {
                    WarningSwallower.AttachToTransaction(tx);
                    tx.Start();

                    try
                    {
                        // 1. Crear una vista de diseño (Drafting View) temporal en blanco
                        var tempView = ViewDrafting.Create(doc, draftingType.Id);
                        tempView.Name = $"_TransferPlus_TempPreview_{Guid.NewGuid():N}";
                        tempView.Scale = 1;

                        Element? placedElem = null;

                        // 2. Colocar o copiar el elemento aislado en la vista temporal
                        if (elem is FamilyInstance fi && fi.Symbol != null)
                        {
                            if (!fi.Symbol.IsActive)
                            {
                                fi.Symbol.Activate();
                            }
                            placedElem = doc.Create.NewFamilyInstance(XYZ.Zero, fi.Symbol, tempView);
                        }
                        else if (elem is FamilySymbol sym)
                        {
                            if (!sym.IsActive)
                            {
                                sym.Activate();
                            }
                            placedElem = doc.Create.NewFamilyInstance(XYZ.Zero, sym, tempView);
                        }
                        else if (ownerViewId != null && ownerViewId != ElementId.InvalidElementId && doc.GetElement(ownerViewId) is View srcView)
                        {
                            var copied = ElementTransformUtils.CopyElements(srcView, new List<ElementId> { elem.Id }, tempView, Transform.Identity, new CopyPasteOptions());
                            if (copied.Count > 0)
                            {
                                placedElem = doc.GetElement(copied.First());
                            }
                        }

                        doc.Regenerate();

                        // 3. Ajustar CropBox ceñido al elemento si está disponible
                        if (placedElem != null)
                        {
                            try
                            {
                                var bbox = placedElem.get_BoundingBox(tempView);
                                if (bbox != null && Math.Abs(bbox.Max.X - bbox.Min.X) > 1e-4 && Math.Abs(bbox.Max.Y - bbox.Min.Y) > 1e-4)
                                {
                                    double width = bbox.Max.X - bbox.Min.X;
                                    double height = bbox.Max.Y - bbox.Min.Y;
                                    double marginX = Math.Max(width * 0.08, 0.02);
                                    double marginY = Math.Max(height * 0.08, 0.02);

                                    var crop = tempView.CropBox;
                                    crop.Min = new XYZ(bbox.Min.X - marginX, bbox.Min.Y - marginY, crop.Min.Z);
                                    crop.Max = new XYZ(bbox.Max.X + marginX, bbox.Max.Y + marginY, crop.Max.Z);
                                    tempView.CropBox = crop;
                                    tempView.CropBoxActive = true;
                                    tempView.CropBoxVisible = false;
                                }
                            }
                            catch { }
                        }

                        // 4. Exportar la vista temporal que contiene ÚNICAMENTE este elemento aislado
                        var options = new ImageExportOptions
                        {
                            ExportRange = ExportRange.SetOfViews,
                            ZoomType = ZoomFitType.FitToPage,
                            PixelSize = 512,
                            ImageResolution = ImageResolution.DPI_72,
                            ShadowViewsFileType = ImageFileType.PNG,
                            HLRandWFViewsFileType = ImageFileType.PNG,
                            FilePath = baseFilePath,
                            FitDirection = FitDirectionType.Horizontal
                        };

                        options.SetViewsAndSheets(new List<ElementId> { tempView.Id });

                        doc.ExportImage(options);

                        var generatedFiles = Directory.GetFiles(tempDir, "*.png");
                        if (generatedFiles.Length > 0)
                        {
                            resultPath = generatedFiles[0];
                            OptimizeImageFraming(resultPath);
                            TelemetryLogger.LogInfo($"[GenerateElementPreview] Vista previa aislada generada exitosamente para '{elem.Name}': {resultPath}");
                        }
                    }
                    catch (Exception exInner)
                    {
                        TelemetryLogger.LogWarning($"[GenerateElementPreview] Excepción interna al crear vista temporal para '{elem.Name}': {exInner.Message}");
                    }
                    finally
                    {
                        // SIEMPRE revertir la transacción para que el documento no sea modificado
                        if (tx.HasStarted() && !tx.HasEnded())
                        {
                            tx.RollBack();
                        }
                    }
                }

                return resultPath;
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogExceptionSilently($"[GenerateElementPreview] Error exportando vista previa para ElementId={elementId.Value}", ex);
            }

            return null;
        }

        /// <summary>
        /// Genera una previsualización renderizada real para una familia (2D o 3D) en memoria,
        /// probando primero la edición en memoria sin modificar documento (EditFamily) o creando una vista
        /// temporal (ViewSheet para cuadros de rotulación, DraftingView o 3D) con RollBack.
        /// </summary>
        public string? GenerateFamilyRenderedPreview(Family nativeFam, Document? targetDoc = null)
        {
            if (nativeFam == null || !nativeFam.IsValidObject) return null;

            Document? doc = nativeFam.Document ?? targetDoc;
            if (doc == null) return null;

            try
            {
                // Sanitizar carpeta temporal bajo %TEMP%\TransferPlus_Previews
                string tempDir = Path.Combine(Path.GetTempPath(), "TransferPlus_Previews", Guid.NewGuid().ToString("N"));
                tempDir = Path.GetFullPath(tempDir);
                if (!Directory.Exists(tempDir))
                {
                    Directory.CreateDirectory(tempDir);
                }

                string baseFilePath = Path.Combine(tempDir, "preview");
                baseFilePath = Path.GetFullPath(baseFilePath);

                // --- ESTRATEGIA 1: Abrir el documento de familia en memoria (EditFamily) ---
                // Funciona para TODO tipo de familias editables (Cuadros de rotulación, perfiles, anotaciones, 3D) sin problemas de hospedaje
                if (nativeFam.IsEditable)
                {
                    Document? famDoc = null;
                    try
                    {
                        famDoc = doc.EditFamily(nativeFam);
                        if (famDoc != null)
                        {
                            View? exportView = new FilteredElementCollector(famDoc)
                                .OfClass(typeof(View3D))
                                .Cast<View3D>()
                                .FirstOrDefault(v => !v.IsTemplate && !v.IsPerspective);

                            exportView ??= new FilteredElementCollector(famDoc)
                                .OfClass(typeof(ViewPlan))
                                .Cast<ViewPlan>()
                                .FirstOrDefault(v => !v.IsTemplate);

                            exportView ??= new FilteredElementCollector(famDoc)
                                .OfClass(typeof(ViewDrafting))
                                .Cast<ViewDrafting>()
                                .FirstOrDefault(v => !v.IsTemplate);

                            exportView ??= new FilteredElementCollector(famDoc)
                                .OfClass(typeof(View))
                                .Cast<View>()
                                .FirstOrDefault(v => !v.IsTemplate && v.ViewType != ViewType.Internal);

                            exportView ??= famDoc.ActiveView;

                            if (exportView != null)
                            {
                                PrepareViewForPreview(famDoc, exportView);

                                var options = new ImageExportOptions
                                {
                                    ExportRange = ExportRange.SetOfViews,
                                    ZoomType = ZoomFitType.FitToPage,
                                    PixelSize = 512,
                                    ImageResolution = ImageResolution.DPI_72,
                                    ShadowViewsFileType = ImageFileType.PNG,
                                    HLRandWFViewsFileType = ImageFileType.PNG,
                                    FilePath = baseFilePath,
                                    FitDirection = FitDirectionType.Horizontal
                                };

                                options.SetViewsAndSheets(new List<ElementId> { exportView.Id });
                                famDoc.ExportImage(options);

                                var files = Directory.GetFiles(tempDir, "*.png");
                                if (files.Length > 0)
                                {
                                    string result = files[0];
                                    OptimizeImageFraming(result);
                                    TelemetryLogger.LogInfo($"[GenerateFamilyRenderedPreview] EditFamily vista previa generada con éxito para '{nativeFam.Name}': {result}");
                                    return result;
                                }
                            }
                        }
                    }
                    catch (Exception exEdit)
                    {
                        TelemetryLogger.LogWarning($"[GenerateFamilyRenderedPreview] EditFamily no disponible o falló para '{nativeFam.Name}': {exEdit.Message}");
                    }
                    finally
                    {
                        try
                        {
                            famDoc?.Close(false);
                        }
                        catch { }
                    }
                }

                // --- ESTRATEGIA 2: Instanciar en vista temporal con transacción RollBack ---
                var symIds = nativeFam.GetFamilySymbolIds();
                if (symIds.Count == 0) return null;

                var symId = symIds.First();
                var symbol = doc.GetElement(symId) as FamilySymbol;
                if (symbol == null) return null;

                bool isTitleBlock = false;
                bool isAnnotationOr2D = false;
                try
                {
                    BuiltInCategory bic = BuiltInCategory.INVALID;
                    if (nativeFam.FamilyCategory != null) bic = (BuiltInCategory)nativeFam.FamilyCategory.Id.Value;
                    else if (symbol.Category != null) bic = (BuiltInCategory)symbol.Category.Id.Value;

                    if (bic == BuiltInCategory.OST_TitleBlocks)
                    {
                        isTitleBlock = true;
                    }
                    else if (bic == BuiltInCategory.OST_DetailComponents ||
                             bic == BuiltInCategory.OST_ProfileFamilies ||
                             bic == BuiltInCategory.OST_GenericAnnotation ||
                             (nativeFam.FamilyCategory != null && nativeFam.FamilyCategory.CategoryType == CategoryType.Annotation) ||
                             (symbol.Category != null && symbol.Category.CategoryType == CategoryType.Annotation))
                    {
                        isAnnotationOr2D = true;
                    }
                }
                catch { }

                string? resultPath = null;

                // Si el documento es de solo lectura (ej. modelo vinculado), usar targetDoc si es modificable
                Document workDoc = doc.IsReadOnly && targetDoc != null && !targetDoc.IsReadOnly ? targetDoc : doc;
                if (workDoc.IsReadOnly) return null;

                using (var tx = new Transaction(workDoc, "Generate Rendered Family Preview"))
                {
                    WarningSwallower.AttachToTransaction(tx);
                    tx.Start();

                    try
                    {
                        View? tempView = null;
                        Element? placedElem = null;

                        if (isTitleBlock)
                        {
                            // Los cuadros de rotulación (TitleBlocks) SOLO pueden colocarse sobre un ViewSheet
                            var tempSheet = ViewSheet.Create(workDoc, ElementId.InvalidElementId);
                            tempSheet.Name = $"_TransferPlus_TempSheet_{Guid.NewGuid():N}";
                            tempSheet.SheetNumber = $"ZZ_{Guid.NewGuid():N}".Substring(0, 8);
                            tempView = tempSheet;

                            FamilySymbol workSym = symbol;
                            if (workDoc != doc)
                            {
                                var copiedIds = ElementTransformUtils.CopyElements(doc, new List<ElementId> { symbol.Id }, workDoc, Transform.Identity, new CopyPasteOptions());
                                if (copiedIds.Count > 0 && workDoc.GetElement(copiedIds.First()) is FamilySymbol cs)
                                {
                                    workSym = cs;
                                }
                            }

                            if (!workSym.IsActive)
                            {
                                workSym.Activate();
                            }
                            placedElem = workDoc.Create.NewFamilyInstance(XYZ.Zero, workSym, tempSheet);
                        }
                        else if (isAnnotationOr2D)
                        {
                            var draftingType = new FilteredElementCollector(workDoc)
                                .OfClass(typeof(ViewFamilyType))
                                .Cast<ViewFamilyType>()
                                .FirstOrDefault(vft => vft.ViewFamily == ViewFamily.Drafting);

                            if (draftingType != null)
                            {
                                var vDraft = ViewDrafting.Create(workDoc, draftingType.Id);
                                vDraft.Name = $"_TransferPlus_Temp2D_{Guid.NewGuid():N}";
                                vDraft.Scale = 1;
                                tempView = vDraft;

                                FamilySymbol workSym = symbol;
                                if (workDoc != doc)
                                {
                                    var copiedIds = ElementTransformUtils.CopyElements(doc, new List<ElementId> { symbol.Id }, workDoc, Transform.Identity, new CopyPasteOptions());
                                    if (copiedIds.Count > 0 && workDoc.GetElement(copiedIds.First()) is FamilySymbol cs)
                                    {
                                        workSym = cs;
                                    }
                                }

                                if (!workSym.IsActive)
                                {
                                    workSym.Activate();
                                }
                                placedElem = workDoc.Create.NewFamilyInstance(XYZ.Zero, workSym, vDraft);
                            }
                        }
                        else
                        {
                            var vft3D = new FilteredElementCollector(workDoc)
                                .OfClass(typeof(ViewFamilyType))
                                .Cast<ViewFamilyType>()
                                .FirstOrDefault(v => v.ViewFamily == ViewFamily.ThreeDimensional);

                            if (vft3D != null)
                            {
                                var v3D = View3D.CreateIsometric(workDoc, vft3D.Id);
                                v3D.Name = $"_TransferPlus_Temp3D_{Guid.NewGuid():N}";
                                tempView = v3D;

                                FamilySymbol workSym = symbol;
                                if (workDoc != doc)
                                {
                                    var copiedIds = ElementTransformUtils.CopyElements(doc, new List<ElementId> { symbol.Id }, workDoc, Transform.Identity, new CopyPasteOptions());
                                    if (copiedIds.Count > 0 && workDoc.GetElement(copiedIds.First()) is FamilySymbol cs)
                                    {
                                        workSym = cs;
                                    }
                                }

                                if (!workSym.IsActive)
                                {
                                    workSym.Activate();
                                }

                                try
                                {
                                    placedElem = workDoc.Create.NewFamilyInstance(XYZ.Zero, workSym, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
                                }
                                catch
                                {
                                    try
                                    {
                                        placedElem = workDoc.Create.NewFamilyInstance(XYZ.Zero, workSym, v3D);
                                    }
                                    catch { }
                                }
                            }
                        }

                        if (tempView != null)
                        {
                            workDoc.Regenerate();

                            // Ceñir CropBox en vistas 2D
                            if (placedElem != null && (tempView is ViewDrafting || tempView is ViewPlan))
                            {
                                try
                                {
                                    var bbox = placedElem.get_BoundingBox(tempView);
                                    if (bbox != null && Math.Abs(bbox.Max.X - bbox.Min.X) > 1e-4 && Math.Abs(bbox.Max.Y - bbox.Min.Y) > 1e-4)
                                    {
                                        double width = bbox.Max.X - bbox.Min.X;
                                        double height = bbox.Max.Y - bbox.Min.Y;
                                        double marginX = Math.Max(width * 0.08, 0.02);
                                        double marginY = Math.Max(height * 0.08, 0.02);

                                        var crop = tempView.CropBox;
                                        crop.Min = new XYZ(bbox.Min.X - marginX, bbox.Min.Y - marginY, crop.Min.Z);
                                        crop.Max = new XYZ(bbox.Max.X + marginX, bbox.Max.Y + marginY, crop.Max.Z);
                                        tempView.CropBox = crop;
                                        tempView.CropBoxActive = true;
                                        tempView.CropBoxVisible = false;
                                    }
                                }
                                catch { }
                            }

                            var options = new ImageExportOptions
                            {
                                ExportRange = ExportRange.SetOfViews,
                                ZoomType = ZoomFitType.FitToPage,
                                PixelSize = 512,
                                ImageResolution = ImageResolution.DPI_72,
                                ShadowViewsFileType = ImageFileType.PNG,
                                HLRandWFViewsFileType = ImageFileType.PNG,
                                FilePath = baseFilePath,
                                FitDirection = FitDirectionType.Horizontal
                            };

                            options.SetViewsAndSheets(new List<ElementId> { tempView.Id });
                            workDoc.ExportImage(options);

                            var files = Directory.GetFiles(tempDir, "*.png");
                            if (files.Length > 0)
                            {
                                resultPath = files[0];
                                OptimizeImageFraming(resultPath);
                                TelemetryLogger.LogInfo($"[GenerateFamilyRenderedPreview] Vista previa renderizada generada exitosamente para '{nativeFam.Name}': {resultPath}");
                            }
                        }
                    }
                    catch (Exception exInner)
                    {
                        TelemetryLogger.LogWarning($"[GenerateFamilyRenderedPreview] Error interno renderizando familia '{nativeFam.Name}': {exInner.Message}");
                    }
                    finally
                    {
                        if (tx.HasStarted() && !tx.HasEnded())
                        {
                            tx.RollBack();
                        }
                    }
                }

                return resultPath;
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogExceptionSilently($"[GenerateFamilyRenderedPreview] Error general para familia '{nativeFam.Name}'", ex);
            }

            return null;
        }

        /// <summary>
        /// Abre silenciosamente un archivo .rfa en memoria, localiza su mejor vista (3D o plano) y exporta
        /// la imagen PNG a %TEMP% para usarla como miniatura cuando el archivo carece de thumbnail OLE embebido.
        /// </summary>
        public string? GenerateRfaFileRenderedPreview(string rfaPath, Autodesk.Revit.ApplicationServices.Application? app = null)
        {
            if (string.IsNullOrWhiteSpace(rfaPath) || !File.Exists(rfaPath)) return null;

            app ??= RevitApp ?? FamilyThumbnailService.CurrentApplication;
            if (app == null) return null;

            string tempDir = Path.Combine(Path.GetTempPath(), "TransferPlus_Previews", Guid.NewGuid().ToString("N"));
            tempDir = Path.GetFullPath(tempDir);
            if (!Directory.Exists(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }

            string baseFilePath = Path.Combine(tempDir, "preview");
            baseFilePath = Path.GetFullPath(baseFilePath);

            Document? rfaDoc = null;
            try
            {
                rfaDoc = app.OpenDocumentFile(rfaPath);
                if (rfaDoc == null) return null;

                View? exportView = new FilteredElementCollector(rfaDoc)
                    .OfClass(typeof(View3D))
                    .Cast<View3D>()
                    .FirstOrDefault(v => !v.IsTemplate && !v.IsPerspective);

                if (exportView == null)
                {
                    exportView = new FilteredElementCollector(rfaDoc)
                        .OfClass(typeof(ViewPlan))
                        .Cast<ViewPlan>()
                        .FirstOrDefault(v => !v.IsTemplate);
                }

                if (exportView == null)
                {
                    exportView = new FilteredElementCollector(rfaDoc)
                        .OfClass(typeof(ViewDrafting))
                        .Cast<ViewDrafting>()
                        .FirstOrDefault(v => !v.IsTemplate);
                }

                if (exportView == null)
                {
                    exportView = new FilteredElementCollector(rfaDoc)
                        .OfClass(typeof(View))
                        .Cast<View>()
                        .FirstOrDefault(v => !v.IsTemplate && v.ViewType != ViewType.Internal);
                }

                exportView ??= rfaDoc.ActiveView;

                if (exportView != null)
                {
                    PrepareViewForPreview(rfaDoc, exportView);

                    var options = new ImageExportOptions
                    {
                        ExportRange = ExportRange.SetOfViews,
                        ZoomType = ZoomFitType.FitToPage,
                        PixelSize = 512,
                        ImageResolution = ImageResolution.DPI_72,
                        ShadowViewsFileType = ImageFileType.PNG,
                        HLRandWFViewsFileType = ImageFileType.PNG,
                        FilePath = baseFilePath,
                        FitDirection = FitDirectionType.Horizontal
                    };

                    options.SetViewsAndSheets(new List<ElementId> { exportView.Id });
                    rfaDoc.ExportImage(options);

                    var generatedFiles = Directory.GetFiles(tempDir, "*.png");
                    if (generatedFiles.Length > 0)
                    {
                        string result = generatedFiles[0];
                        OptimizeImageFraming(result);
                        TelemetryLogger.LogInfo($"[GenerateRfaFileRenderedPreview] Miniatura extraída exitosamente de '{Path.GetFileName(rfaPath)}': {result}");
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogWarning($"[GenerateRfaFileRenderedPreview] Error abriendo y exportando '{rfaPath}': {ex.Message}");
            }
            finally
            {
                try
                {
                    rfaDoc?.Close(false);
                }
                catch { }
            }

            return null;
        }

        private static void PrepareViewForPreview(Document doc, View view)
        {
            if (doc == null || view == null) return;
            try
            {
                using (var tx = new Transaction(doc, "Prepare View For Preview"))
                {
                    WarningSwallower.AttachToTransaction(tx);
                    tx.Start();

                    // 1. Ocultar categorías de anotación que deforman la extensión
                    var categoriesToHide = new[]
                    {
                        BuiltInCategory.OST_CLines,
                        BuiltInCategory.OST_ReferenceLines,
                        BuiltInCategory.OST_Dimensions,
                        BuiltInCategory.OST_Constraints,
                        BuiltInCategory.OST_WeakDims,
                        BuiltInCategory.OST_Grids,
                        BuiltInCategory.OST_Levels
                    };

                    foreach (var bic in categoriesToHide)
                    {
                        try
                        {
                            var cat = doc.Settings.Categories.get_Item(bic);
                            if (cat != null && view.CanCategoryBeHidden(cat.Id))
                            {
                                view.SetCategoryHidden(cat.Id, true);
                            }
                        }
                        catch { }
                    }

                    // 2. Ocultar explícitamente instancias de Planos de Referencia, Cotas y Puntos de Referencia
                    try
                    {
                        var elementsToHide = new FilteredElementCollector(doc, view.Id)
                            .WherePasses(new ElementMulticlassFilter(new List<Type>
                            {
                                typeof(ReferencePlane),
                                typeof(Dimension),
                                typeof(ReferencePoint)
                            }))
                            .ToElementIds();

                        if (elementsToHide.Count > 0)
                        {
                            view.HideElements(elementsToHide);
                        }
                    }
                    catch { }

                    // 3. Ajustar caja de recorte (CropBox) en vistas 2D
                    if (view is ViewDrafting || view is ViewPlan)
                    {
                        try
                        {
                            var remainingElements = new FilteredElementCollector(doc, view.Id)
                                .WhereElementIsNotElementType()
                                .ToElements();

                            BoundingBoxXYZ? totalBbox = null;
                            foreach (var elem in remainingElements)
                            {
                                if (elem is ReferencePlane || elem is Dimension || elem is ReferencePoint) continue;
                                if (elem.Category != null)
                                {
                                    var bic = (BuiltInCategory)elem.Category.Id.Value;
                                    if (bic == BuiltInCategory.OST_CLines ||
                                        bic == BuiltInCategory.OST_ReferenceLines ||
                                        bic == BuiltInCategory.OST_Dimensions ||
                                        bic == BuiltInCategory.OST_Constraints ||
                                        bic == BuiltInCategory.OST_WeakDims)
                                        continue;
                                }

                                var bbox = elem.get_BoundingBox(view);
                                if (bbox != null && Math.Abs(bbox.Max.X - bbox.Min.X) > 1e-4 && Math.Abs(bbox.Max.Y - bbox.Min.Y) > 1e-4)
                                {
                                    if (totalBbox == null)
                                    {
                                        totalBbox = new BoundingBoxXYZ { Min = bbox.Min, Max = bbox.Max };
                                    }
                                    else
                                    {
                                        totalBbox.Min = new XYZ(Math.Min(totalBbox.Min.X, bbox.Min.X), Math.Min(totalBbox.Min.Y, bbox.Min.Y), Math.Min(totalBbox.Min.Z, bbox.Min.Z));
                                        totalBbox.Max = new XYZ(Math.Max(totalBbox.Max.X, bbox.Max.X), Math.Max(totalBbox.Max.Y, bbox.Max.Y), Math.Max(totalBbox.Max.Z, bbox.Max.Z));
                                    }
                                }
                            }

                            if (totalBbox != null)
                            {
                                double width = totalBbox.Max.X - totalBbox.Min.X;
                                double height = totalBbox.Max.Y - totalBbox.Min.Y;
                                double marginX = Math.Max(width * 0.08, 0.02);
                                double marginY = Math.Max(height * 0.08, 0.02);

                                var crop = view.CropBox;
                                crop.Min = new XYZ(totalBbox.Min.X - marginX, totalBbox.Min.Y - marginY, crop.Min.Z);
                                crop.Max = new XYZ(totalBbox.Max.X + marginX, totalBbox.Max.Y + marginY, crop.Max.Z);
                                view.CropBox = crop;
                                view.CropBoxActive = true;
                                view.CropBoxVisible = false;
                            }
                        }
                        catch { }
                    }

                    doc.Regenerate();
                    tx.Commit();
                }
            }
            catch { }
        }

        /// <summary>
        /// Ajusta y encuadra la imagen generada eliminando el exceso de espacio en blanco periférico (Auto-Crop / Zoom to Extents)
        /// y reescalando el contenido centrado sobre un lienzo cuadrado de 512x512 px con un margen limpio del 8%.
        /// </summary>
        public static void OptimizeImageFraming(string imagePath, int targetSize = 512, double paddingFactor = 0.08)
        {
            if (string.IsNullOrWhiteSpace(imagePath) || !File.Exists(imagePath)) return;

            try
            {
                using (var original = new System.Drawing.Bitmap(imagePath))
                {
                    int width = original.Width;
                    int height = original.Height;
                    if (width <= 10 || height <= 10) return;

                    int minX = width;
                    int minY = height;
                    int maxX = 0;
                    int maxY = 0;
                    bool foundContent = false;

                    // Escanear píxeles para encontrar el área de contenido (píxeles no blancos y no transparentes)
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            var pixel = original.GetPixel(x, y);
                            // Ignorar fondo blanco / casi blanco y transparente
                            if (pixel.A > 20 && (pixel.R < 245 || pixel.G < 245 || pixel.B < 245))
                            {
                                // Comprobar si el pixel no es una línea de referencia verde pura o cian puro de fondo
                                bool isRefLineColor = (pixel.G > 200 && pixel.R < 100 && pixel.B < 100) ||
                                                      (pixel.B > 200 && pixel.G > 200 && pixel.R < 100);
                                if (!isRefLineColor)
                                {
                                    if (x < minX) minX = x;
                                    if (x > maxX) maxX = x;
                                    if (y < minY) minY = y;
                                    if (y > maxY) maxY = y;
                                    foundContent = true;
                                }
                            }
                        }
                    }

                    if (!foundContent) return;

                    int contentWidth = (maxX - minX) + 1;
                    int contentHeight = (maxY - minY) + 1;

                    if (contentWidth <= 2 || contentHeight <= 2) return;

                    // Si el contenido ya ocupa casi todo el lienzo (>= 88%), no requiere re-encuadre
                    if (contentWidth >= width * 0.88 && contentHeight >= height * 0.88) return;

                    using (var cropped = new System.Drawing.Bitmap(contentWidth, contentHeight))
                    {
                        using (var gCrop = System.Drawing.Graphics.FromImage(cropped))
                        {
                            gCrop.DrawImage(original, new System.Drawing.Rectangle(0, 0, contentWidth, contentHeight),
                                new System.Drawing.Rectangle(minX, minY, contentWidth, contentHeight),
                                System.Drawing.GraphicsUnit.Pixel);
                        }

                        using (var final = new System.Drawing.Bitmap(targetSize, targetSize))
                        {
                            using (var gFinal = System.Drawing.Graphics.FromImage(final))
                            {
                                gFinal.Clear(System.Drawing.Color.White);
                                gFinal.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                gFinal.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                gFinal.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                                int padding = (int)(targetSize * paddingFactor);
                                int availSize = targetSize - (padding * 2);

                                double scale = Math.Min((double)availSize / contentWidth, (double)availSize / contentHeight);
                                int destWidth = Math.Max(1, (int)(contentWidth * scale));
                                int destHeight = Math.Max(1, (int)(contentHeight * scale));

                                int destX = padding + (availSize - destWidth) / 2;
                                int destY = padding + (availSize - destHeight) / 2;

                                gFinal.DrawImage(cropped, new System.Drawing.Rectangle(destX, destY, destWidth, destHeight));
                            }

                            string tempSave = imagePath + ".tmp.png";
                            final.Save(tempSave, System.Drawing.Imaging.ImageFormat.Png);
                            File.Copy(tempSave, imagePath, true);
                            try { File.Delete(tempSave); } catch { }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogWarning($"[OptimizeImageFraming] Excepción al auto-encuadrar '{imagePath}': {ex.Message}");
            }
        }
    }
}
