// FATAL: Intentar estirar una pieza de fabricación modificando su curva como si fuera un Pipe.
// Los Fabrication Parts tienen restricciones de catálogo. Si modificas su geometría 
// más allá de su longitud máxima de compra, el elemento se corromperá.
FabricationPart pieza = doc.GetElement(id) as FabricationPart;
(pieza.Location as LocationCurve).Curve = nuevaCurva; // ERROR
