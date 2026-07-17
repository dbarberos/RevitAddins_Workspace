# Walkthrough: Tarjeta On Duplicates UI & Logic

## Fecha: 2026-07-17

## 1. Cambios de Interfaz (UI)
Se modificó la disposición de la tarjeta **"On Duplicates"** en el archivo `TransferPlusView.xaml`:
- El título **"On Duplicates:"** se alineó en la parte superior izquierda, siguiendo los márgenes y colores ("#999", FontWeight Bold, FontSize 12) establecidos para la tarjeta "Filter:".
- Se ajustó el layout a un `Grid` con dos filas:
  - **Fila Superior:** Muestra las opciones "Keep Original" y "Abort Transaction".
  - **Fila Inferior:** Muestra "Append Suffix:" alineado verticalmente con el borde de "Keep Original", seguido de un `TextBox` que ocupa todo el ancho restante de la tarjeta hacia la derecha.
- Se añadió la propiedad `GroupName="OnDuplicatesGroup"` a todos los `RadioButton` de esta tarjeta, para asegurar que su estado sea mutuamente excluyente y corregir el bug de selección simultánea.

## 2. Ajustes en la Lógica (Backend)
En el archivo `TransferOrchestrator.cs` se solucionó el conflicto que ocurría al usar la opción **"Keep Original"** junto con elementos renombrados:

### Problema anterior:
Al usar "Keep Original" y detectar duplicados, los elementos (Tipos, Vistas, etc.) seguían pasando a la lista de copia nativa de Revit (`CopyElements`). Al tener nombres distintos en el archivo origen (ej. "Tipo A") pero causar conflicto con su nuevo nombre ("Tipo B") en el destino, Revit copiaba el "Tipo A" y luego la API fallaba al renombrarlo, dejando elementos duplicados no deseados en el destino.

### Solución implementada:
- **Filtrado previo para Elementos Estándar:** Antes de efectuar la copia de elementos estándar, se itera sobre `elementsCopyList`. Si se detecta un duplicado y la opción marcada es "Keep Original", el elemento se excluye de la lista final a copiar (`finalCopyList`).
- **Seguridad de API:** Si `finalCopyList` queda vacío tras el filtrado, se omite por completo la llamada a `CopyElements` para evitar excepciones de lista vacía en la API de Revit.
- **Estilos de Objeto:** Si "Keep Original" está activo, se salta (`continue`) la llamada a `TransferSingleCategoryStyle` para las subcategorías duplicadas, evitando la sobreescritura indeseada de patrones y grosores de línea en el archivo destino.
