public void InyectarParametrosYTipos(Document doc)
{
    FamilyManager fm = doc.FamilyManager;

    using (Transaction t = new Transaction(doc, "Configurar Parámetros"))
    {
        t.Start();

        // 1. Crear Parámetros
        FamilyParameter paramAncho = fm.AddParameter("Ancho Libre", 
            GroupTypeId.Geometry, 
            SpecTypeId.Length, 
            false); // false = Parámetro de Tipo, true = Parámetro de Ejemplar

        // 2. Crear un Nuevo Tipo
        FamilyType tipo1 = fm.NewType("Modelo Estándar 1000mm");

        // 3. Asignar Valor al Tipo Actual
        fm.Set(paramAncho, UnitUtils.ConvertFromInternalUnits(1000, UnitTypeId.Millimeters));
        
        t.Commit();
    }
}
