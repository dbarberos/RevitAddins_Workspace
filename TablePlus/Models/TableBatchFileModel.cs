using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TablePlus.Models;

/// <summary>
/// Observable item model representing an individual spreadsheet or document in the batch "Add Tables" list.
/// Displays Views count (with expand/collapse arrow for multi-sheet files), File type icon, File name without extension, and Path.
/// </summary>
public partial class TableBatchFileModel : ObservableObject
{
    private readonly Func<string?>? _getBaseDirectory;
    private readonly Action? _onStateChanged;

    [ObservableProperty]
    private string _filePath = string.Empty;

    [ObservableProperty]
    private string _fileName = string.Empty;

    [ObservableProperty]
    private string _fileNameWithoutExtension = string.Empty;

    [ObservableProperty]
    private string _displayPath = string.Empty;

    [ObservableProperty]
    private bool _isRelativePath;

    [ObservableProperty]
    private TableSourceType _sourceType = TableSourceType.ExcelXlsx;

    [ObservableProperty]
    private bool _isExpanded;

    [ObservableProperty]
    private ObservableCollection<TableBatchSheetItemModel> _sheets = new();

    [ObservableProperty]
    private int _viewsCount;

    public bool HasMultipleSheets => Sheets.Count > 1;

    public string FileTypeIconUri => SourceType switch
    {
        TableSourceType.ExcelXlsx or TableSourceType.ExcelXlsm =>
            "pack://application:,,,/TablePlus;component/Resources/Icons/FileExcel16.png",
        TableSourceType.Csv =>
            "pack://application:,,,/TablePlus;component/Resources/Icons/FileCsv16.png",
        TableSourceType.TextFile =>
            "pack://application:,,,/TablePlus;component/Resources/Icons/FileText16.png",
        TableSourceType.WordDocument =>
            "pack://application:,,,/TablePlus;component/Resources/Icons/FileWord16.png",
        TableSourceType.PdfDocument =>
            "pack://application:,,,/TablePlus;component/Resources/Icons/FilePdf16.png",
        _ =>
            "pack://application:,,,/TablePlus;component/Resources/Icons/FileGeneric16.png"
    };

    public string ToolTipPath => $"File: {FileName}\nPath: {DisplayPath}\n(Right-click to toggle Relative/Absolute path)";

    public TableBatchFileModel(string filePath, bool isRelative = false, Func<string?>? getBaseDirectory = null, Action? onStateChanged = null)
    {
        _getBaseDirectory = getBaseDirectory;
        _onStateChanged = onStateChanged;

        FilePath = filePath;
        FileName = Path.GetFileName(filePath);
        FileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
        IsRelativePath = isRelative;

        var ext = Path.GetExtension(filePath).ToLowerInvariant();
        SourceType = ext switch
        {
            ".xlsx" or ".xls" or ".xlsb" => TableSourceType.ExcelXlsx,
            ".xlsm" => TableSourceType.ExcelXlsm,
            ".csv" => TableSourceType.Csv,
            ".tsv" or ".tab" or ".txt" or ".prn" or ".dat" or ".log" or ".asc" => TableSourceType.TextFile,
            ".docx" or ".doc" or ".rtf" => TableSourceType.WordDocument,
            ".pdf" => TableSourceType.PdfDocument,
            ".md" or ".markdown" => TableSourceType.MarkdownDocument,
            _ => TableSourceType.ExcelXlsx
        };

        UpdateDisplayPath();
    }

    public void OnChildSheetSelectionChanged()
    {
        UpdateViewsCount();
        _onStateChanged?.Invoke();
    }

    public void UpdateViewsCount()
    {
        ViewsCount = Sheets.Count(s => s.IsSelected);
        OnPropertyChanged(nameof(HasMultipleSheets));
    }

    [RelayCommand]
    public void ToggleExpand()
    {
        if (HasMultipleSheets)
        {
            IsExpanded = !IsExpanded;
        }
    }

    [RelayCommand]
    public void SwitchToRelativePath()
    {
        IsRelativePath = true;
        UpdateDisplayPath();
        _onStateChanged?.Invoke();
    }

    [RelayCommand]
    public void SwitchToAbsolutePath()
    {
        IsRelativePath = false;
        UpdateDisplayPath();
        _onStateChanged?.Invoke();
    }

    public void UpdateDisplayPath()
    {
        if (IsRelativePath)
        {
            var baseDir = _getBaseDirectory?.Invoke();
            DisplayPath = ComputeRelativePath(baseDir, FilePath);
        }
        else
        {
            DisplayPath = FilePath;
        }

        OnPropertyChanged(nameof(ToolTipPath));
    }

    public static string ComputeRelativePath(string? baseDirectory, string fullPath)
    {
        if (string.IsNullOrWhiteSpace(baseDirectory) || string.IsNullOrWhiteSpace(fullPath))
        {
            return fullPath;
        }

        try
        {
            var baseDirClean = baseDirectory!.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;
            var baseUri = new Uri(baseDirClean);
            var targetUri = new Uri(fullPath);

            if (baseUri.Scheme != targetUri.Scheme)
            {
                return fullPath;
            }

            var relativeUri = baseUri.MakeRelativeUri(targetUri);
            var relPath = Uri.UnescapeDataString(relativeUri.ToString())
                .Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);

            if (!relPath.StartsWith(".") && !Path.IsPathRooted(relPath))
            {
                relPath = ".\\" + relPath;
            }

            return relPath;
        }
        catch
        {
            return fullPath;
        }
    }
}
