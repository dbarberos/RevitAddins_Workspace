public void ColocarSoporte(Document doc, FabricationPart conducto, ElementId hangerButtonId)
{
    using (Transaction t = new Transaction(doc, "Colocar Hanger"))
    {
        t.Start();
        
        // El conector no es el extremo del tubo, se refiere al enganche del soporte.
        // hangerButtonId representa el identificador del soporte en el catálogo MAJ.
        FabricationPart soporte = FabricationPart.CreateHanger(
            doc, 
            hangerButtonId, 
            conducto.Id, 
            ObtenerConectorMasCercano(conducto), // Lógica SKILL 20
            0.5 // Posición paramétrica (0.0 a 1.0) a lo largo del conducto (50% = centro)
        );

        // Ajustar la varilla del soporte hasta el forjado superior más cercano
        soporte.AdjustLengthTo(doc.GetElement(ObtenerForjadoSuperior(doc, conducto).Id));

        t.Commit();
    }
}
