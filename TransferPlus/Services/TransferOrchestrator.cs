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
        Dictionary<ElementId, string>? customNames = null)
    {
        var elementsCopyList = new List<ElementId>();
        var familiesLoadList = new List<Elemento>();
        var worksetsToCreate = new List<Elemento>();
        var objectStylesToTransfer = new List<Elemento>();

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
                WarningSwallower.AttachToTransaction(t);
                foreach (var wsItem in worksetsToCreate)
                {
                    string wsName = customNames?.ContainsKey(wsItem.eID) == true ? customNames[wsItem.eID] : wsItem.Nombre;
                    Report($"Creating Workset: {wsName}");
                    try
                    {
                        if (!WorksetTable.IsWorksetNameUnique(targetDoc, wsName)) continue;
                        Workset.Create(targetDoc, wsName);
                    }
                    catch { }
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
                        Document famDoc = sourceDoc.EditFamily(family);
                        string tempDir = Path.Combine(Path.GetTempPath(), "TransferPlusTMP");
                        if (!Directory.Exists(tempDir)) Directory.CreateDirectory(tempDir);

                        string tempPath = Path.Combine(tempDir, family.Name + ".rfa");
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
                catch { }
            }
        }

        // 2.5. Process Object Styles
        if (objectStylesToTransfer.Any())
        {
            using (Transaction t = new Transaction(targetDoc, "TransferPlus: Object Styles"))
            {
                t.Start();
                WarningSwallower.AttachToTransaction(t);
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
                                targetCat = targetDoc.Settings.Categories.NewSubcategory(destParent, catName);
                            }
                        }

                        if (targetCat != null)
                        {
                            TransferSingleCategoryStyle(sourceDoc, targetDoc, sourceCat, targetCat);
                        }
                    }
                    catch { }
                }
                t.Commit();
            }
        }

        // 3. Process Standards and View elements (CopyElements)
        if (elementsCopyList.Any())
        {
            using (Transaction t = new Transaction(targetDoc, "TransferPlus: Standards"))
            {
                t.Start();
                WarningSwallower.AttachToTransaction(t);

                CopyPasteOptions options = new CopyPasteOptions();
                options.SetDuplicateTypeNamesHandler(config.cf_rbOverride 
                    ? new CustomCopyHandlerOk() 
                    : new CustomCopyHandlerAbort());

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

                try
                {
                    Report("Copying Standards Elements");
                    ICollection<ElementId> copied = ElementTransformUtils.CopyElements(sourceDoc, elementsCopyList, targetDoc, transform, options);

                    // If copy includes views, match templates, copy detail items and callouts recursively
                    for (int i = 0; i < elementsCopyList.Count; i++)
                    {
                        ElementId originalId = elementsCopyList[i];
                        ElementId newId = copied.ElementAtOrDefault(i);
                        if (newId == null || newId == ElementId.InvalidElementId) continue;

                        if (sourceDoc.GetElement(originalId) is View sourceView && targetDoc.GetElement(newId) is View targetView)
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
                        }
                    }

                    // Apply renamed elements
                    if (customNames != null)
                    {
                        for (int i = 0; i < elementsCopyList.Count; i++)
                        {
                            ElementId originalId = elementsCopyList[i];
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
                catch { }

                t.Commit();
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
        catch { }
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
                                catch { }

                                try
                                {
                                    Line rotationAxis = GetRotationAxisFromTransform(T);
                                    double angle = GetRotationAngleFromTransform(T);
                                    if (angle != 0.0)
                                    {
                                        ElementTransformUtils.RotateElement(destino, GetCropBoxFor(view), rotationAxis, angle);
                                    }
                                }
                                catch { }

                                try
                                {
                                    XYZ offset = DameVectorReposicionOrigenTransformada(view2, view, T);
                                    if (!offset.IsAlmostEqualTo(XYZ.Zero))
                                    {
                                        ElementTransformUtils.MoveElement(destino, GetCropBoxFor(view), offset);
                                    }
                                }
                                catch { }
                            }

                            if (CopiaDetalles)
                            {
                                ponDependientes(origen, vistaorigen.GetDependentElements(null), view2, view, copyOptions);
                            }

                            ponCallouts(origen, destino, view2, view, copyOptions, CopiaDetalles, Contador + 1, transforma, T);
                        }
                    }
                    catch { }
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
        public DuplicateTypeAction OnDuplicateTypeNamesFound(DuplicateTypeNamesHandlerArgs args)
        {
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
