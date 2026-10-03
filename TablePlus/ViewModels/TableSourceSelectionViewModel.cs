using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using TablePlus.Models;
using TablePlus.Services;
using TablePlus.Views;

namespace TablePlus.ViewModels;

/// <summary>
/// Presentation logic for the initial "Select Source" intermediate window.
/// Prompts the user to select either the local disk or a pre-configured storage source (ACC, Azure, AWS S3, local directory),
/// and navigates the chosen source allowing multi-selection of table files.
/// </summary>
public partial class TableSourceSelectionViewModel : ObservableObject
{
    private const string TableFileFilter =
        "All Supported Tables (*.xlsx;*.xls;*.csv;*.xlsm;*.txt;*.tsv;*.tab;*.prn;*.pdf;*.docx;*.doc;*.rtf;*.md;*.markdown)|*.xlsx;*.xls;*.csv;*.xlsm;*.txt;*.tsv;*.tab;*.prn;*.pdf;*.docx;*.doc;*.rtf;*.md;*.markdown|" +
        "Excel Workbooks (*.xlsx;*.xls;*.xlsm;*.xltx;*.xltm)|*.xlsx;*.xls;*.xlsm;*.xltx;*.xltm|" +
        "Word & RTF Documents (*.docx;*.doc;*.rtf)|*.docx;*.doc;*.rtf|" +
        "PDF Documents (*.pdf)|*.pdf|" +
        "Markdown Files (*.md;*.markdown)|*.md;*.markdown|" +
        "Text & Delimited Files (*.txt;*.csv;*.tsv;*.tab;*.prn;*.dat;*.log;*.asc)|*.txt;*.csv;*.tsv;*.tab;*.prn;*.dat;*.log;*.asc|" +
        "All Files (*.*)|*.*";

    public TableSourceSelectionViewModel()
    {
        InitializeSources();
    }

    [ObservableProperty]
    private ObservableCollection<TableSourcePickerItem> _sources = new();

    [ObservableProperty]
    private TableSourcePickerItem? _selectedSource;

    [ObservableProperty]
    private bool _isRelativePath;

    [ObservableProperty]
    private bool _isRelativePathEnabled = true;

    partial void OnSelectedSourceChanged(TableSourcePickerItem? value)
    {
        UpdateRelativePathState();
    }

    private void UpdateRelativePathState()
    {
        bool isLocal = SelectedSource != null && (SelectedSource.IsLocalDefault || SelectedSource.SourceType == ExternalTableSourceType.Directory);
        IsRelativePathEnabled = isLocal;
        if (!isLocal)
        {
            IsRelativePath = false;
        }
    }

    /// <summary>
    /// File paths of the selected table files (local disk or downloaded cloud copies).
    /// </summary>
    public List<string> ResultFilePaths { get; private set; } = new();

    /// <summary>
    /// Action invoked to close the source selection window upon successful file selection or cancellation.
    /// </summary>
    public Action? RequestClose { get; set; }

    private void InitializeSources()
    {
        Sources.Clear();

        // 1. Default local disk option
        var defaultLocal = new TableSourcePickerItem
        {
            DisplayName = "(Local) Local Disk / File Explorer",
            SourceModel = null
        };
        Sources.Add(defaultLocal);

        try
        {
            var activeSources = TableSourceConfigService.LoadSources()
                .Where(s => s.IsActive)
                .ToList();

            // 2. Favorite Local Directories
            foreach (var dir in activeSources.Where(s => s.SourceType == ExternalTableSourceType.Directory))
            {
                Sources.Add(new TableSourcePickerItem
                {
                    DisplayName = $"(Local) {dir.Name}",
                    SourceModel = dir
                });
            }

            // 3. Autodesk Construction Cloud (ACC / Autodesk Docs)
            foreach (var acc in activeSources.Where(s => s.SourceType == ExternalTableSourceType.AutodeskDocs))
            {
                Sources.Add(new TableSourcePickerItem
                {
                    DisplayName = $"(ACC) {acc.Name}",
                    SourceModel = acc
                });
            }

            // 4. Azure Blob Storage
            foreach (var az in activeSources.Where(s => s.SourceType == ExternalTableSourceType.AzureStorage))
            {
                Sources.Add(new TableSourcePickerItem
                {
                    DisplayName = $"(Azure) {az.Name}",
                    SourceModel = az
                });
            }

            // 5. AWS S3 Storage
            foreach (var aws in activeSources.Where(s => s.SourceType == ExternalTableSourceType.AwsS3))
            {
                Sources.Add(new TableSourcePickerItem
                {
                    DisplayName = $"(AWS S3) {aws.Name}",
                    SourceModel = aws
                });
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error loading sources into TableSourceSelectionViewModel", ex);
        }

        SelectedSource = Sources.FirstOrDefault();
        UpdateRelativePathState();
    }

    [RelayCommand]
    public void Select(Window? ownerWindow)
    {
        if (SelectedSource == null) return;

        // Local disk or Local Directory source: Native Windows File Explorer with Multiselect
        if (SelectedSource.IsLocalDefault || SelectedSource.SourceType == ExternalTableSourceType.Directory)
        {
            var dialog = new OpenFileDialog
            {
                Title = "TablePlus — Select Table File(s)",
                Filter = TableFileFilter,
                Multiselect = true,
                CheckFileExists = true
            };

            if (SelectedSource.SourceModel != null &&
                !string.IsNullOrWhiteSpace(SelectedSource.SourceModel.Path) &&
                Directory.Exists(SelectedSource.SourceModel.Path))
            {
                dialog.InitialDirectory = SelectedSource.SourceModel.Path;
            }

            var dialogResult = dialog.ShowDialog(ownerWindow);
            if (dialogResult == true && dialog.FileNames.Length > 0)
            {
                ResultFilePaths = dialog.FileNames.ToList();
                LoggerService.LogInfo($"[TableSourceSelectionViewModel] Selected {ResultFilePaths.Count} file(s) via File Explorer. IsRelativePath={IsRelativePath}");
                RequestClose?.Invoke();
            }
        }
        else
        {
            // Cloud Source: Autodesk Docs, Azure, AWS S3
            var cloudModel = SelectedSource.SourceModel;
            if (cloudModel == null) return;

            var browserVm = new CloudFileBrowserViewModel(cloudModel);
            var browserView = new CloudFileBrowserView(browserVm);

            if (ownerWindow != null)
            {
                browserView.Owner = ownerWindow;
            }

            var result = browserView.ShowDialog();
            if (result == true && browserVm.DownloadedFilePaths.Count > 0)
            {
                ResultFilePaths = browserVm.DownloadedFilePaths.ToList();
                LoggerService.LogInfo($"[TableSourceSelectionViewModel] Downloaded/selected {ResultFilePaths.Count} file(s) from cloud source '{cloudModel.Name}'.");
                RequestClose?.Invoke();
            }
        }
    }

    [RelayCommand]
    public void Cancel()
    {
        ResultFilePaths.Clear();
        RequestClose?.Invoke();
    }
}
