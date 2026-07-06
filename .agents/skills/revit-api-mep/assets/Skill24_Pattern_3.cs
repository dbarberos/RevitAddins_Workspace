public void SegmentarTramosComerciales(Document doc, ISet<ElementId> idsFabricacion)
{
    using (Transaction t = new Transaction(doc, "Optimizar Longitudes (Straights)"))
    {
        t.Start();
        // Rutina nativa que corta los tramos largos y añade las uniones necesarias
        // según el servicio de fabricación.
        FabricationPart.OptimizeLengths(doc, idsFabricacion);
        t.Commit();
    }
}
