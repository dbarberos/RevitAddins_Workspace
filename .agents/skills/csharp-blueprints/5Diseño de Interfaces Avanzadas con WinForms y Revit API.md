Creación de interfaces de usuario avanzadas (WinForms) para interactuar con el usuario, solicitar datos y mostrar el progreso de operaciones largas.

***

# Guía 5: Diseño Avanzado de Formularios (WinForms y ListView)

Esta guía consolida los conocimientos de las Lecciones 13, 14, 15, 18 y 19. El objetivo principal es aprender a separar la interfaz gráfica (Front-end) de la lógica del plugin (Back-end) empleando el sistema de `System.Windows.Forms`.

## 1. La clase envoltura: FormResult (Lección 13)

Antes de crear formularios visuales, necesitas una forma estandarizada de procesar sus resultados. Un error común es extraer valores del formulario directamente, lo que falla si el usuario presiona la "X" para cerrar.

**Mejores Prácticas:**
*   Crea una clase genérica `FormResult<T>` que rastree si el formulario fue validado, si fue cancelado y qué objetos devuelve.
*   El formulario siempre debe inicializarse asumiendo que fue **cancelado**. Solo cambia a validado cuando el usuario hace clic afirmativamente (ej. en "OK" o "Sí").

**Ejemplo de Código: Estructura del FormResult**

```csharp
public class FormResult<T> 
{ 
    public T Object { get; set; } 
    public List<T> Objects { get; set; } 
    public bool Cancelled { get; set; } 
    public bool IsValid { get; set; } 

    // Por defecto asume que el formulario fue cancelado 
    public FormResult() 
    { 
        this.Cancelled = true; 
        this.IsValid = false; 
    } 

    // Método para validar cuando el usuario presiona "OK" 
    public void Validate(T obj) 
    { 
        this.Object = obj; 
        this.Cancelled = false; 
        this.IsValid = true; 
    } 
}
```

## 2. Formularios de Selección (Dropdown/ComboBox) y Layouts (Lección 14)

Al usar el diseñador visual de Visual Studio para crear Windows Forms, te enfrentarás a problemas de ambigüedad y diseño adaptable.

**Resolución de Ambigüedad de Form:**
Revit tiene su propia clase `Form` (para masas/geometría) y Windows usa `System.Windows.Forms.Form`. En el código *behind* (el archivo `.cs` del formulario), debes definir explícitamente qué Form usar mediante un alias.

```csharp
using Form = System.Windows.Forms.Form; // Resuelve el choque de nombres
```

**Layouts Responsivos con TableLayoutPanel:**
Para que la interfaz no se rompa si el usuario redimensiona la ventana o si tiene un monitor 4K, nunca uses posiciones fijas. Arrastra un control `TableLayoutPanel`, define filas/columnas en porcentajes o píxeles fijos y "ancla" (`Dock`) tus botones dentro de sus celdas.

**El uso de la propiedad Tag:**
Cuando el usuario presiona "OK", puedes almacenar el objeto seleccionado (`Value`) en la propiedad nativa `.Tag` del formulario para enviarlo de vuelta a tu comando principal.

## 3. ListViews Avanzados con Clases Personalizadas (Lecciones 15 y 19)

Un `ListView` es ideal para mostrar listas de planos o vistas. Asegúrate de configurarlo con `View = View.Details` para que se vea como una lista real y no como iconos gigantes.

**El Problema del Filtrado:**
Si implementas una barra de búsqueda para filtrar la lista y ocultas elementos, el `ListView` nativo "olvida" cuáles elementos estaban marcados (`Checked`) si desaparecen de la vista.

**La Solución: Clase KeyedValue**
Debes abandonar las listas paralelas y crear una clase envoltorio en tu lógica que rastree permanentemente el estado en el Back-end.

**Ejemplo de Código: Clase contenedora de datos**

```csharp
public class KeyedValue<T> 
{ 
    public string ItemKey { get; set; } // Lo que el usuario ve (ej. "A101 - Plano") 
    public T ItemValue { get; set; } // El objeto real de Revit (ej. ViewSheet) 
    public int ItemIndex { get; set; } // Su posición original 
    public bool Visible { get; set; } // Si pasa el filtro de texto 
    public bool Checked { get; set; } // Si el usuario lo seleccionó 

    public KeyedValue(string key, T value, int index) 
    { 
        ItemKey = key; 
        ItemValue = value; 
        ItemIndex = index; 
        Visible = true; 
        Checked = false; 
    } 
}
```

Al cambiar el texto de búsqueda, actualizas la propiedad `Visible` de esta clase y reconstruyes el `ListView` leyendo solo los elementos con `Visible == true` y re-marcando los que tengan `Checked == true`.

## 4. Barra de Progreso y Asincronía de Interfaz (Lección 18)

Las tareas que iteran sobre cientos de elementos "congelarán" Revit. Una barra de progreso (*Progress Bar*) resuelve esto y permite al usuario cancelar el comando a la mitad.

**Forzar Repintado Asíncrono (DoEvents):**
Como la API de Revit bloquea el hilo principal, la interfaz de tu barra de progreso no se actualizará visualmente. Debes llamar obligatoriamente a `Application.DoEvents()` en cada ciclo de la iteración para forzar a Windows a repintar el gráfico.

**El "Bug" Visual del Progress Bar en WinForms:**
La barra nativa de Windows se anima con un retraso y nunca parece alcanzar el 100%. Para forzar que el llenado visual sea instantáneo, incrementas el valor por encima, lo bajas y lo devuelves a su estado real.

**Ejemplo de Código: Ciclo Seguro de Progreso**

```csharp
using System.Windows.Forms; 

public void IncrementProgress() 
{ 
    this.ProgressCount++; // Aumentamos la cuenta real 

    // Hack para corregir el bug de animación de Windows 
    if (this.ProgressCount > 1 && this.ProgressCount <= this.Total) 
    { 
        this.ProgressBarObj.Value = this.ProgressCount; 
        this.ProgressBarObj.Value = this.ProgressCount - 1; 
        this.ProgressBarObj.Value = this.ProgressCount; 
    } 

    // Forzamos a la ventana gráfica a actualizarse sin importar si Revit está ocupado 
    Application.DoEvents(); 
}
```

Si el usuario presiona "Cancelar", levantas una bandera (`this.Cancelled = true`). En tu comando principal de Revit, después de llamar a `IncrementProgress()`, verificas esa bandera y ejecutas un `transaction.RollBack()` para deshacer la tarea limpiamente.

***