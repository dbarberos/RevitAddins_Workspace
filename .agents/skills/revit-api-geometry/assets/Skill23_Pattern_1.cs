public IList<Element> EncontrarColisiones(Document doc, Element elementoMep, BuiltInCategory categoriaFiltro)
{
    // 1. Crear el filtro de intersección geométrica exacta (Filtro Lento nativo)
    ElementIntersectsElementFilter filtroColision = new ElementIntersectsElementFilter(elementoMep);

    // 2. Combinar con Filtros Rápidos (Categoría) para reducir la carga de Marshalling
    FilteredElementCollector colector = new FilteredElementCollector(doc)
        .OfCategory(categoriaFiltro)
        .WhereElementIsNotElementType()
        .WherePasses(filtroColision); // La intersección geométrica se evalúa al final

    // Retorna todos los elementos de la categoría dada que se cruzan físicamente con 'elementoMep'
    return colector.ToElements();
}
