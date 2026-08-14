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
        var processedViewsMap = new Dictionary<ElementId, ElementId>();

        if (config != null)
        {
            LoggerService.LogInfo("=== [UI CONFIGURATION SWITCHES LOG] ===");
            LoggerService.LogInfo($"  On Duplicates : KeepOriginal={config.cf_rbKeepOriginal}, AbortTransaction={config.cf_rbAbortTransaction}, AppendSuffix={config.cf_rbAppendSuffix} (Suffix='{config.cf_suffixText}')");
            LoggerService.LogInfo($"  On View       : ViewElements={config.cf_chk_ViewElements}, Callouts={config.cf_chk_Callout}, Sections&Details={config.cf_chk_Section}, SheetWithViews={config.cf_chk_SheetWithViews}, ForceLevel={config.cf_chk_ForceLevelInLevelBaseViews}");
            LoggerService.LogInfo($"  Transform By  : TransformNone={config.cf_chk_GetTransformNone}, TransformLink={config.cf_chk_GetTransformLink}, TransformShared={config.cf_chk_GetTransformShared}");
            LoggerService.LogInfo($"  Reuse Options : LegendIfExists={config.cf_chk_UseLegendIfExists}, ScheduleIfExists={config.cf_chk_UseScheduleIfExists}, AssemblyViewsIfExists={config.cf_chk_UseAssemblyViewsIfExists}");
            LoggerService.LogInfo("========================================");
        }

        foreach (var item in elementsToCopy)
        {
            if (item.IsWorkset || item.Categoria == "Worksets" || (item.wID != null && item.wID != WorksetId.InvalidWorksetId))
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
        if (worksetsToCreate.Any())
        {
            if (!targetDoc.IsWorkshared)
            {
                LoggerService.LogWarning($"Transfer: Cannot transfer worksets to target model '{targetDoc.Title}' because worksharing is not enabled on the destination project.");
                var cancelEx = new OperationCanceledException("Cannot transfer worksets to a non-workshared project.");
                cancelEx.Data["NotWorkshared"] = targetDoc.Title;
                throw cancelEx;
            }

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
        if (levelMappings != null)
        {
            using (Transaction tLevels = new Transaction(targetDoc, "TransferPlus: Create Missing Levels"))
            {
                tLevels.Start();
                if (config.cf_chk_AcceptAll) WarningSwallower.AttachToTransaction(tLevels);
                foreach (var mapping in levelMappings)
                {
                    string srcLevelName = mapping.Key;
                    string targetAction = mapping.Value;
                    if (targetAction.StartsWith("CREATE_NEW"))
                    {
                        string customName = srcLevelName;
                        if (targetAction.StartsWith("CREATE_NEW:"))
                        {
                            customName = targetAction.Substring(11);
                        }

                        var existingTargetLevel = new FilteredElementCollector(targetDoc)
                            .OfClass(typeof(Level))
                            .Cast<Level>()
                            .FirstOrDefault(l => l.Name.Equals(customName, StringComparison.OrdinalIgnoreCase));

                        if (existingTargetLevel == null)
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
                                    newLevel.Name = customName;
                                    LoggerService.LogInfo($"LevelMapping: Created new level '{newLevel.Name}' at elevation {newLevel.ProjectElevation}.");
                                }
                                catch (Exception exLevel)
                                {
                                    LoggerService.LogWarning($"LevelMapping: Could not create level '{customName}': {exLevel.Message}");
                                }
                            }
                        }
                    }
                }
                tLevels.Commit();
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

                Transform? transform = GetTransformForSource(sourceDoc, targetDoc, config);

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
                            processedViewsMap[sourceView.Id] = targetView.Id;
                            matchPlantilla(sourceDoc, targetDoc, sourceView, targetView, options, config, duplicateItems);
                            
                            if (config.cf_chk_Callout)
                            {
                                 ponCallouts(sourceDoc, targetDoc, sourceView, targetView, options, config.cf_chk_ViewElements, 1, transform != null, transform, config, processedViewsMap);
                            }

                            if (config.cf_chk_Section)
                            {
                                ponSections(sourceDoc, targetDoc, sourceView, targetView, options, config.cf_chk_ViewElements, transform != null, transform, config, processedViewsMap);
                            }

                            if (!config.cf_chk_Callout && !config.cf_chk_Section && config.cf_chk_ViewElements)
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

                Transform? transform = GetTransformForSource(sourceDoc, targetDoc, config);

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
                        LoggerService.LogInfo($"SheetTransfer [PLACED VIEWS QUERY]: GetAllPlacedViews returned {placedViewIds.Count} view(s) for source sheet '{sourceSheet.SheetNumber}' (Sheet Id: {sourceSheet.Id.Value}).");

                        // Collect Viewports globally from sourceDoc (view-scoped collector FilteredElementCollector(sourceDoc, sheet.Id) returns empty for linked documents)
                        var globalViewports = new FilteredElementCollector(sourceDoc)
                            .OfClass(typeof(Viewport))
                            .Cast<Viewport>()
                            .Where(vp => vp.OwnerViewId == sourceSheet.Id || vp.SheetId == sourceSheet.Id)
                            .ToList();

                        LoggerService.LogInfo($"SheetTransfer [GLOBAL VIEWPORTS QUERY]: Found {globalViewports.Count} Viewport(s) in source document for sheet '{sourceSheet.SheetNumber}'.");

                        foreach (var vp in globalViewports)
                        {
                            if (vp.ViewId != ElementId.InvalidElementId && !placedViewIds.Contains(vp.ViewId))
                            {
                                placedViewIds.Add(vp.ViewId);
                            }
                        }

                        // Collect ScheduleSheetInstances globally from sourceDoc
                        var globalSchedules = new FilteredElementCollector(sourceDoc)
                            .OfClass(typeof(ScheduleSheetInstance))
                            .Cast<ScheduleSheetInstance>()
                            .Where(inst => inst.OwnerViewId == sourceSheet.Id)
                            .ToList();

                        LoggerService.LogInfo($"SheetTransfer [GLOBAL SCHEDULES QUERY]: Found {globalSchedules.Count} ScheduleSheetInstance(s) in source document for sheet '{sourceSheet.SheetNumber}'.");

                        foreach (var inst in globalSchedules)
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

                        LoggerService.LogInfo($"SheetTransfer [TOTAL PLACED]: Total views+schedules to replicate for sheet '{sourceSheet.SheetNumber}': {placedViewIds.Count}.");

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

                                if (processedViewsMap.TryGetValue(placedViewId, out ElementId mappedViewId))
                                {
                                    targetViewId = mappedViewId;
                                    shouldCopyView = false;
                                    LoggerService.LogInfo($"SheetTransfer: View '{srcPlacedView.Name}' [Id: {placedViewId.Value}] was already processed in this transfer run (Target ViewId: {targetViewId.Value}). Re-using mapped view.");
                                }
                                else
                                {
                                    bool isCopyable = srcPlacedView.ViewType == ViewType.DraftingView ||
                                                      isLegend ||
                                                      (isSchedule && !isTitleblockRevisionSchedule);

                                    if (isCopyable)
                                    {
                                        shouldCopyView = true;
                                        var existingTargetView = FindExistingViewByName(targetDoc, srcPlacedView.Name);

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
                                    var existingTargetView = FindExistingViewByName(targetDoc, srcPlacedView.Name);

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
                                                LoggerService.LogInfo($"SheetTransfer [APPEND SUFFIX]: Duplicate plan view '{srcPlacedView.Name}' exists in target. Creating new ViewPlan with suffix...");
                                                ViewPlan newPlan = CreateViewPlan(sourceDoc, targetDoc, srcViewPlanSuffix, levelMappings, config.cf_chk_ForceLevelInLevelBaseViews, config, forceNewSuffixedView: true);
                                                if (newPlan != null)
                                                {
                                                    targetViewId = newPlan.Id;
                                                    viewWasNewlyCreated = true;
                                                    LoggerService.LogInfo($"SheetTransfer [APPEND SUFFIX SUCCESS]: Created suffixed ViewPlan '{newPlan.Name}' (Target ViewId: {newPlan.Id.Value}).");
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
                                            targetViewId = existingTargetView.Id;
                                            bool canAddExisting = Viewport.CanAddViewToSheet(targetDoc, targetSheet.Id, existingTargetView.Id);
                                            if (canAddExisting)
                                            {
                                                LoggerService.LogInfo($"SheetTransfer: Model view '{srcPlacedView.Name}' already exists in target document and is unplaced. Re-using target view for viewport.");
                                            }
                                            else if (isLegend)
                                            {
                                                LoggerService.LogInfo($"SheetTransfer: Legend view '{srcPlacedView.Name}' is already placed but can be placed on multiple sheets. Re-using target legend.");
                                            }
                                            else
                                            {
                                                LoggerService.LogInfo($"SheetTransfer: Model view '{srcPlacedView.Name}' already exists in target document and is placed on another sheet. Option 'Keep Original' active. Re-using target view reference without creating duplicate.");
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

                                }

                                if (targetViewId != ElementId.InvalidElementId)
                                {
                                    processedViewsMap[placedViewId] = targetViewId;
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
                                        View consolidatedPlacedView = ponDependientes(sourceDoc, srcPlacedView.GetDependentElements(null), srcPlacedView, newPlacedView, options);
                                        if (consolidatedPlacedView != null && consolidatedPlacedView.IsValidObject && consolidatedPlacedView.Id != targetViewId)
                                        {
                                            targetViewId = consolidatedPlacedView.Id;
                                            processedViewsMap[placedViewId] = targetViewId;
                                            newPlacedView = consolidatedPlacedView;
                                            LoggerService.LogInfo($"SheetTransfer [CONSOLIDATED VIEW UPDATED]: Updated targetViewId to {targetViewId.Value} ('{newPlacedView.Name}') after 2D consolidation.");

                                            LoggerService.LogInfo($"SheetTransfer [RE-APPLYING TEMPLATE]: Re-applying matchPlantilla on consolidated view '{newPlacedView.Name}'...");
                                            matchPlantilla(sourceDoc, targetDoc, srcPlacedView, newPlacedView, options, config, duplicateItems);
                                        }

                                        if (config.cf_chk_Callout && srcPlacedView.ViewType != ViewType.DraftingView)
                                        {
                                             ponCallouts(sourceDoc, targetDoc, srcPlacedView, newPlacedView, options, true, 1, transform != null, transform, config, processedViewsMap);
                                        }

                                        if (config.cf_chk_Section && srcPlacedView.ViewType != ViewType.DraftingView)
                                        {
                                             ponSections(sourceDoc, targetDoc, srcPlacedView, newPlacedView, options, true, transform != null, transform, config, processedViewsMap);
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
                                              var srcViewports = new FilteredElementCollector(sourceDoc)
                                                  .OfClass(typeof(Viewport))
                                                  .Cast<Viewport>()
                                                  .Where(vp => vp.ViewId == placedViewId && (vp.OwnerViewId == sourceSheet.Id || vp.SheetId == sourceSheet.Id))
                                                  .ToList();

                                              if (!srcViewports.Any())
                                              {
                                                  srcViewports = new FilteredElementCollector(sourceDoc)
                                                      .OfClass(typeof(Viewport))
                                                      .Cast<Viewport>()
                                                      .Where(vp => vp.ViewId == placedViewId)
                                                      .ToList();
                                              }

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
                                         var srcSchedules = new FilteredElementCollector(sourceDoc)
                                             .OfClass(typeof(ScheduleSheetInstance))
                                             .Cast<ScheduleSheetInstance>()
                                             .Where(s => s.ScheduleId == placedViewId && s.OwnerViewId == sourceSheet.Id)
                                             .ToList();

                                         if (!srcSchedules.Any())
                                         {
                                             srcSchedules = new FilteredElementCollector(sourceDoc)
                                                 .OfClass(typeof(ScheduleSheetInstance))
                                                 .Cast<ScheduleSheetInstance>()
                                                 .Where(s => s.ScheduleId == placedViewId)
                                                 .ToList();
                                         }

                                         foreach (ScheduleSheetInstance srcScheduleInstance in srcSchedules)
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

                Transform? transform = GetTransformForSource(sourceDoc, targetDoc, config);

                LogTargetViewsCheckpoint(targetDoc, "4-BEFORE_PLAN_VIEWS_LOOP");
                foreach (var item in planViewsToTransfer)
                {
                    ViewPlan srcViewPlan = sourceDoc.GetElement(item.eID) as ViewPlan;
                    if (srcViewPlan != null)
                    {
                        View targetPlanToUse = null;

                        if (processedViewsMap.TryGetValue(srcViewPlan.Id, out ElementId mappedPlanId))
                        {
                            targetPlanToUse = targetDoc.GetElement(mappedPlanId) as View;
                            LoggerService.LogInfo($"Transfer: ViewPlan '{srcViewPlan.Name}' [Id: {srcViewPlan.Id.Value}] was already processed during sheet processing in this run (Target ViewId: {mappedPlanId.Value}). Re-using mapped view.");
                        }
                        else
                        {
                            View existingTargetView = FindExistingViewByName(targetDoc, srcViewPlan.Name);

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
                                    LoggerService.LogInfo($"Transfer [PLAN VIEW APPEND SUFFIX]: ViewPlan '{srcViewPlan.Name}' already exists in target document. Option 'Append Suffix' active. Creating new ViewPlan with suffix...");
                                    targetPlanToUse = CreateViewPlan(sourceDoc, targetDoc, srcViewPlan, levelMappings, config.cf_chk_ForceLevelInLevelBaseViews, config, forceNewSuffixedView: true);
                                }
                                else if (config.cf_rbKeepOriginal)
                                {
                                    LoggerService.LogInfo($"Transfer: ViewPlan '{srcViewPlan.Name}' already exists in target document. Option 'Keep Original' active. Re-using existing target view for graphics/2D synchronization.");
                                    targetPlanToUse = existingTargetView;
                                }
                            }
                            else
                            {
                                LoggerService.LogInfo($"Transfer: Creating new ViewPlan '{srcViewPlan.Name}' in target document...");
                                targetPlanToUse = CreateViewPlan(sourceDoc, targetDoc, srcViewPlan, levelMappings, config.cf_chk_ForceLevelInLevelBaseViews, config);
                            }

                            if (targetPlanToUse != null)
                            {
                                processedViewsMap[srcViewPlan.Id] = targetPlanToUse.Id;
                            }
                        }

                        LogTargetViewsCheckpoint(targetDoc, "11-AFTER_CREATE_VIEW_PLAN_RETURNED");

                        if (targetPlanToUse != null && targetPlanToUse.IsValidObject)
                        {
                            LoggerService.LogInfo($"Transfer: Calling matchPlantilla for '{targetPlanToUse.Name}'...");
                            matchPlantilla(sourceDoc, targetDoc, srcViewPlan, targetPlanToUse, options, config, duplicateItems);
                            SyncViewPhaseAndFilter(sourceDoc, targetDoc, srcViewPlan, targetPlanToUse);
                            EnsureViewerSymbolsVisible(targetDoc, targetPlanToUse, targetPlanToUse.Scale);
                            LogTargetViewsCheckpoint(targetDoc, "12-AFTER_MATCH_PLANTILLA");

                            if (config.cf_chk_ViewElements)
                            {
                                LoggerService.LogInfo($"Transfer: Calling ponDependientes for '{targetPlanToUse.Name}'...");
                                ElementId previousTargetPlanId = targetPlanToUse.Id;
                                View consolidatedPlan = ponDependientes(sourceDoc, srcViewPlan, targetPlanToUse, options);
                                if (consolidatedPlan != null && consolidatedPlan.IsValidObject)
                                {
                                    targetPlanToUse = consolidatedPlan;
                                    processedViewsMap[srcViewPlan.Id] = targetPlanToUse.Id;

                                    if (consolidatedPlan.Id != previousTargetPlanId)
                                    {
                                        LoggerService.LogInfo($"Transfer [CONSOLIDATED PLAN UPDATED]: Updated targetPlanToUse to {targetPlanToUse.Id.Value} ('{targetPlanToUse.Name}') after 2D consolidation.");

                                        LoggerService.LogInfo($"Transfer [RE-APPLYING TEMPLATE]: Re-applying matchPlantilla on consolidated plan view '{targetPlanToUse.Name}'...");
                                        matchPlantilla(sourceDoc, targetDoc, srcViewPlan, targetPlanToUse, options, config, duplicateItems);
                                        SyncViewPhaseAndFilter(sourceDoc, targetDoc, srcViewPlan, targetPlanToUse);
                                        EnsureViewerSymbolsVisible(targetDoc, targetPlanToUse, targetPlanToUse.Scale);
                                    }
                                }
                                LogTargetViewsCheckpoint(targetDoc, "13-AFTER_PON_DEPENDIENTES");
                            }

                            if (config.cf_chk_Callout)
                            {
                                LoggerService.LogInfo($"Transfer: Calling ponCallouts for '{targetPlanToUse.Name}'...");
                                ponCallouts(sourceDoc, targetDoc, srcViewPlan, targetPlanToUse, options, config.cf_chk_ViewElements, 1, transform != null, transform, config, processedViewsMap);
                                LogTargetViewsCheckpoint(targetDoc, "14-AFTER_PON_CALLOUTS");
                            }

                            if (config.cf_chk_Section)
                            {
                                LoggerService.LogInfo($"Transfer: Calling ponSections for '{targetPlanToUse.Name}'...");
                                ponSections(sourceDoc, targetDoc, srcViewPlan, targetPlanToUse, options, config.cf_chk_ViewElements, transform != null, transform, config, processedViewsMap);
                                LogTargetViewsCheckpoint(targetDoc, "15-AFTER_PON_SECTIONS");
                            }
                            // ── Final sweep: ensure ALL created section/callout views have
                            // their scale thresholds unlocked. This is a safety net because
                            // View Templates applied during ponCallouts/ponSections may have
                            // re-locked the SECTION_COARSER_SCALE_PULLDOWN parameter.
                            EnsureViewerSymbolsVisible(targetDoc, targetPlanToUse, targetPlanToUse.Scale);
                            if (processedViewsMap != null && processedViewsMap.Count > 0)
                            {
                                LoggerService.LogInfo($"Transfer [FINAL SWEEP]: Ensuring scale thresholds on {processedViewsMap.Count} mapped views...");
                                foreach (var kvp in processedViewsMap)
                                {
                                    try
                                    {
                                        View mappedView = targetDoc.GetElement(kvp.Value) as View;
                                        if (mappedView != null && mappedView.IsValidObject
                                            && (mappedView.ViewType == ViewType.Section
                                                || mappedView.ViewType == ViewType.Detail
                                                || mappedView is ViewPlan))
                                        {
                                            EnsureViewerSymbolsVisible(targetDoc, mappedView, targetPlanToUse.Scale);
                                        }
                                    }
                                    catch { }
                                }
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

    public static View ponDependientes(Document origen, ICollection<ElementId> dependientes, View vistaorigen, View vistadestino, CopyPasteOptions copyOptions)
    {
        return ponDependientes(origen, vistaorigen, vistadestino, copyOptions);
    }

    public static bool Is2DViewForCopy(View view)
    {
        if (view == null) return false;
        if (view is View3D || view is ViewSchedule || view is ViewSheet) return false;
        ViewType vt = view.ViewType;
        return vt == ViewType.FloorPlan ||
               vt == ViewType.CeilingPlan ||
               vt == ViewType.EngineeringPlan ||
               vt == ViewType.AreaPlan ||
               vt == ViewType.Section ||
               vt == ViewType.Elevation ||
               vt == ViewType.DraftingView;
    }

    public static bool IsCalloutView(View view)
    {
        if (view == null) return false;
        try
        {
            var param = view.get_Parameter(BuiltInParameter.SECTION_PARENT_VIEW_NAME);
            if (param != null && !string.IsNullOrWhiteSpace(param.AsString())) return true;
        }
        catch { }
        if (view.ViewType == ViewType.Section || view.ViewType == ViewType.Elevation) return true;
        if (view.Name != null && (view.Name.IndexOf("Llamada", StringComparison.OrdinalIgnoreCase) >= 0 || view.Name.IndexOf("Callout", StringComparison.OrdinalIgnoreCase) >= 0)) return true;
        return false;
    }

    public static List<ElementId> Copy2DElementsViaDraftingBridge(
        View vistaorigen,
        List<ElementId> elementIdsToCopy,
        View vistadestino,
        CopyPasteOptions copyOptions)
    {
        var resultIds = new List<ElementId>();
        if (vistaorigen == null || vistadestino == null || elementIdsToCopy == null || !elementIdsToCopy.Any()) return resultIds;
        if (!Is2DViewForCopy(vistaorigen) || !Is2DViewForCopy(vistadestino)) return resultIds;

        Document targetDoc = vistadestino.Document;

        ViewFamilyType draftingVft = new FilteredElementCollector(targetDoc)
            .OfClass(typeof(ViewFamilyType))
            .Cast<ViewFamilyType>()
            .FirstOrDefault(vft => vft.ViewFamily == ViewFamily.Drafting);

        if (draftingVft == null)
        {
            LoggerService.LogWarning("Copy2DElementsViaDraftingBridge: No ViewFamilyType found for ViewFamily.Drafting in target document.");
            return resultIds;
        }

        ViewDrafting tempDrafting = null;
        try
        {
            tempDrafting = ViewDrafting.Create(targetDoc, draftingVft.Id);
            tempDrafting.Name = "TransferPlus_DraftingBridge_" + Guid.NewGuid().ToString().Substring(0, 8);
            targetDoc.Regenerate();

            LoggerService.LogInfo($"Copy2DElementsViaDraftingBridge: Step 1 - Copying {elementIdsToCopy.Count} 2D elements from '{vistaorigen.Name}' to temporary Drafting View '{tempDrafting.Name}'...");
            var tempCopiedIds = ElementTransformUtils.CopyElements(vistaorigen, elementIdsToCopy, tempDrafting, Transform.Identity, copyOptions);

            if (tempCopiedIds != null && tempCopiedIds.Any())
            {
                targetDoc.Regenerate();
                LoggerService.LogInfo($"Copy2DElementsViaDraftingBridge: Step 2 - Copying {tempCopiedIds.Count} 2D elements from temporary Drafting View to target view '{vistadestino.Name}'...");
                var finalCopiedIds = ElementTransformUtils.CopyElements(tempDrafting, tempCopiedIds.ToList(), vistadestino, Transform.Identity, copyOptions);

                if (finalCopiedIds != null)
                {
                    resultIds.AddRange(finalCopiedIds);
                    LoggerService.LogInfo($"Copy2DElementsViaDraftingBridge [SUCCESS]: Successfully transferred {resultIds.Count} 2D elements to '{vistadestino.Name}' via Drafting View Bridge!");
                }
            }
        }
        catch (Exception exBridge)
        {
            LoggerService.LogWarning($"Copy2DElementsViaDraftingBridge [EXCEPTION]: {exBridge.Message}");
        }
        finally
        {
            if (tempDrafting != null && tempDrafting.IsValidObject)
            {
                try
                {
                    targetDoc.Delete(tempDrafting.Id);
                    LoggerService.LogInfo($"Copy2DElementsViaDraftingBridge: Cleaned up temporary Drafting View (Id: {tempDrafting.Id.Value}).");
                }
                catch (Exception exDel)
                {
                    LoggerService.LogWarning($"Copy2DElementsViaDraftingBridge: Could not delete temp Drafting View: {exDel.Message}");
                }
            }
        }

        return resultIds;
    }

    public static View ponDependientes(Document origen, View vistaorigen, View vistadestino, CopyPasteOptions copyOptions)
    {
        if (vistaorigen == null || vistadestino == null) return vistadestino;

        if (!Is2DViewForCopy(vistaorigen) || !Is2DViewForCopy(vistadestino))
        {
            LoggerService.LogInfo($"ponDependientes: View '{vistaorigen.Name}' (Type: {vistaorigen.ViewType}) or '{vistadestino.Name}' (Type: {vistadestino.ViewType}) is not a 2D graphical view. Revit API does not support view-to-view 2D copying for 3D/Schedule/Sheet views. Skipping 2D element copy.");
            return vistadestino;
        }

        if (copyOptions == null) copyOptions = new CopyPasteOptions();
        copyOptions.SetDuplicateTypeNamesHandler(new CustomCopyHandlerOk());

        LoggerService.LogInfo($"ponDependientes: Collecting 2D view elements for view '{vistaorigen.Name}' (Source ViewId: {vistaorigen.Id.Value})...");

        var viewElements = new FilteredElementCollector(origen, vistaorigen.Id)
            .WhereElementIsNotElementType()
            .Where(e => e != null && e.IsValidObject && e.ViewSpecific && 
                        e is not View && 
                        e is not Viewport && 
                        e is not SunAndShadowSettings && 
                        e is not Level && 
                        e is not SketchPlane &&
                        e is not ElevationMarker &&
                        e.GetType().Name != "ReferenceViewer" &&
                        e.Name != "extentElem" &&
                        e.GetType().Name != "ViewCrop" &&
                        e.GetType().Name != "ExtentElem" &&
                        (e.Category == null || (
                            e.Category.Id.Value != (long)BuiltInCategory.OST_Viewers &&
                            e.Category.Id.Value != (long)BuiltInCategory.OST_ReferenceViewer &&
                            e.Category.Id.Value != (long)BuiltInCategory.OST_CalloutBoundary &&
                            e.Category.Id.Value != (long)BuiltInCategory.OST_Elev
                        )))
            .ToList();

        LoggerService.LogInfo($"ponDependientes: Filtered {viewElements.Count} pure 2D detail/annotation elements from source view '{vistaorigen.Name}'.");

        if (!viewElements.Any())
        {
            LoggerService.LogInfo($"ponDependientes: No 2D view elements found to copy for view '{vistaorigen.Name}'.");
            return vistadestino;
        }

        Document destino = vistadestino.Document;
        EnsureSourceLevelExistsInTarget(destino, vistaorigen.GenLevel);
        EnsureViewWorkplane(vistadestino);

        double targetZ = vistadestino.GenLevel != null ? vistadestino.GenLevel.Elevation : 0.0;
        double srcZ = vistaorigen.GenLevel != null ? vistaorigen.GenLevel.Elevation : 0.0;
        double deltaZ = targetZ - srcZ;

        LoggerService.LogInfo($"ponDependientes [ELEVATION TRACE]: Source View '{vistaorigen.Name}' (Level: '{vistaorigen.GenLevel?.Name}', Z={srcZ:F3} ft) -> Target View '{vistadestino.Name}' (Level: '{vistadestino.GenLevel?.Name}', Z={targetZ:F3} ft) | DeltaZ={deltaZ:F3} ft.");

        var all2DIds = viewElements.Select(e => e.Id).ToList();

        var existingViewIdsBeforeCopy = new HashSet<ElementId>(
            new FilteredElementCollector(destino)
                .OfClass(typeof(View))
                .WhereElementIsNotElementType()
                .Select(v => v.Id)
        );
        int viewsBefore = existingViewIdsBeforeCopy.Count;

        // FIX: Callout Views must bypass batch strategies entirely.
        // Batch CopyElements into a CalloutView always creates a side-effect sibling view ("Llamada N+1").
        // We route callout destinations directly to element-by-element (Strategy 3), which handles
        // per-element side-effects individually and prevents the phantom sibling cascade.
        bool targetIsCallout = IsCalloutView(vistadestino);
        if (targetIsCallout)
        {
            LoggerService.LogInfo($"ponDependientes [CALLOUT DIRECT PATH]: Target view '{vistadestino.Name}' is a Callout View. Skipping batch strategies to prevent side-effect sibling creation. Using element-by-element copy.");
            goto Strategy3;
        }

        // Strategy 1: Batch View-level CopyElements (Preserves connected line joins & 2D references!)
        try
        {
            LoggerService.LogInfo($"ponDependientes [BATCH VIEW COPY]: Copying {all2DIds.Count} 2D elements in batch via View-level CopyElements(Transform.Identity)...");
            var copiedBatchIds = ElementTransformUtils.CopyElements(vistaorigen, all2DIds, vistadestino, Transform.Identity, copyOptions);
            int viewsAfter = new FilteredElementCollector(destino).OfClass(typeof(View)).WhereElementIsNotElementType().Count();

            if (viewsAfter > viewsBefore)
            {
                var newlyCreatedViews = new FilteredElementCollector(destino)
                    .OfClass(typeof(View))
                    .WhereElementIsNotElementType()
                    .Cast<View>()
                    .Where(v => !existingViewIdsBeforeCopy.Contains(v.Id) && v.Id != vistadestino.Id)
                    .ToList();

                View sideEffectView = newlyCreatedViews.FirstOrDefault();
                if (sideEffectView != null && sideEffectView.IsValidObject)
                {
                    LoggerService.LogInfo($"ponDependientes [SIDE-EFFECT VIEW CONSOLIDATION]: Revit created view '{sideEffectView.Name}' (Id: {sideEffectView.Id.Value}) containing the copied {all2DIds.Count} 2D elements. Consolidating into single target view...");

                    if (IsCalloutView(vistadestino))
                    {
                        // This branch should never be reached now (guarded above), but kept as safety net.
                        LoggerService.LogInfo($"ponDependientes [CALLOUT VIEW PRESERVATION - SAFETY NET]: Target '{vistadestino.Name}' is Callout. Cleaning side-effect and falling through...");
                        try
                        {
                            destino.Delete(sideEffectView.Id);
                            LoggerService.LogInfo($"ponDependientes [CALLOUT CLEANUP]: Cleaned up temporary sideEffectView '{sideEffectView.Name}' (Id: {sideEffectView.Id.Value}).");
                        }
                        catch (Exception exClean)
                        {
                            LoggerService.LogWarning($"ponDependientes [CALLOUT CLEANUP FAILED]: Could not delete side-effect view '{sideEffectView.Name}' (Id: {sideEffectView.Id.Value}): {exClean.Message}");
                        }
                        return vistadestino;
                    }

                    string targetName = vistadestino.Name;
                    ElementId emptyViewId = vistadestino.Id;

                    // Copy view settings & instance parameters to sideEffectView
                    CopyViewSettings(vistaorigen, sideEffectView);
                    CopyViewInstanceParameters(vistaorigen, sideEffectView);

                    // Delete the initial empty target view to free up the desired view name
                    try
                    {
                        destino.Delete(emptyViewId);
                        LoggerService.LogInfo($"ponDependientes [CONSOLIDATION]: Deleted empty initial view (Id: {emptyViewId.Value}).");
                    }
                    catch (Exception exDel)
                    {
                        LoggerService.LogWarning($"ponDependientes [CONSOLIDATION]: Could not delete initial empty view: {exDel.Message}");
                    }

                    // Rename sideEffectView to targetName
                    try
                    {
                        sideEffectView.Name = targetName;
                        LoggerService.LogInfo($"ponDependientes [CONSOLIDATION SUCCESS]: Renamed view '{sideEffectView.Id.Value}' to '{sideEffectView.Name}'. 100% 2D elements consolidated into single view!");
                    }
                    catch (Exception exRename)
                    {
                        LoggerService.LogWarning($"ponDependientes [CONSOLIDATION RENAME FALLBACK]: Could not set name '{targetName}': {exRename.Message}");
                    }

                    return sideEffectView;
                }
            }
            else if (copiedBatchIds != null && copiedBatchIds.Any())
            {
                LoggerService.LogInfo($"ponDependientes [BATCH VIEW OK]: Successfully copied {copiedBatchIds.Count} 2D elements into '{vistadestino.Name}' in a single batch!");
                return vistadestino;
            }
        }
        catch (Exception exBatchView)
        {
            LoggerService.LogWarning($"ponDependientes [BATCH VIEW FALLBACK]: Batch view-level copy failed: {exBatchView.Message}. Trying Batch Doc-level copy...");
        }

        // Strategy 2: Batch Document-level CopyElements with 3D deltaZ translation vector
        if (Math.Abs(deltaZ) > 0.0001)
        {
            try
            {
                Transform docCopyTransform = Transform.CreateTranslation(new XYZ(0, 0, deltaZ));
                LoggerService.LogInfo($"ponDependientes [BATCH DOC COPY]: Copying {all2DIds.Count} 2D elements in batch via Document-level CopyElements...");
                var copiedDocIds = ElementTransformUtils.CopyElements(origen, all2DIds, destino, docCopyTransform, copyOptions);
                int viewsAfter = new FilteredElementCollector(destino).OfClass(typeof(View)).WhereElementIsNotElementType().Count();

                if (viewsAfter > viewsBefore)
                {
                    LoggerService.LogWarning($"ponDependientes [BATCH DOC DUPLICATION DETECTED!]: Batch doc copy caused Revit to duplicate the view! Deleting duplicated view...");
                    var newlyCreatedViews = new FilteredElementCollector(destino)
                        .OfClass(typeof(View))
                        .WhereElementIsNotElementType()
                        .Cast<View>()
                        .Where(v => !existingViewIdsBeforeCopy.Contains(v.Id) && v.Id != vistadestino.Id)
                        .ToList();

                    foreach (var dupView in newlyCreatedViews)
                    {
                        try { destino.Delete(dupView.Id); } catch { }
                    }
                }
                else if (copiedDocIds != null && copiedDocIds.Any())
                {
                    LoggerService.LogInfo($"ponDependientes [BATCH DOC OK]: Successfully copied {copiedDocIds.Count} 2D elements via Document-level CopyElements!");
                    return vistadestino;
                }
            }
            catch (Exception exBatchDoc)
            {
                LoggerService.LogWarning($"ponDependientes [BATCH DOC FALLBACK]: Batch doc-level copy failed: {exBatchDoc.Message}. Falling back to element-by-element copy...");
            }
        }

        // Strategy 3: Element-by-element fallback with failure tracking and duplication protection
        Strategy3:
        int copiedCount = 0;
        int skippedTriggerCount = 0;
        var failedElementsSummary = new List<string>();

        foreach (Element elem in viewElements)
        {
            string catName = elem.Category?.Name ?? "NoCategory";
            long catId = elem.Category?.Id.Value ?? -1;
            string className = elem.GetType().Name;

            if (elem.Name.StartsWith("extentElem", StringComparison.OrdinalIgnoreCase) ||
                elem.Name.StartsWith("ViewCrop", StringComparison.OrdinalIgnoreCase) ||
                className.Equals("ViewCrop", StringComparison.OrdinalIgnoreCase) ||
                className.Equals("ExtentElem", StringComparison.OrdinalIgnoreCase))
            {
                LoggerService.LogInfo($"ponDependientes [SKIP EXTENT]: Excluding view extent element '{elem.Name}' [Id: {elem.Id.Value}] from 2D copy.");
                continue;
            }

            int vBefore = new FilteredElementCollector(destino).OfClass(typeof(View)).WhereElementIsNotElementType().Count();

            try
            {
                LoggerService.LogInfo($"ponDependientes [VIEW-LEVEL COPY]: Copying 2D element '{elem.Name}' (Category: '{catName}', Class: '{className}', Id: {elem.Id.Value}) via View-level CopyElements(Transform.Identity)...");
                var copiedIds = ElementTransformUtils.CopyElements(vistaorigen, new List<ElementId> { elem.Id }, vistadestino, Transform.Identity, copyOptions);
                int vAfter = new FilteredElementCollector(destino).OfClass(typeof(View)).WhereElementIsNotElementType().Count();

                if (vAfter > vBefore)
                {
                    LoggerService.LogWarning($"ponDependientes [VIEW DUPLICATION TRIGGER DETECTED!]: Element '{elem.Name}' (Category: '{catName}' [Id: {catId}], Class: '{className}', Id: {elem.Id.Value}) CAUSED REVIT TO DUPLICATE THE VIEW!");

                    var newlyCreatedViews = new FilteredElementCollector(destino)
                        .OfClass(typeof(View))
                        .WhereElementIsNotElementType()
                        .Cast<View>()
                        .Where(v => !existingViewIdsBeforeCopy.Contains(v.Id) && v.Id != vistadestino.Id)
                        .ToList();

                    foreach (var dupView in newlyCreatedViews)
                    {
                        try
                        {
                            destino.Delete(dupView.Id);
                            LoggerService.LogInfo($"ponDependientes [CLEANUP DUP VIEW]: Deleted side-effect duplicated view '{dupView.Name}' (Id: {dupView.Id.Value}).");
                        }
                        catch { }
                    }
                    skippedTriggerCount++;
                }
                else if (copiedIds != null && copiedIds.Any())
                {
                    copiedCount++;
                    LoggerService.LogInfo($"ponDependientes [VIEW-LEVEL OK]: Successfully copied 2D element '{elem.Name}' (Category: '{catName}', Class: '{className}', Id: {elem.Id.Value}).");
                }
            }
            catch (Exception exElem)
            {
                string failMsg = $"• '{elem.Name}' (Id: {elem.Id.Value}, Category: '{catName}') - {exElem.Message}";
                failedElementsSummary.Add(failMsg);
                LoggerService.LogWarning($"ponDependientes [FAILED]: Could not copy 2D element '{elem.Name}' (Category: '{catName}', Id: {elem.Id.Value}) into target view '{vistadestino.Name}': {exElem.Message}");
            }
        }

        LoggerService.LogInfo($"ponDependientes [SUMMARY]: Element-by-element copy complete for '{vistadestino.Name}'. Successfully Copied: {copiedCount}, Failed 2D Elements: {failedElementsSummary.Count}, Skipped/Cleaned Duplicating Triggers: {skippedTriggerCount}.");

        if (failedElementsSummary.Any())
        {
            string msgDetails = string.Join("\n", failedElementsSummary.Take(10));
            if (failedElementsSummary.Count > 10)
            {
                msgDetails += $"\n... and {failedElementsSummary.Count - 10} additional 2D elements.";
            }

            try
            {
                Autodesk.Revit.UI.TaskDialog mainDialog = new Autodesk.Revit.UI.TaskDialog("TransferPlus - 2D Elements Warning")
                {
                    MainInstruction = $"Could not transfer {failedElementsSummary.Count} 2D elements to view '{vistadestino.Name}'.",
                    MainContent = $"Cause: Revit API restriction when copying 2D view-dependent elements (Detail Lines/Annotations) across levels with different elevations.\n\n" +
                                  $"• Source Level ({vistaorigen.GenLevel?.Name}): Z = {srcZ:F3} ft\n" +
                                  $"• Target Level ({vistadestino.GenLevel?.Name}): Z = {targetZ:F3} ft\n" +
                                  $"• Elevation Offset (DeltaZ): {deltaZ:F3} ft\n\n" +
                                  $"The target view was created successfully, but Revit API prevents transferring the following 2D elements off-plane:\n\n{msgDetails}",
                    CommonButtons = Autodesk.Revit.UI.TaskDialogCommonButtons.Ok,
                    DefaultButton = Autodesk.Revit.UI.TaskDialogResult.Ok,
                    MainIcon = Autodesk.Revit.UI.TaskDialogIcon.TaskDialogIconWarning
                };
                mainDialog.Show();
            }
            catch (Exception exDlg)
            {
                        LoggerService.LogWarning($"ponDependientes: Could not display TaskDialog: {exDlg.Message}");
            }
        }

        return vistadestino;
    }

    private static ElementId GetMatchingViewFamilyType(Document sourceDoc, Document targetDoc, ElementId srcVftId)
    {
        if (sourceDoc == null || targetDoc == null || srcVftId == null || srcVftId == ElementId.InvalidElementId)
            return ElementId.InvalidElementId;

        ViewFamilyType srcVft = sourceDoc.GetElement(srcVftId) as ViewFamilyType;
        if (srcVft == null) return ElementId.InvalidElementId;

        ViewFamilyType targetVft = new FilteredElementCollector(targetDoc)
            .OfClass(typeof(ViewFamilyType))
            .Cast<ViewFamilyType>()
            .FirstOrDefault(vft => vft.Name.Equals(srcVft.Name, StringComparison.OrdinalIgnoreCase) && vft.ViewFamily == srcVft.ViewFamily)
            ?? new FilteredElementCollector(targetDoc)
            .OfClass(typeof(ViewFamilyType))
            .Cast<ViewFamilyType>()
            .FirstOrDefault(vft => vft.ViewFamily == srcVft.ViewFamily);

        return targetVft?.Id ?? ElementId.InvalidElementId;
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
        Transform? T,
        Configuraciones? config = null,
        Dictionary<ElementId, ElementId>? processedViewsMap = null)
    {
        if (origen == null || destino == null || vistaorigen == null || vistadestino == null) return;

        if (Contador > 2)
        {
            LoggerService.LogInfo($"ponCallouts: Reached max callout depth (Contador={Contador}) on view '{vistaorigen.Name}'. Stopping callout traversal.");
            return;
        }

        try
        {
            vistadestino.SetCategoryHidden(new ElementId(BuiltInCategory.OST_Viewers), false);
            vistadestino.SetCategoryHidden(new ElementId(BuiltInCategory.OST_CalloutBoundary), false);
        }
        catch { }

        // DIAGNOSTIC LOGGING FOR CALLOUT DISCOVERY
        LoggerService.LogInfo($"ponCallouts [DIAGNOSTIC START]: Inspecting source view '{vistaorigen.Name}' (Id: {vistaorigen.Id.Value}, Type: {vistaorigen.ViewType})...");

        // 1. Collect ALL Viewer Symbols (annotations) in document
        var allViewersInDoc = new FilteredElementCollector(origen)
            .WhereElementIsNotElementType()
            .Where(e => e != null && e.IsValidObject && e.Category != null &&
                (e.Category.Id.Value == (long)BuiltInCategory.OST_Viewers ||
                 e.Category.Id.Value == (long)BuiltInCategory.OST_CalloutBoundary ||
                 e.Category.Id.Value == (long)BuiltInCategory.OST_ReferenceViewer))
            .ToList();

        LoggerService.LogInfo($"ponCallouts [DIAGNOSTIC]: Total viewers in entire source document: {allViewersInDoc.Count}");
        foreach (var vElem in allViewersInDoc)
        {
            var paramRefs = vElem.Parameters.Cast<Parameter>()
                .Where(p => p != null && p.StorageType == StorageType.ElementId && p.AsElementId() != ElementId.InvalidElementId)
                .Select(p => $"{p.Definition?.Name}={p.AsElementId().Value}")
                .ToList();

            LoggerService.LogInfo($"  -> Viewer Symbol Id: {vElem.Id.Value} | Category: '{vElem.Category?.Name}' | OwnerViewId: {vElem.OwnerViewId?.Value ?? -1} | Parameters: [{string.Join(", ", paramRefs)}]");
        }

        var viewersOnVistaOrigen = allViewersInDoc.Where(e => e.OwnerViewId != null && e.OwnerViewId.Value == vistaorigen.Id.Value).ToList();

        // 2. Discover child Callout Views linked to vistaorigen
        List<ElementId> depIds = vistaorigen.GetDependentElements(null)?.ToList() ?? new List<ElementId>();
        List<Element> depElements = depIds.Select(id => origen.GetElement(id)).Where(e => e != null && e.IsValidObject).ToList();

        var childViewsOnSource = depElements.OfType<View>()
            .Where(v => v != null && v.IsValidObject && !v.IsTemplate && v.Id.Value != vistaorigen.Id.Value)
            .ToList();

        // Also check views where SECTION_PARENT_VIEW_NAME matches vistaorigen.Name
        foreach (View v in new FilteredElementCollector(origen).OfClass(typeof(View)).Cast<View>())
        {
            if (v == null || !v.IsValidObject || v.IsTemplate || v.Id.Value == vistaorigen.Id.Value) continue;
            var parentParam = v.get_Parameter(BuiltInParameter.SECTION_PARENT_VIEW_NAME);
            if (parentParam != null && !string.IsNullOrWhiteSpace(parentParam.AsString()) &&
                parentParam.AsString().Equals(vistaorigen.Name, StringComparison.OrdinalIgnoreCase))
            {
                if (!childViewsOnSource.Any(cv => cv.Id.Value == v.Id.Value))
                {
                    childViewsOnSource.Add(v);
                }
            }
        }

        // 3. For each child view, pair it with its viewer symbol
        var calloutPairs = new List<(View calloutView, Element? viewerSymbol)>();
        var processedCalloutIds = new HashSet<long>();

        foreach (View v in childViewsOnSource)
        {
            if (!processedCalloutIds.Add(v.Id.Value)) continue;

            Element? viewerSym = viewersOnVistaOrigen.FirstOrDefault(e =>
                e.Parameters.Cast<Parameter>().Any(p => p != null && p.StorageType == StorageType.ElementId && p.AsElementId() != null && p.AsElementId().Value == v.Id.Value));

            if (viewerSym == null)
            {
                viewerSym = allViewersInDoc.FirstOrDefault(e =>
                    e.Parameters.Cast<Parameter>().Any(p => p != null && p.StorageType == StorageType.ElementId && p.AsElementId() != null && p.AsElementId().Value == v.Id.Value));
            }

            if (viewerSym == null)
            {
                viewerSym = depElements.Where(e => e is not View && e.Id.Value != vistaorigen.Id.Value)
                    .FirstOrDefault(e => e.Parameters.Cast<Parameter>().Any(p => p != null && p.StorageType == StorageType.ElementId && p.AsElementId() != null && p.AsElementId().Value == v.Id.Value));
            }

            if (viewerSym == null && viewersOnVistaOrigen.Count == 1 && childViewsOnSource.Count == 1)
            {
                viewerSym = viewersOnVistaOrigen.First();
            }

            if (viewerSym == null && viewersOnVistaOrigen.Any())
            {
                var usedSymbols = calloutPairs.Select(p => p.viewerSymbol?.Id?.Value).Where(id => id.HasValue).ToHashSet();
                viewerSym = viewersOnVistaOrigen.FirstOrDefault(e => !usedSymbols.Contains(e.Id.Value));
            }

            if (viewerSym == null && allViewersInDoc.Any())
            {
                var usedSymbols = calloutPairs.Select(p => p.viewerSymbol?.Id?.Value).Where(id => id.HasValue).ToHashSet();
                viewerSym = allViewersInDoc.FirstOrDefault(e => !usedSymbols.Contains(e.Id.Value));
            }

            calloutPairs.Add((v, viewerSym));
        }

        LoggerService.LogInfo($"ponCallouts: Found {calloutPairs.Count} callout view(s) on source view '{vistaorigen.Name}'.");

        foreach (var (calloutView, viewerSymbol) in calloutPairs)
        {
            if (calloutView == null || !calloutView.IsValidObject) continue;

            if (processedViewsMap != null && processedViewsMap.TryGetValue(calloutView.Id, out ElementId mappedCalloutId))
            {
                View mappedCallout = destino.GetElement(mappedCalloutId) as View;
                if (mappedCallout != null && mappedCallout.IsValidObject)
                {
                    LoggerService.LogInfo($"ponCallouts: Callout view '{calloutView.Name}' was already processed in this run (Target ViewId: {mappedCalloutId.Value}). Re-using mapped callout.");
                    if (CopiaDetalles)
                    {
                        View consolidatedMapped = ponDependientes(origen, calloutView, mappedCallout, copyOptions);
                        if (consolidatedMapped != null && consolidatedMapped.IsValidObject)
                        {
                            mappedCallout = consolidatedMapped;
                            processedViewsMap[calloutView.Id] = mappedCallout.Id;
                        }
                    }
                    ponCallouts(origen, destino, calloutView, mappedCallout, copyOptions, CopiaDetalles, Contador + 1, transforma, T, config, processedViewsMap);
                    continue;
                }
            }

            View existingCallout = FindExistingViewByName(destino, calloutView.Name);
            if (existingCallout != null && existingCallout.IsValidObject)
            {
                LoggerService.LogInfo($"ponCallouts: Callout view '{calloutView.Name}' already exists in target document (Target ViewId: {existingCallout.Id.Value}). Re-using existing callout view.");
                if (CopiaDetalles)
                {
                    View consolidatedExisting = ponDependientes(origen, calloutView, existingCallout, copyOptions);
                    if (consolidatedExisting != null && consolidatedExisting.IsValidObject)
                    {
                        existingCallout = consolidatedExisting;
                    }
                }
                if (config != null)
                {
                    matchPlantilla(origen, destino, calloutView, existingCallout, copyOptions, config, new List<TransferPlus.Models.DuplicateElementInfo>());
                }
                if (processedViewsMap != null) processedViewsMap[calloutView.Id] = existingCallout.Id;
                ponCallouts(origen, destino, calloutView, existingCallout, copyOptions, CopiaDetalles, Contador + 1, transforma, T, config, processedViewsMap);
                continue;
            }

            try
            {
                View targetCalloutView = null;

                // Try native View.CreateCallout API to draw the physical Callout Bubble on vistadestino
                try
                {
                    ElementId targetVftId = GetMatchingViewFamilyType(origen, destino, calloutView.GetTypeId());
                    BoundingBoxXYZ cropBox = calloutView.CropBox;

                    if (targetVftId != ElementId.InvalidElementId && cropBox != null)
                    {
                        // --- STRATEGY: EXACT RELATIVE VIEW-SPACE MAPPING (matching CopyElements) ---
                        // Use parent view's fixed 2D plane coordinate system (view.Origin), which matches
                        // Revit's CopyElements 2D coordinate space. This ensures the callout bubble is drawn
                        // over the exact same situation of elements as in the source file, regardless of crop box center offsets.

                        Transform calloutTf = cropBox.Transform ?? Transform.Identity;

                        // Always use parent view's fixed plane origin and orientation
                        Transform srcParentTf = Transform.Identity;
                        srcParentTf.Origin = vistaorigen.Origin;
                        srcParentTf.BasisX = vistaorigen.RightDirection;
                        srcParentTf.BasisY = vistaorigen.UpDirection;
                        srcParentTf.BasisZ = vistaorigen.ViewDirection;

                        Transform tgtParentTf = Transform.Identity;
                        tgtParentTf.Origin = vistadestino.Origin;
                        tgtParentTf.BasisX = vistadestino.RightDirection;
                        tgtParentTf.BasisY = vistadestino.UpDirection;
                        tgtParentTf.BasisZ = vistadestino.ViewDirection;


                        // Collect 8 corners of the callout crop box in local callout space
                        XYZ cMin = cropBox.Min;
                        XYZ cMax = cropBox.Max;
                        XYZ[] localCorners = new XYZ[]
                        {
                            new XYZ(cMin.X, cMin.Y, cMin.Z),
                            new XYZ(cMax.X, cMin.Y, cMin.Z),
                            new XYZ(cMin.X, cMax.Y, cMin.Z),
                            new XYZ(cMax.X, cMax.Y, cMin.Z),
                            new XYZ(cMin.X, cMin.Y, cMax.Z),
                            new XYZ(cMax.X, cMin.Y, cMax.Z),
                            new XYZ(cMin.X, cMax.Y, cMax.Z),
                            new XYZ(cMax.X, cMax.Y, cMax.Z)
                        };

                        List<XYZ> targetWorldCorners = new List<XYZ>();

                        foreach (XYZ corner in localCorners)
                        {
                            XYZ tgtWorldPt;
                            if (transforma && T != null)
                            {
                                // Transformed directly by link/shared coordinates matrix T
                                tgtWorldPt = T.OfPoint(calloutTf.OfPoint(corner));
                            }
                            else
                            {
                                // 1. Local callout corner -> Source World point
                                XYZ srcWorldPt = calloutTf.OfPoint(corner);

                                // 2. Source World point -> vistaorigen 2D local space (u, v, w)
                                XYZ deltaSrc = srcWorldPt - srcParentTf.Origin;
                                double u = deltaSrc.DotProduct(srcParentTf.BasisX);
                                double v = deltaSrc.DotProduct(srcParentTf.BasisY);
                                double w = deltaSrc.DotProduct(srcParentTf.BasisZ);

                                // 3. (u, v, w) -> vistadestino Target World point
                                tgtWorldPt = tgtParentTf.Origin + u * tgtParentTf.BasisX + v * tgtParentTf.BasisY + w * tgtParentTf.BasisZ;
                            }
                            targetWorldCorners.Add(tgtWorldPt);
                        }

                        // 4. Compute bounding box pMin and pMax in Target World Space
                        double minX = targetWorldCorners.Min(p => p.X);
                        double minY = targetWorldCorners.Min(p => p.Y);
                        double minZ = targetWorldCorners.Min(p => p.Z);
                        double maxX = targetWorldCorners.Max(p => p.X);
                        double maxY = targetWorldCorners.Max(p => p.Y);
                        double maxZ = targetWorldCorners.Max(p => p.Z);

                        // Ensure adequate 3D depth centered on the parent view's cut plane
                        // so the 3D callout box intersects the parent view's cut plane across level elevation offsets.
                        double targetCutPlaneZ = vistadestino.Origin?.Z ?? 0.0;
                        try
                        {
                            if (vistadestino is ViewPlan vpTarget && vpTarget.GenLevel != null)
                            {
                                PlanViewRange pvr = vpTarget.GetViewRange();
                                double cutOffset = pvr.GetOffset(PlanViewPlane.CutPlane);
                                targetCutPlaneZ = vpTarget.GenLevel.Elevation + cutOffset;
                            }
                        }
                        catch { }

                        double zCenter = targetCutPlaneZ;
                        double zHalfDepth = Math.Max((maxZ - minZ) * 0.5, 15.0);

                        XYZ pMin = new XYZ(minX, minY, zCenter - zHalfDepth);
                        XYZ pMax = new XYZ(maxX, maxY, zCenter + zHalfDepth);

                        LoggerService.LogInfo($"ponCallouts [CALLOUT RELATIVE COORDS OK]: " +
                            $"Mapped {localCorners.Length} corners | Target pMin={pMin:F3} pMax={pMax:F3} (CutPlaneZ: {targetCutPlaneZ:F3})");

                        if (calloutView is ViewSection || calloutView is ViewPlan || calloutView.ViewType == ViewType.Section || calloutView.ViewType == ViewType.Detail || calloutView.ViewType == ViewType.FloorPlan || calloutView.ViewType == ViewType.EngineeringPlan)
                        {
                            LoggerService.LogInfo($"ponCallouts [NATIVE CALLOUT CREATION]: Calling ViewSection.CreateCallout on parent view '{vistadestino.Name}' (Id: {vistadestino.Id.Value}) for callout '{calloutView.Name}'...");
                            targetCalloutView = ViewSection.CreateCallout(destino, vistadestino.Id, targetVftId, pMin, pMax);
                        }
                    }

                }
                catch (Exception exNative)
                {
                    LoggerService.LogWarning($"ponCallouts [NATIVE CALLOUT EXCEPTION]: {exNative.Message}. Falling back to CopyElements.");
                }

                // Fallback to CopyElements if native CreateCallout did not produce a view
                if (targetCalloutView == null)
                {
                    ElementId elementToCopy = viewerSymbol != null ? viewerSymbol.Id : calloutView.Id;
                    if (viewerSymbol != null)
                    {
                        LoggerService.LogInfo($"ponCallouts: Copying callout bubble symbol (Category: '{viewerSymbol.Category?.Name}', Id: {viewerSymbol.Id.Value}) to draw callout boundary on target view '{vistadestino.Name}'.");
                    }
                    else
                    {
                        LoggerService.LogInfo($"ponCallouts: Viewer symbol not found for '{calloutView.Name}'. Copying view directly (Id: {calloutView.Id.Value}).");
                    }

                    var source = ElementTransformUtils.CopyElements(vistaorigen, new List<ElementId> { elementToCopy }, vistadestino, null, copyOptions);

                    targetCalloutView = source.Select(id => destino.GetElement(id)).OfType<View>().FirstOrDefault();

                    if (targetCalloutView == null && source.Any())
                    {
                        ElementId createdId = source.FirstOrDefault();
                        Element createdElem = destino.GetElement(createdId);
                        if (createdElem != null && createdElem.IsValidObject)
                        {
                            foreach (Parameter p in createdElem.Parameters)
                            {
                                if (p != null && p.StorageType == StorageType.ElementId)
                                {
                                    ElementId targetId = p.AsElementId();
                                    if (targetId != null && targetId != ElementId.InvalidElementId && targetId != vistadestino.Id)
                                    {
                                        if (destino.GetElement(targetId) is View targetView)
                                        {
                                            targetCalloutView = targetView;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (targetCalloutView == null)
                    {
                        targetCalloutView = FindExistingViewByName(destino, calloutView.Name);
                    }
                }

                if (targetCalloutView != null && targetCalloutView.IsValidObject)
                {
                    LoggerService.LogInfo($"ponCallouts: Created linked callout view '{targetCalloutView.Name}' (Target ViewId: {targetCalloutView.Id.Value}). Transferring 2D elements and settings...");

                    // Sychronize Discipline
                    try
                    {
                        var srcDisciplineParam = calloutView.get_Parameter(BuiltInParameter.VIEW_DISCIPLINE);
                        var tgtDisciplineParam = targetCalloutView.get_Parameter(BuiltInParameter.VIEW_DISCIPLINE);
                        if (tgtDisciplineParam != null && !tgtDisciplineParam.IsReadOnly)
                        {
                            if (srcDisciplineParam != null)
                            {
                                tgtDisciplineParam.Set(srcDisciplineParam.AsInteger());
                            }
                            else
                            {
                                var parentDiscipline = vistadestino.get_Parameter(BuiltInParameter.VIEW_DISCIPLINE);
                                if (parentDiscipline != null)
                                {
                                    tgtDisciplineParam.Set(parentDiscipline.AsInteger());
                                }
                            }
                        }
                    }
                    catch { }

                    // Synchronize Phase and PhaseFilter
                    SyncViewPhaseAndFilter(origen, destino, calloutView, targetCalloutView);

                    // Ensure viewers and scale threshold are unlocked
                    EnsureViewerSymbolsVisible(destino, targetCalloutView, vistadestino.Scale);
                    EnsureViewerSymbolsVisible(destino, vistadestino, vistadestino.Scale);

                    // Only rename if the source name is not already occupied in the target document.
                    try
                    {
                        if (!targetCalloutView.Name.Equals(calloutView.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            bool nameAlreadyTaken = FindExistingViewByName(destino, calloutView.Name) != null;
                            if (!nameAlreadyTaken)
                            {
                                targetCalloutView.Name = calloutView.Name;
                                LoggerService.LogInfo($"ponCallouts [RENAME SUCCESS]: Renamed callout view to '{calloutView.Name}'.");
                            }
                            else
                            {
                                LoggerService.LogWarning($"ponCallouts [RENAME SKIPPED]: Name '{calloutView.Name}' already exists in target. Keeping current name '{targetCalloutView.Name}' to avoid duplicate.");
                            }
                        }
                    }
                    catch (Exception exRename)
                    {
                        LoggerService.LogWarning($"ponCallouts [RENAME FAILED]: Could not rename callout to '{calloutView.Name}': {exRename.Message}");
                    }

                    if (processedViewsMap != null) processedViewsMap[calloutView.Id] = targetCalloutView.Id;

                    if (config != null)
                    {
                        matchPlantilla(origen, destino, calloutView, targetCalloutView, copyOptions, config, new List<TransferPlus.Models.DuplicateElementInfo>());
                        SyncViewPhaseAndFilter(origen, destino, calloutView, targetCalloutView);
                        EnsureViewerSymbolsVisible(destino, targetCalloutView, vistadestino.Scale);
                        EnsureViewerSymbolsVisible(destino, vistadestino, vistadestino.Scale);
                    }

                    if (CopiaDetalles)
                    {
                        View consolidatedCallout = ponDependientes(origen, calloutView, targetCalloutView, copyOptions);
                        if (consolidatedCallout != null && consolidatedCallout.IsValidObject)
                        {
                            targetCalloutView = consolidatedCallout;
                            if (config != null)
                            {
                                matchPlantilla(origen, destino, calloutView, targetCalloutView, copyOptions, config, new List<TransferPlus.Models.DuplicateElementInfo>());
                                SyncViewPhaseAndFilter(origen, destino, calloutView, targetCalloutView);
                                EnsureViewerSymbolsVisible(destino, targetCalloutView, vistadestino.Scale);
                                EnsureViewerSymbolsVisible(destino, vistadestino, vistadestino.Scale);
                            }
                        }
                    }

                    EnsureViewerSymbolsVisible(destino, targetCalloutView, vistadestino.Scale);
                    EnsureViewerSymbolsVisible(destino, vistadestino, vistadestino.Scale);

                    if (processedViewsMap != null && targetCalloutView != null && targetCalloutView.IsValidObject)
                    {
                        processedViewsMap[calloutView.Id] = targetCalloutView.Id;
                    }

                    if (targetCalloutView != null && targetCalloutView.IsValidObject)
                    {
                        ponCallouts(origen, destino, calloutView, targetCalloutView, copyOptions, CopiaDetalles, Contador + 1, transforma, T, config, processedViewsMap);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerService.LogExceptionSilently($"ponCallouts - processing '{calloutView.Name}'", ex);
            }
        }
    }

    // ─────────────────────────────────────────────────────────────────────────
    // ponSections: Transfers Section AND Detail child views from a source
    // parent view to the corresponding target parent view.
    //
    // Architecture mirrors ponCallouts:
    //  1. Discover child Section/Detail views on vistaorigen.
    //  2. Skip already-processed views (processedViewsMap de-duplication).
    //  3. Reconstruct BoundingBoxXYZ with Transform in target coordinates.
    //  4. Create native ViewSection via ViewSection.CreateSection.
    //  5. Apply visibility safeguards (scale unlock, category unhide, template).
    //  6. Transfer 2D detail elements (ponDependientes).
    // ─────────────────────────────────────────────────────────────────────────
    public static void ponSections(
        Document origen,
        Document destino,
        View vistaorigen,
        View vistadestino,
        CopyPasteOptions copyOptions,
        bool CopiaDetalles,
        bool transforma,
        Transform? T,
        Configuraciones config,
        Dictionary<ElementId, ElementId>? processedViewsMap,
        int Contador = 1)
    {
        if (vistaorigen == null || !vistaorigen.IsValidObject) return;
        if (vistadestino == null || !vistadestino.IsValidObject) return;

        if (Contador > 2)
        {
            LoggerService.LogInfo($"ponSections: Reached max depth (Contador={Contador}) on view '{vistaorigen.Name}'. Stopping section traversal.");
            return;
        }

        LoggerService.LogInfo($"ponSections [START]: Inspecting source view '{vistaorigen.Name}' (Id: {vistaorigen.Id.Value}, Type: {vistaorigen.ViewType})...");

        try
        {
            // Initialize result list early so all strategies can contribute
            var childSectionViews = new List<View>();

            // ══════════════════════════════════════════════════════════════════
            // STRATEGY 0 (PRIMARY): View-scoped FilteredElementCollector + Dereferencing
            // ──────────────────────────────────────────────────────────────────
            // Scopes collector to vistaorigen.Id to retrieve OST_Viewers,
            // OST_CalloutBoundary, and OST_ReferenceViewer annotation marks.
            // ══════════════════════════════════════════════════════════════════
            try
            {
                var categories = new List<BuiltInCategory>
                {
                    BuiltInCategory.OST_Viewers,
                    BuiltInCategory.OST_CalloutBoundary,
                    BuiltInCategory.OST_ReferenceViewer,
                    BuiltInCategory.OST_Elev
                };

                var multiCatFilter = new ElementMulticategoryFilter(categories);
                var viewScopedViewers = new FilteredElementCollector(origen, vistaorigen.Id)
                    .WherePasses(multiCatFilter)
                    .WhereElementIsNotElementType()
                    .ToList();

                LoggerService.LogInfo($"ponSections [STRATEGY 0]: Found {viewScopedViewers.Count} view-scoped viewer mark(s) on '{vistaorigen.Name}' (Id: {vistaorigen.Id.Value}).");

                foreach (var viewer in viewScopedViewers)
                {
                    LoggerService.LogInfo($"  [Viewer Mark {viewer.Id.Value}]: Name='{viewer.Name}', Cat='{viewer.Category?.Name}', Type='{viewer.GetType().Name}', OwnerView='{viewer.OwnerViewId?.Value}'");

                    // 0a. Check all ElementId parameters on the viewer symbol
                    foreach (Parameter p in viewer.Parameters)
                    {
                        if (p != null && p.StorageType == StorageType.ElementId &&
                            p.AsElementId() is ElementId refId &&
                            refId != ElementId.InvalidElementId)
                        {
                            Element refElem = origen.GetElement(refId);
                            if (refElem != null)
                            {
                                string targetInfo = $"{refElem.GetType().Name} '{refElem.Name}' (Cat: {refElem.Category?.Name})";
                                if (refElem is View testV) targetInfo += $" [ViewType: {testV.ViewType}, IsTemplate: {testV.IsTemplate}]";
                                LoggerService.LogInfo($"    -> Param '{p.Definition?.Name}' ({p.Id.Value}) = {refId.Value} -> Element: {targetInfo}");

                                // Case 1: Direct View reference
                                if (refElem is View refView && refView.IsValidObject && !refView.IsTemplate &&
                                    refView.Id.Value != vistaorigen.Id.Value &&
                                    (refView.ViewType == ViewType.Section || refView.ViewType == ViewType.Detail || refView.ViewType == ViewType.Elevation))
                                {
                                    if (!childSectionViews.Any(cv => cv.Id.Value == refView.Id.Value))
                                    {
                                        childSectionViews.Add(refView);
                                        LoggerService.LogInfo($"ponSections [DISCOVERY via Strategy 0 Direct View]: Found '{refView.Name}' (Id: {refView.Id.Value}) via viewer mark {viewer.Id.Value}");
                                    }
                                }

                                // Case 2: Viewport reference (Viewport -> View)
                                else if (refElem is Viewport vp && vp.IsValidObject && vp.ViewId != ElementId.InvalidElementId)
                                {
                                    if (origen.GetElement(vp.ViewId) is View vpView && vpView.IsValidObject && !vpView.IsTemplate &&
                                        vpView.Id.Value != vistaorigen.Id.Value &&
                                        (vpView.ViewType == ViewType.Section || vpView.ViewType == ViewType.Detail || vpView.ViewType == ViewType.Elevation))
                                    {
                                        if (!childSectionViews.Any(cv => cv.Id.Value == vpView.Id.Value))
                                        {
                                            childSectionViews.Add(vpView);
                                            LoggerService.LogInfo($"ponSections [DISCOVERY via Strategy 0 Viewport]: Found '{vpView.Name}' (Id: {vpView.Id.Value}) via viewport {vp.Id.Value}");
                                        }
                                    }
                                }

                                // Case 3: ElevationMarker reference
                                else if (refElem is ElevationMarker em && em.IsValidObject)
                                {
                                    for (int idx = 0; idx < em.MaximumViewCount; idx++)
                                    {
                                        ElementId vId = em.GetViewId(idx);
                                        if (vId != ElementId.InvalidElementId && origen.GetElement(vId) is View emView &&
                                            emView.IsValidObject && !emView.IsTemplate && emView.Id.Value != vistaorigen.Id.Value)
                                        {
                                            if (!childSectionViews.Any(cv => cv.Id.Value == emView.Id.Value))
                                            {
                                                childSectionViews.Add(emView);
                                                LoggerService.LogInfo($"ponSections [DISCOVERY via Strategy 0 ElevationMarker]: Found '{emView.Name}' (Id: {emView.Id.Value}) via marker {em.Id.Value}");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // 0b. Check dependent elements of the viewer symbol itself
                    try
                    {
                        var vDepIds = viewer.GetDependentElements(null);
                        if (vDepIds != null)
                        {
                            foreach (var depId in vDepIds)
                            {
                                if (depId != ElementId.InvalidElementId && origen.GetElement(depId) is View depView &&
                                    depView.IsValidObject && !depView.IsTemplate && depView.Id.Value != vistaorigen.Id.Value &&
                                    (depView.ViewType == ViewType.Section || depView.ViewType == ViewType.Detail || depView.ViewType == ViewType.Elevation))
                                {
                                    if (!childSectionViews.Any(cv => cv.Id.Value == depView.Id.Value))
                                    {
                                        childSectionViews.Add(depView);
                                        LoggerService.LogInfo($"ponSections [DISCOVERY via Strategy 0 Viewer Dependent]: Found '{depView.Name}' (Id: {depView.Id.Value})");
                                    }
                                }
                            }
                        }
                    }
                    catch { }
                }
            }
            catch (Exception exS0)
            {
                LoggerService.LogWarning($"ponSections [STRATEGY 0 EXCEPTION]: {exS0.Message}. Falling back to Strategy 1.");
            }

            // ══════════════════════════════════════════════════════════════════
            // STRATEGY 1 (UNCONDITIONAL COMPREHENSIVE SCAN)
            // ──────────────────────────────────────────────────────────────────
            // Scans ALL ViewSection/ViewDetail/Elevation views in the document,
            // matching against parent view parameters, names, or viewer links.
            // ══════════════════════════════════════════════════════════════════
            string normalizedName = System.Text.RegularExpressions.Regex.Replace(vistaorigen.Name, @"(?i)\s+(copia|copy).*$", "").Trim();
            View? baseView = new FilteredElementCollector(origen)
                .OfClass(typeof(View))
                .Cast<View>()
                .FirstOrDefault(v => v != null && v.IsValidObject && !v.IsTemplate && v.Name.Equals(normalizedName, StringComparison.OrdinalIgnoreCase));
            ElementId baseViewId = baseView?.Id ?? ElementId.InvalidElementId;

            var allDocSections = new FilteredElementCollector(origen)
                .OfClass(typeof(View))
                .Cast<View>()
                .Where(v => v != null && v.IsValidObject && !v.IsTemplate && v.Id.Value != vistaorigen.Id.Value &&
                            (v.ViewType == ViewType.Section || v.ViewType == ViewType.Detail || v.ViewType == ViewType.Elevation))
                .ToList();

            LoggerService.LogInfo($"ponSections [STRATEGY 1 SCAN]: Total candidate Section/Detail/Elevation views in source doc: {allDocSections.Count}. Base View: '{baseView?.Name}' (Id: {baseViewId.Value})");

            foreach (View secView in allDocSections)
            {
                if (childSectionViews.Any(cv => cv.Id.Value == secView.Id.Value)) continue;

                bool isMatch = false;
                string matchReason = "";

                // 1. Parameter referencing vistaorigen.Id or baseViewId
                foreach (Parameter p in secView.Parameters)
                {
                    if (p != null && p.StorageType == StorageType.ElementId && p.AsElementId() != null)
                    {
                        long val = p.AsElementId().Value;
                        if (val == vistaorigen.Id.Value)
                        {
                            isMatch = true;
                            matchReason = $"Parameter '{p.Definition?.Name}' matches vistaorigen.Id ({val})";
                            break;
                        }
                        else if (baseViewId != ElementId.InvalidElementId && val == baseViewId.Value)
                        {
                            isMatch = true;
                            matchReason = $"Parameter '{p.Definition?.Name}' matches baseViewId ({val})";
                            break;
                        }
                    }
                }

                // 2. SECTION_PARENT_VIEW_NAME parameter
                if (!isMatch)
                {
                    var parentParam = secView.get_Parameter(BuiltInParameter.SECTION_PARENT_VIEW_NAME);
                    if (parentParam != null && !string.IsNullOrWhiteSpace(parentParam.AsString()))
                    {
                        string parentName = parentParam.AsString().Trim();
                        if (parentName.Equals(vistaorigen.Name, StringComparison.OrdinalIgnoreCase) ||
                            (!string.IsNullOrEmpty(vistaorigen.Title) && parentName.Equals(vistaorigen.Title, StringComparison.OrdinalIgnoreCase)) ||
                            parentName.Equals(normalizedName, StringComparison.OrdinalIgnoreCase))
                        {
                            isMatch = true;
                            matchReason = $"SECTION_PARENT_VIEW_NAME '{parentName}' matches parent/base name";
                        }
                    }
                }

                // 3. Inspect parameters for parent/primary view ID
                if (!isMatch)
                {
                    foreach (Parameter p in secView.Parameters)
                    {
                        if (p != null && p.StorageType == StorageType.ElementId && p.AsElementId() is ElementId pId && pId != ElementId.InvalidElementId)
                        {
                            string pName = p.Definition?.Name ?? "";
                            if (pName.IndexOf("Primary", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                pName.IndexOf("Parent", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                pName.IndexOf("Principal", StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                if (pId.Value == vistaorigen.Id.Value || (baseViewId != ElementId.InvalidElementId && pId.Value == baseViewId.Value))
                                {
                                    isMatch = true;
                                    matchReason = $"Parameter '{pName}' matches parent/base ID ({pId.Value})";
                                    break;
                                }
                            }
                        }
                    }
                }

                if (isMatch)
                {
                    childSectionViews.Add(secView);
                    LoggerService.LogInfo($"ponSections [DISCOVERY via Strategy 1 Match]: Found '{secView.Name}' (Id: {secView.Id.Value}) -> {matchReason}");
                }
            }

            LoggerService.LogInfo($"ponSections: Found {childSectionViews.Count} Section/Detail child view(s) on '{vistaorigen.Name}'.");

            if (childSectionViews.Count == 0) return;

            // ── 2. Process each child Section/Detail view ──
            var processedIds = new HashSet<long>();

            foreach (View sectionView in childSectionViews)
            {
                if (!processedIds.Add(sectionView.Id.Value)) continue;

                try
                {
                    // ── 2a. Skip if already processed in this transfer run ──
                    if (processedViewsMap != null && processedViewsMap.TryGetValue(sectionView.Id, out ElementId mappedId))
                    {
                        View? mappedSection = destino.GetElement(mappedId) as View;
                        if (mappedSection != null && mappedSection.IsValidObject)
                        {
                            LoggerService.LogInfo($"ponSections: Section '{sectionView.Name}' already processed (Target: {mappedId.Value}). Re-using.");
                            if (CopiaDetalles)
                            {
                                View consolidatedMapped = ponDependientes(origen, sectionView, mappedSection, copyOptions);
                                if (consolidatedMapped != null && consolidatedMapped.IsValidObject)
                                {
                                    mappedSection = consolidatedMapped;
                                    processedViewsMap[sectionView.Id] = mappedSection.Id;
                                }
                            }
                            ponSections(origen, destino, sectionView, mappedSection, copyOptions, CopiaDetalles, transforma, T, config, processedViewsMap, Contador + 1);
                            continue;
                        }
                    }

                    // ── 2b. Skip if a matching view already exists in target ──
                    View? existingSection = null;
                    try
                    {
                        existingSection = FindExistingViewByName(destino, sectionView.Name);
                        if (existingSection == null || existingSection.ViewType != ViewType.Section && existingSection.ViewType != ViewType.Detail)
                        {
                            existingSection = new FilteredElementCollector(destino)
                                .OfClass(typeof(View))
                                .Cast<View>()
                                .FirstOrDefault(v => v != null && v.IsValidObject && !v.IsTemplate
                                                 && (v.ViewType == ViewType.Section || v.ViewType == ViewType.Detail)
                                                 && v.Name.Equals(sectionView.Name, StringComparison.OrdinalIgnoreCase));
                        }
                    }
                    catch { }

                    if (existingSection != null)
                    {
                        LoggerService.LogInfo($"ponSections: Section '{sectionView.Name}' already exists in target (Id: {existingSection.Id.Value}). Re-using existing.");
                        if (CopiaDetalles)
                        {
                            View consolidatedExisting = ponDependientes(origen, sectionView, existingSection, copyOptions);
                            if (consolidatedExisting != null && consolidatedExisting.IsValidObject)
                            {
                                existingSection = consolidatedExisting;
                            }
                        }
                        if (config != null)
                        {
                            matchPlantilla(origen, destino, sectionView, existingSection, copyOptions, config, new List<DuplicateElementInfo>());
                        }
                        processedViewsMap?.TryAdd(sectionView.Id, existingSection.Id);
                        ponSections(origen, destino, sectionView, existingSection, copyOptions, CopiaDetalles, transforma, T, config, processedViewsMap, Contador + 1);
                        continue;
                    }

                    // ── 3. Reconstruct the section BoundingBoxXYZ in target coordinate space ──
                    BoundingBoxXYZ? srcBox = null;
                    try
                    {
                        srcBox = sectionView.CropBox;
                    }
                    catch (Exception exBox)
                    {
                        LoggerService.LogWarning($"ponSections: Could not get CropBox for '{sectionView.Name}': {exBox.Message}. Skipping.");
                        continue;
                    }

                    XYZ srcOriginWorld = sectionView.Origin;
                    XYZ basisX_raw     = sectionView.RightDirection;
                    XYZ basisY_raw     = sectionView.UpDirection;
                    XYZ basisZ_raw     = sectionView.ViewDirection;

                    if (srcBox == null)
                    {
                        LoggerService.LogWarning($"ponSections: SectionBox is null for '{sectionView.Name}'. Skipping.");
                        continue;
                    }

                    // Project into the coordinate system of the target document
                    XYZ tgtOriginWorld = srcOriginWorld;
                    XYZ basisX = basisX_raw;
                    XYZ basisY = basisY_raw;
                    XYZ basisZ = basisZ_raw;

                    if (transforma && T != null)
                    {
                        tgtOriginWorld = T.OfPoint(srcOriginWorld);
                        try
                        {
                            basisX = T.OfVector(basisX_raw).Normalize();
                            basisY = T.OfVector(basisY_raw).Normalize();
                            basisZ = T.OfVector(basisZ_raw).Normalize();
                        }
                        catch { }
                    }
                    else if (!transforma)
                    {
                        // Cross-document with different elevations: adjust Z using the same
                        // level-offset strategy validated in ponCallouts.
                        double srcViewZ = vistaorigen.Origin?.Z ?? 0.0;
                        double tgtViewZ = vistadestino.Origin?.Z ?? 0.0;
                        double zDelta   = tgtViewZ - srcViewZ;
                        tgtOriginWorld  = new XYZ(srcOriginWorld.X, srcOriginWorld.Y, srcOriginWorld.Z + zDelta);
                    }

                    // Compute target Cut Plane elevation so the section box is guaranteed
                    // to intersect the parent view's cut plane vertically.
                    double targetCutPlaneZ = vistadestino.Origin?.Z ?? 0.0;
                    try
                    {
                        if (vistadestino is ViewPlan vpTarget && vpTarget.GenLevel != null)
                        {
                            PlanViewRange pvr = vpTarget.GetViewRange();
                            double cutOffset = pvr.GetOffset(PlanViewPlane.CutPlane);
                            targetCutPlaneZ = vpTarget.GenLevel.Elevation + cutOffset;
                        }
                    }
                    catch { }

                    // Guarantee sufficient vertical height and depth so the section box penetrates the cut plane
                    double distToCutPlane = Math.Abs(targetCutPlaneZ - tgtOriginWorld.Z);
                    double halfWidth  = Math.Abs(srcBox.Max.X - srcBox.Min.X) / 2.0;
                    double halfHeight = Math.Max(Math.Abs(srcBox.Max.Y - srcBox.Min.Y) / 2.0, distToCutPlane + 30.0);
                    double halfDepth  = Math.Max(Math.Abs(srcBox.Max.Z - srcBox.Min.Z) / 2.0, 15.0);

                    var tgtTransform = Transform.Identity;
                    tgtTransform.Origin = tgtOriginWorld;
                    tgtTransform.BasisX = basisX;
                    tgtTransform.BasisY = basisY;
                    tgtTransform.BasisZ = basisZ;

                    var tgtBox = new BoundingBoxXYZ
                    {
                        Transform = tgtTransform,
                        Min = new XYZ(-halfWidth, -halfHeight, -halfDepth),
                        Max = new XYZ( halfWidth,  halfHeight,  halfDepth)
                    };

                    LoggerService.LogInfo($"ponSections [COORDS]: '{sectionView.Name}' srcOrigin=({srcOriginWorld.X:F3},{srcOriginWorld.Y:F3},{srcOriginWorld.Z:F3}) → tgtOrigin=({tgtOriginWorld.X:F3},{tgtOriginWorld.Y:F3},{tgtOriginWorld.Z:F3}) (CutPlaneZ: {targetCutPlaneZ:F3}, halfHeight: {halfHeight:F3})");

                    // ── 4. Find matching ViewFamilyType in target document ──
                    ElementId tgtVftId = ElementId.InvalidElementId;
                    try
                    {
                        string srcVftName = (origen.GetElement(sectionView.GetTypeId()) as ViewFamilyType)?.Name ?? string.Empty;
                        ViewFamily targetVF = sectionView.ViewType == ViewType.Detail ? ViewFamily.Detail : ViewFamily.Section;

                        ViewFamilyType? tgtVft = new FilteredElementCollector(destino)
                            .OfClass(typeof(ViewFamilyType))
                            .Cast<ViewFamilyType>()
                            .FirstOrDefault(vft => vft.ViewFamily == targetVF &&
                                            (string.IsNullOrEmpty(srcVftName) || vft.Name.Equals(srcVftName, StringComparison.OrdinalIgnoreCase)));

                        // Fallback: first VFT of the correct family
                        tgtVft ??= new FilteredElementCollector(destino)
                            .OfClass(typeof(ViewFamilyType))
                            .Cast<ViewFamilyType>()
                            .FirstOrDefault(vft => vft.ViewFamily == targetVF);

                        if (tgtVft != null) tgtVftId = tgtVft.Id;
                    }
                    catch (Exception exVft)
                    {
                        LoggerService.LogWarning($"ponSections: Could not find ViewFamilyType for '{sectionView.Name}': {exVft.Message}.");
                    }

                    if (tgtVftId == ElementId.InvalidElementId)
                    {
                        LoggerService.LogWarning($"ponSections: No compatible ViewFamilyType found in target for '{sectionView.Name}'. Skipping.");
                        continue;
                    }

                    // ── 5. Create the Section natively ──
                    View? targetSectionView = null;
                    try
                    {
                        LoggerService.LogInfo($"ponSections [CREATE]: Calling ViewSection.CreateSection on '{vistadestino.Name}' for '{sectionView.Name}'...");
                        targetSectionView = ViewSection.CreateSection(destino, tgtVftId, tgtBox);
                    }
                    catch (Exception exCreate)
                    {
                        LoggerService.LogWarning($"ponSections [CREATE FAILED]: {exCreate.Message}. Skipping '{sectionView.Name}'.");
                        continue;
                    }

                    if (targetSectionView == null || !targetSectionView.IsValidObject)
                    {
                        LoggerService.LogWarning($"ponSections: ViewSection.CreateSection returned null for '{sectionView.Name}'.");
                        continue;
                    }

                    LoggerService.LogInfo($"ponSections [CREATED]: '{sectionView.Name}' → Target Id: {targetSectionView.Id.Value}");

                    // ── 6. Visibility safeguards ──

                    // 6a. Synchronize Discipline (View Discipline) to prevent Revit hiding sections across disciplines
                    try
                    {
                        var srcDisciplineParam = sectionView.get_Parameter(BuiltInParameter.VIEW_DISCIPLINE);
                        var tgtDisciplineParam = targetSectionView.get_Parameter(BuiltInParameter.VIEW_DISCIPLINE);
                        if (tgtDisciplineParam != null && !tgtDisciplineParam.IsReadOnly)
                        {
                            if (srcDisciplineParam != null)
                            {
                                tgtDisciplineParam.Set(srcDisciplineParam.AsInteger());
                            }
                            else
                            {
                                var parentDiscipline = vistadestino.get_Parameter(BuiltInParameter.VIEW_DISCIPLINE);
                                if (parentDiscipline != null)
                                {
                                    tgtDisciplineParam.Set(parentDiscipline.AsInteger());
                                }
                            }
                        }
                    }
                    catch { }

                    // 6b. Synchronize Phase and Phase Filter
                    SyncViewPhaseAndFilter(origen, destino, sectionView, targetSectionView);

                    // 6c. Apply view template
                    try
                    {
                        matchPlantilla(origen, destino, sectionView, targetSectionView, copyOptions, config, new List<DuplicateElementInfo>());
                        SyncViewPhaseAndFilter(origen, destino, sectionView, targetSectionView);
                    }
                    catch { }

                    // 6d. Ensure viewer symbols and scale thresholds are unlocked
                    EnsureViewerSymbolsVisible(destino, targetSectionView, vistadestino.Scale);
                    EnsureViewerSymbolsVisible(destino, vistadestino, vistadestino.Scale);

                    // ── 7. Rename to match source ──
                    try
                    {
                        bool nameExists = new FilteredElementCollector(destino)
                            .OfClass(typeof(View))
                            .Cast<View>()
                            .Any(v => v != null && v.IsValidObject && v.Id.Value != targetSectionView.Id.Value
                                  && v.Name.Equals(sectionView.Name, StringComparison.OrdinalIgnoreCase));

                        if (!nameExists)
                        {
                            targetSectionView.Name = sectionView.Name;
                            LoggerService.LogInfo($"ponSections [RENAME OK]: Renamed to '{sectionView.Name}'.");
                        }
                        else
                        {
                            LoggerService.LogWarning($"ponSections [RENAME SKIP]: Name '{sectionView.Name}' already taken in target. Keeping '{targetSectionView.Name}'.");
                        }
                    }
                    catch (Exception exRename)
                    {
                        LoggerService.LogWarning($"ponSections [RENAME FAIL]: {exRename.Message}");
                    }

                    // ── 8. Register in processedViewsMap ──
                    processedViewsMap?.TryAdd(sectionView.Id, targetSectionView.Id);

                    // ── 9. Transfer 2D annotation elements inside the section view & consolidate ──
                    if (CopiaDetalles)
                    {
                        try
                        {
                            View consolidated = ponDependientes(origen, sectionView, targetSectionView, copyOptions);
                            if (consolidated != null && consolidated.IsValidObject)
                            {
                                targetSectionView = consolidated;
                                if (processedViewsMap != null) processedViewsMap[sectionView.Id] = targetSectionView.Id;
                                if (config != null)
                                {
                                    matchPlantilla(origen, destino, sectionView, targetSectionView, copyOptions, config, new List<DuplicateElementInfo>());
                                    SyncViewPhaseAndFilter(origen, destino, sectionView, targetSectionView);
                                }
                            }
                        }
                        catch (Exception exDep) { LoggerService.LogWarning($"ponSections [DEPENDIENTES FAIL]: {exDep.Message}"); }
                    }

                    EnsureViewerSymbolsVisible(destino, targetSectionView, vistadestino.Scale);
                    EnsureViewerSymbolsVisible(destino, vistadestino, vistadestino.Scale);

                    // ── 10. Traversal of child callouts or sections nested inside this section ──
                    try
                    {
                        ponCallouts(origen, destino, sectionView, targetSectionView, copyOptions, CopiaDetalles, Contador + 1, transforma, T, config, processedViewsMap);
                        ponSections(origen, destino, sectionView, targetSectionView, copyOptions, CopiaDetalles, transforma, T, config, processedViewsMap, Contador + 1);
                    }
                    catch { }
                }
                catch (Exception exSection)
                {
                    LoggerService.LogExceptionSilently($"ponSections - processing '{sectionView.Name}'", exSection);
                }
            }
        }
        catch (Exception exOuter)
        {
            LoggerService.LogExceptionSilently($"ponSections - outer on '{vistaorigen.Name}'", exOuter);
        }
    }


    public static ElementId EnsureFillPatternTransferred(Document sourceDoc, Document targetDoc, ElementId srcPatternId)
    {
        if (srcPatternId == null || srcPatternId == ElementId.InvalidElementId) return ElementId.InvalidElementId;
        FillPatternElement srcPattern = sourceDoc.GetElement(srcPatternId) as FillPatternElement;
        if (srcPattern == null) return ElementId.InvalidElementId;

        // Check if pattern with same name already exists in targetDoc
        FillPatternElement existingTargetPattern = new FilteredElementCollector(targetDoc)
            .OfClass(typeof(FillPatternElement))
            .Cast<FillPatternElement>()
            .FirstOrDefault(p => p.Name.Equals(srcPattern.Name, StringComparison.OrdinalIgnoreCase));

        if (existingTargetPattern != null)
        {
            return existingTargetPattern.Id;
        }

        // Copy pattern into targetDoc
        try
        {
            var copiedIds = ElementTransformUtils.CopyElements(sourceDoc, new List<ElementId> { srcPatternId }, targetDoc, Transform.Identity, new CopyPasteOptions());
            ElementId targetPatternId = copiedIds?.FirstOrDefault() ?? ElementId.InvalidElementId;
            if (targetPatternId != ElementId.InvalidElementId)
            {
                FillPatternElement newTargetPattern = targetDoc.GetElement(targetPatternId) as FillPatternElement;
                FillPattern fp = srcPattern.GetFillPattern();
                LoggerService.LogInfo($"EnsureFillPatternTransferred: Copied FillPatternElement '{srcPattern.Name}' (Target: {fp?.Target}) into target project library.");
                return targetPatternId;
            }
        }
        catch (Exception exPattern)
        {
            LoggerService.LogWarning($"EnsureFillPatternTransferred: Could not copy FillPatternElement '{srcPattern.Name}': {exPattern.Message}");
        }

        return ElementId.InvalidElementId;
    }

    public static OverrideGraphicSettings SanitizeAndPrepareOverrideSettings(Document sourceDoc, Document targetDoc, OverrideGraphicSettings srcOverrides)
    {
        if (srcOverrides == null) return new OverrideGraphicSettings();

        OverrideGraphicSettings targetOverrides = new OverrideGraphicSettings();

        // Copy projection line weight & color & pattern
        try { targetOverrides.SetProjectionLineWeight(srcOverrides.ProjectionLineWeight); } catch { }
        try { targetOverrides.SetProjectionLineColor(srcOverrides.ProjectionLineColor); } catch { }
        try
        {
            if (srcOverrides.ProjectionLinePatternId != ElementId.InvalidElementId)
            {
                ElementId targetLinePatternId = TransferLinePattern(sourceDoc, targetDoc, srcOverrides.ProjectionLinePatternId);
                if (targetLinePatternId != ElementId.InvalidElementId) targetOverrides.SetProjectionLinePatternId(targetLinePatternId);
            }
        }
        catch { }

        // Copy cut line weight & color & pattern
        try { targetOverrides.SetCutLineWeight(srcOverrides.CutLineWeight); } catch { }
        try { targetOverrides.SetCutLineColor(srcOverrides.CutLineColor); } catch { }
        try
        {
            if (srcOverrides.CutLinePatternId != ElementId.InvalidElementId)
            {
                ElementId targetLinePatternId = TransferLinePattern(sourceDoc, targetDoc, srcOverrides.CutLinePatternId);
                if (targetLinePatternId != ElementId.InvalidElementId) targetOverrides.SetCutLinePatternId(targetLinePatternId);
            }
        }
        catch { }

        // Copy transparency & detail level & halftone
        try { targetOverrides.SetSurfaceTransparency(srcOverrides.Transparency); } catch { }
        try { targetOverrides.SetHalftone(srcOverrides.Halftone); } catch { }

        // Surface Foreground Pattern
        ElementId srcSurfFgId = srcOverrides.SurfaceForegroundPatternId;
        if (srcSurfFgId != null && srcSurfFgId != ElementId.InvalidElementId)
        {
            ElementId targetPatternId = EnsureFillPatternTransferred(sourceDoc, targetDoc, srcSurfFgId);
            if (targetPatternId != ElementId.InvalidElementId)
            {
                FillPatternElement patElem = targetDoc.GetElement(targetPatternId) as FillPatternElement;
                if (patElem != null && patElem.GetFillPattern()?.Target == FillPatternTarget.Drafting)
                {
                    try
                    {
                        targetOverrides.SetSurfaceForegroundPatternId(targetPatternId);
                        targetOverrides.SetSurfaceForegroundPatternColor(srcOverrides.SurfaceForegroundPatternColor);
                        targetOverrides.SetSurfaceForegroundPatternVisible(srcOverrides.IsSurfaceForegroundPatternVisible);
                    }
                    catch { }
                }
                else if (patElem != null)
                {
                    LoggerService.LogInfo($"ViewGraphics: Model Fill Pattern '{patElem.Name}' was copied to target project library, but skipped in View Graphic Overrides because Revit API requires Drafting patterns.");
                }
            }
        }

        // Surface Background Pattern
        ElementId srcSurfBgId = srcOverrides.SurfaceBackgroundPatternId;
        if (srcSurfBgId != null && srcSurfBgId != ElementId.InvalidElementId)
        {
            ElementId targetPatternId = EnsureFillPatternTransferred(sourceDoc, targetDoc, srcSurfBgId);
            if (targetPatternId != ElementId.InvalidElementId)
            {
                FillPatternElement patElem = targetDoc.GetElement(targetPatternId) as FillPatternElement;
                if (patElem != null && patElem.GetFillPattern()?.Target == FillPatternTarget.Drafting)
                {
                    try
                    {
                        targetOverrides.SetSurfaceBackgroundPatternId(targetPatternId);
                        targetOverrides.SetSurfaceBackgroundPatternColor(srcOverrides.SurfaceBackgroundPatternColor);
                        targetOverrides.SetSurfaceBackgroundPatternVisible(srcOverrides.IsSurfaceBackgroundPatternVisible);
                    }
                    catch { }
                }
            }
        }

        // Cut Foreground Pattern
        ElementId srcCutFgId = srcOverrides.CutForegroundPatternId;
        if (srcCutFgId != null && srcCutFgId != ElementId.InvalidElementId)
        {
            ElementId targetPatternId = EnsureFillPatternTransferred(sourceDoc, targetDoc, srcCutFgId);
            if (targetPatternId != ElementId.InvalidElementId)
            {
                FillPatternElement patElem = targetDoc.GetElement(targetPatternId) as FillPatternElement;
                if (patElem != null && patElem.GetFillPattern()?.Target == FillPatternTarget.Drafting)
                {
                    try
                    {
                        targetOverrides.SetCutForegroundPatternId(targetPatternId);
                        targetOverrides.SetCutForegroundPatternColor(srcOverrides.CutForegroundPatternColor);
                        targetOverrides.SetCutForegroundPatternVisible(srcOverrides.IsCutForegroundPatternVisible);
                    }
                    catch { }
                }
                else if (patElem != null)
                {
                    LoggerService.LogInfo($"ViewGraphics: Model Fill Pattern '{patElem.Name}' was copied to target project library, but skipped in View Cut Overrides because Revit API requires Drafting patterns.");
                }
            }
        }

        // Cut Background Pattern
        ElementId srcCutBgId = srcOverrides.CutBackgroundPatternId;
        if (srcCutBgId != null && srcCutBgId != ElementId.InvalidElementId)
        {
            ElementId targetPatternId = EnsureFillPatternTransferred(sourceDoc, targetDoc, srcCutBgId);
            if (targetPatternId != ElementId.InvalidElementId)
            {
                FillPatternElement patElem = targetDoc.GetElement(targetPatternId) as FillPatternElement;
                if (patElem != null && patElem.GetFillPattern()?.Target == FillPatternTarget.Drafting)
                {
                    try
                    {
                        targetOverrides.SetCutBackgroundPatternId(targetPatternId);
                        targetOverrides.SetCutBackgroundPatternColor(srcOverrides.CutBackgroundPatternColor);
                        targetOverrides.SetCutBackgroundPatternVisible(srcOverrides.IsCutBackgroundPatternVisible);
                    }
                    catch { }
                }
            }
        }

        return targetOverrides;
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

                        OverrideGraphicSettings srcFilterOverrides = vistaorigen.GetFilterOverrides(filterId);
                        OverrideGraphicSettings preparedOverrides = SanitizeAndPrepareOverrideSettings(origen, destino, srcFilterOverrides);
                        vistadestino.SetFilterOverrides(targetFilterId, preparedOverrides);

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
                LoggerService.LogInfo($"ViewTemplate: Applied template '{templateView.Name}' (TargetId: {targetTemplateId.Value}) to view '{vistadestino.Name}'.");
            }
            catch (Exception exApplyTmpl)
            {
                LoggerService.LogWarning($"ViewTemplate: Failed to apply template '{templateView.Name}' to view '{vistadestino.Name}': {exApplyTmpl.Message}");
            }
        }

        // STEP 5: Re-apply view graphics & link overrides directly onto vistadestino after template assignment
        CopyViewGraphicsAndOverrides(origen, destino, vistaorigen, vistadestino, copyOptions, config, duplicateItems);
    }

    public static string GetLinkCleanName(RevitLinkInstance link, Document doc)
    {
        if (link == null) return string.Empty;

        try
        {
            Document linkDoc = link.GetLinkDocument();
            if (linkDoc != null && !string.IsNullOrWhiteSpace(linkDoc.Title))
            {
                return linkDoc.Title.Replace(".rvt", "").Trim();
            }
        }
        catch { }

        try
        {
            RevitLinkType linkType = doc.GetElement(link.GetTypeId()) as RevitLinkType;
            if (linkType != null && !string.IsNullOrWhiteSpace(linkType.Name))
            {
                return linkType.Name.Replace(".rvt", "").Trim();
            }
        }
        catch { }

        if (!string.IsNullOrWhiteSpace(link.Name))
        {
            string rawName = link.Name.Split(':')[0].Trim();
            return rawName.Replace(".rvt", "").Trim();
        }

        return string.Empty;
    }

    private static string StripRvtExtension(string? title)
    {
        if (string.IsNullOrEmpty(title)) return string.Empty;
        if (title.EndsWith(".rvt", StringComparison.OrdinalIgnoreCase))
            return title.Substring(0, title.Length - 4).Trim();
        return title.Trim();
    }

    public static Transform? GetTransformForSource(Document sourceDoc, Document targetDoc, Configuraciones config)
    {
        if (config.cf_chk_GetTransformLink)
        {
            string cleanSourceTitle = StripRvtExtension(sourceDoc.Title);

            var linkInstances = new FilteredElementCollector(targetDoc)
                .OfClass(typeof(RevitLinkInstance))
                .Cast<RevitLinkInstance>()
                .ToList();

            var matchingLink = linkInstances.FirstOrDefault(i =>
            {
                string cleanLinkTitle = GetLinkCleanName(i, targetDoc);
                if (!string.IsNullOrEmpty(cleanLinkTitle) && cleanLinkTitle.Equals(cleanSourceTitle, StringComparison.OrdinalIgnoreCase))
                    return true;

                string docTitle = StripRvtExtension(i.GetLinkDocument()?.Title);
                if (!string.IsNullOrEmpty(docTitle) && docTitle.Equals(cleanSourceTitle, StringComparison.OrdinalIgnoreCase))
                    return true;

                if (!string.IsNullOrEmpty(i.Name) && i.Name.IndexOf(cleanSourceTitle, StringComparison.OrdinalIgnoreCase) >= 0)
                    return true;

                return false;
            });

            if (matchingLink != null)
            {
                Transform tf = matchingLink.GetTotalTransform();
                LoggerService.LogInfo($"Transform [Link]: Matched link instance '{matchingLink.Name}' (CleanName: '{GetLinkCleanName(matchingLink, targetDoc)}'). Applied TotalTransform (Origin: {tf.Origin}).");
                return tf;
            }
            else
            {
                string availableLinks = string.Join(", ", linkInstances.Select(l => $"'{l.Name}' (Clean: '{GetLinkCleanName(l, targetDoc)}')"));
                LoggerService.LogWarning($"Transform [Link]: No matching link instance found for source '{sourceDoc.Title}' (Clean: '{cleanSourceTitle}'). Available links in target: [{availableLinks}]. Defaulting to Identity transform.");
                return Transform.Identity;
            }
        }
        else if (config.cf_chk_GetTransformShared)
        {
            try
            {
                Transform sourceTransform = sourceDoc.ActiveProjectLocation.GetTotalTransform();
                Transform tf = targetDoc.ActiveProjectLocation.GetTotalTransform().Multiply(sourceTransform.Inverse);
                LoggerService.LogInfo($"Transform [Shared]: Applied Shared Coordinates differential transform (Origin: {tf.Origin}).");
                return tf;
            }
            catch (Exception exShared)
            {
                LoggerService.LogWarning($"Transform [Shared]: Failed to compute shared transform: {exShared.Message}. Defaulting to Identity.");
                return Transform.Identity;
            }
        }
        else
        {
            LoggerService.LogInfo("Transform [None]: Internal Origin (0,0,0) alignment selected. Transform is Identity.");
            return Transform.Identity;
        }
    }

    public static void EnsureViewerSymbolsVisible(Document doc, View view, int minScale)
    {
        if (view == null || !view.IsValidObject) return;

        // 1. Unhide OST_Viewers and all its subcategories on the view
        try
        {
            Category viewersCat = Category.GetCategory(doc, BuiltInCategory.OST_Viewers);
            if (viewersCat != null)
            {
                if (view.CanCategoryBeHidden(viewersCat.Id))
                    view.SetCategoryHidden(viewersCat.Id, false);

                foreach (Category subCat in viewersCat.SubCategories)
                {
                    if (subCat != null && view.CanCategoryBeHidden(subCat.Id))
                    {
                        try { view.SetCategoryHidden(subCat.Id, false); } catch { }
                    }
                }

                // Also check on the view template if assigned
                if (view.ViewTemplateId != ElementId.InvalidElementId)
                {
                    View tmpl = doc.GetElement(view.ViewTemplateId) as View;
                    if (tmpl != null)
                    {
                        if (tmpl.CanCategoryBeHidden(viewersCat.Id))
                            tmpl.SetCategoryHidden(viewersCat.Id, false);

                        foreach (Category subCat in viewersCat.SubCategories)
                        {
                            if (subCat != null && tmpl.CanCategoryBeHidden(subCat.Id))
                            {
                                try { tmpl.SetCategoryHidden(subCat.Id, false); } catch { }
                            }
                        }
                    }
                }
            }

            // Also unhide OST_CalloutBoundary
            Category calloutCat = Category.GetCategory(doc, BuiltInCategory.OST_CalloutBoundary);
            if (calloutCat != null)
            {
                if (view.CanCategoryBeHidden(calloutCat.Id))
                    view.SetCategoryHidden(calloutCat.Id, false);

                if (view.ViewTemplateId != ElementId.InvalidElementId)
                {
                    View tmpl = doc.GetElement(view.ViewTemplateId) as View;
                    if (tmpl != null && tmpl.CanCategoryBeHidden(calloutCat.Id))
                    {
                        try { tmpl.SetCategoryHidden(calloutCat.Id, false); } catch { }
                    }
                }
            }
        }
        catch (Exception exCat)
        {
            LoggerService.LogWarning($"EnsureViewerSymbolsVisible [Category]: {exCat.Message}");
        }

        // 2. Unlock "Hide at scales coarser than" parameter on view and its template
        // Use a guaranteed-safe minimum of 10000 to ensure marks show at all common
        // architectural scales (1:50 through 1:10000). This prevents the issue where
        // recursive calls pass a section view's scale (~100) instead of the root plan
        // view's scale (~1000), resulting in marks being hidden.
        try
        {
            int targetScale = Math.Max(Math.Max(view.Scale, minScale), 10000);

            void UnlockScale(View v)
            {
                if (v == null || !v.IsValidObject) return;
                Parameter hideParam = v.get_Parameter(BuiltInParameter.SECTION_COARSER_SCALE_PULLDOWN_IMPERIAL)
                                   ?? v.get_Parameter(BuiltInParameter.SECTION_COARSER_SCALE_PULLDOWN_METRIC);

                if (hideParam != null && !hideParam.IsReadOnly)
                {
                    int current = hideParam.AsInteger();
                    if (current != targetScale)
                    {
                        hideParam.Set(targetScale);
                        LoggerService.LogInfo($"EnsureViewerSymbolsVisible: Set scale threshold on '{v.Name}' from {current} to {targetScale}.");
                    }
                }
                else
                {
                    LoggerService.LogInfo($"EnsureViewerSymbolsVisible: Scale param on '{v.Name}' is {(hideParam == null ? "NULL" : "READ-ONLY")}. Cannot set.");
                }
            }

            UnlockScale(view);
            if (view.ViewTemplateId != ElementId.InvalidElementId)
            {
                View tmpl = doc.GetElement(view.ViewTemplateId) as View;
                if (tmpl != null) UnlockScale(tmpl);
            }
        }
        catch (Exception exScale)
        {
            LoggerService.LogWarning($"EnsureViewerSymbolsVisible [Scale]: {exScale.Message}");
        }
    }

    public static void SyncViewPhaseAndFilter(Document srcDoc, Document tgtDoc, View srcView, View tgtView)
    {
        if (srcView == null || tgtView == null) return;
        try
        {
            // 1. Sync Phase
            Parameter srcPhaseParam = srcView.get_Parameter(BuiltInParameter.VIEW_PHASE);
            Parameter tgtPhaseParam = tgtView.get_Parameter(BuiltInParameter.VIEW_PHASE);
            if (srcPhaseParam != null && tgtPhaseParam != null && !tgtPhaseParam.IsReadOnly)
            {
                ElementId srcPhaseId = srcPhaseParam.AsElementId();
                if (srcPhaseId != null && srcPhaseId != ElementId.InvalidElementId)
                {
                    Phase srcPhase = srcDoc.GetElement(srcPhaseId) as Phase;
                    if (srcPhase != null)
                    {
                        Phase tgtPhase = new FilteredElementCollector(tgtDoc)
                            .OfClass(typeof(Phase))
                            .Cast<Phase>()
                            .FirstOrDefault(p => p.Name.Equals(srcPhase.Name, StringComparison.OrdinalIgnoreCase));

                        if (tgtPhase != null && tgtPhase.Id != tgtPhaseParam.AsElementId())
                        {
                            tgtPhaseParam.Set(tgtPhase.Id);
                            LoggerService.LogInfo($"SyncViewPhaseAndFilter: Synchronized Phase '{tgtPhase.Name}' for view '{tgtView.Name}'.");
                        }
                    }
                }
            }

            // 2. Sync Phase Filter
            Parameter srcFilterParam = srcView.get_Parameter(BuiltInParameter.VIEW_PHASE_FILTER);
            Parameter tgtFilterParam = tgtView.get_Parameter(BuiltInParameter.VIEW_PHASE_FILTER);
            if (srcFilterParam != null && tgtFilterParam != null && !tgtFilterParam.IsReadOnly)
            {
                ElementId srcFilterId = srcFilterParam.AsElementId();
                if (srcFilterId != null && srcFilterId != ElementId.InvalidElementId)
                {
                    PhaseFilter srcPf = srcDoc.GetElement(srcFilterId) as PhaseFilter;
                    if (srcPf != null)
                    {
                        PhaseFilter tgtPf = new FilteredElementCollector(tgtDoc)
                            .OfClass(typeof(PhaseFilter))
                            .Cast<PhaseFilter>()
                            .FirstOrDefault(pf => pf.Name.Equals(srcPf.Name, StringComparison.OrdinalIgnoreCase));

                        if (tgtPf != null && tgtPf.Id != tgtFilterParam.AsElementId())
                        {
                            tgtFilterParam.Set(tgtPf.Id);
                            LoggerService.LogInfo($"SyncViewPhaseAndFilter: Synchronized PhaseFilter '{tgtPf.Name}' for view '{tgtView.Name}'.");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LoggerService.LogWarning($"SyncViewPhaseAndFilter: {ex.Message}");
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

        // Synchronize Top-Level Revit Links Category (OST_RvtLinks)
        try
        {
            Category rvtLinksCatSrc = Category.GetCategory(sourceDoc, BuiltInCategory.OST_RvtLinks);
            Category rvtLinksCatTgt = Category.GetCategory(targetDoc, BuiltInCategory.OST_RvtLinks);
            if (rvtLinksCatSrc != null && rvtLinksCatTgt != null)
            {
                bool isRvtLinksHidden = srcView.GetCategoryHidden(rvtLinksCatSrc.Id);
                targetGraphicsView.SetCategoryHidden(rvtLinksCatTgt.Id, isRvtLinksHidden);
                if (targetView != targetGraphicsView)
                {
                    try { targetView.SetCategoryHidden(rvtLinksCatTgt.Id, isRvtLinksHidden); } catch { }
                }

                OverrideGraphicSettings srcCatOverrides = srcView.GetCategoryOverrides(rvtLinksCatSrc.Id);
                OverrideGraphicSettings preparedCatOverrides = SanitizeAndPrepareOverrideSettings(sourceDoc, targetDoc, srcCatOverrides);
                targetGraphicsView.SetCategoryOverrides(rvtLinksCatTgt.Id, preparedCatOverrides);
                if (targetView != targetGraphicsView)
                {
                    try { targetView.SetCategoryOverrides(rvtLinksCatTgt.Id, preparedCatOverrides); } catch { }
                }
                LoggerService.LogInfo($"ViewGraphics: Synchronized OST_RvtLinks CategoryHidden={isRvtLinksHidden} for view '{targetView.Name}'.");
            }
        }
        catch (Exception exRvtLinks)
        {
            LoggerService.LogWarning($"ViewGraphics: Failed setting OST_RvtLinks hidden/overrides: {exRvtLinks.Message}");
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
                        try
                        {
                            OverrideGraphicSettings srcCatOverrides = srcView.GetCategoryOverrides(srcCat.Id);
                            OverrideGraphicSettings preparedCatOverrides = SanitizeAndPrepareOverrideSettings(sourceDoc, targetDoc, srcCatOverrides);
                            targetGraphicsView.SetCategoryOverrides(targetCat.Id, preparedCatOverrides);
                        }
                        catch { }
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

            var targetLinks = new FilteredElementCollector(targetDoc)
                .OfClass(typeof(RevitLinkInstance))
                .Cast<RevitLinkInstance>()
                .ToList();

            var missingLinkNames = new List<string>();

            foreach (var srcLink in srcLinks)
            {
                string srcCleanName = GetLinkCleanName(srcLink, sourceDoc);

                RevitLinkInstance targetLink = targetLinks.FirstOrDefault(l =>
                {
                    if (l.Id == srcLink.Id) return true;
                    if (l.Name.Equals(srcLink.Name, StringComparison.OrdinalIgnoreCase)) return true;
                    string tgtCleanName = GetLinkCleanName(l, targetDoc);
                    return !string.IsNullOrEmpty(srcCleanName) &&
                           !string.IsNullOrEmpty(tgtCleanName) &&
                           srcCleanName.Equals(tgtCleanName, StringComparison.OrdinalIgnoreCase);
                });

                if (targetLink != null)
                {
                    bool isHiddenInSrc = false;
                    try
                    {
                        isHiddenInSrc = srcLink.IsHidden(srcView);
                    }
                    catch (Exception exIsHidden)
                    {
                        LoggerService.LogInfo($"LinkOverrides [INFO]: Could not query IsHidden for link '{srcLink.Name}' in view '{srcView.Name}': {exIsHidden.Message}");
                    }

                    if (!isHiddenInSrc && srcView.ViewTemplateId != ElementId.InvalidElementId)
                    {
                        View srcTemplateView = sourceDoc.GetElement(srcView.ViewTemplateId) as View;
                        if (srcTemplateView != null)
                        {
                            try
                            {
                                isHiddenInSrc = srcLink.IsHidden(srcTemplateView);
                                if (isHiddenInSrc)
                                {
                                    LoggerService.LogInfo($"LinkOverrides [DETECTED IN TEMPLATE]: Link '{srcLink.Name}' is hidden in source ViewTemplate '{srcTemplateView.Name}'.");
                                }
                            }
                            catch { }
                        }
                    }

                    try
                    {
                        if (isHiddenInSrc)
                        {
                            // Apply HideElements to targetGraphicsView (which is the ViewTemplate if targetView has a template, or targetView itself)
                            if (targetGraphicsView != null)
                            {
                                try
                                {
                                    targetGraphicsView.HideElements(new List<ElementId> { targetLink.Id });
                                    LoggerService.LogInfo($"LinkOverrides [HIDE TEMPLATE/GRAPHICS SUCCESS]: Successfully hid link '{srcLink.Name}' (CleanName: '{srcCleanName}') in target graphics view/template '{targetGraphicsView.Name}'.");
                                }
                                catch (Exception exHideG)
                                {
                                    LoggerService.LogInfo($"LinkOverrides [HIDE GRAPHICS NOTICE]: Could not apply HideElements on '{targetGraphicsView.Name}': {exHideG.Message}");
                                }
                            }

                            // Also apply directly to targetView if distinct from targetGraphicsView
                            if (targetView != null && targetView != targetGraphicsView)
                            {
                                try
                                {
                                    targetView.HideElements(new List<ElementId> { targetLink.Id });
                                    LoggerService.LogInfo($"LinkOverrides [HIDE VIEW SUCCESS]: Successfully hid link '{srcLink.Name}' (CleanName: '{srcCleanName}') in target view '{targetView.Name}'.");
                                }
                                catch (Exception exHideInner)
                                {
                                    LoggerService.LogInfo($"LinkOverrides [HIDE VIEW NOTICE]: Could not apply HideElements directly on target view '{targetView.Name}': {exHideInner.Message}");
                                }
                            }
                        }
                        else
                        {
                            if (targetGraphicsView != null)
                            {
                                try { targetGraphicsView.UnhideElements(new List<ElementId> { targetLink.Id }); } catch { }
                            }
                            if (targetView != null && targetView != targetGraphicsView)
                            {
                                try { targetView.UnhideElements(new List<ElementId> { targetLink.Id }); } catch { }
                            }
                        }
                    }
                    catch (Exception exHide)
                    {
                        LoggerService.LogWarning($"LinkOverrides [HIDE ERROR]: Could not sync hide/show visibility for link '{srcLink.Name}' in view '{targetView.Name}': {exHide.Message}");
                    }

                    RevitLinkGraphicsSettings srcSettings = null;
                    try
                    {
                        srcSettings = srcView.GetLinkOverrides(srcLink.Id);
                    }
                    catch (Exception exGetOverrides)
                    {
                        LoggerService.LogInfo($"LinkOverrides [INFO]: View '{srcView.Name}' (Type: {srcView.ViewType}) does not support GetLinkOverrides ({exGetOverrides.Message}). Checking template...");
                    }

                    if (srcSettings == null && srcView.ViewTemplateId != ElementId.InvalidElementId)
                    {
                        View srcTemplateView = sourceDoc.GetElement(srcView.ViewTemplateId) as View;
                        if (srcTemplateView != null)
                        {
                            try
                            {
                                srcSettings = srcTemplateView.GetLinkOverrides(srcLink.Id);
                                if (srcSettings != null)
                                {
                                    LoggerService.LogInfo($"LinkOverrides [TEMPLATE SOURCE SUCCESS]: Retrieved link overrides for '{srcLink.Name}' (CleanName: '{srcCleanName}') from source template '{srcTemplateView.Name}'.");
                                }
                            }
                            catch (Exception exTmplGet)
                            {
                                LoggerService.LogInfo($"LinkOverrides [TEMPLATE SOURCE INFO]: Source template '{srcTemplateView.Name}' does not support GetLinkOverrides for link '{srcLink.Name}': {exTmplGet.Message}");
                            }
                        }
                    }

                    if (srcSettings != null)
                    {
                        try
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

                            // Apply SetLinkOverrides to targetGraphicsView (the template view, if view template exists, or targetView if no template)
                            if (targetGraphicsView != null)
                            {
                                try
                                {
                                    targetGraphicsView.SetLinkOverrides(targetLink.Id, targetSettings);
                                    LoggerService.LogInfo($"LinkOverrides [SET SUCCESS]: Applied LinkVisibilityType={targetSettings.LinkVisibilityType} for link '{srcLink.Name}' onto target view/template '{targetGraphicsView.Name}'.");
                                }
                                catch (Exception exSetG)
                                {
                                    LoggerService.LogInfo($"LinkOverrides [SET INFO]: View/Template '{targetGraphicsView.Name}' (Type: {targetGraphicsView.ViewType}) does not support SetLinkOverrides ({exSetG.Message}).");
                                }
                            }

                            // Only apply to targetView directly if it has NO view template assigned (to prevent "The view does not support link graphical overrides")
                            if (targetView != null && targetView != targetGraphicsView && targetView.ViewTemplateId == ElementId.InvalidElementId)
                            {
                                try
                                {
                                    targetView.SetLinkOverrides(targetLink.Id, targetSettings);
                                    LoggerService.LogInfo($"LinkOverrides [SET DIRECT SUCCESS]: Applied LinkVisibilityType={targetSettings.LinkVisibilityType} directly for link '{srcLink.Name}' onto target view '{targetView.Name}'.");
                                }
                                catch (Exception exSetV)
                                {
                                    LoggerService.LogInfo($"LinkOverrides [SET DIRECT INFO]: View '{targetView.Name}' does not support direct SetLinkOverrides ({exSetV.Message}).");
                                }
                            }
                        }
                        catch (Exception exLinkOverrides)
                        {
                            LoggerService.LogWarning($"LinkOverrides [WARNING]: Error configuring override settings for link '{srcLink.Name}' in view '{targetView.Name}': {exLinkOverrides.Message}");
                        }
                    }
                }
                else
                {
                    try
                    {
                        bool isHiddenInSrc = false;
                        try { isHiddenInSrc = srcLink.IsHidden(srcView); } catch { }

                        RevitLinkGraphicsSettings srcSettings = null;
                        try { srcSettings = srcView.GetLinkOverrides(srcLink.Id); } catch { }

                        if (isHiddenInSrc || srcSettings != null)
                        {
                            string linkDisplayName = !string.IsNullOrEmpty(srcCleanName) ? srcCleanName : srcLink.Name;
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

    public static string ToAlphaNumericOnly(string input)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;
        var sb = new System.Text.StringBuilder();
        foreach (char c in input)
        {
            if (char.IsLetterOrDigit(c))
            {
                sb.Append(char.ToLowerInvariant(c));
            }
        }
        return sb.ToString();
    }

    public static string NormalizeName(string text)
    {
        if (string.IsNullOrEmpty(text)) return string.Empty;

        char[] dashes = new char[] { '\u2010', '\u2011', '\u2012', '\u2013', '\u2014', '\u2015', '\u2212', '\u00AD' };
        foreach (char d in dashes)
        {
            text = text.Replace(d, '-');
        }

        char[] whitespaces = new char[] { '\u00A0', '\u200B', '\uFEFF', '\r', '\n', '\t', '\u2000', '\u2001', '\u2002', '\u2003', '\u2004', '\u2005', '\u2006', '\u2007', '\u2008', '\u2009', '\u200A', '\u202F', '\u205F', '\u3000' };
        foreach (char ws in whitespaces)
        {
            text = text.Replace(ws, ' ');
        }

        return System.Text.RegularExpressions.Regex.Replace(text, @"\s+", " ").Trim();
    }

    public static View FindExistingViewByName(Document doc, string viewName)
    {
        if (doc == null || string.IsNullOrWhiteSpace(viewName)) return null;

        string exactTarget = viewName.Trim();
        string cleanTarget = NormalizeName(viewName);
        string alphaTarget = ToAlphaNumericOnly(viewName);

        var views = new FilteredElementCollector(doc)
            .OfClass(typeof(View))
            .WhereElementIsNotElementType()
            .Cast<View>()
            .Where(v => v != null && v.IsValidObject && !v.IsTemplate)
            .ToList();

        // Tier 1: Exact match
        foreach (View v in views)
        {
            try
            {
                if (v.Name.Trim().Equals(exactTarget, StringComparison.OrdinalIgnoreCase))
                    return v;
            }
            catch { }
        }

        // Tier 2: Normalized match (whitespace, dashes, hyphens)
        foreach (View v in views)
        {
            try
            {
                if (NormalizeName(v.Name).Equals(cleanTarget, StringComparison.OrdinalIgnoreCase))
                    return v;
            }
            catch { }
        }

        // Tier 3: BuiltInParameter.VIEW_NAME match
        foreach (View v in views)
        {
            try
            {
                Parameter p = v.get_Parameter(BuiltInParameter.VIEW_NAME);
                if (p != null && p.HasValue)
                {
                    string pVal = NormalizeName(p.AsString());
                    if (pVal.Equals(cleanTarget, StringComparison.OrdinalIgnoreCase))
                        return v;
                }
            }
            catch { }
        }

        // Tier 4: AlphaNumeric-only match (ignores all hyphens, spaces, underscores, case)
        if (!string.IsNullOrEmpty(alphaTarget))
        {
            foreach (View v in views)
            {
                try
                {
                    if (ToAlphaNumericOnly(v.Name).Equals(alphaTarget, StringComparison.OrdinalIgnoreCase))
                        return v;
                }
                catch { }
            }
        }

        return null;
    }

    public static ViewSheet FindExistingSheetByNumberOrName(Document doc, string sheetNumber, string sheetName)
    {
        if (doc == null) return null;
        string cleanNum = NormalizeName(sheetNumber);
        string cleanName = NormalizeName(sheetName);

        var sheets = new FilteredElementCollector(doc)
            .OfClass(typeof(ViewSheet))
            .Cast<ViewSheet>();

        foreach (ViewSheet s in sheets)
        {
            try
            {
                if (s != null && s.IsValidObject)
                {
                    if (!string.IsNullOrEmpty(cleanNum) && NormalizeName(s.SheetNumber).Equals(cleanNum, StringComparison.OrdinalIgnoreCase))
                        return s;
                    if (!string.IsNullOrEmpty(cleanName) && NormalizeName(s.Name).Equals(cleanName, StringComparison.OrdinalIgnoreCase))
                        return s;
                }
            }
            catch { }
        }
        return null;
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
                string cleanType = NormalizeName(srcName);
                return new FilteredElementCollector(targetDoc)
                    .OfClass(elemType)
                    .Any(e => NormalizeName(e.Name).Equals(cleanType, StringComparison.OrdinalIgnoreCase));
            }
            
            if (srcElem is ViewSheet srcSheet)
            {
                return FindExistingSheetByNumberOrName(targetDoc, srcSheet.SheetNumber, srcName) != null;
            }

            if (srcElem is View)
            {
                return FindExistingViewByName(targetDoc, srcName) != null;
            }

            if (srcElem is Level || srcElem is ParameterFilterElement)
            {
                string cleanElem = NormalizeName(srcName);
                return new FilteredElementCollector(targetDoc)
                    .OfClass(srcElem.GetType())
                    .Any(e => NormalizeName(e.Name).Equals(cleanElem, StringComparison.OrdinalIgnoreCase));
            }

            if (srcElem.Category != null)
            {
                string cleanCatName = NormalizeName(srcName);
                return new FilteredElementCollector(targetDoc)
                    .OfCategoryId(srcElem.Category.Id)
                    .Any(e => NormalizeName(e.Name).Equals(cleanCatName, StringComparison.OrdinalIgnoreCase));
            }
        }
        catch
        {
            try
            {
                string cleanFallback = NormalizeName(srcName);
                return new FilteredElementCollector(targetDoc)
                    .WhereElementIsNotElementType()
                    .Any(e => NormalizeName(e.Name).Equals(cleanFallback, StringComparison.OrdinalIgnoreCase));
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
    public static void LogTargetViewsCheckpoint(Document targetDoc, string checkpointName)
    {
        try
        {
            var planViews = new FilteredElementCollector(targetDoc)
                .OfClass(typeof(ViewPlan))
                .Cast<ViewPlan>()
                .Where(v => !v.IsTemplate)
                .Select(v => $"'{v.Name}'(Id:{v.Id.Value})")
                .ToList();
            LoggerService.LogInfo($"[VIEW CHECKPOINT - {checkpointName}]: Total ViewPlans in targetDoc: {planViews.Count}. List: [{string.Join(", ", planViews)}]");
        }
        catch (Exception ex)
        {
            LoggerService.LogWarning($"[VIEW CHECKPOINT - {checkpointName}]: Error listing target views: {ex.Message}");
        }
    }

    private static ViewPlan CreateViewPlan(Document sourceDoc, Document targetDoc, ViewPlan srcViewPlan, Dictionary<string, string>? levelMappings, bool forceLevel, Configuraciones? config = null, bool forceNewSuffixedView = false)
    {
        LoggerService.LogInfo($"CreateViewPlan [START]: Processing ViewPlan '{srcViewPlan.Name}' (Source ViewId: {srcViewPlan.Id.Value}, ForceNewSuffixed: {forceNewSuffixedView})...");
        LogTargetViewsCheckpoint(targetDoc, "6-CREATE_VIEW_PLAN_START");

        // 1. Get the ViewFamily of the source view
        ViewFamilyType srcVft = sourceDoc.GetElement(srcViewPlan.GetTypeId()) as ViewFamilyType;
        if (srcVft == null)
        {
            LoggerService.LogWarning($"CreateViewPlan [ABORT]: Source ViewFamilyType is null for '{srcViewPlan.Name}'.");
            return null;
        }
        ViewFamily family = srcVft.ViewFamily;

        // 2. Find a matching ViewFamilyType in targetDoc
        ViewFamilyType targetVft = new FilteredElementCollector(targetDoc)
            .OfClass(typeof(ViewFamilyType))
            .Cast<ViewFamilyType>()
            .FirstOrDefault(vft => vft.ViewFamily == family);

        if (targetVft == null)
        {
            LoggerService.LogWarning($"CreateViewPlan [ABORT]: Could not find matching ViewFamilyType for ViewFamily '{family}' in target document.");
            return null;
        }

        string desiredName = srcViewPlan.Name;
        View existingByName = FindExistingViewByName(targetDoc, desiredName);

        if (existingByName != null && !forceNewSuffixedView)
        {
            if (config == null || config.cf_rbKeepOriginal)
            {
                LoggerService.LogInfo($"CreateViewPlan [RE-USE EXISTING]: View '{desiredName}' already exists in target document (Target Id: {existingByName.Id.Value}). Re-using existing view without creating a new copy.");
                return existingByName as ViewPlan;
            }
        }

        if (existingByName != null && (forceNewSuffixedView || (config != null && config.cf_rbAppendSuffix)))
        {
            string suffixText = !string.IsNullOrEmpty(config?.cf_suffixText) ? config.cf_suffixText : " 1";
            desiredName = GetUniqueViewName(targetDoc, srcViewPlan.Name + suffixText, srcViewPlan.ViewType);
            LoggerService.LogInfo($"CreateViewPlan [SUFFIX NAME GENERATED]: View '{srcViewPlan.Name}' exists in target. Generated suffixed target view name: '{desiredName}'.");
        }

        // 3. Resolve target Level
        Level srcLevel = srcViewPlan.GenLevel;
        if (srcLevel == null)
        {
            LoggerService.LogWarning($"CreateViewPlan [ABORT]: Source view plan '{srcViewPlan.Name}' does not have a GenLevel. Cannot create plan view.");
            return null;
        }

        ElementId targetLevelId = ElementId.InvalidElementId;
        string srcLevelName = srcLevel.Name;

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

                var existingLevel = targetLevels.FirstOrDefault(l => l.Name.Equals(customName, StringComparison.OrdinalIgnoreCase));
                if (existingLevel != null)
                {
                    targetLevelId = existingLevel.Id;
                    LoggerService.LogInfo($"CreateViewPlan [LEVEL RESOLVED]: Using newly created or existing Level '{existingLevel.Name}' (Id: {existingLevel.Id.Value}).");
                }
                else
                {
                    Level newLevel = Level.Create(targetDoc, srcLevel.Elevation);
                    try { newLevel.Name = customName; }
                    catch { newLevel.Name = GetUniqueLevelName(targetDoc, customName); }
                    targetLevelId = newLevel.Id;
                    targetDoc.Regenerate();
                    LoggerService.LogInfo($"CreateViewPlan [LEVEL CREATED]: Created new Level '{newLevel.Name}' (Id: {newLevel.Id.Value}) at elevation {newLevel.Elevation:F3} ft (mapped from '{srcLevelName}').");
                }
            }
            else
            {
                var matchedLevel = targetLevels.FirstOrDefault(l => l.Name.Equals(mappedActionOrLevel, StringComparison.OrdinalIgnoreCase));
                if (matchedLevel != null)
                {
                    targetLevelId = matchedLevel.Id;
                    LoggerService.LogInfo($"CreateViewPlan [LEVEL MAPPED]: Mapped view level '{srcLevelName}' -> existing Level '{matchedLevel.Name}' (Id: {matchedLevel.Id.Value}).");
                }
                else
                {
                    LoggerService.LogWarning($"CreateViewPlan [LEVEL FALLBACK]: Mapped target level '{mappedActionOrLevel}' not found by name. Falling back to first available level.");
                    var fallbackLevel = targetLevels.FirstOrDefault();
                    if (fallbackLevel != null) targetLevelId = fallbackLevel.Id;
                }
            }
        }
        else
        {
            var matchedLevel = targetLevels.FirstOrDefault(l => l.Name.Equals(srcLevelName, StringComparison.OrdinalIgnoreCase));
            if (matchedLevel != null)
            {
                targetLevelId = matchedLevel.Id;
                LoggerService.LogInfo($"CreateViewPlan [LEVEL MATCHED]: Found matching Level '{matchedLevel.Name}' (Id: {matchedLevel.Id.Value}) in target document.");
            }
            else
            {
                Level newLevel = Level.Create(targetDoc, srcLevel.Elevation);
                try { newLevel.Name = srcLevelName; }
                catch { newLevel.Name = GetUniqueLevelName(targetDoc, srcLevelName); }
                targetLevelId = newLevel.Id;
                targetDoc.Regenerate();
                LoggerService.LogInfo($"CreateViewPlan [LEVEL CREATED]: Created missing Level '{newLevel.Name}' (Id: {newLevel.Id.Value}) at elevation {newLevel.Elevation:F3} ft in target document.");
            }
        }

        LogTargetViewsCheckpoint(targetDoc, "7-AFTER_LEVEL_RESOLUTION");

        if (targetLevelId == ElementId.InvalidElementId)
        {
            LoggerService.LogWarning($"CreateViewPlan [ABORT]: Could not resolve a target Level for '{srcViewPlan.Name}'.");
            return null;
        }

        // 4. Create the new ViewPlan
        ViewPlan targetViewPlan = null;
        try
        {
            LoggerService.LogInfo($"CreateViewPlan [API CALL]: Calling ViewPlan.Create(targetDoc, targetVftId: {targetVft.Id.Value}, targetLevelId: {targetLevelId.Value})...");
            targetViewPlan = ViewPlan.Create(targetDoc, targetVft.Id, targetLevelId);
            LogTargetViewsCheckpoint(targetDoc, "8-AFTER_VIEWPLAN_CREATE_API");
            LoggerService.LogInfo($"CreateViewPlan [API SUCCESS]: ViewPlan.Create succeeded! (Target ViewId: {targetViewPlan.Id.Value}, Initial Default Name: '{targetViewPlan.Name}'). Setting name to '{desiredName}'...");

            try
            {
                targetViewPlan.Name = desiredName;
                LoggerService.LogInfo($"CreateViewPlan [NAME ASSIGNED]: Successfully set view name to '{targetViewPlan.Name}' (Target ViewId: {targetViewPlan.Id.Value}).");
            }
            catch (Exception exName)
            {
                LoggerService.LogWarning($"CreateViewPlan [NAME COLLISION CATCH]: Failed to set view name to '{desiredName}' ({exName.Message}). Falling back to GetUniqueViewName...");
                string uniqueFallbackName = GetUniqueViewName(targetDoc, desiredName, srcViewPlan.ViewType);
                targetViewPlan.Name = uniqueFallbackName;
                LoggerService.LogInfo($"CreateViewPlan [FALLBACK NAME ASSIGNED]: Assigned unique fallback name '{uniqueFallbackName}' to target ViewPlan (Id: {targetViewPlan.Id.Value}).");
            }

            LogTargetViewsCheckpoint(targetDoc, "9-AFTER_VIEWPLAN_NAME_SET");
        }
        catch (Exception exCreate)
        {
            LoggerService.LogError($"CreateViewPlan [API EXCEPTION]: ViewPlan.Create failed for '{srcViewPlan.Name}': {exCreate.Message}", exCreate);
            return null;
        }

        // 5. Copy view settings (templates, filters, scale, crop box)
        LoggerService.LogInfo($"CreateViewPlan [COPY SETTINGS]: Copying scale, discipline, crop box, and templates from '{srcViewPlan.Name}' to '{targetViewPlan.Name}'...");
        CopyViewSettings(srcViewPlan, targetViewPlan);
        targetDoc.Regenerate();
        EnsureViewWorkplane(targetViewPlan);

        LoggerService.LogInfo($"CreateViewPlan [COMPLETE]: Successfully initialized ViewPlan '{targetViewPlan.Name}' (Id: {targetViewPlan.Id.Value}).");
        return targetViewPlan;
    }

    public static Level EnsureSourceLevelExistsInTarget(Document targetDoc, Level srcLevel)
    {
        if (srcLevel == null || !srcLevel.IsValidObject) return null;

        double srcZ = srcLevel.Elevation;
        string srcName = srcLevel.Name;

        var existingLevels = new FilteredElementCollector(targetDoc)
            .OfClass(typeof(Level))
            .Cast<Level>()
            .ToList();

        Level matchLevel = existingLevels.FirstOrDefault(l => 
            string.Equals(l.Name, srcName, StringComparison.OrdinalIgnoreCase));

        if (matchLevel != null) return matchLevel;

        try
        {
            Level tempLvl = Level.Create(targetDoc, srcZ);
            try { tempLvl.Name = srcName; }
            catch { tempLvl.Name = GetUniqueLevelName(targetDoc, srcName); }
            targetDoc.Regenerate();
            LoggerService.LogInfo($"EnsureSourceLevelExistsInTarget: Created level '{tempLvl.Name}' (Id: {tempLvl.Id.Value}, Z={srcZ:F3} ft) in target doc to satisfy CopyElements workplane matching.");
            return tempLvl;
        }
        catch (Exception ex)
        {
            LoggerService.LogWarning($"EnsureSourceLevelExistsInTarget: Could not create level in target: {ex.Message}");
            return null;
        }
    }

    public static SketchPlane GetOrCreateLevelSketchPlane(Document doc, Level level)
    {
        if (level == null || !level.IsValidObject) return null;

        try
        {
            var levelSketchPlanes = new FilteredElementCollector(doc)
                .OfClass(typeof(SketchPlane))
                .Cast<SketchPlane>()
                .ToList();

            foreach (var sk in levelSketchPlanes)
            {
                try
                {
                    Plane p = sk.GetPlane();
                    if (p != null)
                    {
                        if (Math.Abs(p.Origin.Z - level.Elevation) < 0.001 &&
                            Math.Abs(p.Normal.Z - 1.0) < 0.001)
                        {
                            return sk;
                        }
                    }
                }
                catch { }
            }
        }
        catch { }

        try
        {
            return SketchPlane.Create(doc, level.Id);
        }
        catch
        {
            try
            {
                Plane plane = Plane.CreateByNormalAndOrigin(XYZ.BasisZ, new XYZ(0, 0, level.Elevation));
                return SketchPlane.Create(doc, plane);
            }
            catch
            {
                return null;
            }
        }
    }

    public static void EnsureViewWorkplane(View targetView)
    {
        if (targetView == null || targetView.Document == null || !targetView.IsValidObject) return;

        // ViewPlan views cannot have an explicitly assigned SketchPlane in Revit API.
        // Assigning one causes NewDetailCurve to throw "View does not and may not contain a fixed sketch plane".
        if (targetView is ViewPlan) return;

        try
        {
            Document doc = targetView.Document;

            if (targetView.SketchPlane == null || !targetView.SketchPlane.IsValidObject)
            {
                doc.Regenerate();
                if (targetView.GenLevel != null && targetView.GenLevel.IsValidObject)
                {
                    SketchPlane sk = GetOrCreateLevelSketchPlane(doc, targetView.GenLevel);
                    if (sk != null)
                    {
                        try
                        {
                            targetView.SketchPlane = sk;
                            doc.Regenerate();
                            LoggerService.LogInfo($"EnsureViewWorkplane: Successfully assigned Level SketchPlane (Id: {sk.Id.Value}) to view '{targetView.Name}'.");
                        }
                        catch (Exception exAssign)
                        {
                            LoggerService.LogWarning($"EnsureViewWorkplane: Could not assign SketchPlane to view '{targetView.Name}': {exAssign.Message}");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LoggerService.LogWarning($"EnsureViewWorkplane [EXCEPTION]: Exception ensuring SketchPlane for '{targetView.Name}': {ex.Message}");
        }
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

    public static void CopyViewInstanceParameters(View srcView, View targetView)
    {
        if (srcView == null || targetView == null) return;

        foreach (Parameter srcParam in srcView.Parameters)
        {
            if (srcParam == null || srcParam.IsReadOnly || !srcParam.HasValue) continue;

            string paramName = srcParam.Definition?.Name ?? string.Empty;
            if (string.IsNullOrWhiteSpace(paramName)) continue;

            if (paramName.Equals("Nombre de vista", StringComparison.OrdinalIgnoreCase) ||
                paramName.Equals("View Name", StringComparison.OrdinalIgnoreCase) ||
                paramName.Equals("Nivel asociado", StringComparison.OrdinalIgnoreCase) ||
                paramName.Equals("Associated Level", StringComparison.OrdinalIgnoreCase) ||
                paramName.Equals("Plantilla de vista", StringComparison.OrdinalIgnoreCase) ||
                paramName.Equals("View Template", StringComparison.OrdinalIgnoreCase) ||
                paramName.Equals("Escala de vista", StringComparison.OrdinalIgnoreCase) ||
                paramName.Equals("View Scale", StringComparison.OrdinalIgnoreCase) ||
                paramName.Equals("Dependencia", StringComparison.OrdinalIgnoreCase) ||
                paramName.Equals("Dependency", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            Parameter targetParam = targetView.LookupParameter(paramName);
            if (targetParam != null && !targetParam.IsReadOnly)
            {
                try
                {
                    switch (srcParam.StorageType)
                    {
                        case StorageType.String:
                            string strVal = srcParam.AsString();
                            if (strVal != null) targetParam.Set(strVal);
                            break;

                        case StorageType.Integer:
                            targetParam.Set(srcParam.AsInteger());
                            break;

                        case StorageType.Double:
                            targetParam.Set(srcParam.AsDouble());
                            break;

                        case StorageType.ElementId:
                            ElementId idVal = srcParam.AsElementId();
                            if (idVal != ElementId.InvalidElementId)
                            {
                                try { targetParam.Set(idVal); } catch { }
                            }
                            break;
                    }
                    LoggerService.LogInfo($"CopyViewInstanceParameters: Transferred parameter '{paramName}' = '{srcParam.AsValueString() ?? srcParam.AsString()}' to view '{targetView.Name}'.");
                }
                catch (Exception exParam)
                {
                    LoggerService.LogWarning($"CopyViewInstanceParameters: Could not set parameter '{paramName}' on '{targetView.Name}': {exParam.Message}");
                }
            }
        }
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

            // View Template assignment
            if (srcView.ViewTemplateId != ElementId.InvalidElementId)
            {
                View srcTemplate = srcView.Document.GetElement(srcView.ViewTemplateId) as View;
                if (srcTemplate != null)
                {
                    View targetTemplate = new FilteredElementCollector(targetView.Document)
                        .OfClass(typeof(View))
                        .Cast<View>()
                        .FirstOrDefault(v => v.IsTemplate && v.Name.Equals(srcTemplate.Name, StringComparison.OrdinalIgnoreCase));
                    if (targetTemplate != null)
                    {
                        try
                        {
                            targetView.ViewTemplateId = targetTemplate.Id;
                            LoggerService.LogInfo($"CopyViewSettings: Successfully assigned template '{targetTemplate.Name}' to view '{targetView.Name}'.");
                        }
                        catch (Exception exTmplAssign)
                        {
                            LoggerService.LogWarning($"CopyViewSettings: Could not assign template '{targetTemplate.Name}' to view '{targetView.Name}': {exTmplAssign.Message}");
                        }
                    }
                }
            }

            // Copy custom and user project/shared instance parameters (e.g. KRN_Grupo 1, KRN_Grupo 2, KRN_Grupo 3)
            CopyViewInstanceParameters(srcView, targetView);
        }
        catch (Exception ex)
        {
            LoggerService.LogWarning($"CopyViewSettings: Failed to copy some view properties for '{srcView.Name}': {ex.Message}");
        }
    }

    private static ViewSheet CreateViewSheet(Document sourceDoc, Document targetDoc, ViewSheet srcSheet, Configuraciones config)
    {
        LoggerService.LogInfo($"CreateViewSheet: Pre-check for existing sheet '{srcSheet.SheetNumber} - {srcSheet.Name}' in target document...");

        var existingSheet = FindExistingSheetByNumberOrName(targetDoc, srcSheet.SheetNumber, srcSheet.Name);

        if (existingSheet != null)
        {
            if (config.cf_rbKeepOriginal)
            {
                LoggerService.LogInfo($"CreateViewSheet: ViewSheet '{srcSheet.SheetNumber} - {srcSheet.Name}' (Id: {existingSheet.Id.Value}) already exists in target document. Option 'Keep Original' active. Re-using existing target sheet.");
                return existingSheet;
            }
            else if (config.cf_rbAbortTransaction)
            {
                LoggerService.LogWarning($"CreateViewSheet: ViewSheet '{srcSheet.SheetNumber} - {srcSheet.Name}' already exists in target document. Option 'Abort Transaction' active.");
                return null;
            }
        }

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
                    LoggerService.LogInfo($"CreateViewSheet: Matched TitleBlock family type '{srcTbType.Name}' in target document.");
                }
                else
                {
                    try
                    {
                        var copiedTbTypes = ElementTransformUtils.CopyElements(sourceDoc, new List<ElementId> { srcTbTypeId }, targetDoc, null, new CopyPasteOptions());
                        titleBlockTypeId = copiedTbTypes.FirstOrDefault() ?? ElementId.InvalidElementId;
                        LoggerService.LogInfo($"CreateViewSheet: Copied TitleBlock family type '{srcTbType.Name}' into target document.");
                    }
                    catch (Exception exTb)
                    {
                        LoggerService.LogWarning($"CreateViewSheet: Could not copy TitleBlock type '{srcTbType.Name}': {exTb.Message}");
                    }
                }
            }
        }

        // 2. Create the ViewSheet
        LoggerService.LogInfo($"CreateViewSheet: Executing ViewSheet.Create for '{srcSheet.SheetNumber} - {srcSheet.Name}'...");
        ViewSheet targetSheet = ViewSheet.Create(targetDoc, titleBlockTypeId);

        // 3. Resolve SheetNumber and Name according to duplicate config
        string evalSheetNumber = srcSheet.SheetNumber;
        string evalName = srcSheet.Name;

        if (existingSheet != null && config.cf_rbAppendSuffix)
        {
            evalSheetNumber += config.cf_suffixText;
            evalName += config.cf_suffixText;
            LoggerService.LogInfo($"CreateViewSheet: Option 'Append Suffix' active. Assigned sheet number '{evalSheetNumber}'.");
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
