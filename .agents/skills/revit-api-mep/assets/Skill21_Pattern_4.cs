using (Transaction t = new Transaction(doc, "Trazado MEP Automático"))
{
    t.Start();
    
    // 1. Creación de tramos lineales
    Pipe tubo1 = Pipe.Create(doc, sysId, typeId, lvlId, p0, p1);
    Pipe tubo2 = Pipe.Create(doc, sysId, typeId, lvlId, p1, p2);
    
    // 2. SINCRONIZACIÓN OBLIGATORIA (El motor compila la geometría de tubo1 y tubo2)
    doc.Regenerate(); 
    
    // 3. Ahora los conectores están vivos en p1 y se puede pedir el codo
    Connector c1 = ObtenerConectorEnPunto(tubo1, p1);
    Connector c2 = ObtenerConectorEnPunto(tubo2, p1);
    doc.Create.NewElbowFitting(c1, c2);
    
    t.Commit();
}
