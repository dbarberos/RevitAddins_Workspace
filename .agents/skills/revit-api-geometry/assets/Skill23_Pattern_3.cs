// FATAL: Usar ReferenceIntersector sin filtros de clase/categoría.
ReferenceIntersector intersector = new ReferenceIntersector(vista3D); 
// Esto obligará a Revit a evaluar el rayo contra CADA cara de CADA tornillo o mueble del modelo, 
// disparando el tiempo de procesamiento de milisegundos a segundos por cada tubería analizada.
