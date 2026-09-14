using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace TransferPlus.Models
{
    /// <summary>
    /// Model representing a leaf element to be deleted in the CAD deletion confirmation window.
    /// </summary>
    public class CadDeleteItemNode
    {
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public ElementId? ElementId { get; set; }
        public string ElementIdText => ElementId != null ? $"ID: {ElementId.Value}" : string.Empty;
        public string StatusText => "To be deleted";
    }

    /// <summary>
    /// Model representing a parent view container in the CAD deletion confirmation window.
    /// Parent views are always preserved to allow project reuse.
    /// </summary>
    public class CadDeleteViewGroup
    {
        public string ViewName { get; set; } = string.Empty;
        public string StatusText => "Preserved (View)";
        public List<CadDeleteItemNode> Items { get; set; } = new();
    }

    /// <summary>
    /// Model representing a parent sheet container in the CAD deletion confirmation window.
    /// Parent sheets are always preserved to allow project reuse.
    /// </summary>
    public class CadDeleteSheetGroup
    {
        public string SheetName { get; set; } = string.Empty;
        public string StatusText => "Preserved (Sheet)";
        public List<CadDeleteViewGroup> Views { get; set; } = new();
    }
}
