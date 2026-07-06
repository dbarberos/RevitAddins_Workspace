// FATAL: Intentar colocar un codo calculando el vector normal y la rotación manualmente.
// Es propenso a errores, ignora las reglas del BIM Manager y a menudo deja los elementos desconectados.
FamilyInstance miCodo = doc.Create.NewFamilyInstance(puntoInterseccion, simboloCodo, StructuralType.NonStructural);
// Faltan líneas para intentar rotarlo, alinearlo y forzar la conexión de sus 2 nodos.
