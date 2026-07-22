using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services;

public class TransferOrchestrator
{
    public static void TransferElements(
        Document sourceDoc,
        Document targetDoc,
        List<Elemento> elementsToCopy,
        Configuraciones config,
        Action<string, int, int>? progressCallback = null,
        Dictionary<ElementId, string>? customNames = null,
        Dictionary<string, string>? levelMappings = null)
    {
        var elementsCopyList = new List<ElementId>();
        var familiesLoadList = new List<Elemento>();
        var worksetsToCreate = new List<Elemento>();
        var objectStylesToTransfer = new List<Elemento>();
        var duplicateItems = new List<TransferPlus.Models.DuplicateElementInfo>();

        var sheetsToTransfer = new List<Elemento>();

        foreach (var item in elementsToCopy)
        {
            if (item.IsWorkset)
            {
                worksetsToCreate.Add(item);
            }
            else if (item.IsLoadable)
            {
                familiesLoadList.Add(item);
            }
            else if (item.IsObjectStyle)
            {
                objectStylesToTransfer.Add(item);
            }
            else
            {
                Element elem = sourceDoc.GetElement(item.eID);
                if (elem is Phase || (elem != null && elem.Category != null && elem.Category.Id.Value == (long)BuiltInCategory.OST_Phases))
                {
                    LoggerService.LogWarning($"Transfer: Element '{item.Nombre}' (Category: Fases, Id: {item.eID.Value}) is a Project Phase. Revit API restricts direct Phase copying between documents. Skipping.");
                    continue;
                }
                if (elem is ViewSheet)
                {
                    sheetsToTransfer.Add(item);
                    LoggerService.LogInfo($"Transfer: Sheet '{item.Nombre}' (Id: {item.eID.Value}) queued for programmatic sheet creation.");
                }
                else if (elem is View v)
                {
                    bool isCopyableViaDocumentCopy = v.IsTemplate ||
                                                     v.ViewType == ViewType.DraftingView ||
                                                     v.ViewType == ViewType.Legend ||
                                                     v.ViewType == ViewType.ThreeD ||
                                                     v.ViewType == ViewType.Section ||
                                                     v.ViewType == ViewType.Elevation ||
                                                     (v is ViewSchedule vs && !vs.IsTitleblockRevisionSchedule);

                    if (!isCopyableViaDocumentCopy)
                    {
                        LoggerService.LogInfo($"Transfer: Model view '{v.Name}' (type {v.ViewType}, Id: {v.Id.Value}) excluded from direct CopyElements. Handled separately in plan/sheet processing.");
                    }
                    else
                    {
                        elementsCopyList.Add(item.eID);
                        string viewKind = v.IsTemplate ? "ViewTemplate" : v.ViewType.ToString();
                        LoggerService.LogInfo($"Transfer: {viewKind} '{elem.Name}' [Id: {elem.Id.Value}] queued for document CopyElements.");
                    }
                }
                else if (elem != null)
                {
                    elementsCopyList.Add(item.eID);
                    LoggerService.LogInfo($"Transfer: Standards Element '{elem.Name}' [Category: {elem.Category?.Name ?? "None"}, Class: {elem.GetType().Name}, Id: {elem.Id.Value}] queued for document CopyElements.");
                }
            }
        }

        int totalCount = worksetsToCreate.Count + familiesLoadList.Count + elementsCopyList.Count + objectStylesToTransfer.Count + sheetsToTransfer.Count;
        int currentCount = 0;

        void Report(string msg)
        {
            currentCount++;
            progressCallback?.Invoke(msg, currentCount, totalCount);
        }

        // 1. Process Worksets
        if (targetDoc.IsWorkshared && worksetsToCreate.Any())
        {
            using (Transaction t = new Transaction(targetDoc, "TransferPlus: Worksets"))
            {
                t.Start();
                if (config.cf_chk_AcceptAll)
                {
                    WarningSwallower.AttachToTransaction(t);
                }
                foreach (var wsItem in worksetsToCreate)
                {
                    string wsName = customNames?.ContainsKey(wsItem.eID) == true ? customNames[wsItem.eID] : wsItem.Nombre;
                    bool exists = !WorksetTable.IsWorksetNameUnique(targetDoc, wsName);
                    if (exists)
                    {
                        if (config.cf_rbAbortTransaction)
                        {
                            duplicateItems.Add(new TransferPlus.Models.DuplicateElementInfo("Worksets", "Workset", "Workset", wsName));
                            t.RollBack();
                            var cancelEx = new OperationCanceledException("Transfer canceled: Duplicate element names found.");
                            cancelEx.Data["Duplicates"] = duplicateItems;
                            throw cancelEx;
                        }
                        else if (config.cf_rbAppendSuffix)
                        {
                            wsName += config.cf_suffixText;
                        }
                        else // Keep Original
                        {
                            continue;
                        }
                    }

                    Report($"Creating Workset: {wsName}");
                    try
                    {
                        if (WorksetTable.IsWorksetNameUnique(targetDoc, wsName))
                        {
                            Workset.Create(targetDoc, wsName);
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerService.LogExceptionSilently("Creating Workset", ex);
                    }
                }
                t.Commit();
            }
        }

        // 2. Process Loadable Families
        if (familiesLoadList.Any())
        {
            var familyLoadOptions = new FamilyLoadOptionsOk();
            foreach (var famItem in familiesLoadList)
            {
                Report($"Loading Family: {famItem.Nombre}");
                try
                {
                    if (sourceDoc.GetElement(famItem.eID) is Family family)
                    {
                        string famName = customNames?.ContainsKey(famItem.eID) == true ? customNames[famItem.eID] : family.Name;
                        bool hasDuplicate = new FilteredElementCollector(targetDoc)
                            .OfClass(typeof(Family))
                            .Any(f => f.Name.Equals(famName, StringComparison.OrdinalIgnoreCase));

                        if (hasDuplicate)
                        {
                            if (config.cf_rbAbortTransaction)
                            {
                                duplicateItems.Add(new TransferPlus.Models.DuplicateElementInfo(famItem.Categoria ?? "Families", famItem.Familia ?? "Loadable Family", "Family", famName));
                                var cancelEx = new OperationCanceledException("Transfer canceled: Duplicate element names found.");
                                cancelEx.Data["Duplicates"] = duplicateItems;
                                throw cancelEx;
                            }
                            else if (config.cf_rbAppendSuffix)
                            {
                                famName += config.cf_suffixText;
                            }
                            else // Keep Original
                            {
                                continue;
                            }
                        }

                        Document famDoc = sourceDoc.EditFamily(family);
                        string tempDir = Path.Combine(Path.GetTempPath(), "TransferPlusTMP");
                        if (!Directory.Exists(tempDir)) Directory.CreateDirectory(tempDir);

                        string tempPath = Path.Combine(tempDir, famName + ".rfa");
                        if (File.Exists(tempPath)) File.Delete(tempPath);

                        famDoc.SaveAs(tempPath);
                        famDoc.Close(false);

                        targetDoc.LoadFamily(tempPath, familyLoadOptions, out Family loadedFam);
                        if (loadedFam != null && customNames?.ContainsKey(famItem.eID) == true)
                        {
                            try { loadedFam.Name = customNames[famItem.eID]; } catch { }
                        }
                        if (File.Exists(tempPath)) File.Delete(tempPath);
                    }
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
                catch { }
            }
        }

        // 2.5. Process Object Styles
        if (objectStylesToTransfer.Any())
        {
            using (Transaction t = new Transaction(targetDoc, "TransferPlus: Object Styles"))
            {
                t.Start();
                if (config.cf_chk_AcceptAll)
                {
                    WarningSwallower.AttachToTransaction(t);
                }
                foreach (var styleItem in objectStylesToTransfer)
                {
                    Report($"Transferring Object Style: {styleItem.Nombre}");
                    try
                    {
                        Category sourceCat = Category.GetCategory(sourceDoc, styleItem.eID);
                        if (sourceCat == null) continue;

                        Category targetCat = Category.GetCategory(targetDoc, styleItem.eID);
                        if (targetCat == null && sourceCat.Parent != null)
                        {
                            Category destParent = Category.GetCategory(targetDoc, sourceCat.Parent.Id);
                            if (destParent != null)
                            {
                                string catName = customNames?.ContainsKey(styleItem.eID) == true ? customNames[styleItem.eID] : sourceCat.Name;
                                bool exists = destParent.SubCategories.Contains(catName);
                                if (exists)
                                {
                                    if (config.cf_rbAbortTransaction)
                                    {
                                        duplicateItems.Add(new TransferPlus.Models.DuplicateElementInfo(styleItem.Categoria ?? "Object Styles", styleItem.Familia ?? "Category", "GraphicsStyle", catName));
                                        t.RollBack();
                                        var cancelEx = new OperationCanceledException("Transfer canceled: Duplicate element names found.");
                                        cancelEx.Data["Duplicates"] = duplicateItems;
                                        throw cancelEx;
                                    }
                                    else if (config.cf_rbAppendSuffix)
                                    {
                                        catName += config.cf_suffixText;
                                    }
                                    else // Keep Original: use existing target category style
                                    {
                                        continue;
                                    }
                                }

                                if (targetCat == null)
                                {
                                    targetCat = targetDoc.Settings.Categories.NewSubcategory(destParent, catName);
                                }
                            }
                        }

                        if (targetCat != null)
                        {
                            TransferSingleCategoryStyle(sourceDoc, targetDoc, sourceCat, targetCat);
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        throw;
                    }
                    catch { }
                }
                t.Commit();
            }
        }

        // 2.8. Process Level Mapping and Creation
        var temporaryRenamedLevels = new List<(Level level, string originalName)>();
        if (levelMappings != null)
        {
            // 2.8.1 Create missing levels
            using (Transaction tLevels = new Transaction(targetDoc, "TransferPlus: Create Missing Levels"))
            {
                tLevels.Start();
                if (config.cf_chk_AcceptAll) WarningSwallower.AttachToTransaction(tLevels);
                foreach (var mapping in levelMappings)
                {
                    string srcLevelName = mapping.Key;
                    string targetAction = mapping.Value;
                    if (targetAction == "CREATE_NEW")
                    {
                        var srcLevel = new FilteredElementCollector(sourceDoc)
                            .OfClass(typeof(Level))
                            .Cast<Level>()
                            .FirstOrDefault(l => l.Name.Equals(srcLevelName, StringComparison.OrdinalIgnoreCase));
                        if (srcLevel != null)
                        {
                            try
                            {
                                var newLevel = Level.Create(targetDoc, srcLevel.ProjectElevation);
                                newLevel.Name = srcLevelName;
                            }
                            catch { }
                        }
                    }
                }
                tLevels.Commit();
            }

            // 2.8.2 Temporarily rename mapped levels
            using (Transaction tRename = new Transaction(targetDoc, "TransferPlus: Prep Mapped Levels"))
            {
                tRename.Start();
                if (config.cf_chk_AcceptAll) WarningSwallower.AttachToTransaction(tRename);
                foreach (var mapping in levelMappings)
                {
                    string srcLevelName = mapping.Key;
                    string targetAction = mapping.Value;
                    if (targetAction != "CREATE_NEW")
                    {
                        var targetLevel = new FilteredElementCollector(targetDoc)
                            .OfClass(typeof(Level))
                            .Cast<Level>()
                            .FirstOrDefault(l => l.Name.Equals(targetAction, StringComparison.OrdinalIgnoreCase));
                        if (targetLevel != null)
                        {
                            try
                            {
                                temporaryRenamedLevels.Add((targetLevel, targetAction));
                                targetLevel.Name = srcLevelName;
                            }
                            catch { }
                        }
                    }
                }
                tRename.Commit();
            }
        }

        // 3. Process Standards and View elements (CopyElements)
        if (elementsCopyList.Any())
        {
            using (Transaction t = new Transaction(targetDoc, "TransferPlus: Standards"))
            {
                t.Start();
                if (config.cf_chk_AcceptAll)
                {
                    WarningSwallower.AttachToTransaction(t);
                }

                CustomCopyHandlerAbort abortHandler = new CustomCopyHandlerAbort();
                CopyPasteOptions options = new CopyPasteOptions();
                if (config.cf_rbAbortTransaction)
                {
                    options.SetDuplicateTypeNamesHandler(abortHandler);
                }
                else
                {
                    options.SetDuplicateTypeNamesHandler(new CustomCopyHandlerOk());
                }

                Transform? transform = null;
                if (config.cf_chk_GetTransformLink)
                {
                    var linkInstances = new FilteredElementCollector(targetDoc)
                        .OfClass(typeof(RevitLinkInstance))
                        .Cast<RevitLinkInstance>()
                        .Where(i => i.GetLinkDocument()?.Title?.Equals(sourceDoc.Title) == true)
                        .ToList();

                    if (linkInstances.Any())
                    {
                        transform = linkInstances.First().GetTotalTransform();
                    }
                }
                else if (config.cf_chk_GetTransformShared)
                {
                    Transform sourceTransform = sourceDoc.ActiveProjectLocation.GetTotalTransform();
                    transform = targetDoc.ActiveProjectLocation.GetTotalTransform().Multiply(sourceTransform.Inverse);
                }

                var finalCopyList = new List<ElementId>();
                bool hasDuplicates = false;
                foreach (var id in elementsCopyList)
                {
                    Element elem = sourceDoc.GetElement(id);
                    if (elem != null)
                    {
                        string evalName = customNames?.ContainsKey(id) == true ? customNames[id] : elem.Name;
                        if (TargetHasDuplicateName(targetDoc, elem, evalName))
                        {
                            hasDuplicates = true;
                            if (config.cf_rbAbortTransaction)
                            {
                                var matchingItem = elementsToCopy.FirstOrDefault(x => x.eID == id);
                                string cat = matchingItem?.Categoria ?? elem.Category?.Name ?? "General";
                                string fam = matchingItem?.Familia ?? "Standard";
                                string cls = elem.GetType().Name;
                                duplicateItems.Add(new TransferPlus.Models.DuplicateElementInfo(cat, fam, cls, evalName));
                            }
                            else if (config.cf_rbKeepOriginal)
                            {
                                LoggerService.LogInfo($"DuplicateCheck: Element '{evalName}' (Id: {id.Value}) already exists in target. Option 'Keep Original' selected. Skipping transfer for this element.");
                                continue;
                            }
                        }
                        finalCopyList.Add(id);
                    }
                }

                if (config.cf_rbAbortTransaction && duplicateItems.Any())
                {
                    t.RollBack();
                    var cancelEx = new OperationCanceledException("Transfer canceled: Duplicate element names found.");
                    cancelEx.Data["Duplicates"] = duplicateItems;
                    throw cancelEx;
                }

                Document tempDoc = null;
                try
                {
                    ICollection<ElementId> copied = new List<ElementId>();
                    if (finalCopyList.Any())
                    {
                        if (config.cf_rbAppendSuffix && hasDuplicates)
                        {
                            Report("Preparing temporary document for renaming duplicates...");
                            LoggerService.LogInfo("TempDoc: Creating temporary project document for suffix renaming...");
                            UnitSystem unitSys = targetDoc.DisplayUnitSystem == DisplayUnit.IMPERIAL ? UnitSystem.Imperial : UnitSystem.Metric;
                            tempDoc = targetDoc.Application.NewProjectDocument(unitSys);
                            LoggerService.LogInfo($"TempDoc: Temporary document '{tempDoc.Title}' created successfully.");

                            ICollection<ElementId> tempCopied;
                            using (Transaction tTemp = new Transaction(tempDoc, "Temp Copy"))
                            {
                                tTemp.Start();
                                tempCopied = ElementTransformUtils.CopyElements(sourceDoc, finalCopyList, tempDoc, null, new CopyPasteOptions());
                                LoggerService.LogInfo($"TempDoc: Copied {tempCopied.Count} elements to temporary document.");

                                var tempCopiedList = tempCopied.ToList();
                                for (int i = 0; i < finalCopyList.Count; i++)
                                {
                                    ElementId originalId = finalCopyList[i];
                                    ElementId tempId = tempCopiedList.ElementAtOrDefault(i);
                                    if (tempId == null || tempId == ElementId.InvalidElementId) continue;

                                    Element srcElem = sourceDoc.GetElement(originalId);
                                    if (srcElem != null)
                                    {
                                        string evalName = customNames?.ContainsKey(originalId) == true ? customNames[originalId] : srcElem.Name;
                                        Element tempElem = tempDoc.GetElement(tempId);
                                        if (tempElem != null)
                                        {
                                            if (TargetHasDuplicateName(targetDoc, srcElem, evalName))
                                            {
                                                string newName = evalName + config.cf_suffixText;
                                                try 
                                                { 
                                                    tempElem.Name = newName; 
                                                    LoggerService.LogInfo($"TempDoc: Renamed duplicate element '{evalName}' -> '{newName}'.");
                                                    
                                                    if (tempElem is ViewSheet tempSheet)
                                                    {
                                                        try
                                                        {
                                                            tempSheet.SheetNumber = tempSheet.SheetNumber + config.cf_suffixText;
                                                            LoggerService.LogInfo($"TempDoc: Renamed duplicate SheetNumber to '{tempSheet.SheetNumber}'.");
                                                        }
                                                        catch (Exception exSheetNum)
                                                        {
                                                            LoggerService.LogWarning($"TempDoc: Could not rename SheetNumber for '{evalName}': {exSheetNum.Message}");
                                                        }
                                                    }
                                                } 
                                                catch (Exception exRename)
                                                {
                                                    LoggerService.LogWarning($"TempDoc: Could not rename element '{evalName}': {exRename.Message}");
                                                }
                                            }
                                            else if (customNames?.ContainsKey(originalId) == true)
                                            {
                                                try { tempElem.Name = evalName; } catch { }
                                            }
                                        }
                                    }

                                }
                                tTemp.Commit();
                            }

                            Report("Copying Standards Elements (with suffixes)");
                            LoggerService.LogInfo($"TempDoc: Transferring {tempCopied.Count} renamed elements from temporary document to target document...");
                            copied = ElementTransformUtils.CopyElements(tempDoc, tempCopied.ToList(), targetDoc, transform, options);
                            LoggerService.LogInfo($"TempDoc: Successfully transferred {copied.Count} elements into target document.");
                        }
                        else
                        {
                            Report("Copying Standards Elements");
                            LoggerService.LogInfo($"Transfer: Copying {finalCopyList.Count} elements directly from source to target document...");
                            copied = ElementTransformUtils.CopyElements(sourceDoc, finalCopyList, targetDoc, transform, options);
                            LoggerService.LogInfo($"Transfer: Successfully copied {copied.Count} elements into target document.");
                        }

                        if (copied.Any())
                        {
                            targetDoc.Regenerate();
                            LoggerService.LogInfo("Transfer: Regenerated target document after main copy.");
                        }
                    }

                    // If copy includes views, match templates, copy detail items and callouts recursively
                    for (int i = 0; i < finalCopyList.Count; i++)
                    {
                        ElementId originalId = finalCopyList[i];
                        ElementId newId = copied.ElementAtOrDefault(i);
                        if (newId == null || newId == ElementId.InvalidElementId)
                        {
                            LoggerService.LogWarning($"Transfer: Element Id '{originalId.Value}' was in finalCopyList but resulted in InvalidElementId/null in target document. Skipping subsequent processing for this element.");
                            continue;
                        }

                        Element srcElem = sourceDoc.GetElement(originalId);
                        Element destElem = targetDoc.GetElement(newId);

                        if (srcElem is View sourceView && destElem is View targetView)
                        {
                            matchPlantilla(sourceDoc, targetDoc, sourceView, targetView, options, config, duplicateItems);
                            
                            if (config.cf_chk_Callout)
                            {
                                ponCallouts(sourceDoc, targetDoc, sourceView, targetView, options, config.cf_chk_ViewElements, 1, transform != null, transform);
                            }
                            else if (config.cf_chk_ViewElements)
                            {
                                ponDependientes(sourceDoc, sourceView.GetDependentElements(null), sourceView, targetView, options);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LoggerService.LogError("Transfer Elements", ex);
                    try
                    {
                        t.RollBack();
                    }
                    catch { }

                    if (config.cf_rbAbortTransaction && abortHandler.Triggered)
                    {
                        var cancelEx = new OperationCanceledException("Transfer canceled: Duplicate element names found.", ex);
                        cancelEx.Data["Duplicates"] = duplicateItems;
                        throw cancelEx;
                    }
                    throw;
                }
                finally
                {
                    if (tempDoc != null)
                    {
                        try 
                        { 
                            tempDoc.Close(false); 
                            LoggerService.LogInfo("TempDoc: Closed temporary document cleanly.");
                        } 
                        catch (Exception exCloseTemp)
                        {
                            LoggerService.LogExceptionSilently("Closing TempDoc", exCloseTemp);
                        }
                    }

                    // Restore renamed levels
                    if (temporaryRenamedLevels.Any())
                    {
                        using (Transaction tRestore = new Transaction(targetDoc, "TransferPlus: Restore Mapped Levels"))
                        {
                            tRestore.Start();
                            if (config.cf_chk_AcceptAll) WarningSwallower.AttachToTransaction(tRestore);
                            foreach (var renamed in temporaryRenamedLevels)
                            {
                                try
                                {
                                    renamed.level.Name = renamed.originalName;
                                }
                                catch { }
                            }
                            tRestore.Commit();
                        }
                    }
                }

                if (t.GetStatus() == TransactionStatus.Started)
                {
                    t.Commit();
                }
            }
        }

        // 4. Process Sheets programmatically (sheetsToTransfer)
        if (sheetsToTransfer.Any())
        {
            LoggerService.LogInfo($"Transfer: Processing {sheetsToTransfer.Count} sheets programmatically...");
            using (Transaction tSheets = new Transaction(targetDoc, "TransferPlus: Sheets"))
            {
                tSheets.Start();
                if (config.cf_chk_AcceptAll)
                {
                    WarningSwallower.AttachToTransaction(tSheets);
                }

                CustomCopyHandlerAbort abortHandler = new CustomCopyHandlerAbort();
                CopyPasteOptions options = new CopyPasteOptions();
                if (config.cf_rbAbortTransaction)
                {
                    options.SetDuplicateTypeNamesHandler(abortHandler);
                }
                else
                {
                    options.SetDuplicateTypeNamesHandler(new CustomCopyHandlerOk());
                }

                Transform? transform = null;
                if (config.cf_chk_GetTransformLink)
                {
                    var linkInstances = new FilteredElementCollector(targetDoc)
                        .OfClass(typeof(RevitLinkInstance))
                        .Cast<RevitLinkInstance>()
                        .Where(i => i.GetLinkDocument()?.Title?.Equals(sourceDoc.Title) == true)
                        .ToList();

                    if (linkInstances.Any())
                    {
                        transform = linkInstances.First().GetTotalTransform();
                    }
                }
                else if (config.cf_chk_GetTransformShared)
                {
                    Transform sourceTransform = sourceDoc.ActiveProjectLocation.GetTotalTransform();
                    transform = targetDoc.ActiveProjectLocation.GetTotalTransform().Multiply(sourceTransform.Inverse);
                }

                foreach (var item in sheetsToTransfer)
                {
                    ViewSheet sourceSheet = sourceDoc.GetElement(item.eID) as ViewSheet;
                    if (sourceSheet == null) continue;

                    Report($"Transferring Sheet: {sourceSheet.SheetNumber} - {sourceSheet.Name}");
                    LoggerService.LogInfo($"SheetTransfer: Initiating transfer for Sheet '{sourceSheet.SheetNumber} - {sourceSheet.Name}' (Id: {sourceSheet.Id.Value})...");

                    ViewSheet targetSheet = CreateViewSheet(sourceDoc, targetDoc, sourceSheet, config);
                    if (targetSheet == null)
                    {
                        LoggerService.LogWarning($"SheetTransfer: Failed to create target sheet for '{sourceSheet.SheetNumber}'.");
                        continue;
                    }

                    try
                    {
                        var allSheetElements = new FilteredElementCollector(sourceDoc, sourceSheet.Id)
                            .WhereElementIsNotElementType()
                            .Where(e => e is not Viewport && 
                                        e is not View && 
                                        e is not ScheduleSheetInstance && 
                                        e.GetType().Name != "PanelScheduleSheetInstance" && 
                                        e is not SunAndShadowSettings && 
                                        e is not Level && 
                                        e is not SketchPlane)
                            .ToList();

                        var titleBlockIds = allSheetElements
                            .Where(e => e.Category != null && e.Category.Id.Value == (long)BuiltInCategory.OST_TitleBlocks)
                            .Select(e => e.Id)
                            .ToList();

                        var detailElementIds = allSheetElements
                            .Where(e => e.Category == null || e.Category.Id.Value != (long)BuiltInCategory.OST_TitleBlocks)
                            .Select(e => e.Id)
                            .ToList();

                        var sheetElementsToCopy = new List<ElementId>();
                        sheetElementsToCopy.AddRange(titleBlockIds);
                        LoggerService.LogInfo($"SheetTransfer: Found {titleBlockIds.Count} TitleBlocks on source sheet '{sourceSheet.SheetNumber}'.");

                        if (config.cf_chk_ViewElements && detailElementIds.Any())
                        {
                            sheetElementsToCopy.AddRange(detailElementIds);
                            LoggerService.LogInfo($"SheetTransfer: 'Transfer View Elements' is enabled. Including {detailElementIds.Count} 2D detail/annotation elements from sheet '{sourceSheet.SheetNumber}'.");
                        }

                        if (sheetElementsToCopy.Any())
                        {
                            var typeIdsToCopy = new List<ElementId>();
                            foreach (ElementId elId in sheetElementsToCopy)
                            {
                                Element el = sourceDoc.GetElement(elId);
                                if (el != null)
                                {
                                    ElementId typeId = el.GetTypeId();
                                    if (typeId != ElementId.InvalidElementId)
                                    {
                                        typeIdsToCopy.Add(typeId);
                                    }
                                }
                            }

                            if (typeIdsToCopy.Any())
                            {
                                var distinctTypes = typeIdsToCopy.Distinct().ToList();
                                try
                                {
                                    ElementTransformUtils.CopyElements(sourceDoc, distinctTypes, targetDoc, null, options);
                                    targetDoc.Regenerate();
                                }
                                catch { }
                            }

                            ElementTransformUtils.CopyElements(sourceSheet, sheetElementsToCopy, targetSheet, Transform.Identity, options);
                            LoggerService.LogInfo($"SheetTransfer: Successfully copied {sheetElementsToCopy.Count} TitleBlock/2D elements to target sheet '{targetSheet.SheetNumber}'.");
                        }
                    }
                    catch (Exception exSheetElements)
                    {
                        LoggerService.LogError($"SheetTransfer: Failed copying TitleBlock/2D elements for sheet '{sourceSheet.SheetNumber}'", exSheetElements);
                    }

                    if (config.cf_chk_SheetWithViews)
                    {
                        try
                        {
                            targetDoc.Regenerate();
                            LoggerService.LogInfo("SheetTransfer: Regenerated target document to update geometry before placing viewports.");
                        }
                        catch (Exception exRegen)
                        {
                            LoggerService.LogWarning($"SheetTransfer: Notice during document regeneration: {exRegen.Message}");
                        }

                        LoggerService.LogInfo($"SheetTransfer: Replicating placed views and viewports/schedules for Sheet '{sourceSheet.SheetNumber}'...");
                        var placedViewIds = sourceSheet.GetAllPlacedViews().ToList();

                        // Query for ScheduleSheetInstances to retrieve the IDs of placed schedules (ViewSchedule)
                        var scheduleInstances = new FilteredElementCollector(sourceDoc, sourceSheet.Id)
                            .OfClass(typeof(ScheduleSheetInstance))
                            .Cast<ScheduleSheetInstance>();

                        foreach (var inst in scheduleInstances)
                        {
                            if (inst.ScheduleId != ElementId.InvalidElementId)
                            {
                                if (sourceDoc.GetElement(inst.ScheduleId) is ViewSchedule vs && !vs.IsTitleblockRevisionSchedule)
                                {
                                    if (!placedViewIds.Contains(inst.ScheduleId))
                                    {
                                        placedViewIds.Add(inst.ScheduleId);
                                    }
                                }
                            }
                        }

                        foreach (ElementId placedViewId in placedViewIds)
                        {
                            try
                            {
                                View srcPlacedView = sourceDoc.GetElement(placedViewId) as View;
                                if (srcPlacedView == null) continue;

                                ElementId targetViewId = ElementId.InvalidElementId;
                                bool shouldCopyView = false;
                                bool viewWasNewlyCreated = false;

                                bool isLegend = srcPlacedView.ViewType == ViewType.Legend;
                                bool isSchedule = srcPlacedView.ViewType == ViewType.Schedule;
                                bool isAssembly = srcPlacedView.IsAssemblyView;

                                bool isTitleblockRevisionSchedule = false;
                                if (srcPlacedView is ViewSchedule vs)
                                {
                                    isTitleblockRevisionSchedule = vs.IsTitleblockRevisionSchedule;
                                }
                        bool isCopyable = srcPlacedView.ViewType == ViewType.DraftingView ||
                                                  isLegend ||
                                                  (isSchedule && !isTitleblockRevisionSchedule);

                                if (isCopyable)
                                {
                                    shouldCopyView = true;
                                    var existingTargetView = new FilteredElementCollector(targetDoc)
                                        .OfClass(typeof(View))
                                        .Cast<View>()
                                        .FirstOrDefault(v => v.ViewType == srcPlacedView.ViewType && v.Name.Equals(srcPlacedView.Name, StringComparison.OrdinalIgnoreCase));

                                    if (existingTargetView != null)
                                    {
                                        bool useExistingSetting = (isLegend && config.cf_chk_UseLegendIfExists) ||
                                                                  (isSchedule && config.cf_chk_UseScheduleIfExists) ||
                                                                  (isAssembly && config.cf_chk_UseAssemblyViewsIfExists);

                                        if (useExistingSetting)
                                        {
                                            shouldCopyView = false;
                                            targetViewId = existingTargetView.Id;
                                            LoggerService.LogInfo($"SheetTransfer: Option 'Use if exists in Target' active for '{srcPlacedView.Name}' ({srcPlacedView.ViewType}). Re-using existing target view.");
                                        }
                                        else
                                        {
                                            shouldCopyView = false;
                                            if (config.cf_rbKeepOriginal)
                                            {
                                                targetViewId = existingTargetView.Id;
                                                LoggerService.LogInfo($"SheetTransfer: Duplicate view '{srcPlacedView.Name}' already exists. Re-using target view.");
                                            }
                                            else if (config.cf_rbAbortTransaction)
                                            {
                                                duplicateItems.Add(new TransferPlus.Models.DuplicateElementInfo("Views & Sheets", srcPlacedView.ViewType.ToString(), srcPlacedView.GetType().Name, srcPlacedView.Name));
                                                var cancelEx = new OperationCanceledException("Transfer canceled: Duplicate element names found.");
                                                cancelEx.Data["Duplicates"] = duplicateItems;
                                                throw cancelEx;
                                            }
                                            else if (config.cf_rbAppendSuffix)
                                            {
                                                shouldCopyView = true;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    shouldCopyView = false;
                                    var existingTargetView = new FilteredElementCollector(targetDoc)
                                        .OfClass(typeof(View))
                                        .Cast<View>()
                                        .FirstOrDefault(v => v.ViewType == srcPlacedView.ViewType && v.Name.Equals(srcPlacedView.Name, StringComparison.OrdinalIgnoreCase));

                                    if (existingTargetView != null)
                                    {
                                        if (config.cf_rbAbortTransaction)
                                        {
                                            duplicateItems.Add(new TransferPlus.Models.DuplicateElementInfo("Views & Sheets", srcPlacedView.ViewType.ToString(), srcPlacedView.GetType().Name, srcPlacedView.Name));
                                            var cancelEx = new OperationCanceledException("Transfer canceled: Duplicate element names found.");
                                            cancelEx.Data["Duplicates"] = duplicateItems;
                                            throw cancelEx;
                                        }
                                        else if (config.cf_rbAppendSuffix)
                                        {
                                            if (srcPlacedView is ViewPlan srcViewPlanSuffix)
                                            {
                                                LoggerService.LogInfo($"SheetTransfer: Duplicate view '{srcPlacedView.Name}' exists in target. Option 'Append Suffix' active. Creating new ViewPlan with suffix...");
                                                ViewPlan newPlan = CreateViewPlan(sourceDoc, targetDoc, srcViewPlanSuffix, levelMappings, config.cf_chk_ForceLevelInLevelBaseViews);
                                                if (newPlan != null)
                                                {
                                                    try { newPlan.Name = srcPlacedView.Name + config.cf_suffixText; }
                                                    catch { newPlan.Name = GetUniqueViewName(targetDoc, srcPlacedView.Name + config.cf_suffixText, srcPlacedView.ViewType); }
                                                    targetViewId = newPlan.Id;
                                                    viewWasNewlyCreated = true;
                                                }
                                            }
                                            else
                                            {
                                                shouldCopyView = true;
                                                LoggerService.LogInfo($"SheetTransfer: Duplicate non-plan view '{srcPlacedView.Name}' exists. Option 'Append Suffix' active. Copying view...");
                                            }
                                        }
                                        else if (config.cf_rbKeepOriginal)
                                        {
                                            bool canAddExisting = Viewport.CanAddViewToSheet(targetDoc, targetSheet.Id, existingTargetView.Id);
                                            if (canAddExisting)
                                            {
                                                targetViewId = existingTargetView.Id;
                                                LoggerService.LogInfo($"SheetTransfer: Model view '{srcPlacedView.Name}' already exists in target document and is unplaced. Re-using target view for viewport.");
                                            }
                                            else
                                            {
                                                if (srcPlacedView is ViewPlan srcViewPlanKeep)
                                                {
                                                    LoggerService.LogInfo($"SheetTransfer: Model view '{srcPlacedView.Name}' exists in target but is ALREADY placed on another sheet. Creating new ViewPlan for target sheet...");
                                                    ViewPlan newPlan = CreateViewPlan(sourceDoc, targetDoc, srcViewPlanKeep, levelMappings, config.cf_chk_ForceLevelInLevelBaseViews);
                                                    if (newPlan != null)
                                                    {
                                                        targetViewId = newPlan.Id;
                                                        viewWasNewlyCreated = true;
                                                    }
                                                }
                                                else if (isLegend)
                                                {
                                                    targetViewId = existingTargetView.Id;
                                                    LoggerService.LogInfo($"SheetTransfer: Legend view '{srcPlacedView.Name}' is already placed but can be placed on multiple sheets. Re-using target legend.");
                                                }
                                                else
                                                {
                                                    shouldCopyView = true;
                                                    LoggerService.LogInfo($"SheetTransfer: View '{srcPlacedView.Name}' already exists and is placed on another sheet. Copying view...");
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (srcPlacedView is ViewPlan srcViewPlan)
                                        {
                                            LoggerService.LogInfo($"SheetTransfer: Model view '{srcPlacedView.Name}' is a level-based ViewPlan and does not exist in target. Creating a new ViewPlan...");
                                            ViewPlan newPlan = CreateViewPlan(sourceDoc, targetDoc, srcViewPlan, levelMappings, config.cf_chk_ForceLevelInLevelBaseViews);
                                            if (newPlan != null)
                                            {
                                                targetViewId = newPlan.Id;
                                                viewWasNewlyCreated = true;
                                            }
                                        }
                                        else
                                        {
                                            shouldCopyView = true;
                                            LoggerService.LogInfo($"SheetTransfer: Non-plan view '{srcPlacedView.Name}' does not exist in target document. Copying view...");
                                        }
                                    }

                                    if (targetViewId == ElementId.InvalidElementId && !shouldCopyView)
                                    {
                                        LoggerService.LogWarning($"SheetTransfer: View '{srcPlacedView.Name}' of type '{srcPlacedView.ViewType}' cannot be copied or created. Skipping viewport placement.");
                                    }
                                }

                                if (shouldCopyView)
                                {
                                    var copiedViewIds = ElementTransformUtils.CopyElements(sourceDoc, new List<ElementId> { placedViewId }, targetDoc, Transform.Identity, options);
                                    targetViewId = (copiedViewIds != null && copiedViewIds.Any()) ? copiedViewIds.FirstOrDefault() : ElementId.InvalidElementId;
                                    if (targetViewId != ElementId.InvalidElementId)
                                    {
                                        viewWasNewlyCreated = true;
                                    }
                                }

                                if (targetViewId != ElementId.InvalidElementId)
                                {
                                    View newPlacedView = targetDoc.GetElement(targetViewId) as View;
                                    if (newPlacedView != null && viewWasNewlyCreated)
                                    {
                                        if (config.cf_rbAppendSuffix)
                                        {
                                            var existingTargetView = new FilteredElementCollector(targetDoc)
                                                .OfClass(typeof(View))
                                                .Cast<View>()
                                                .FirstOrDefault(v => v.Id != targetViewId && v.ViewType == srcPlacedView.ViewType && v.Name.Equals(srcPlacedView.Name, StringComparison.OrdinalIgnoreCase));
                                            if (existingTargetView != null)
                                            {
                                                try { newPlacedView.Name = srcPlacedView.Name + config.cf_suffixText; } catch { }
                                            }
                                        }

                                        matchPlantilla(sourceDoc, targetDoc, srcPlacedView, newPlacedView, options, config, duplicateItems);

                                        // For sheet-placed views, we ALWAYS copy the dependent 2D elements (dimensions, tags, detail lines, text)
                                        ponDependientes(sourceDoc, srcPlacedView.GetDependentElements(null), srcPlacedView, newPlacedView, options);

                                        if (config.cf_chk_Callout && srcPlacedView.ViewType != ViewType.DraftingView)
                                        {
                                            ponCallouts(sourceDoc, targetDoc, srcPlacedView, newPlacedView, options, true, 3, transform != null, transform);
                                        }
                                    }

                                     if (srcPlacedView.ViewType != ViewType.Schedule)
                                     {
                                         LoggerService.LogInfo($"SheetTransfer: Evaluating Viewport placement for view '{srcPlacedView.Name}' (Target ViewId: {targetViewId.Value}) on sheet '{targetSheet.SheetNumber}'...");
                                         bool canAdd = Viewport.CanAddViewToSheet(targetDoc, targetSheet.Id, targetViewId);
                                         if (!canAdd)
                                         {
                                             LoggerService.LogWarning($"SheetTransfer: View '{srcPlacedView.Name}' (Target ViewId: {targetViewId.Value}) CANNOT be added to sheet '{targetSheet.SheetNumber}' (Viewport.CanAddViewToSheet returned false). Skipping viewport placement.");
                                         }
                                         else
                                         {
                                             var srcViewports = new FilteredElementCollector(sourceDoc, sourceSheet.Id)
                                                 .OfClass(typeof(Viewport))
                                                 .Cast<Viewport>()
                                                 .Where(vp => vp.ViewId == placedViewId)
                                                 .ToList();

                                             LoggerService.LogInfo($"SheetTransfer: Found {srcViewports.Count} matching viewports for view '{srcPlacedView.Name}' on source sheet '{sourceSheet.SheetNumber}'.");

                                             foreach (Viewport srcViewport in srcViewports)
                                             {
                                                 try
                                                 {
                                                     string name = srcViewport.Name;
                                                     XYZ center = null;
                                                     try
                                                     {
                                                         center = srcViewport.GetBoxCenter();
                                                     }
                                                     catch { }

                                                     if (center == null)
                                                     {
                                                         try
                                                         {
                                                             Outline boxOutline = srcViewport.GetBoxOutline();
                                                             if (boxOutline != null)
                                                             {
                                                                 center = (boxOutline.MaximumPoint + boxOutline.MinimumPoint) / 2.0;
                                                             }
                                                         }
                                                         catch { }
                                                     }

                                                     if (center == null)
                                                     {
                                                         center = new XYZ(1.5, 1.0, 0.0);
                                                     }

                                                     LoggerService.LogInfo($"SheetTransfer: Creating Viewport for '{srcPlacedView.Name}' at center point ({center.X:F2}, {center.Y:F2}, {center.Z:F2})...");

                                                      Viewport targetViewport = Viewport.Create(targetDoc, targetSheet.Id, targetViewId, center);
                                                      if (targetViewport != null)
                                                      {
                                                          foreach (ElementId typeId in targetViewport.GetValidTypes())
                                                          {
                                                              if ((targetDoc.GetElement(typeId) as ElementType)?.Name.Equals(name) == true)
                                                              {
                                                                  targetViewport.ChangeTypeId(typeId);
                                                              }
                                                          }
                                                          try
                                                          {
                                                              targetViewport.SetBoxCenter(center);
                                                              targetViewport.Rotation = srcViewport.Rotation;
                                                          }
                                                          catch (Exception exPos)
                                                          {
                                                              LoggerService.LogWarning($"SheetTransfer: Non-fatal notice when setting Viewport center/rotation for '{srcPlacedView.Name}': {exPos.Message}");
                                                          }
                                                          LoggerService.LogInfo($"SheetTransfer: Successfully placed Viewport for '{srcPlacedView.Name}' on target sheet '{targetSheet.SheetNumber}'.");
                                                      }
                                                      else
                                                      {
                                                          LoggerService.LogWarning($"SheetTransfer: Viewport.Create returned null for view '{srcPlacedView.Name}' on sheet '{targetSheet.SheetNumber}'.");
                                                      }
                                                 }
                                                 catch (Exception exVpCreate)
                                                 {
                                                     LoggerService.LogError($"SheetTransfer: Failed creating Viewport for '{srcPlacedView.Name}' on sheet '{targetSheet.SheetNumber}'", exVpCreate);
                                                 }
                                             }
                                         }
                                     }
                                    else
                                    {
                                        foreach (Element element3 in new FilteredElementCollector(sourceDoc, sourceSheet.Id).OfClass(typeof(ScheduleSheetInstance)))
                                        {
                                            ScheduleSheetInstance srcScheduleInstance = (ScheduleSheetInstance)element3;
                                            if (srcScheduleInstance.ScheduleId == placedViewId)
                                            {
                                                XYZ point = srcScheduleInstance.Point;
                                                try
                                                {
                                                    ScheduleSheetInstance.Create(targetDoc, targetSheet.Id, targetViewId, point);
                                                    LoggerService.LogInfo($"SheetTransfer: Placed Schedule '{srcPlacedView.Name}' on sheet '{targetSheet.SheetNumber}'.");
                                                }
                                                catch (Exception exSched)
                                                {
                                                    LoggerService.LogWarning($"SheetTransfer: Failed to place Schedule '{srcPlacedView.Name}' on sheet '{targetSheet.SheetNumber}': {exSched.Message}");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception exViewPlacement)
                            {
                                LoggerService.LogError($"SheetTransfer: Failed processing view '{placedViewId.Value}' on sheet '{sourceSheet.SheetNumber}'", exViewPlacement);
                            }
                        }
                    }
                }

                tSheets.Commit();
                LoggerService.LogInfo("SheetTransfer: Sheet transfer transaction committed successfully.");
            }
        }

        // 5. Create plan views that were directly selected
        var planViewsToTransfer = elementsToCopy.Where(item => !item.IsWorkset && !item.IsLoadable && !item.IsObjectStyle && sourceDoc.GetElement(item.eID) is ViewPlan).ToList();
        if (planViewsToTransfer.Any())
        {
            LoggerService.LogInfo($"Transfer: Processing {planViewsToTransfer.Count} selected plan views...");
            using (Transaction tPlans = new Transaction(targetDoc, "TransferPlus: Plan Views"))
            {
                tPlans.Start();
                if (config.cf_chk_AcceptAll) WarningSwallower.AttachToTransaction(tPlans);
                CopyPasteOptions options = new CopyPasteOptions();

                foreach (var item in planViewsToTransfer)
                {
                    ViewPlan srcViewPlan = sourceDoc.GetElement(item.eID) as ViewPlan;
                    if (srcViewPlan != null)
                    {
                        var existingTargetView = new FilteredElementCollector(targetDoc)
                            .OfClass(typeof(View))
                            .Cast<View>()
                            .FirstOrDefault(v => v.ViewType == srcViewPlan.ViewType && v.Name.Equals(srcViewPlan.Name, StringComparison.OrdinalIgnoreCase));

                        ViewPlan targetPlanToUse = null;

                        if (existingTargetView != null)
                        {
                            if (config.cf_rbAbortTransaction)
                            {
                                duplicateItems.Add(new TransferPlus.Models.DuplicateElementInfo("Views", srcViewPlan.ViewType.ToString(), srcViewPlan.GetType().Name, srcViewPlan.Name));
                                var cancelEx = new OperationCanceledException("Transfer canceled: Duplicate element names found.");
                                cancelEx.Data["Duplicates"] = duplicateItems;
                                throw cancelEx;
                            }
                            else if (config.cf_rbAppendSuffix)
                            {
                                LoggerService.LogInfo($"Transfer: ViewPlan '{srcViewPlan.Name}' already exists in target document. Option 'Append Suffix' active. Creating new ViewPlan with suffix...");
                                targetPlanToUse = CreateViewPlan(sourceDoc, targetDoc, srcViewPlan, levelMappings, config.cf_chk_ForceLevelInLevelBaseViews);
                                if (targetPlanToUse != null)
                                {
                                    try { targetPlanToUse.Name = srcViewPlan.Name + config.cf_suffixText; }
                                    catch { targetPlanToUse.Name = GetUniqueViewName(targetDoc, srcViewPlan.Name + config.cf_suffixText, srcViewPlan.ViewType); }
                                }
                            }
                            else if (config.cf_rbKeepOriginal)
                            {
                                LoggerService.LogInfo($"Transfer: ViewPlan '{srcViewPlan.Name}' already exists in target document. Option 'Keep Original' active. Re-using existing target view for graphics/2D synchronization.");
                                targetPlanToUse = existingTargetView as ViewPlan;
                            }
                        }
                        else
                        {
                            LoggerService.LogInfo($"Transfer: Creating new ViewPlan '{srcViewPlan.Name}' in target document...");
                            targetPlanToUse = CreateViewPlan(sourceDoc, targetDoc, srcViewPlan, levelMappings, config.cf_chk_ForceLevelInLevelBaseViews);
                        }

                        if (targetPlanToUse != null)
                        {
                            matchPlantilla(sourceDoc, targetDoc, srcViewPlan, targetPlanToUse, options, config, duplicateItems);
                            if (config.cf_chk_ViewElements)
                            {
                                ponDependientes(sourceDoc, srcViewPlan, targetPlanToUse, options);
                            }
                            if (config.cf_chk_Callout)
                            {
                                ponCallouts(sourceDoc, targetDoc, srcViewPlan, targetPlanToUse, options, config.cf_chk_ViewElements, 3, false, null);
                            }
                            LoggerService.LogInfo($"Transfer: Successfully processed plan view '{srcViewPlan.Name}'.");
                        }
                        else
                        {
                            LoggerService.LogWarning($"Transfer: Failed to obtain target ViewPlan for '{srcViewPlan.Name}'.");
                        }
                    }
                }
                tPlans.Commit();
            }
        }
    }

    public static void ponDependientes(Document origen, ICollection<ElementId> dependientes, View vistaorigen, View vistadestino, CopyPasteOptions copyOptions)
    {
        ponDependientes(origen, vistaorigen, vistadestino, copyOptions);
    }

    public static void ponDependientes(Document origen, View vistaorigen, View vistadestino, CopyPasteOptions copyOptions)
    {
        if (vistaorigen == null || vistadestino == null) return;

        LoggerService.LogInfo($"ponDependientes: Collecting 2D view elements for view '{vistaorigen.Name}' (Source ViewId: {vistaorigen.Id.Value})...");

        var viewElements = new FilteredElementCollector(origen, vistaorigen.Id)
            .WhereElementIsNotElementType()
            .Where(e => e.ViewSpecific && 
                        e is not View && 
                        e is not Viewport && 
                        e is not SunAndShadowSettings && 
                        e is not Level && 
                        e is not SketchPlane)
            .ToList();

        LoggerService.LogInfo($"ponDependientes: Collected {viewElements.Count} 2D detail/annotation elements from source view '{vistaorigen.Name}'.");

        var collection = viewElements.Select(e => e.Id).ToList();

        if (!collection.Any())
        {
            LoggerService.LogInfo($"ponDependientes: No 2D view elements found to copy for view '{vistaorigen.Name}'.");
            return;
        }

        try
        {
            ElementTransformUtils.CopyElements(vistaorigen, collection, vistadestino, Transform.Identity, copyOptions);
            LoggerService.LogInfo($"ponDependientes: Batch copied all {collection.Count} 2D view elements into target view '{vistadestino.Name}'.");
        }
        catch (Exception exBatch)
        {
            LoggerService.LogWarning($"ponDependientes: Batch copy of {collection.Count} 2D view elements from '{vistaorigen.Name}' failed ({exBatch.Message}). Retrying element-by-element...");
            int copiedCount = 0;
            int failedCount = 0;
            foreach (Element elem in viewElements)
            {
                try
                {
                    ElementTransformUtils.CopyElements(vistaorigen, new List<ElementId> { elem.Id }, vistadestino, Transform.Identity, copyOptions);
                    copiedCount++;
                }
                catch (Exception exSingle)
                {
                    failedCount++;
                    LoggerService.LogWarning($"ponDependientes: Could not copy 2D element '{elem.Name}' (Category: {elem.Category?.Name ?? "NoCategory"}, Id: {elem.Id.Value}) into target view '{vistadestino.Name}': {exSingle.Message}");
                }
            }
            LoggerService.LogInfo($"ponDependientes: Element-by-element copy complete for '{vistadestino.Name}'. Successfully Copied: {copiedCount}, Skipped/Failed: {failedCount}.");
        }
    }

    public static void ponCallouts(
        Document origen,
        Document destino,
        View vistaorigen,
        View vistadestino,
        CopyPasteOptions copyOptions,
        bool CopiaDetalles,
        int Contador,
        bool transforma,
        Transform? T)
    {
        foreach (ElementId elementId in vistaorigen.GetDependentElements(null))
        {
            Element elem = origen.GetElement(elementId);
            if (elem != null && elem is View && elem.Id != vistaorigen.Id)
            {
                var viewTemplatesCount = new FilteredElementCollector(origen)
                    .OfClass(typeof(View))
                    .Cast<View>()
                    .Where(i => i.GetDependentElements(null).Contains(elem.Id))
                    .Count();

                if (viewTemplatesCount < Contador)
                {
                    try
                    {
                        var source = ElementTransformUtils.CopyElements(vistaorigen, new List<ElementId> { elem.Id }, vistadestino, null, copyOptions);
                        if (destino.GetElement(source.FirstOrDefault()) is View view && origen.GetElement(elem.Id) is View view2)
                        {
                            if (transforma && T != null)
                            {
                                try
                                {
                                    if (!T.Origin.IsAlmostEqualTo(XYZ.Zero))
                                    {
                                        ElementTransformUtils.MoveElement(destino, GetCropBoxFor(view), T.Origin);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    LoggerService.LogExceptionSilently("ponCallouts - move CropBox", ex);
                                }

                                try
                                {
                                    Line rotationAxis = GetRotationAxisFromTransform(T);
                                    double angle = GetRotationAngleFromTransform(T);
                                    if (angle != 0.0)
                                    {
                                        ElementTransformUtils.RotateElement(destino, GetCropBoxFor(view), rotationAxis, angle);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    LoggerService.LogExceptionSilently("ponCallouts - rotate CropBox", ex);
                                }

                                try
                                {
                                    XYZ offset = DameVectorReposicionOrigenTransformada(view2, view, T);
                                    if (!offset.IsAlmostEqualTo(XYZ.Zero))
                                    {
                                        ElementTransformUtils.MoveElement(destino, GetCropBoxFor(view), offset);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    LoggerService.LogExceptionSilently("ponCallouts - reposition CropBox", ex);
                                }
                            }

                            if (CopiaDetalles)
                            {
                                ponDependientes(origen, vistaorigen.GetDependentElements(null), view2, view, copyOptions);
                            }

                            ponCallouts(origen, destino, view2, view, copyOptions, CopiaDetalles, Contador + 1, transforma, T);
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerService.LogExceptionSilently("ponCallouts - copying callout view", ex);
                    }
                }
            }
        }
    }

    private static void CopyFilters(Document origen, Document destino, View vistaorigen, View vistadestino, CopyPasteOptions copyOptions, Configuraciones config, List<TransferPlus.Models.DuplicateElementInfo> duplicateItems)
    {
        if (vistaorigen == null || vistadestino == null) return;
        if (vistaorigen is ViewSchedule vs && vs.IsTitleblockRevisionSchedule) return;
        if (vistaorigen is ViewSchedule) return;
        if (!vistaorigen.AreGraphicsOverridesAllowed()) return;

        try
        {
            var filters = vistaorigen.GetFilters();
            if (filters == null || !filters.Any()) return;

            foreach (ElementId filterId in filters)
            {
                ParameterFilterElement srcFilter = origen.GetElement(filterId) as ParameterFilterElement;
                if (srcFilter == null) continue;

                ElementId targetFilterId = ElementId.InvalidElementId;
                ParameterFilterElement existingFilter = new FilteredElementCollector(destino)
                    .OfClass(typeof(ParameterFilterElement))
                    .Cast<ParameterFilterElement>()
                    .FirstOrDefault(f => f.Name.Equals(srcFilter.Name, StringComparison.OrdinalIgnoreCase));

                if (existingFilter != null)
                {
                    if (config.cf_rbKeepOriginal)
                    {
                        targetFilterId = existingFilter.Id;
                    }
                    else if (config.cf_rbAbortTransaction)
                    {
                        duplicateItems.Add(new TransferPlus.Models.DuplicateElementInfo("Filters", "Filter", "ParameterFilterElement", srcFilter.Name));
                        var cancelEx = new OperationCanceledException("Transfer canceled: Duplicate view filter names found.");
                        cancelEx.Data["Duplicates"] = duplicateItems;
                        throw cancelEx;
                    }
                    else if (config.cf_rbAppendSuffix)
                    {
                        try
                        {
                            var copiedIds = ElementTransformUtils.CopyElements(origen, new List<ElementId> { filterId }, destino, Transform.Identity, copyOptions);
                            var newFilterId = (copiedIds != null && copiedIds.Any()) ? copiedIds.FirstOrDefault() : ElementId.InvalidElementId;
                            if (newFilterId != ElementId.InvalidElementId)
                            {
                                ParameterFilterElement newFilter = destino.GetElement(newFilterId) as ParameterFilterElement;
                                if (newFilter != null)
                                {
                                    try { newFilter.Name = srcFilter.Name + config.cf_suffixText; } catch { }
                                    targetFilterId = newFilter.Id;
                                }
                            }
                        }
                        catch (Exception exCopyFilter)
                        {
                            LoggerService.LogError($"ViewFilter: Failed copying filter '{srcFilter.Name}'", exCopyFilter);
                        }
                    }
                }
                else
                {
                    try
                    {
                        var copiedIds = ElementTransformUtils.CopyElements(origen, new List<ElementId> { filterId }, destino, Transform.Identity, copyOptions);
                        var newFilterId = (copiedIds != null && copiedIds.Any()) ? copiedIds.FirstOrDefault() : ElementId.InvalidElementId;
                        if (newFilterId != ElementId.InvalidElementId)
                        {
                            ParameterFilterElement newFilter = destino.GetElement(newFilterId) as ParameterFilterElement;
                            if (newFilter != null)
                            {
                                targetFilterId = newFilter.Id;
                            }
                        }
                    }
                    catch (Exception exCopyFilter)
                    {
                        LoggerService.LogError($"ViewFilter: Failed copying filter '{srcFilter.Name}'", exCopyFilter);
                    }
                }

                if (targetFilterId != ElementId.InvalidElementId)
                {
                    try
                    {
                        if (!vistadestino.GetFilters().Contains(targetFilterId))
                        {
                            vistadestino.AddFilter(targetFilterId);
                        }
                        vistadestino.SetFilterVisibility(targetFilterId, vistaorigen.GetFilterVisibility(filterId));
                        vistadestino.SetFilterOverrides(targetFilterId, vistaorigen.GetFilterOverrides(filterId));
                        vistadestino.SetIsFilterEnabled(targetFilterId, vistaorigen.GetIsFilterEnabled(filterId));
                    }
                    catch (Exception exApplyFilter)
                    {
                        LoggerService.LogWarning($"ViewFilter: Failed to apply filter '{srcFilter.Name}' to view '{vistadestino.Name}': {exApplyFilter.Message}");
                    }
                }
            }
        }
        catch (Exception exFilters)
        {
            LoggerService.LogExceptionSilently($"CopyFilters from '{vistaorigen.Name}' to '{vistadestino.Name}'", exFilters);
        }
    }

    public static void matchPlantilla(
        Document origen,
        Document destino,
        View vistaorigen,
        View vistadestino,
        CopyPasteOptions copyOptions,
        Configuraciones config,
        List<TransferPlus.Models.DuplicateElementInfo> duplicateItems)
    {
        ElementId targetTemplateId = ElementId.InvalidElementId;
        View templateView = null;
        View newTemplate = null;

        if (vistaorigen.ViewTemplateId != ElementId.InvalidElementId)
        {
            templateView = origen.GetElement(vistaorigen.ViewTemplateId) as View;
            if (templateView != null)
            {
                View existingTemplate = new FilteredElementCollector(destino)
                    .OfClass(typeof(View))
                    .Cast<View>()
                    .FirstOrDefault(v => v.IsTemplate && v.Name.Equals(templateView.Name, StringComparison.OrdinalIgnoreCase));

                if (existingTemplate != null)
                {
                    if (config.cf_rbKeepOriginal)
                    {
                        targetTemplateId = existingTemplate.Id;
                        newTemplate = existingTemplate;
                        LoggerService.LogInfo($"ViewTemplate: Re-using existing template '{templateView.Name}' in target document.");
                    }
                    else if (config.cf_rbAbortTransaction)
                    {
                        duplicateItems.Add(new TransferPlus.Models.DuplicateElementInfo("View Templates", "ViewTemplate", "View", templateView.Name));
                        var cancelEx = new OperationCanceledException("Transfer canceled: Duplicate view template names found.");
                        cancelEx.Data["Duplicates"] = duplicateItems;
                        throw cancelEx;
                    }
                    else if (config.cf_rbAppendSuffix)
                    {
                        try
                        {
                            var copiedIds = ElementTransformUtils.CopyElements(origen, new List<ElementId> { templateView.Id }, destino, Transform.Identity, copyOptions);
                            var newTemplateId = (copiedIds != null && copiedIds.Any()) ? copiedIds.FirstOrDefault() : ElementId.InvalidElementId;
                            if (newTemplateId != ElementId.InvalidElementId)
                            {
                                newTemplate = destino.GetElement(newTemplateId) as View;
                                if (newTemplate != null)
                                {
                                    try { newTemplate.Name = templateView.Name + config.cf_suffixText; }
                                    catch { newTemplate.Name = GetUniqueViewName(destino, templateView.Name + config.cf_suffixText, templateView.ViewType); }
                                    targetTemplateId = newTemplate.Id;
                                    LoggerService.LogInfo($"ViewTemplate: Copied template '{templateView.Name}' and renamed to '{newTemplate.Name}'.");
                                }
                            }
                        }
                        catch (Exception exCopyTmpl)
                        {
                            LoggerService.LogError($"ViewTemplate: Failed copying template '{templateView.Name}'", exCopyTmpl);
                        }
                    }
                }
                else
                {
                    try
                    {
                        var copiedIds = ElementTransformUtils.CopyElements(origen, new List<ElementId> { templateView.Id }, destino, Transform.Identity, copyOptions);
                        var newTemplateId = (copiedIds != null && copiedIds.Any()) ? copiedIds.FirstOrDefault() : ElementId.InvalidElementId;
                        if (newTemplateId != ElementId.InvalidElementId)
                        {
                            newTemplate = destino.GetElement(newTemplateId) as View;
                            if (newTemplate != null)
                            {
                                targetTemplateId = newTemplate.Id;
                                LoggerService.LogInfo($"ViewTemplate: Copied template '{templateView.Name}' to target document.");
                            }
                        }
                    }
                    catch (Exception exCopyTmpl)
                    {
                        LoggerService.LogError($"ViewTemplate: Failed copying template '{templateView.Name}'", exCopyTmpl);
                    }
                }
            }
        }

        // STEP 1: Apply all filters directly to the target view (without the template applied yet)
        CopyFilters(origen, destino, vistaorigen, vistadestino, copyOptions, config, duplicateItems);

        // STEP 2: Apply all category/workset/link visibility overrides directly to the target view (without the template applied yet)
        CopyViewGraphicsAndOverrides(origen, destino, vistaorigen, vistadestino, copyOptions, config, duplicateItems);

        // STEP 3: If there is a template, also populate the template itself with overrides and filters
        if (templateView != null && newTemplate != null)
        {
            CopyFilters(origen, destino, templateView, newTemplate, copyOptions, config, duplicateItems);
            CopyViewGraphicsAndOverrides(origen, destino, templateView, newTemplate, copyOptions, config, duplicateItems);
        }

        // STEP 4: Finally, apply the template to the target view
        if (targetTemplateId != ElementId.InvalidElementId && templateView != null)
        {
            try
            {
                vistadestino.ViewTemplateId = targetTemplateId;
            }
            catch (Exception exApplyTmpl)
            {
                LoggerService.LogWarning($"ViewTemplate: Failed to apply template '{templateView.Name}' to view '{vistadestino.Name}': {exApplyTmpl.Message}");
            }
        }
    }

    private static void CopyViewGraphicsAndOverrides(
        Document sourceDoc,
        Document targetDoc,
        View srcView,
        View targetView,
        CopyPasteOptions options,
        Configuraciones config,
        List<TransferPlus.Models.DuplicateElementInfo> duplicateItems)
    {
        if (srcView == null || targetView == null) return;
        if (srcView is ViewSchedule vs && vs.IsTitleblockRevisionSchedule) return;
        if (srcView is ViewSchedule) return;
        if (!srcView.AreGraphicsOverridesAllowed()) return;

        // Resolve target graphic view: if it has a template, we apply overrides to the template itself so they are not locked/ignored
        View targetGraphicsView = targetView;
        if (targetView.ViewTemplateId != ElementId.InvalidElementId)
        {
            targetGraphicsView = targetDoc.GetElement(targetView.ViewTemplateId) as View ?? targetView;
        }

        // Synchronize Crop Box settings (Cuadro de Recorte)
        if (!srcView.IsTemplate && !targetView.IsTemplate)
        {
            try
            {
                targetView.CropBoxActive = srcView.CropBoxActive;
                targetView.CropBoxVisible = srcView.CropBoxVisible;
                if (srcView.CropBoxActive && srcView.CropBox != null)
                {
                    targetView.CropBox = srcView.CropBox;
                }
                LoggerService.LogInfo($"ViewGraphics: Synchronized CropBox settings (Active: {srcView.CropBoxActive}, Visible: {srcView.CropBoxVisible}) for view '{targetView.Name}'.");
            }
            catch (Exception exCrop)
            {
                LoggerService.LogExceptionSilently($"ViewGraphics: Could not sync CropBox for view '{targetView.Name}'", exCrop);
            }
        }

        // 1. Transfer Categories (Model, Annotation, Imported)
        foreach (Category srcCat in sourceDoc.Settings.Categories)
        {
            try
            {
                if (targetDoc.Settings.Categories.Contains(srcCat.Name))
                {
                    Category targetCat = targetDoc.Settings.Categories.get_Item(srcCat.Name);
                    if (targetCat != null)
                    {
                        try { targetGraphicsView.SetCategoryHidden(targetCat.Id, srcView.GetCategoryHidden(srcCat.Id)); } catch { }
                        try { targetGraphicsView.SetCategoryOverrides(targetCat.Id, srcView.GetCategoryOverrides(srcCat.Id)); } catch { }
                    }
                }
            }
            catch { }
        }

        // 2. Transfer Worksets (Subproyectos)
        if (sourceDoc.IsWorkshared && targetDoc.IsWorkshared)
        {
            try
            {
                FilteredWorksetCollector srcWorksets = new FilteredWorksetCollector(sourceDoc).OfKind(WorksetKind.UserWorkset);
                foreach (Workset srcWs in srcWorksets)
                {
                    try
                    {
                        WorksetVisibility srcWsVisibility = srcView.GetWorksetVisibility(srcWs.Id);
                        Workset targetWs = new FilteredWorksetCollector(targetDoc)
                            .OfKind(WorksetKind.UserWorkset)
                            .FirstOrDefault(w => w.Name.Equals(srcWs.Name, StringComparison.OrdinalIgnoreCase));

                        if (targetWs == null)
                        {
                            targetWs = Workset.Create(targetDoc, srcWs.Name);
                            LoggerService.LogInfo($"Worksets: Created missing workset '{srcWs.Name}' in target document to preserve view visibility overrides.");
                        }

                        if (targetWs != null)
                        {
                            targetGraphicsView.SetWorksetVisibility(targetWs.Id, srcWsVisibility);
                        }
                    }
                    catch { }
                }
            }
            catch (Exception exWs)
            {
                LoggerService.LogExceptionSilently($"Transferring Worksets visibility for view '{targetView.Name}'", exWs);
            }
        }

        // 3. Transfer Revit Link Overrides (Vínculos de Revit)
        try
        {
            var srcLinks = new FilteredElementCollector(sourceDoc)
                .OfClass(typeof(RevitLinkInstance))
                .Cast<RevitLinkInstance>()
                .ToList();

            var missingLinkNames = new List<string>();

            foreach (var srcLink in srcLinks)
            {
                RevitLinkInstance targetLink = new FilteredElementCollector(targetDoc)
                    .OfClass(typeof(RevitLinkInstance))
                    .Cast<RevitLinkInstance>()
                    .FirstOrDefault(l => l.Name.Equals(srcLink.Name, StringComparison.OrdinalIgnoreCase) ||
                                         l.GetLinkDocument()?.Title?.Equals(srcLink.GetLinkDocument()?.Title, StringComparison.OrdinalIgnoreCase) == true);

                if (targetLink != null)
                {
                    try
                    {
                        bool isHidden = srcLink.IsHidden(srcView);
                        bool isTargetHidden = targetLink.IsHidden(targetGraphicsView);
                        if (isHidden && !isTargetHidden)
                        {
                            targetGraphicsView.HideElements(new List<ElementId> { targetLink.Id });
                            LoggerService.LogInfo($"LinkOverrides: Hidden link '{srcLink.Name}' in view '{targetGraphicsView.Name}'.");
                        }
                        else if (!isHidden && isTargetHidden)
                        {
                            targetGraphicsView.UnhideElements(new List<ElementId> { targetLink.Id });
                            LoggerService.LogInfo($"LinkOverrides: Unhidden link '{srcLink.Name}' in view '{targetGraphicsView.Name}'.");
                        }
                    }
                    catch (Exception exHide)
                    {
                        LoggerService.LogWarning($"LinkOverrides: Failed to sync hide/show visibility for link '{srcLink.Name}' in view '{targetGraphicsView.Name}': {exHide.Message}");
                    }

                    try
                    {
                        RevitLinkGraphicsSettings srcSettings = srcView.GetLinkOverrides(srcLink.Id);
                        if (srcSettings != null)
                        {
                            RevitLinkGraphicsSettings targetSettings = new RevitLinkGraphicsSettings();
                            targetSettings.LinkVisibilityType = srcSettings.LinkVisibilityType;

                            if (srcSettings.LinkVisibilityType == LinkVisibility.ByLinkView && srcSettings.LinkedViewId != ElementId.InvalidElementId)
                            {
                                Document srcLinkDoc = srcLink.GetLinkDocument();
                                Document targetLinkDoc = targetLink.GetLinkDocument();
                                if (srcLinkDoc != null && targetLinkDoc != null)
                                {
                                    View srcLinkedView = srcLinkDoc.GetElement(srcSettings.LinkedViewId) as View;
                                    if (srcLinkedView != null)
                                    {
                                        View targetLinkedView = new FilteredElementCollector(targetLinkDoc)
                                            .OfClass(typeof(View))
                                            .Cast<View>()
                                            .FirstOrDefault(v => v.Name.Equals(srcLinkedView.Name, StringComparison.OrdinalIgnoreCase));
                                        if (targetLinkedView != null)
                                        {
                                            targetSettings.LinkedViewId = targetLinkedView.Id;
                                        }
                                    }
                                }
                            }
                            targetGraphicsView.SetLinkOverrides(targetLink.Id, targetSettings);
                            LoggerService.LogInfo($"LinkOverrides: Applied overrides for link '{srcLink.Name}' onto target view '{targetView.Name}'.");
                        }
                    }
                    catch (Exception exLinkOverrides)
                    {
                        LoggerService.LogExceptionSilently($"LinkOverrides: Failed override settings for link '{srcLink.Name}' in view '{targetView.Name}'", exLinkOverrides);
                    }
                }
                else
                {
                    try
                    {
                        RevitLinkGraphicsSettings srcSettings = srcView.GetLinkOverrides(srcLink.Id);
                        if (srcSettings != null)
                        {
                            string linkDisplayName = srcLink.GetLinkDocument()?.Title ?? srcLink.Name;
                            if (!missingLinkNames.Contains(linkDisplayName))
                            {
                                missingLinkNames.Add(linkDisplayName);
                            }
                        }
                    }
                    catch { }
                }
            }

            if (missingLinkNames.Any())
            {
                string missingList = string.Join(", ", missingLinkNames);
                LoggerService.LogWarning($"LinkOverrides: The following linked models were NOT found in the target document. Skipping overrides for: [{missingList}]");
            }
        }
        catch (Exception exLinksAll)
        {
            LoggerService.LogExceptionSilently($"Processing Revit Link overrides for view '{targetView.Name}'", exLinksAll);
        }
    }

    private static Line GetRotationAxisFromTransform(Transform transform)
    {
        double num = transform.BasisY.Z - transform.BasisZ.Y;
        double num2 = transform.BasisZ.X - transform.BasisX.Z;
        double num3 = transform.BasisX.Y - transform.BasisY.X;
        return Line.CreateUnbound(transform.Origin, new XYZ(num, num2, num3));
    }

    private static double GetRotationAngleFromTransform(Transform transform)
    {
        double x = transform.BasisX.X;
        double y = transform.BasisY.Y;
        double z = transform.BasisZ.Z;
        return Math.Acos((x + y + z - 1.0) / 2.0);
    }

    private static ElementId GetCropBoxFor(View view)
    {
        var elementParameterFilter = new ElementParameterFilter(new FilterElementIdRule(new ParameterValueProvider(new ElementId(-1002100)), new FilterNumericEquals(), view.Id));
        return new FilteredElementCollector(view.Document)
            .WherePasses(elementParameterFilter)
            .ToElementIds()
            .FirstOrDefault(a => a.IntegerValue != view.Id.IntegerValue) ?? ElementId.InvalidElementId;
    }

    private static XYZ DameVectorReposicionOrigenTransformada(View vistaorigen, View vistadestino, Transform T)
    {
        XYZ xyz = vistaorigen.CropBox.Transform.Origin;
        xyz = T.OfPoint(xyz);
        XYZ origin = vistadestino.CropBox.Transform.Origin;
        return new XYZ(xyz.X - origin.X, xyz.Y - origin.Y, xyz.Z - origin.Z);
    }

    private class CustomCopyHandlerOk : IDuplicateTypeNamesHandler
    {
        public DuplicateTypeAction OnDuplicateTypeNamesFound(DuplicateTypeNamesHandlerArgs args)
        {
            return DuplicateTypeAction.UseDestinationTypes;
        }
    }

    private class CustomCopyHandlerAbort : IDuplicateTypeNamesHandler
    {
        public bool Triggered { get; set; } = false;
        public DuplicateTypeAction OnDuplicateTypeNamesFound(DuplicateTypeNamesHandlerArgs args)
        {
            Triggered = true;
            return DuplicateTypeAction.Abort;
        }
    }

    private class FamilyLoadOptionsOk : IFamilyLoadOptions
    {
        public bool OnFamilyFound(bool familyInUse, out bool overwriteParameterValues)
        {
            overwriteParameterValues = true;
            return true;
        }

        public bool OnSharedFamilyFound(Family sharedFamily, bool familyInUse, out FamilySource source, out bool overwriteParameterValues)
        {
            source = FamilySource.Family;
            overwriteParameterValues = true;
            return true;
        }
    }

    private static bool TargetHasDuplicateName(Document targetDoc, Element srcElem, string evalName = null)
    {
        Type elemType = srcElem.GetType();
        string srcName = !string.IsNullOrEmpty(evalName) ? evalName : srcElem.Name;
        if (string.IsNullOrEmpty(srcName)) return false;

        try
        {
            if (srcElem is ElementType)
            {
                return new FilteredElementCollector(targetDoc)
                    .OfClass(elemType)
                    .Any(e => e.Name.Equals(srcName, StringComparison.OrdinalIgnoreCase));
            }
            
            if (srcElem is View || srcElem is ViewSheet || srcElem is Level || srcElem is ParameterFilterElement)
            {
                return new FilteredElementCollector(targetDoc)
                    .OfClass(elemType)
                    .Any(e => e.Name.Equals(srcName, StringComparison.OrdinalIgnoreCase));
            }

            if (srcElem.Category != null)
            {
                return new FilteredElementCollector(targetDoc)
                    .OfCategoryId(srcElem.Category.Id)
                    .Any(e => e.Name.Equals(srcName, StringComparison.OrdinalIgnoreCase));
            }
        }
        catch
        {
            try
            {
                return new FilteredElementCollector(targetDoc)
                    .WhereElementIsNotElementType()
                    .Any(e => e.Name.Equals(srcName, StringComparison.OrdinalIgnoreCase));
            }
            catch { }
        }
        return false;
    }

    private static void TransferSingleCategoryStyle(Document sourceDoc, Document targetDoc, Category sourceCat, Category targetCat)
    {
        // 1. Line Weight (Projection)
        int? projLW = sourceCat.GetLineWeight(GraphicsStyleType.Projection);
        if (projLW.HasValue)
        {
            try { targetCat.SetLineWeight(projLW.Value, GraphicsStyleType.Projection); } catch { }
        }

        // 2. Line Weight (Cut)
        if (sourceCat.IsCuttable)
        {
            int? cutLW = sourceCat.GetLineWeight(GraphicsStyleType.Cut);
            if (cutLW.HasValue)
            {
                try { targetCat.SetLineWeight(cutLW.Value, GraphicsStyleType.Cut); } catch { }
            }
        }

        // 3. Line Color
        try { targetCat.LineColor = sourceCat.LineColor; } catch { }

        // 4. Line Pattern (Projection)
        ElementId sourcePatternProj = sourceCat.GetLinePatternId(GraphicsStyleType.Projection);
        if (sourcePatternProj != null && sourcePatternProj != ElementId.InvalidElementId)
        {
            ElementId targetPatternProj = TransferLinePattern(sourceDoc, targetDoc, sourcePatternProj);
            try { targetCat.SetLinePatternId(targetPatternProj, GraphicsStyleType.Projection); } catch { }
        }

        // 5. Line Pattern (Cut)
        if (sourceCat.IsCuttable)
        {
            ElementId sourcePatternCut = sourceCat.GetLinePatternId(GraphicsStyleType.Cut);
            if (sourcePatternCut != null && sourcePatternCut != ElementId.InvalidElementId)
            {
                ElementId targetPatternCut = TransferLinePattern(sourceDoc, targetDoc, sourcePatternCut);
                try { targetCat.SetLinePatternId(targetPatternCut, GraphicsStyleType.Cut); } catch { }
            }
        }

        // 6. Material
        if (sourceCat.Material != null)
        {
            ElementId targetMatId = TransferMaterial(sourceDoc, targetDoc, sourceCat.Material.Id);
            if (targetMatId != null && targetMatId != ElementId.InvalidElementId)
            {
                try { targetCat.Material = targetDoc.GetElement(targetMatId) as Material; } catch { }
            }
        }

        // Recurse for subcategories
        if (sourceCat.SubCategories != null && sourceCat.SubCategories.Size > 0)
        {
            foreach (object obj in sourceCat.SubCategories)
            {
                if (obj is Category sourceSub)
                {
                    Category targetSub = null;
                    if (targetCat.SubCategories != null)
                    {
                        targetSub = targetCat.SubCategories.get_Item(sourceSub.Name);
                    }
                    if (targetSub == null)
                    {
                        try
                        {
                            targetSub = targetDoc.Settings.Categories.NewSubcategory(targetCat, sourceSub.Name);
                        }
                        catch { }
                    }
                    if (targetSub != null)
                    {
                        TransferSingleCategoryStyle(sourceDoc, targetDoc, sourceSub, targetSub);
                    }
                }
            }
        }
    }

    private static ElementId TransferLinePattern(Document sourceDoc, Document targetDoc, ElementId sourcePatternId)
    {
        if (sourcePatternId == null || sourcePatternId == ElementId.InvalidElementId) return ElementId.InvalidElementId;
        Element sourcePattern = sourceDoc.GetElement(sourcePatternId);
        if (sourcePattern == null) return ElementId.InvalidElementId;

        Element targetPattern = new FilteredElementCollector(targetDoc)
            .OfClass(typeof(LinePatternElement))
            .FirstOrDefault(p => p.Name == sourcePattern.Name);
        if (targetPattern != null) return targetPattern.Id;

        try
        {
            var copied = ElementTransformUtils.CopyElements(sourceDoc, new List<ElementId> { sourcePatternId }, targetDoc, null, new CopyPasteOptions());
            return copied.FirstOrDefault() ?? ElementId.InvalidElementId;
        }
        catch
        {
            return ElementId.InvalidElementId;
        }
    }

    private static ElementId TransferMaterial(Document sourceDoc, Document targetDoc, ElementId sourceMatId)
    {
        if (sourceMatId == null || sourceMatId == ElementId.InvalidElementId) return ElementId.InvalidElementId;
        Element sourceMat = sourceDoc.GetElement(sourceMatId);
        if (sourceMat == null) return ElementId.InvalidElementId;

        Element targetMat = new FilteredElementCollector(targetDoc)
            .OfClass(typeof(Material))
            .FirstOrDefault(m => m.Name == sourceMat.Name);
        if (targetMat != null) return targetMat.Id;

        try
        {
            var copied = ElementTransformUtils.CopyElements(sourceDoc, new List<ElementId> { sourceMatId }, targetDoc, null, new CopyPasteOptions());
            return copied.FirstOrDefault() ?? ElementId.InvalidElementId;
        }
        catch
        {
            return ElementId.InvalidElementId;
        }
    }

    private static ViewPlan CreateViewPlan(Document sourceDoc, Document targetDoc, ViewPlan srcViewPlan, Dictionary<string, string>? levelMappings, bool forceLevel)
    {
        // 1. Get the ViewFamily of the source view
        ViewFamilyType srcVft = sourceDoc.GetElement(srcViewPlan.GetTypeId()) as ViewFamilyType;
        if (srcVft == null) return null;
        ViewFamily family = srcVft.ViewFamily;

        // 2. Find a matching ViewFamilyType in targetDoc
        ViewFamilyType targetVft = new FilteredElementCollector(targetDoc)
            .OfClass(typeof(ViewFamilyType))
            .Cast<ViewFamilyType>()
            .FirstOrDefault(vft => vft.ViewFamily == family);

        if (targetVft == null)
        {
            LoggerService.LogWarning($"CreateViewPlan: Could not find matching ViewFamilyType for ViewFamily '{family}' in target document.");
            return null;
        }

        // 3. Resolve target Level
        Level srcLevel = srcViewPlan.GenLevel;
        if (srcLevel == null)
        {
            LoggerService.LogWarning($"CreateViewPlan: Source view plan '{srcViewPlan.Name}' does not have a GenLevel. Cannot create plan view.");
            return null;
        }

        ElementId targetLevelId = ElementId.InvalidElementId;
        string srcLevelName = srcLevel.Name;

        // Fetch all levels in targetDoc
        var targetLevels = new FilteredElementCollector(targetDoc)
            .OfClass(typeof(Level))
            .Cast<Level>()
            .ToList();

        if (forceLevel && levelMappings != null && levelMappings.ContainsKey(srcLevelName))
        {
            string mappedActionOrLevel = levelMappings[srcLevelName];
            if (mappedActionOrLevel.StartsWith("CREATE_NEW"))
            {
                string customName = srcLevelName;
                if (mappedActionOrLevel.StartsWith("CREATE_NEW:"))
                {
                    customName = mappedActionOrLevel.Substring(11);
                }

                // Create a new level
                Level newLevel = Level.Create(targetDoc, srcLevel.ProjectElevation);
                try
                {
                    newLevel.Name = customName;
                }
                catch
                {
                    newLevel.Name = GetUniqueLevelName(targetDoc, customName);
                }
                targetLevelId = newLevel.Id;
                LoggerService.LogInfo($"CreateViewPlan: Created new Level '{newLevel.Name}' at elevation {newLevel.ProjectElevation} ft (mapped from '{srcLevelName}').");
            }
            else
            {
                // Map to existing target level
                var matchedLevel = targetLevels.FirstOrDefault(l => l.Name.Equals(mappedActionOrLevel, StringComparison.OrdinalIgnoreCase));
                if (matchedLevel != null)
                {
                    targetLevelId = matchedLevel.Id;
                    LoggerService.LogInfo($"CreateViewPlan: Mapped view level to existing Level '{matchedLevel.Name}'.");
                }
                else
                {
                    // Fallback: create level
                    Level newLevel = Level.Create(targetDoc, srcLevel.ProjectElevation);
                    newLevel.Name = GetUniqueLevelName(targetDoc, srcLevelName);
                    targetLevelId = newLevel.Id;
                }
            }
        }
        else
        {
            // Not forcing level mapping, or mapping not found. Search by name.
            var existingLevel = targetLevels.FirstOrDefault(l => l.Name.Equals(srcLevelName, StringComparison.OrdinalIgnoreCase));
            if (existingLevel != null)
            {
                targetLevelId = existingLevel.Id;
                LoggerService.LogInfo($"CreateViewPlan: Found existing Level '{existingLevel.Name}' in target document. Using it.");
            }
            else
            {
                // Create new level with same name and elevation
                Level newLevel = Level.Create(targetDoc, srcLevel.ProjectElevation);
                try
                {
                    newLevel.Name = srcLevelName;
                }
                catch
                {
                    newLevel.Name = GetUniqueLevelName(targetDoc, srcLevelName);
                }
                targetLevelId = newLevel.Id;
                LoggerService.LogInfo($"CreateViewPlan: Created new Level '{newLevel.Name}' at elevation {newLevel.ProjectElevation} ft.");
            }
        }

        if (targetLevelId == ElementId.InvalidElementId)
        {
            LoggerService.LogWarning($"CreateViewPlan: Failed to resolve level for ViewPlan '{srcViewPlan.Name}'.");
            return null;
        }

        // 4. Create the ViewPlan
        ViewPlan targetViewPlan = ViewPlan.Create(targetDoc, targetVft.Id, targetLevelId);
        try
        {
            targetViewPlan.Name = srcViewPlan.Name;
        }
        catch
        {
            targetViewPlan.Name = GetUniqueViewName(targetDoc, srcViewPlan.Name, srcViewPlan.ViewType);
        }

        LoggerService.LogInfo($"CreateViewPlan: Successfully created ViewPlan '{targetViewPlan.Name}' (Id: {targetViewPlan.Id.Value}) on Level '{targetDoc.GetElement(targetLevelId).Name}'.");

        // 5. Copy view settings (templates, filters, scale, crop box)
        CopyViewSettings(srcViewPlan, targetViewPlan);

        return targetViewPlan;
    }

    private static string GetUniqueLevelName(Document doc, string baseName)
    {
        var levelNames = new FilteredElementCollector(doc)
            .OfClass(typeof(Level))
            .Cast<Level>()
            .Select(l => l.Name)
            .ToList();

        string uniqueName = baseName;
        int counter = 1;
        while (levelNames.Contains(uniqueName, StringComparer.OrdinalIgnoreCase))
        {
            uniqueName = $"{baseName}_{counter}";
            counter++;
        }
        return uniqueName;
    }

    private static string GetUniqueViewName(Document doc, string baseName, ViewType viewType)
    {
        var viewNames = new FilteredElementCollector(doc)
            .OfClass(typeof(View))
            .Cast<View>()
            .Where(v => v.ViewType == viewType)
            .Select(v => v.Name)
            .ToList();

        string uniqueName = baseName;
        int counter = 1;
        while (viewNames.Contains(uniqueName, StringComparer.OrdinalIgnoreCase))
        {
            uniqueName = $"{baseName}_{counter}";
            counter++;
        }
        return uniqueName;
    }

    private static void CopyViewSettings(View srcView, View targetView)
    {
        try
        {
            targetView.Scale = srcView.Scale;
            targetView.DetailLevel = srcView.DetailLevel;
            targetView.DisplayStyle = srcView.DisplayStyle;
            
            // Crop Box
            targetView.CropBoxActive = srcView.CropBoxActive;
            targetView.CropBoxVisible = srcView.CropBoxVisible;
            if (srcView.CropBoxActive)
            {
                targetView.CropBox = srcView.CropBox;
            }
        }
        catch (Exception ex)
        {
            LoggerService.LogWarning($"CopyViewSettings: Failed to copy some view properties for '{srcView.Name}': {ex.Message}");
        }
    }

    private static ViewSheet CreateViewSheet(Document sourceDoc, Document targetDoc, ViewSheet srcSheet, Configuraciones config)
    {
        // 1. Resolve TitleBlock type
        ElementId titleBlockTypeId = ElementId.InvalidElementId;
        var srcTitleBlocks = new FilteredElementCollector(sourceDoc, srcSheet.Id)
            .OfCategory(BuiltInCategory.OST_TitleBlocks)
            .WhereElementIsNotElementType()
            .ToList();

        if (srcTitleBlocks.Any())
        {
            ElementId srcTbTypeId = srcTitleBlocks.First().GetTypeId();
            Element srcTbType = sourceDoc.GetElement(srcTbTypeId);
            if (srcTbType != null)
            {
                Element targetTbType = new FilteredElementCollector(targetDoc)
                    .OfCategory(BuiltInCategory.OST_TitleBlocks)
                    .WhereElementIsElementType()
                    .FirstOrDefault(e => e.Name.Equals(srcTbType.Name, StringComparison.OrdinalIgnoreCase));

                if (targetTbType != null)
                {
                    titleBlockTypeId = targetTbType.Id;
                }
                else
                {
                    try
                    {
                        var copiedTbTypes = ElementTransformUtils.CopyElements(sourceDoc, new List<ElementId> { srcTbTypeId }, targetDoc, null, new CopyPasteOptions());
                        titleBlockTypeId = copiedTbTypes.FirstOrDefault() ?? ElementId.InvalidElementId;
                    }
                    catch { }
                }
            }
        }

        // 2. Create the ViewSheet
        ViewSheet targetSheet = ViewSheet.Create(targetDoc, titleBlockTypeId);

        // 3. Resolve SheetNumber and Name according to duplicate config
        string evalSheetNumber = srcSheet.SheetNumber;
        string evalName = srcSheet.Name;

        var existingSheet = new FilteredElementCollector(targetDoc)
            .OfClass(typeof(ViewSheet))
            .Cast<ViewSheet>()
            .FirstOrDefault(s => s.SheetNumber.Equals(srcSheet.SheetNumber, StringComparison.OrdinalIgnoreCase));

        if (existingSheet != null)
        {
            if (config.cf_rbAppendSuffix)
            {
                evalSheetNumber += config.cf_suffixText;
                evalName += config.cf_suffixText;
            }
            else if (config.cf_rbKeepOriginal)
            {
                evalSheetNumber = GetUniqueSheetNumber(targetDoc, srcSheet.SheetNumber);
            }
        }

        try { targetSheet.SheetNumber = evalSheetNumber; } catch { }
        try { targetSheet.Name = evalName; } catch { }

        LoggerService.LogInfo($"CreateViewSheet: Successfully created ViewSheet '{targetSheet.SheetNumber} - {targetSheet.Name}' (Id: {targetSheet.Id.Value}).");
        return targetSheet;
    }

    private static string GetUniqueSheetNumber(Document doc, string baseNumber)
    {
        var sheetNumbers = new FilteredElementCollector(doc)
            .OfClass(typeof(ViewSheet))
            .Cast<ViewSheet>()
            .Select(s => s.SheetNumber)
            .ToList();

        string uniqueNum = baseNumber;
        int counter = 1;
        while (sheetNumbers.Contains(uniqueNum, StringComparer.OrdinalIgnoreCase))
        {
            uniqueNum = $"{baseNumber}_{counter}";
            counter++;
        }
        return uniqueNum;
    }
}
