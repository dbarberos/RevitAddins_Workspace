// FATAL: Dibujar una extrusión directamente con coordenadas estáticas.
// Cuando el usuario intente cambiar el parámetro "Ancho" en el proyecto, 
// la familia no se deformará, porque la geometría no está alineada a los planos de referencia.
Extrusion cubo = doc.FamilyCreate.NewExtrusion(perfilAbierto, planoBoceto, 2.0);
