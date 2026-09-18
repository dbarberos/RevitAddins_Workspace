using CommunityToolkit.Mvvm.ComponentModel;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.ViewModels;

public partial class RenamePreviewItem : ObservableObject
{
    [ObservableProperty]
    private string _newName = string.Empty;

    [ObservableProperty]
    private string _workingName = string.Empty;

    [ObservableProperty]
    private bool _isSelected = true;

    [ObservableProperty]
    private bool _isMatchingFilter;

    public ElementId? SourceId { get; init; }
    public string? FamilyIdentifier { get; init; }
    public string? CadIdentifier { get; init; }
    public CadDetailItemModel? CadItem { get; init; }
    public string OriginalName { get; init; }
    public bool IsType { get; init; }
    public string? ParentFamilyName { get; init; }

    public RenamePreviewItem(ElementId sourceId, string originalName)
    {
        SourceId = sourceId;
        OriginalName = originalName;
        WorkingName = originalName;
        NewName = originalName;
    }

    public RenamePreviewItem(string familyIdentifier, string originalName, bool isType = false, string? parentFamilyName = null)
    {
        FamilyIdentifier = familyIdentifier;
        OriginalName = originalName;
        WorkingName = originalName;
        NewName = originalName;
        IsType = isType;
        ParentFamilyName = parentFamilyName;
    }

    public RenamePreviewItem(CadDetailItemModel cadItem, string cadIdentifier)
    {
        CadItem = cadItem;
        CadIdentifier = cadIdentifier;
        SourceId = cadItem.ElementId;
        OriginalName = !string.IsNullOrWhiteSpace(cadItem.Name) ? cadItem.Name : (!string.IsNullOrWhiteSpace(cadItem.ViewName) ? cadItem.ViewName : "CAD Detail");
        WorkingName = OriginalName;
        NewName = OriginalName;
    }
}
