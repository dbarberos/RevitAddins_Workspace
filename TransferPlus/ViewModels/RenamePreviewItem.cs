using CommunityToolkit.Mvvm.ComponentModel;
using Autodesk.Revit.DB;

namespace TransferPlus.ViewModels;

public partial class RenamePreviewItem : ObservableObject
{
    [ObservableProperty]
    private string _newName = string.Empty;

    [ObservableProperty]
    private bool _isSelected = true;

    [ObservableProperty]
    private bool _isMatchingFilter;

    public ElementId? SourceId { get; init; }
    public string? FamilyIdentifier { get; init; }
    public string OriginalName { get; init; }

    public RenamePreviewItem(ElementId sourceId, string originalName)
    {
        SourceId = sourceId;
        OriginalName = originalName;
        NewName = originalName;
    }

    public RenamePreviewItem(string familyIdentifier, string originalName)
    {
        FamilyIdentifier = familyIdentifier;
        OriginalName = originalName;
        NewName = originalName;
    }
}
