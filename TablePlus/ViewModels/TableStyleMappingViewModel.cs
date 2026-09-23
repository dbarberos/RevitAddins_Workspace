using System.Collections.ObjectModel;
using System.Windows;
using Autodesk.Revit.DB;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TablePlus.Models;

namespace TablePlus.ViewModels;

/// <summary>
/// Presentation logic for configuring table line styles, body typography, and header row overrides.
/// </summary>
public partial class TableStyleMappingViewModel : ObservableObject
{
    private readonly Document _doc;
    private readonly TableItemModel _item;

    [ObservableProperty]
    private string _viewName;

    [ObservableProperty]
    private ObservableCollection<string> _availableLineStyles = new();

    [ObservableProperty]
    private ObservableCollection<string> _availableTextStyles = new();

    [ObservableProperty]
    private string? _selectedGridLineStyle;

    [ObservableProperty]
    private string? _selectedBodyTextStyle;

    [ObservableProperty]
    private bool _headerCustomStyleEnabled;

    [ObservableProperty]
    private string? _selectedHeaderTextStyle;

    [ObservableProperty]
    private string _headerTextColorHex = "#FFFFFF";

    [ObservableProperty]
    private string _headerFillColorHex = "#0F172A";

    [ObservableProperty]
    private ObservableCollection<string> _presetColors = new()
    {
        "#0F172A", // Dark Charcoal
        "#1E293B", // Slate 800
        "#1E3A8A", // Deep Navy
        "#0284C7", // Ocean Blue
        "#0D9488", // Dark Teal
        "#047857", // Forest Green
        "#475569", // Slate Muted
        "#D97706", // Amber
        "#DC2626", // Crimson
        "#FFFFFF"  // White
    };

    public bool DialogResult { get; private set; }

    public TableStyleMappingViewModel(Document doc, TableItemModel item)
    {
        _doc = doc ?? throw new ArgumentNullException(nameof(doc));
        _item = item ?? throw new ArgumentNullException(nameof(item));

        _viewName = item.ViewName;

        LoadRevitStyles();
        LoadCurrentConfig();
    }

    private void LoadRevitStyles()
    {
        // 1. Line styles from BuiltInCategory.OST_Lines subcategories
        var lineCategory = _doc.Settings.Categories.get_Item(BuiltInCategory.OST_Lines);
        if (lineCategory != null)
        {
            var styles = new List<string>();
            foreach (Category subCat in lineCategory.SubCategories)
            {
                styles.Add(subCat.Name);
            }
            styles.Sort(StringComparer.OrdinalIgnoreCase);
            AvailableLineStyles = new ObservableCollection<string>(styles);
        }

        // 2. Text styles from TextNoteType
        var textTypes = new FilteredElementCollector(_doc)
            .OfClass(typeof(TextNoteType))
            .Cast<TextNoteType>()
            .Select(t => t.Name)
            .OrderBy(n => n, StringComparer.OrdinalIgnoreCase)
            .ToList();

        AvailableTextStyles = new ObservableCollection<string>(textTypes);
    }

    private void LoadCurrentConfig()
    {
        var cfg = _item.Config;

        // Selected Grid Line Style
        if (!string.IsNullOrWhiteSpace(cfg.GridLineStyleName) && AvailableLineStyles.Contains(cfg.GridLineStyleName!))
        {
            SelectedGridLineStyle = cfg.GridLineStyleName;
        }
        else
        {
            SelectedGridLineStyle = AvailableLineStyles.FirstOrDefault(s => s.Equals("<Thin Lines>", StringComparison.OrdinalIgnoreCase))
                                 ?? AvailableLineStyles.FirstOrDefault();
        }

        // Selected Body Text Style
        if (!string.IsNullOrWhiteSpace(cfg.BodyTextNoteTypeName) && AvailableTextStyles.Contains(cfg.BodyTextNoteTypeName!))
        {
            SelectedBodyTextStyle = cfg.BodyTextNoteTypeName;
        }
        else
        {
            SelectedBodyTextStyle = AvailableTextStyles.FirstOrDefault();
        }

        // Header Overrides
        HeaderCustomStyleEnabled = cfg.HeaderCustomStyleEnabled;

        if (!string.IsNullOrWhiteSpace(cfg.HeaderTextNoteTypeName) && AvailableTextStyles.Contains(cfg.HeaderTextNoteTypeName!))
        {
            SelectedHeaderTextStyle = cfg.HeaderTextNoteTypeName;
        }
        else
        {
            SelectedHeaderTextStyle = SelectedBodyTextStyle;
        }

        HeaderTextColorHex = !string.IsNullOrWhiteSpace(cfg.HeaderTextColorHex)
            ? cfg.HeaderTextColorHex!
            : "#FFFFFF";

        HeaderFillColorHex = !string.IsNullOrWhiteSpace(cfg.HeaderFillColorHex)
            ? cfg.HeaderFillColorHex!
            : "#0F172A";
    }

    [RelayCommand]
    private void SelectPresetFillColor(string? hex)
    {
        if (!string.IsNullOrWhiteSpace(hex))
        {
            HeaderFillColorHex = hex!;
        }
    }

    [RelayCommand]
    private void SelectPresetTextColor(string? hex)
    {
        if (!string.IsNullOrWhiteSpace(hex))
        {
            HeaderTextColorHex = hex!;
        }
    }

    [RelayCommand]
    private void Save(Window? window)
    {
        _item.Config.GridLineStyleName = SelectedGridLineStyle;
        _item.Config.BodyTextNoteTypeName = SelectedBodyTextStyle;
        _item.Config.HeaderCustomStyleEnabled = HeaderCustomStyleEnabled;
        _item.Config.HeaderTextNoteTypeName = SelectedHeaderTextStyle;
        _item.Config.HeaderTextColorHex = HeaderTextColorHex;
        _item.Config.HeaderFillColorHex = HeaderFillColorHex;

        DialogResult = true;
        window?.Close();
    }

    [RelayCommand]
    private void Cancel(Window? window)
    {
        DialogResult = false;
        window?.Close();
    }
}
