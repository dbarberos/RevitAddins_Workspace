# Walkthrough: Recuperación de la Lógica de Negocio y UI Premium en `TransferPlus`

Hemos recuperado y adaptado el 100% del núcleo de negocio y los controladores visuales del addin original `TransferSingle` de Revit 2020 para que funcione como un addin moderno multi-versión bajo WPF y MVVM en **`TransferPlus`**.

## Tareas Completadas

### 1. Modelos de Negocio Originales
* Se copiaron y adaptaron los modelos `Elemento.cs`, `Nodo.cs`, `Archivo.cs` y `Estructura.cs` del proyecto original.
* Se cambiaron los namespaces a `TransferPlus.Models` y se eliminaron las dependencias a Windows Forms.
* En `Configuraciones.cs`, se retiraron las propiedades de posicionamiento físico de la ventana WinForms, que ya no son necesarias gracias al posicionamiento nativo y adaptativo de WPF.
* Se corrigieron errores de conversión de decompilación IL, como la sustitución de `!!0` por `T` en el deserializador de `Serializaciones.cs`, y la comparación del tipo `StorageType` en `Elemento.cs`.

### 2. Recolección Completa de 32 Pasos (Standards)
* Se portó todo el flujo de recolección de `TomaElementosSeleccion()` a `DocumentCollector.cs`, que cubre las 32+ categorías originales (Filtros, Vistas, Materiales, Worksets, Parámetros del Proyecto, Cuadros de Rotulación, Configuración de Impresión, etc.).
* El recolector ahora admite un callback `Action<string, int, int>` para alimentar dinámicamente la barra de progreso en WPF.

### 3. Orquestador de Copiado Avanzado
* Se implementaron en `TransferOrchestrator.cs` los algoritmos de copiado recursivo de vistas dependientes y llamadas de detalle (`ponCallouts` y `ponDependientes`).
* Se portaron los métodos de cálculo de matrices de transformación geométrica para vínculos de Revit y coordenadas compartidas.
* Se integró con `WarningSwallower` para silenciar las advertencias menores durante las transacciones.

### 4. Capa Gráfica e Interacciones de Texto
* Se diseñaron diálogos modales WPF independientes (`RenameTextView.xaml` y `TakeTextView.xaml`) para la captura de texto de prefijos, sufijos y búsquedas.
* En `TransferPlusViewModel.cs`, se expusieron comandos para re-nombrar elementos en el documento origen (mayúsculas, minúsculas, ProperCase, prefijo, sufijo, reemplazo por Regex) y eliminar elementos checked, ejecutando transacciones locales y refrescando el árbol automáticamente.
* La UI en `TransferPlusView.xaml` ahora muestra todos los parámetros organizados en tarjetas limpias, con interruptores planos e indicadores de porcentaje de progreso.

## Verificación
* El código compila completamente bajo la configuración `Debug.R24` del SDK de Revit 2024.
