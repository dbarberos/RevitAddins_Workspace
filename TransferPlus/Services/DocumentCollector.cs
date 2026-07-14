using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services;

public static class DocumentCollector
{
    public static List<Elemento> GetTransferableElements(Document _doc_origen, Action<string, int, int>? progressCallback = null)
    {
        var elementsAFiltrar = new List<Elemento>();
        int num = 0;
        int maxMain = 33;

        void Report(string stepName, int currentCount)
        {
            num++;
            progressCallback?.Invoke(stepName, num, maxMain);
        }

        // 1. Element Types
        var collection = new FilteredElementCollector(_doc_origen).WhereElementIsElementType().ToElementIds();
        Report("Collecting Element Types", collection.Count);
        foreach (ElementId elementId in collection)
        {
            Element element = _doc_origen.GetElement(elementId);
            if (element != null && element is not AssemblyType && element is not RevitLinkType && element.Category != null)
            {
                try
                {
                    Elemento item = new Elemento(element);
                    elementsAFiltrar.Add(item);
                }
                catch { }
            }
        }

        // 2. Filters
        var collection2 = new FilteredElementCollector(_doc_origen).OfClass(typeof(ParameterFilterElement)).ToElementIds();
        Report("Collecting Filters", collection2.Count);
        foreach (ElementId elementId2 in collection2)
        {
            Element element2 = _doc_origen.GetElement(elementId2);
            if (element2 != null)
            {
                try
                {
                    Elemento item2 = new Elemento(element2, "Filters", 0, _doc_origen);
                    elementsAFiltrar.Add(item2);
                }
                catch { }
            }
        }

        // 3. View Templates
        var list = new FilteredElementCollector(_doc_origen).OfClass(typeof(View)).Cast<View>().Where(i => i.IsTemplate).Select(i => i.Id).ToList();
        Report("Collecting View Templates", list.Count);
        foreach (ElementId elementId3 in list)
        {
            Element element3 = _doc_origen.GetElement(elementId3);
            if (element3 != null)
            {
                try
                {
                    Elemento item3 = new Elemento(element3, "View Templates", 3, _doc_origen);
                    elementsAFiltrar.Add(item3);
                }
                catch { }
            }
        }

        // 4. Browser Organization
        var list2 = new FilteredElementCollector(_doc_origen).OfClass(typeof(BrowserOrganization)).Select(i => i.Id).ToList();
        Report("Collecting Browser Organization Settings", list2.Count);
        foreach (ElementId elementId4 in list2)
        {
            Element element4 = _doc_origen.GetElement(elementId4);
            if (element4 != null && element4 is BrowserOrganization browserOrganization)
            {
                try
                {
                    Elemento item4 = new Elemento(element4, "Browser Organization", browserOrganization.FamilyName, "Undefined", _doc_origen);
                    elementsAFiltrar.Add(item4);
                }
                catch { }
            }
        }

        // 5. DWG Export Settings
        var list3 = new FilteredElementCollector(_doc_origen).OfClass(typeof(ExportDWGSettings)).Select(i => i.Id).ToList();
        Report("Collecting DWG Export Settings", list3.Count);
        foreach (ElementId elementId5 in list3)
        {
            Element element5 = _doc_origen.GetElement(elementId5);
            if (element5 != null)
            {
                try
                {
                    Elemento item5 = new Elemento(element5, "DWG Export Settings", 0, _doc_origen);
                    elementsAFiltrar.Add(item5);
                }
                catch { }
            }
        }

        // 6. Project Standards Category Filters
        var filteredElementCollector2 = new FilteredElementCollector(_doc_origen);
        filteredElementCollector2.WherePasses(new LogicalOrFilter(new List<ElementFilter>
        {
            new ElementCategoryFilter((BuiltInCategory)(-2000552)),
            new ElementCategoryFilter((BuiltInCategory)(-2003201)),
            new ElementCategoryFilter((BuiltInCategory)(-2000112)),
            new ElementCategoryFilter((BuiltInCategory)(-2006000))
        }));
        var collection3 = filteredElementCollector2.ToElementIds();
        Report("Collecting Standards", collection3.Count);
        foreach (ElementId elementId6 in collection3)
        {
            Element element6 = _doc_origen.GetElement(elementId6);
            if (element6 != null)
            {
                try
                {
                    Elemento item6 = new Elemento(element6, 0);
                    elementsAFiltrar.Add(item6);
                }
                catch { }
            }
        }

        // 7. Views
        var list4 = new FilteredElementCollector(_doc_origen).OfClass(typeof(View)).WhereElementIsNotElementType().Cast<View>().Where(i => !i.IsTemplate).Select(i => i.Id).ToList();
        Report("Collecting Views", list4.Count);
        foreach (ElementId elementId7 in list4)
        {
            bool flag = false;
            Element element7 = _doc_origen.GetElement(elementId7);
            if (element7 != null && element7 is View view && view.ViewType != ViewType.Internal && view.ViewType != ViewType.ProjectBrowser)
            {
                if (view.IsAssemblyView || view.ViewType == ViewType.ThreeD)
                {
                    flag = true;
                }
                if (element7.get_Parameter((BuiltInParameter)(-1002051))?.AsValueString() != null || view.ViewType == ViewType.Legend || view.ViewType == ViewType.Schedule || view.ViewType == ViewType.DrawingSheet)
                {
                    if (view.GetPrimaryViewId().IntegerValue != -1)
                    {
                        flag = true;
                    }
                    if (element7.get_Parameter((BuiltInParameter)(-1006612)) != null && element7.get_Parameter((BuiltInParameter)(-1006612)).AsElementId() != ElementId.InvalidElementId)
                    {
                        flag = true;
                    }
                    try
                    {
                        Elemento elemento = new Elemento(element7, "Views", 0, _doc_origen);
                        if (flag)
                        {
                            elemento.NoTransferible = true;
                        }
                        elementsAFiltrar.Add(elemento);
                    }
                    catch { }
                }
            }
        }

        // 8. Elevation Markers
        var list5 = new FilteredElementCollector(_doc_origen).OfClass(typeof(ElevationMarker)).WhereElementIsNotElementType().Cast<ElevationMarker>().Where(i => i.CurrentViewCount > 0).Select(i => i.Id).ToList();
        Report("Collecting Elevation Markers", list5.Count);
        foreach (ElementId elementId8 in list5)
        {
            Element element8 = _doc_origen.GetElement(elementId8);
            if (element8 != null && element8 is ElevationMarker elevationMarker)
            {
                string text = "Views:";
                for (int j = 0; j < elevationMarker.MaximumViewCount; j++)
                {
                    ElementId viewId = elevationMarker.GetViewId(j);
                    if (viewId != ElementId.InvalidElementId)
                    {
                        Element element9 = _doc_origen.GetElement(viewId);
                        if (element9 != null)
                        {
                            text = text + " " + element9.Name;
                        }
                    }
                }
                try
                {
                    Elemento elemento2 = new Elemento(element8, "Views", "Elevation", "Group of Views", text, _doc_origen);
                    elemento2.IsElevation = true;
                    elementsAFiltrar.Add(elemento2);
                }
                catch { }
            }
        }

        // 9. Viewport Types
        var list6 = new FilteredElementCollector(_doc_origen).OfClass(typeof(ElementType)).Cast<ElementType>().Where(q => q.FamilyName == "Viewport").Select(i => i.Id).ToList();
        Report("Collecting Viewport Types", list6.Count);
        foreach (ElementId elementId9 in list6)
        {
            Element element10 = _doc_origen.GetElement(elementId9);
            if (element10 != null)
            {
                try
                {
                    Elemento item7 = new Elemento(element10, "Viewport Types", 0, _doc_origen);
                    elementsAFiltrar.Add(item7);
                }
                catch { }
            }
        }

        // 10. Materials
        var list7 = new FilteredElementCollector(_doc_origen).OfClass(typeof(Material)).Select(i => i.Id).ToList();
        Report("Collecting Materials", list7.Count);
        foreach (ElementId elementId10 in list7)
        {
            Element element11 = _doc_origen.GetElement(elementId10);
            if (element11 != null)
            {
                try
                {
                    Elemento item8 = new Elemento(element11, 0);
                    elementsAFiltrar.Add(item8);
                }
                catch { }
            }
        }

        // 11. Worksets
        if (_doc_origen.IsWorkshared)
        {
            var filteredWorksetCollector = new FilteredWorksetCollector(_doc_origen).OfKind(WorksetKind.UserWorkset);
            Report("Collecting Worksets", filteredWorksetCollector.Count());
            foreach (Workset ws in filteredWorksetCollector)
            {
                try
                {
                    Elemento item9 = new Elemento(ws);
                    elementsAFiltrar.Add(item9);
                }
                catch { }
            }
        }
        else
        {
            Report("Skipping Worksets (Not Workshared)", 0);
        }

        // 12. Print Settings
        var list8 = new FilteredElementCollector(_doc_origen).OfClass(typeof(PrintSetting)).Select(i => i.Id).ToList();
        Report("Collecting Print Settings", list8.Count);
        foreach (ElementId elementId11 in list8)
        {
            Element element12 = _doc_origen.GetElement(elementId11);
            if (element12 != null)
            {
                try
                {
                    Elemento item10 = new Elemento(element12, "Print Settings", 0, _doc_origen);
                    elementsAFiltrar.Add(item10);
                }
                catch { }
            }
        }

        // 13. TextNote Types
        var list9 = new FilteredElementCollector(_doc_origen).OfClass(typeof(TextNoteType)).Select(i => i.Id).ToList();
        Report("Collecting TextNote Types", list9.Count);
        foreach (ElementId elementId12 in list9)
        {
            Element element13 = _doc_origen.GetElement(elementId12);
            if (element13 != null)
            {
                try
                {
                    Elemento item11 = new Elemento(element13, "TextNote Types", 0, _doc_origen);
                    elementsAFiltrar.Add(item11);
                }
                catch { }
            }
        }

        // 14. Project Info
        var list10 = new FilteredElementCollector(_doc_origen).OfClass(typeof(ProjectInfo)).Select(i => i.Id).ToList();
        Report("Collecting Project Info", list10.Count);
        foreach (ElementId elementId13 in list10)
        {
            Element element14 = _doc_origen.GetElement(elementId13);
            if (element14 != null)
            {
                try
                {
                    Elemento elemento3 = new Elemento(element14, "Project Info", 0, _doc_origen);
                    elemento3.IsProjectInfo = true;
                    elementsAFiltrar.Add(elemento3);
                }
                catch { }
            }
        }

        // 15. Project Location
        var list11 = new FilteredElementCollector(_doc_origen).OfClass(typeof(ProjectLocation)).Select(i => i.Id).ToList();
        Report("Collecting Project Locations", list11.Count);
        foreach (ElementId elementId14 in list11)
        {
            Element element15 = _doc_origen.GetElement(elementId14);
            if (element15 != null)
            {
                try
                {
                    Elemento item12 = new Elemento(element15, "Project Location", 0, _doc_origen);
                    elementsAFiltrar.Add(item12);
                }
                catch { }
            }
        }

        // 16. Site Location
        var list12 = new FilteredElementCollector(_doc_origen).OfClass(typeof(SiteLocation)).Select(i => i.Id).ToList();
        Report("Collecting Site Locations", list12.Count);
        foreach (ElementId elementId15 in list12)
        {
            Element element16 = _doc_origen.GetElement(elementId15);
            if (element16 != null)
            {
                try
                {
                    Elemento item13 = new Elemento(element16, "Site Location", 2, _doc_origen);
                    elementsAFiltrar.Add(item13);
                }
                catch { }
            }
        }

        // 17. Revision
        var list13 = new FilteredElementCollector(_doc_origen).OfClass(typeof(Revision)).Select(i => i.Id).ToList();
        Report("Collecting Revisions", list13.Count);
        foreach (ElementId elementId16 in list13)
        {
            Element element17 = _doc_origen.GetElement(elementId16);
            if (element17 != null)
            {
                try
                {
                    Elemento item14 = new Elemento(element17, "Revision", 1, _doc_origen);
                    elementsAFiltrar.Add(item14);
                }
                catch { }
            }
        }

        // 18. Revision Settings
        var list14 = new FilteredElementCollector(_doc_origen).OfClass(typeof(RevisionSettings)).Select(i => i.Id).ToList();
        Report("Collecting Revision Settings", list14.Count);
        foreach (ElementId elementId17 in list14)
        {
            Element element18 = _doc_origen.GetElement(elementId17);
            if (element18 != null)
            {
                try
                {
                    Elemento item15 = new Elemento(element18, "Revision Settings", 0, _doc_origen);
                    elementsAFiltrar.Add(item15);
                }
                catch { }
            }
        }

        // 19. Phase Filter
        var list15 = new FilteredElementCollector(_doc_origen).OfClass(typeof(PhaseFilter)).Select(i => i.Id).ToList();
        Report("Collecting Phase Filters", list15.Count);
        foreach (ElementId elementId18 in list15)
        {
            Element element19 = _doc_origen.GetElement(elementId18);
            if (element19 != null)
            {
                try
                {
                    Elemento item16 = new Elemento(element19, "Phase Filter", 0, _doc_origen);
                    elementsAFiltrar.Add(item16);
                }
                catch { }
            }
        }

        // 20. Line Patterns
        var list16 = new FilteredElementCollector(_doc_origen).OfClass(typeof(LinePatternElement)).Select(i => i.Id).ToList();
        Report("Collecting Line Patterns", list16.Count);
        foreach (ElementId elementId19 in list16)
        {
            Element element20 = _doc_origen.GetElement(elementId19);
            if (element20 != null)
            {
                try
                {
                    Elemento item17 = new Elemento(element20, "Line Patterns", 0, _doc_origen);
                    elementsAFiltrar.Add(item17);
                }
                catch { }
            }
        }

        // 21. Fill Patterns
        var list17 = new FilteredElementCollector(_doc_origen).OfClass(typeof(FillPatternElement)).Select(i => i.Id).ToList();
        Report("Collecting Fill Patterns", list17.Count);
        foreach (ElementId elementId20 in list17)
        {
            Element element21 = _doc_origen.GetElement(elementId20);
            if (element21 != null)
            {
                try
                {
                    Elemento item18 = new Elemento(element21, "Fill Patterns", 0, _doc_origen);
                    elementsAFiltrar.Add(item18);
                }
                catch { }
            }
        }

        // 22. Dimension Types
        var list18 = new FilteredElementCollector(_doc_origen).OfClass(typeof(DimensionType)).Select(i => i.Id).ToList();
        Report("Collecting Dimension Types", list18.Count);
        foreach (ElementId elementId21 in list18)
        {
            Element element22 = _doc_origen.GetElement(elementId21);
            if (element22 != null)
            {
                try
                {
                    Elemento item19 = new Elemento(element22, "Dimension Types", 0, _doc_origen);
                    elementsAFiltrar.Add(item19);
                }
                catch { }
            }
        }

        // 23. Parameters
        if (!_doc_origen.IsFamilyDocument)
        {
            var list19 = new FilteredElementCollector(_doc_origen).OfClass(typeof(ParameterElement)).Select(i => i.Id).ToList();
            Report("Collecting Project Parameters", list19.Count);
            foreach (ElementId elementId22 in list19)
            {
                Element element23 = _doc_origen.GetElement(elementId22);
                if (element23 != null)
                {
                    try
                    {
                        Elemento item20 = new Elemento(element23, "Parameters", 7, _doc_origen);
                        elementsAFiltrar.Add(item20);
                    }
                    catch { }
                }
            }

            Report("Collecting Parameter Bindings", 0);
            DefinitionBindingMapIterator definitionBindingMapIterator = _doc_origen.ParameterBindings.ForwardIterator();
            definitionBindingMapIterator.Reset();
            while (definitionBindingMapIterator.MoveNext())
            {
                InternalDefinition internalDefinition = (InternalDefinition)definitionBindingMapIterator.Key;
                Element paramEl = _doc_origen.GetElement(internalDefinition.Id);
                if (paramEl != null)
                {
                    if (paramEl is not SharedParameterElement)
                    {
                        Elemento item23 = new Elemento(paramEl, "Parameters", 5, _doc_origen);
                        elementsAFiltrar.Add(item23);
                    }
                    else
                    {
                        Elemento item24 = new Elemento(paramEl, "Parameters", 6, _doc_origen);
                        elementsAFiltrar.Add(item24);
                    }
                }
            }
        }
        else
        {
            Report("Skipping Parameters (Family Document)", 0);
            Report("Skipping Parameter Bindings", 0);
        }

        // 24. View Family Types
        var list22 = new FilteredElementCollector(_doc_origen).OfClass(typeof(ViewFamilyType)).Select(i => i.Id).ToList();
        Report("Collecting View Family Types", list22.Count);
        foreach (ElementId elementId25 in list22)
        {
            Element element26 = _doc_origen.GetElement(elementId25);
            if (element26 != null)
            {
                try
                {
                    Elemento item25 = new Elemento(element26, "View Family Types", 4, _doc_origen);
                    elementsAFiltrar.Add(item25);
                }
                catch { }
            }
        }

        // 25. Sun And Shadow Settings
        var list23 = new FilteredElementCollector(_doc_origen).OfClass(typeof(SunAndShadowSettings)).Select(i => i.Id).ToList();
        Report("Collecting Sun and Shadow Settings", list23.Count);
        foreach (ElementId elementId26 in list23)
        {
            Element element27 = _doc_origen.GetElement(elementId26);
            if (element27 != null)
            {
                try
                {
                    Elemento item26 = new Elemento(element27, "Sun And Shadow Settings", 0, _doc_origen);
                    elementsAFiltrar.Add(item26);
                }
                catch { }
            }
        }

        // 26. Spatial Elements (Rooms / Spaces)
        var list24 = new FilteredElementCollector(_doc_origen).OfClass(typeof(SpatialElement)).Select(i => i.Id).ToList();
        Report("Collecting Rooms and Spaces", list24.Count);
        foreach (ElementId elementId27 in list24)
        {
            Element element28 = _doc_origen.GetElement(elementId27);
            if (element28 != null)
            {
                try
                {
                    if (element28.Category.Id.IntegerValue == -2000160)
                    {
                        Elemento item27 = new Elemento(element28, "Rooms", 0, _doc_origen);
                        elementsAFiltrar.Add(item27);
                    }
                    else
                    {
                        Elemento item28 = new Elemento(element28, "Spaces", 0, _doc_origen);
                        elementsAFiltrar.Add(item28);
                    }
                }
                catch { }
            }
        }

        // 27. Categories
        Categories categories = _doc_origen.Settings.Categories;
        Report("Collecting Categories", categories.Size);
        foreach (object obj in categories)
        {
            if (obj is Category category && category.Id.IntegerValue <= 0)
            {
                CategoryNameMap subCategories = category.SubCategories;
                if (subCategories != null && subCategories.Size != 0)
                {
                    foreach (object obj2 in subCategories)
                    {
                        if (obj2 is Category category2)
                        {
                            try
                            {
                                Element element29 = _doc_origen.GetElement(category2.Id);
                                if (element29 != null)
                                {
                                    Elemento item29 = new Elemento(element29, "Category", category.CategoryType.ToString(), category.Name, _doc_origen);
                                    elementsAFiltrar.Add(item29);
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
        }

        // 28. Loadable Families
        var list25 = new FilteredElementCollector(_doc_origen).OfClass(typeof(Family)).Select(i => i.Id).ToList();
        Report("Collecting Loadable Families", list25.Count);
        foreach (ElementId elementId28 in list25)
        {
            Element element30 = _doc_origen.GetElement(elementId28);
            if (element30 != null && element30 is Family family)
            {
                try
                {
                    Elemento item30 = new Elemento(element30, "Loadable Families (Overwrite All Types)", family.FamilyCategory?.Name ?? "Generic", _doc_origen);
                    elementsAFiltrar.Add(item30);
                }
                catch { }
            }
        }

        // 29. Global Parameters
        var list26 = new FilteredElementCollector(_doc_origen).OfClass(typeof(GlobalParameter)).Select(i => i.Id).ToList();
        Report("Collecting Global Parameters", list26.Count);
        foreach (ElementId elementId29 in list26)
        {
            Element element31 = _doc_origen.GetElement(elementId29);
            if (element31 != null)
            {
                try
                {
                    Elemento item31 = new Elemento(element31, "Parameters", 71, _doc_origen);
                    elementsAFiltrar.Add(item31);
                }
                catch { }
            }
        }

        // 30. Assembly Instances
        var list27 = new FilteredElementCollector(_doc_origen).OfClass(typeof(AssemblyInstance)).Select(i => i.Id).ToList();
        Report("Collecting Assembly Instances", list27.Count);
        var processedTypeIds = new HashSet<ElementId>();
        foreach (ElementId elementId30 in list27)
        {
            Element element32 = _doc_origen.GetElement(elementId30);
            if (element32 != null)
            {
                ElementId typeId = element32.GetTypeId();
                if (processedTypeIds.Contains(typeId))
                {
                    continue;
                }
                string familiaForzada = element32.get_Parameter((BuiltInParameter)(-1150403))?.AsValueString() ?? "Assembly";
                try
                {
                    Elemento item32 = new Elemento(element32, "Assembly", familiaForzada, "Only One Instance", _doc_origen);
                    elementsAFiltrar.Add(item32);
                    processedTypeIds.Add(typeId);
                }
                catch { }
            }
        }

        // 31. Assembly (with views)
        Report("Collecting Assembly Views Map", list27.Count);
        foreach (ElementId id in list27)
        {
            Element element33 = _doc_origen.GetElement(id);
            if (element33 != null)
            {
                string familiaForzada2 = element33.get_Parameter((BuiltInParameter)(-1150403))?.AsValueString() ?? "Assembly";
                var second = new FilteredElementCollector(_doc_origen)
                    .OfClass(typeof(View))
                    .WhereElementIsNotElementType()
                    .Cast<View>()
                    .Where(i => !i.IsTemplate && i.IsAssemblyView && i.AssociatedAssemblyInstanceId == id)
                    .Select(i => i.Id)
                    .ToList();

                if (second.Count > 0)
                {
                    try
                    {
                        Elemento elemento4 = new Elemento(element33, "Assembly (with views)", familiaForzada2, "Instance with Views", _doc_origen);
                        elemento4.IdsAdicionales = second;
                        elementsAFiltrar.Add(elemento4);
                    }
                    catch { }
                }
            }
        }

        // 32. Revit Link Instances
        var list32 = new FilteredElementCollector(_doc_origen).OfClass(typeof(RevitLinkInstance)).Select(i => i.Id).ToList();
        Report("Collecting Revit Link Instances", list32.Count);
        foreach (ElementId elementId33 in list32)
        {
            Element element36 = _doc_origen.GetElement(elementId33);
            if (element36 != null && element36 is RevitLinkInstance revitLinkInstance)
            {
                if (_doc_origen.GetElement(revitLinkInstance.GetTypeId()) is RevitLinkType revitLinkType)
                {
                    if (ElementId.InvalidElementId == revitLinkType.GetParentId())
                    {
                        try
                        {
                            Elemento item35 = new Elemento(element36, "Revit Link Instances", 10, _doc_origen);
                            elementsAFiltrar.Add(item35);
                        }
                        catch { }
                    }
                }
            }
        }

        // 33. Object Styles
        Categories categoriesList = _doc_origen.Settings.Categories;
        Report("Collecting Object Styles", categoriesList.Size);
        foreach (object obj in categoriesList)
        {
            if (obj is Category category && category.Parent == null)
            {
                string familyName = "Model Objects";
                if (category.Id.IntegerValue > 0)
                {
                    familyName = "Imported Objects";
                }
                else if (category.CategoryType == CategoryType.Model)
                {
                    familyName = "Model Objects";
                }
                else if (category.CategoryType == CategoryType.Annotation)
                {
                    familyName = "Annotation Objects";
                }
                else if (category.CategoryType == CategoryType.AnalyticalModel)
                {
                    familyName = "Analytical Model Objects";
                }
                else
                {
                    continue; // Skip Internal and other types
                }

                try
                {
                    Elemento itemStyles = new Elemento(category, familyName);
                    elementsAFiltrar.Add(itemStyles);
                }
                catch { }
            }
        }

        // Final Sort
        progressCallback?.Invoke("Sorting items", maxMain, maxMain);
        return elementsAFiltrar.OrderBy(c => c.Categoria)
                               .ThenBy(c => c.Familia)
                               .ThenBy(c => c.Tipo)
                               .ThenBy(c => c.Nombre)
                               .ToList();
    }
}
