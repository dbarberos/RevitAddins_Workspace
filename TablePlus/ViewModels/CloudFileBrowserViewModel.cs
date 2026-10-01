using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TablePlus.Models;
using TablePlus.Services;

namespace TablePlus.ViewModels;

public partial class CloudBrowserItemModel : ObservableObject
{
    [ObservableProperty]
    private bool _isSelected;

    public string FileName { get; set; } = string.Empty;
    public string KeyOrPath { get; set; } = string.Empty;
    public string FormattedSize { get; set; } = string.Empty;
    public string LastModified { get; set; } = string.Empty;

    partial void OnIsSelectedChanged(bool value)
    {
        OnSelectionToggled?.Invoke();
    }

    public Action? OnSelectionToggled { get; set; }
}

public partial class CloudFileBrowserViewModel : ObservableObject
{
    private readonly TableSourceItemModel _source;
    private readonly ObservableCollection<CloudBrowserItemModel> _allItems = new();

    public CloudFileBrowserViewModel(TableSourceItemModel source)
    {
        _source = source ?? throw new ArgumentNullException(nameof(source));

        string typePrefix = source.SourceType switch
        {
            ExternalTableSourceType.AutodeskDocs => "ACC",
            ExternalTableSourceType.AwsS3 => "AWS S3",
            ExternalTableSourceType.AzureStorage => "Azure",
            _ => "Cloud"
        };

        WindowTitle = $"TablePlus — Browse ({typePrefix}) {source.Name}";
        SourceDetails = source.SourceDescription;

        ItemsView = CollectionViewSource.GetDefaultView(_allItems);
        ItemsView.Filter = FilterFile;

        _ = LoadCloudFilesAsync();
    }

    public string WindowTitle { get; }
    public string SourceDetails { get; }
    public ICollectionView ItemsView { get; }
    public List<string> DownloadedFilePaths { get; } = new();
    public Action? RequestClose { get; set; }

    [ObservableProperty]
    private string _searchText = string.Empty;

    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private string _statusMessage = "Connecting to cloud storage...";

    [ObservableProperty]
    private bool _hasError;

    [ObservableProperty]
    private string? _errorMessage;

    [ObservableProperty]
    private int _selectedCount;

    [ObservableProperty]
    private bool _canConfirm;

    partial void OnSearchTextChanged(string value)
    {
        ItemsView.Refresh();
    }

    private bool FilterFile(object obj)
    {
        if (obj is not CloudBrowserItemModel item) return false;
        if (string.IsNullOrWhiteSpace(SearchText)) return true;
        return item.FileName.IndexOf(SearchText.Trim(), StringComparison.OrdinalIgnoreCase) >= 0;
    }

    private void UpdateSelectionState()
    {
        SelectedCount = _allItems.Count(i => i.IsSelected);
        CanConfirm = SelectedCount > 0 && !IsBusy;
    }

    [RelayCommand]
    public async Task LoadCloudFilesAsync()
    {
        try
        {
            IsBusy = true;
            HasError = false;
            ErrorMessage = null;
            StatusMessage = $"Fetching files from {_source.Name}...";
            _allItems.Clear();
            UpdateSelectionState();

            if (_source.SourceType == ExternalTableSourceType.AzureStorage)
            {
                var blobs = await AzureStorageService.GetAvailableSpreadsheetsAsync(
                    _source.ConnectionString, _source.ContainerName, _source.RootPath);

                foreach (var b in blobs)
                {
                    _allItems.Add(new CloudBrowserItemModel
                    {
                        FileName = b.FileName + "." + b.Extension,
                        KeyOrPath = b.BlobName,
                        FormattedSize = b.FormattedSize,
                        LastModified = b.LastModified?.LocalDateTime.ToString("yyyy-MM-dd HH:mm") ?? "-",
                        OnSelectionToggled = UpdateSelectionState
                    });
                }
            }
            else if (_source.SourceType == ExternalTableSourceType.AwsS3)
            {
                var s3Objs = await AwsS3StorageService.GetAvailableSpreadsheetsAsync(_source);

                foreach (var obj in s3Objs)
                {
                    _allItems.Add(new CloudBrowserItemModel
                    {
                        FileName = obj.FileName + "." + obj.Extension,
                        KeyOrPath = obj.ObjectKey,
                        FormattedSize = obj.FormattedSize,
                        LastModified = obj.LastModified.ToString("yyyy-MM-dd HH:mm"),
                        OnSelectionToggled = UpdateSelectionState
                    });
                }
            }
            else if (_source.SourceType == ExternalTableSourceType.AutodeskDocs)
            {
                if (!string.IsNullOrWhiteSpace(_source.AccessToken) &&
                    !string.IsNullOrWhiteSpace(_source.ProjectId) &&
                    !string.IsNullOrWhiteSpace(_source.FolderId))
                {
                    var (_, items) = await AutodeskDocsService.GetFolderSpreadsheetContentsAsync(
                        _source.AccessToken, _source.ProjectId, _source.FolderId);

                    foreach (var itm in items)
                    {
                        _allItems.Add(new CloudBrowserItemModel
                        {
                            FileName = itm.DisplayName,
                            KeyOrPath = itm.Id,
                            FormattedSize = $"{itm.ContentLength / 1024.0:F1} KB",
                            LastModified = itm.LastModified?.ToString("yyyy-MM-dd HH:mm") ?? "-",
                            OnSelectionToggled = UpdateSelectionState
                        });
                    }
                }
            }

            StatusMessage = _allItems.Count > 0
                ? $"{_allItems.Count} table file(s) available in {_source.Name}."
                : $"No supported table files found in {_source.Name}.";
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error loading cloud files from {_source.Name}", ex);
            HasError = true;
            ErrorMessage = $"Failed to list files: {ex.Message}";
            StatusMessage = "Connection failed.";
        }
        finally
        {
            IsBusy = false;
            UpdateSelectionState();
        }
    }

    [RelayCommand]
    public void SelectAll()
    {
        foreach (var item in _allItems)
        {
            item.IsSelected = true;
        }
        UpdateSelectionState();
    }

    [RelayCommand]
    public void DeselectAll()
    {
        foreach (var item in _allItems)
        {
            item.IsSelected = false;
        }
        UpdateSelectionState();
    }

    [RelayCommand]
    public async Task ConfirmAsync()
    {
        var selected = _allItems.Where(i => i.IsSelected).ToList();
        if (selected.Count == 0) return;

        try
        {
            IsBusy = true;
            HasError = false;
            ErrorMessage = null;
            DownloadedFilePaths.Clear();

            int current = 0;
            foreach (var item in selected)
            {
                current++;
                StatusMessage = $"Downloading file {current} of {selected.Count}: {item.FileName}...";

                string localPath = string.Empty;

                if (_source.SourceType == ExternalTableSourceType.AzureStorage)
                {
                    localPath = await AzureStorageService.DownloadSpreadsheetBlobAsync(
                        _source.ConnectionString, _source.ContainerName, item.KeyOrPath);
                }
                else if (_source.SourceType == ExternalTableSourceType.AwsS3)
                {
                    localPath = await AwsS3StorageService.DownloadSpreadsheetAsync(_source, item.KeyOrPath);
                }
                else if (_source.SourceType == ExternalTableSourceType.AutodeskDocs)
                {
                    string? downloadUrl = await AutodeskDocsService.GetLatestVersionDownloadUrlAsync(
                        _source.AccessToken, _source.ProjectId, item.KeyOrPath);

                    if (!string.IsNullOrWhiteSpace(downloadUrl))
                    {
                        localPath = await AutodeskDocsService.DownloadAccSpreadsheetAsync(
                            _source.AccessToken, downloadUrl!, item.FileName);
                    }
                }

                if (!string.IsNullOrWhiteSpace(localPath) && File.Exists(localPath))
                {
                    DownloadedFilePaths.Add(localPath);
                }
            }

            if (DownloadedFilePaths.Count > 0)
            {
                RequestClose?.Invoke();
            }
            else
            {
                throw new InvalidOperationException("Failed to download selected file(s).");
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error downloading files from cloud source", ex);
            HasError = true;
            ErrorMessage = $"Download error: {ex.Message}";
            StatusMessage = "Download failed.";
        }
        finally
        {
            IsBusy = false;
            UpdateSelectionState();
        }
    }

    [RelayCommand]
    public void Cancel()
    {
        DownloadedFilePaths.Clear();
        RequestClose?.Invoke();
    }
}
