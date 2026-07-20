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
                elementsCopyList.Add(item.eID);
            }
        }

        int totalCount = worksetsToCreate.Count + familiesLoadList.Count + elementsCopyList.Count + objectStylesToTransfer.Count;
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
                    }

                    // If copy includes views, match templates, copy detail items and callouts recursively
                    for (int i = 0; i < finalCopyList.Count; i++)
                    {
                        ElementId originalId = finalCopyList[i];
                        ElementId newId = copied.ElementAtOrDefault(i);
                        if (newId == null || newId == ElementId.InvalidElementId) continue;

                        Element srcElem = sourceDoc.GetElement(originalId);
                        Element destElem = targetDoc.GetElement(newId);

                        if (srcElem is View sourceView && destElem is View targetView)
                        {
                            matchPlantilla(sourceDoc, targetDoc, sourceView, targetView);
                            
                            if (config.cf_chk_Callout)
                            {
                                ponCallouts(sourceDoc, targetDoc, sourceView, targetView, options, config.cf_chk_ViewElements, 1, transform != null, transform);
                            }
                            else if (config.cf_chk_ViewElements)
                            {
                                ponDependientes(sourceDoc, sourceView.GetDependentElements(null), sourceView, targetView, options);
                            }

                            // Replicate sheet TitleBlocks, 2D elements, views and viewports
                            if (sourceView is ViewSheet sourceSheet && targetView is ViewSheet targetSheet)
                            {
                                LoggerService.LogInfo($"SheetTransfer: Processing Sheet '{sourceSheet.SheetNumber} - {sourceSheet.Name}' (Id: {sourceSheet.Id.Value}) -> Target Sheet '{targetSheet.SheetNumber} - {targetSheet.Name}' (Id: {targetSheet.Id.Value})");

                                try
                                {
                                    var sheetElementsToCopy = new FilteredElementCollector(sourceDoc, sourceSheet.Id)
                                        .WhereElementIsNotElementType()
                                        .Where(e => e is not Viewport && e is not View && e is not SunAndShadowSettings && e is not Level && e is not SketchPlane)
                                        .Select(e => e.Id)
                                        .ToList();

                                    LoggerService.LogInfo($"SheetTransfer: Found {sheetElementsToCopy.Count} TitleBlocks/2D elements on source sheet '{sourceSheet.SheetNumber}'.");

                                    if (sheetElementsToCopy.Any())
                                    {
                                        var copiedSheetElements = ElementTransformUtils.CopyElements(sourceSheet, sheetElementsToCopy, targetSheet, Transform.Identity, options);
                                        LoggerService.LogInfo($"SheetTransfer: Successfully copied {copiedSheetElements.Count} TitleBlocks/2D elements to target sheet '{targetSheet.SheetNumber}'.");
                                    }
                                }
                                catch (Exception exSheetElements)
                                {
                                    LoggerService.LogError($"SheetTransfer: Failed copying TitleBlock/2D elements for sheet '{sourceSheet.SheetNumber}'", exSheetElements);
                                }

                                if (config.cf_chk_SheetWithViews)
                                {
                                    LoggerService.LogInfo($"SheetTransfer: Replicating placed views and viewports for Sheet '{sourceSheet.SheetNumber}'...");
                                    foreach (ElementId placedViewId in sourceSheet.GetAllPlacedViews())
                                    {
                                        try
                                        {
                                            View srcPlacedView = sourceDoc.GetElement(placedViewId) as View;
                                            if (srcPlacedView == null) continue;

                                            ElementId targetViewId = ElementId.InvalidElementId;
                                            bool shouldCopyView = true;

                                            // Check if Legend, Schedule, or Assembly View
                                            bool isLegend = srcPlacedView.ViewType == ViewType.Legend;
                                            bool isSchedule = srcPlacedView.ViewType == ViewType.Schedule;
                                            bool isAssembly = srcPlacedView.IsAssemblyView;

                                            if ((isLegend && config.cf_chk_UseLegendIfExists) ||
                                                (isSchedule && config.cf_chk_UseScheduleIfExists) ||
                                                (isAssembly && config.cf_chk_UseAssemblyViewsIfExists))
                                            {
                                                var existingTargetView = new FilteredElementCollector(targetDoc)
                                                    .OfClass(typeof(View))
                                                    .Cast<View>()
                                                    .FirstOrDefault(v => v.ViewType == srcPlacedView.ViewType && v.Name.Equals(srcPlacedView.Name, StringComparison.OrdinalIgnoreCase));

                                                if (existingTargetView != null)
                                                {
                                                    shouldCopyView = false;
                                                    if (config.cf_rbKeepOriginal)
                                                    {
                                                        targetViewId = existingTargetView.Id;
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

                                            if (shouldCopyView)
                                            {
                                                var copiedViewIds = ElementTransformUtils.CopyElements(sourceDoc, new List<ElementId> { placedViewId }, targetDoc, transform, options);
                                                targetViewId = copiedViewIds.FirstOrDefault() ?? ElementId.InvalidElementId;

                                                if (targetViewId != ElementId.InvalidElementId)
                                                {
                                                    View newPlacedView = targetDoc.GetElement(targetViewId) as View;
                                                    if (newPlacedView != null)
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

                                                        if (transform != null)
                                                        {
                                                            try
                                                            {
                                                                if (!transform.Origin.IsAlmostEqualTo(XYZ.Zero))
                                                                {
                                                                    ElementTransformUtils.MoveElement(targetDoc, GetCropBoxFor(newPlacedView), transform.Origin);
                                                                }
                                                            }
                                                            catch { }

                                                            try
                                                            {
                                                                Line rotationAxis = GetRotationAxisFromTransform(transform);
                                                                double angle = GetRotationAngleFromTransform(transform);
                                                                if (angle != 0.0)
                                                                {
                                                                    ElementTransformUtils.RotateElement(targetDoc, GetCropBoxFor(newPlacedView), rotationAxis, angle);
                                                                }
                                                            }
                                                            catch { }
                                                        }

                                                        matchPlantilla(sourceDoc, targetDoc, srcPlacedView, newPlacedView);

                                                        if (config.cf_chk_ViewElements)
                                                        {
                                                            ponDependientes(sourceDoc, srcPlacedView.GetDependentElements(null), srcPlacedView, newPlacedView, options);
                                                        }

                                                        if (config.cf_chk_Callout && srcPlacedView.ViewType != ViewType.DraftingView)
                                                        {
                                                            ponCallouts(sourceDoc, targetDoc, srcPlacedView, newPlacedView, options, config.cf_chk_ViewElements, 3, transform != null, transform);
                                                        }
                                                    }
                                                }
                                            }

                                            if (targetViewId != ElementId.InvalidElementId)
                                            {
                                                foreach (Element element3 in new FilteredElementCollector(sourceDoc).OfClass(typeof(Viewport)))
                                                {
                                                    Viewport srcViewport = (Viewport)element3;
                                                    if (srcViewport.SheetId == sourceSheet.Id && srcViewport.ViewId == placedViewId)
                                                    {
                                                        BoundingBoxXYZ boundingBoxXYZ = srcViewport.get_BoundingBox(sourceSheet);
                                                        XYZ xyz = (boundingBoxXYZ.Max + boundingBoxXYZ.Min) / 2.0;
                                                        string name = srcViewport.Name;

                                                        Viewport targetViewport = Viewport.Create(targetDoc, targetSheet.Id, targetViewId, XYZ.Zero);
                                                        foreach (ElementId typeId in targetViewport.GetValidTypes())
                                                        {
                                                            if ((targetDoc.GetElement(typeId) as ElementType).Name.Equals(name))
                                                            {
                                                                targetViewport.ChangeTypeId(typeId);
                                                            }
                                                        }
                                                        BoundingBoxXYZ boundingBoxXYZ2 = targetViewport.get_BoundingBox(targetSheet);
                                                        XYZ xyz2 = (boundingBoxXYZ2.Max + boundingBoxXYZ2.Min) / 2.0;
                                                        ElementTransformUtils.MoveElement(targetDoc, targetViewport.Id, new XYZ(xyz.X - xyz2.X, xyz.Y - xyz2.Y, 0.0));
                                                    }
                                                }
                                            }
                                        }
                                        catch (OperationCanceledException)
                                        {
                                            throw;
                                        }
                                        catch (Exception ex)
                                        {
                                            LoggerService.LogExceptionSilently("Replicating sheet viewport/view", ex);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Apply renamed elements
                    if (customNames != null && tempDoc == null)
                    {
                        for (int i = 0; i < finalCopyList.Count; i++)
                        {
                            ElementId originalId = finalCopyList[i];
                            ElementId newId = copied.ElementAtOrDefault(i);
                            if (newId != null && newId != ElementId.InvalidElementId && customNames.ContainsKey(originalId))
                            {
                                try
                                {
                                    Element newElem = targetDoc.GetElement(newId);
                                    if (newElem != null) newElem.Name = customNames[originalId];
                                }
                                catch { }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (config.cf_rbAbortTransaction && abortHandler.Triggered)
                    {
                        t.RollBack();
                        var cancelEx = new OperationCanceledException("Transfer canceled: Duplicate element names found.", ex);
                        cancelEx.Data["Duplicates"] = duplicateItems;
                        throw cancelEx;
                    }
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
    }

    public static void ponDependientes(Document origen, ICollection<ElementId> dependientes, View vistaorigen, View vistadestino, CopyPasteOptions copyOptions)
    {
        var collection = new List<ElementId>();
        foreach (ElementId elementId in dependientes)
        {
            Element element = origen.GetElement(elementId);
            if (element != null && element is not View && element is not SunAndShadowSettings && element is not Level && element is not Viewport && element is not SketchPlane)
            {
                if (element.OwnerViewId == vistaorigen.Id)
                {
                    collection.Add(elementId);
                }
            }
        }
        try
        {
            if (collection.Any())
            {
                ElementTransformUtils.CopyElements(vistaorigen, collection, vistadestino, Transform.Identity, copyOptions);
            }
        }
        catch (Exception ex)
        {
            LoggerService.LogExceptionSilently("Copying ViewSpecific elements (ponDependientes)", ex);
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

    public static void matchPlantilla(Document origen, Document destino, View vistaorigen, View vistadestino)
    {
        if (vistaorigen.ViewTemplateId == ElementId.InvalidElementId) return;

        if (origen.GetElement(vistaorigen.ViewTemplateId) is View templateView)
        {
            string tName = templateView.Name;
            var list = new FilteredElementCollector(destino)
                .OfClass(typeof(View))
                .Cast<View>()
                .Where(v => v.IsTemplate && v.Name.Equals(tName))
                .Select(v => v.Id)
                .ToList();

            if (list.Any())
            {
                try
                {
                    vistadestino.ViewTemplateId = list.First();
                }
                catch { }
            }
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
}
