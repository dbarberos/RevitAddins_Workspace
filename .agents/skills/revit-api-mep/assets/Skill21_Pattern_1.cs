using Autodesk.Revit.DB.Plumbing;

public Pipe CrearTramoTuberia(Document doc, ElementId systemTypeId, ElementId pipeTypeId, ElementId levelId, XYZ inicio, XYZ fin)
{
    // La creación de geometría requiere siempre una transacción activa
    Pipe nuevaTuberia = Pipe.Create(doc, systemTypeId, pipeTypeId, levelId, inicio, fin);
    
    // Por defecto, Revit la creará con el diámetro estándar más pequeño.
    // El diámetro debe mutarse explícitamente tras la creación.
    Parameter diametroParam = nuevaTuberia.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM);
    
    if (diametroParam != null && !diametroParam.IsReadOnly)
    {
        // El valor a inyectar debe estar en unidades internas (Pies)
        double diametroPulgadas = 2.0; 
        double diametroInterno = UnitUtils.ConvertFromInternalUnits(diametroPulgadas, UnitTypeId.Inches);
        diametroParam.Set(diametroInterno);
    }
    
    return nuevaTuberia;
}
