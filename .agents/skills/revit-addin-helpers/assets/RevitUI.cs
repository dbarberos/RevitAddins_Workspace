namespace {{Namespace}}.Helpers;

/// <summary>
/// Wrapper simplificado para TaskDialog y utilidades de UI (Revit 2024+).
/// </summary>
public static class RevitUI
{
    private static string _appName = "Add-in";

    public static void Initialize(string appName) => _appName = appName;

    public static void Info(string message, string title = "InformaciÃ³n")
    {
        var td = new TaskDialog($"{_appName} â€” {title}")
        {
            MainContent = message,
            MainIcon = TaskDialogIcon.TaskDialogIconInformation
        };
        td.Show();
    }

    public static void Warning(string message, string title = "Advertencia")
    {
        var td = new TaskDialog($"{_appName} â€” {title}")
        {
            MainContent = message,
            MainIcon = TaskDialogIcon.TaskDialogIconWarning
        };
        td.Show();
    }

    public static void Error(string message, Exception ex = null, string title = "Error")
    {
        var td = new TaskDialog($"{_appName} â€” {title}")
        {
            MainContent = message,
            MainIcon = TaskDialogIcon.TaskDialogIconError
        };
        if (ex != null)
            td.ExpandedContent = $"Detalle tÃ©cnico:\n{ex.Message}\n\n{ex.StackTrace}";
        td.Show();
    }

    public static bool Confirm(string message, string title = "Confirmar")
    {
        var td = new TaskDialog($"{_appName} â€” {title}")
        {
            MainContent = message,
            CommonButtons = TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No,
            DefaultButton = TaskDialogResult.No
        };
        return td.Show() == TaskDialogResult.Yes;
    }

    /// <summary>
    /// Detecta si Revit estÃ¡ utilizando el Tema Oscuro (Revit 2024+).
    /// </summary>
    public static bool IsDarkThemeActive()
    {
        return UIThemeManager.CurrentTheme == UITheme.Dark;
    }
}
