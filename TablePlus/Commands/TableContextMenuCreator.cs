#if REVIT2025_OR_GREATER
using Autodesk.Revit.UI;

namespace TablePlus.Commands;

/// <summary>
/// Context menu builder for Revit 2025+ canvas right-click menu integration.
/// Adds a direct action to create a new TablePlus linked table without searching the Ribbon.
/// </summary>
public class TableContextMenuCreator : IContextMenuCreator
{
    public void BuildContextMenu(ContextMenu contextMenu)
    {
        try
        {
            var assemblyPath = typeof(TableContextMenuCreator).Assembly.Location;
            var commandClassName = typeof(CmdAddTableDirect).FullName;

            if (!string.IsNullOrEmpty(commandClassName) && !string.IsNullOrEmpty(assemblyPath))
            {
                var menuItem = new CommandMenuItem("TablePlus: Create New Linked Table", commandClassName, assemblyPath);
                contextMenu.AddItem(menuItem);
            }
        }
        catch (Exception ex)
        {
            Services.LoggerService.LogError("TableContextMenuCreator.BuildContextMenu Error", ex);
        }
    }
}
#endif
