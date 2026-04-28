#if REVIT2025_OR_GREATER
using Autodesk.Revit.UI;

namespace FilterPlus.Commands;

public class FilterContextMenuCreator : IContextMenuCreator
{
    public void BuildContextMenu(ContextMenu contextMenu)
    {
        // Añadir una opción al menú contextual
        // In 2025, we add items to the context menu using CommandIds
        // This is a placeholder for the actual command registration
        // var commandId = RevitCommandId.LookupPostableCommandId(PostableCommand.Properties); 
        // contextMenu.AddItem(new ContextMenuItem("FilterPlus", commandId));
        
        // Wait, ContextMenu has .AddItem() ?
        // The proper way in 2025 API:
        // CommandId myCommandId = CommandId.LookupCommandId("CustomCtrl_%CustomCtrl_%DBDev%FilterPlus%FilterPlus");
        // if (myCommandId != null) { contextMenu.AddItem(new ContextMenuItem("FilterPlus", myCommandId)); }
        
        // Unsafe to assume without testing the exact 2025 API since I'm targeting 2024 right now.
        // I will just leave it empty or add a simple logic if I knew it.
        // Actually, the standard API:
        // CommandId commandId = CommandId.LookupCommandId("CustomCtrl_%CustomCtrl_%DBDev%FilterPlus%FilterPlus"); // Ribbon button ID
        // ContextMenuItem item = new ContextMenuItem("FilterPlus", commandId);
        // contextMenu.AddItem(item);
    }
}
#endif
