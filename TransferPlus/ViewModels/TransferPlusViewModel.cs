using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using TransferPlus.Models;
using TransferPlus.Services;
using TransferPlus.Views;

namespace TransferPlus.ViewModels;

public partial class TransferPlusViewModel : ObservableObject
{
    private readonly Document _targetDoc;
    private readonly UIApplication _app;

    [ObservableProperty]
    private ObservableCollection<Archivo> _sourceDocuments = new();

    [ObservableProperty]
    private Archivo? _selectedSourceDocument;

    [ObservableProperty]
    private ObservableCollection<Archivo> _destinationDocuments = new();

    [ObservableProperty]
    private ObservableCollection<TreeItemViewModel> _rootNodes = new();

    [ObservableProperty]
    private string _searchFilter = string.Empty;

    partial void OnSearchFilterChanged(string value)
    {
        FilterTreeCommand.NotifyCanExecuteChanged();
    }

    // Filters
    [ObservableProperty]
    private bool _filterUseOr;

    [ObservableProperty]
    private bool _filterOnlyNames;

    [ObservableProperty]
    private bool _filterUseRegex;

    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private int _progressPercentage;

    [ObservableProperty]
    private string _statusMessage = "Ready";

    // Count of checked elements
    [ObservableProperty]
    private int _checkedElementsCount;

    // Options
    [ObservableProperty]
    private bool _keepOriginal = true;

    [ObservableProperty]
    private bool _abortTransaction;

    [ObservableProperty]
    private bool _appendSuffix;

    [ObservableProperty]
    private string _duplicatesSuffixText = "_Copy";

    [ObservableProperty]
    private bool _includeCallouts;

    [ObservableProperty]
    private bool _includeSections;

    [ObservableProperty]
    private bool _includeViewElements;

    [ObservableProperty]
    private bool _includeSheetsWithViews;

    // Sub-options for Sheets
    [ObservableProperty]
    private bool _useLegendIfExists = false;

    [ObservableProperty]
    private bool _useScheduleIfExists = false;

    [ObservableProperty]
    private bool _useAssemblyViewsIfExists = false;

    [ObservableProperty]
    private bool _copyLinks;

    [ObservableProperty]
    private bool _saveInSubfoldersOnDownload;

    [ObservableProperty]
    private bool _setDefaultView3DOnDownload;

    [ObservableProperty]
    private bool _exportLogOnDownload;

    [ObservableProperty]
    private string? _exportLogFolderPath;

    partial void OnExportLogOnDownloadChanged(bool value)
    {
        if (value)
        {
            string? folder = PromptFolderBrowserDialog("Select destination folder for download log report (.txt)");
            if (!string.IsNullOrWhiteSpace(folder))
            {
                ExportLogFolderPath = folder;
            }
            else
            {
                ExportLogFolderPath = null;
                _exportLogOnDownload = false;
                OnPropertyChanged(nameof(ExportLogOnDownload));
            }
        }
        else
        {
            ExportLogFolderPath = null;
        }
    }



    [ObservableProperty]
    private bool _transformNone;

    [ObservableProperty]
    private bool _transformLink = true;

    [ObservableProperty]
    private bool _transformShared;

    partial void OnTransformNoneChanged(bool value)
    {
        if (value)
        {
            TransformLink = false;
            TransformShared = false;
        }
    }

    partial void OnTransformLinkChanged(bool value)
    {
        if (value)
        {
            TransformNone = false;
            TransformShared = false;
        }
    }

    partial void OnTransformSharedChanged(bool value)
    {
        if (value)
        {
            TransformNone = false;
            TransformLink = false;
        }
    }

    [ObservableProperty]
    private bool _acceptAllWarnings = true;

    [ObservableProperty]
    private bool _forceLevelInLevelBaseViews;

    // CAD Details Origin Radio Options
    [ObservableProperty]
    private bool _cadOriginLinksAndImports;

    [ObservableProperty]
    private bool _cadOriginDraftingViews = true;

    [ObservableProperty]
    private bool _cadOriginDetailViewsAndCallouts;

    [ObservableProperty]
    private bool _cadOriginDetailGroups;

    [ObservableProperty]
    private bool _cadOriginDetailItems;

    partial void OnCadOriginLinksAndImportsChanged(bool value)
    {
        if (value)
        {
            CadOriginDraftingViews = false;
            CadOriginDetailViewsAndCallouts = false;
            CadOriginDetailGroups = false;
            CadOriginDetailItems = false;
            if (IsCadDetailsManagerActive && SelectedSourceDocument?.Adoc != null)
            {
                LoadCadItemsFromSource(SelectedSourceDocument.Adoc);
            }
        }
    }

    partial void OnCadOriginDraftingViewsChanged(bool value)
    {
        if (value)
        {
            CadOriginLinksAndImports = false;
            CadOriginDetailViewsAndCallouts = false;
            CadOriginDetailGroups = false;
            CadOriginDetailItems = false;
            if (IsCadDetailsManagerActive && SelectedSourceDocument?.Adoc != null)
            {
                LoadCadItemsFromSource(SelectedSourceDocument.Adoc);
            }
        }
    }

    partial void OnCadOriginDetailViewsAndCalloutsChanged(bool value)
    {
        if (value)
        {
            CadOriginLinksAndImports = false;
            CadOriginDraftingViews = false;
            CadOriginDetailGroups = false;
            CadOriginDetailItems = false;
            if (IsCadDetailsManagerActive && SelectedSourceDocument?.Adoc != null)
            {
                LoadCadItemsFromSource(SelectedSourceDocument.Adoc);
            }
        }
    }

    partial void OnCadOriginDetailGroupsChanged(bool value)
    {
        if (value)
        {
            CadOriginLinksAndImports = false;
            CadOriginDraftingViews = false;
            CadOriginDetailViewsAndCallouts = false;
            CadOriginDetailItems = false;
            if (IsCadDetailsManagerActive && SelectedSourceDocument?.Adoc != null)
            {
                LoadCadItemsFromSource(SelectedSourceDocument.Adoc);
            }
        }
    }

    partial void OnCadOriginDetailItemsChanged(bool value)
    {
        if (value)
        {
            CadOriginLinksAndImports = false;
            CadOriginDraftingViews = false;
            CadOriginDetailViewsAndCallouts = false;
            CadOriginDetailGroups = false;
            if (IsCadDetailsManagerActive && SelectedSourceDocument?.Adoc != null)
            {
                LoadCadItemsFromSource(SelectedSourceDocument.Adoc);
            }
        }
    }

    // CAD Details Tree Grouping / Sorting Switches
    [ObservableProperty]
    private bool _cadSortBySheet;

    [ObservableProperty]
    private bool _cadSortByView = true;

    [ObservableProperty]
    private bool _cadSortByName;

    partial void OnCadSortBySheetChanged(bool value)
    {
        if (value)
        {
            CadSortByView = false;
            CadSortByName = false;
            if (IsCadDetailsManagerActive)
            {
                BuildCadTree();
                UpdateCheckedCount();
            }
        }
    }

    partial void OnCadSortByViewChanged(bool value)
    {
        if (value)
        {
            CadSortBySheet = false;
            CadSortByName = false;
            if (IsCadDetailsManagerActive)
            {
                BuildCadTree();
                UpdateCheckedCount();
            }
        }
    }

    partial void OnCadSortByNameChanged(bool value)
    {
        if (value)
        {
            CadSortBySheet = false;
            CadSortByView = false;
            if (IsCadDetailsManagerActive)
            {
                BuildCadTree();
                UpdateCheckedCount();
            }
        }
    }

    private List<Elemento> _allSourceItems = new();
    private List<CadDetailItemModel> _cadItems = new();
    private Configuraciones _config = new();

    // Families Manager State Properties
    private List<FamilyItemModel> _familyItems = new();
    private FamilyRevitService _familyRevitService = new();

    [ObservableProperty]
    private bool _isSingleFamilySelected;

    [ObservableProperty]
    private FamilyItemModel? _selectedFamily;

    [ObservableProperty]
    private string _selectedFamilyName = string.Empty;

    [ObservableProperty]
    private string _selectedFamilyRevitVersion = string.Empty;

    [ObservableProperty]
    private object? _selectedFamilyThumbnail;

    [ObservableProperty]
    private ObservableCollection<FamilySymbolItemModel> _selectedFamilySymbols = new();

    [ObservableProperty]
    private FamilySymbolItemModel? _selectedSymbol;

    [ObservableProperty]
    private int _selectedCategoryCount;

    [ObservableProperty]
    private int _selectedFamilyCount;

    public bool HasCheckedFamilies => SelectedFamilyCount > 0;

    public bool HasFamilyDetails => SelectedFamily != null || HasCheckedFamilies;

    public bool IsSingleFamilyDetails => SelectedFamily != null || SelectedFamilyCount == 1;

    public string FamilyDetailsCardTitle
    {
        get
        {
            if (SelectedFamily != null || SelectedFamilyCount == 1) return "Family Details:";
            if (SelectedFamilyCount > 1) return "Families Details:";
            return "Family(ies) Details:";
        }
    }

    partial void OnSelectedFamilyCountChanged(int value)
    {
        OnPropertyChanged(nameof(HasCheckedFamilies));
        OnPropertyChanged(nameof(HasFamilyDetails));
        OnPropertyChanged(nameof(IsSingleFamilyDetails));
        OnPropertyChanged(nameof(FamilyDetailsCardTitle));
    }

    [ObservableProperty]
    private int _totalFamiliesLoadedCount;

    [ObservableProperty]
    private string _counterLabelText = "Elements Checked";

    [ObservableProperty]
    private int _counterValue;

    private System.Threading.CancellationTokenSource? _thumbnailCts;

    partial void OnSelectedFamilyChanged(FamilyItemModel? value)
    {
        OnPropertyChanged(nameof(HasFamilyDetails));
        OnPropertyChanged(nameof(IsSingleFamilyDetails));
        OnPropertyChanged(nameof(FamilyDetailsCardTitle));

        _thumbnailCts?.Cancel();

        if (value != null)
        {
            if (!string.IsNullOrWhiteSpace(value.ImagePreviewUrl) && System.IO.File.Exists(value.ImagePreviewUrl))
            {
                var (ver, cat) = RfaMetadataExtractor.ExtractMetadata(value.ImagePreviewUrl);
                if (!string.IsNullOrWhiteSpace(ver)) value.RevitVersion = ver;
                if (!string.IsNullOrWhiteSpace(cat)) value.CategoryName = cat;
            }

            SelectedFamilyName = value.Name;
            SelectedFamilyRevitVersion = string.IsNullOrWhiteSpace(value.RevitVersion) ? "RFA File" : value.RevitVersion;
            SelectedFamilySymbols = new ObservableCollection<FamilySymbolItemModel>(value.Symbols ?? new List<FamilySymbolItemModel>());
            
            if (value.Thumbnail != null)
            {
                SelectedFamilyThumbnail = value.Thumbnail;
            }
            else
            {
                SelectedFamilyThumbnail = null;
                _thumbnailCts = new System.Threading.CancellationTokenSource();
                _ = LoadSelectedFamilyThumbnailAsync(value, _thumbnailCts.Token);
            }
        }
        else
        {
            SelectedFamilyName = string.Empty;
            SelectedFamilyRevitVersion = string.Empty;
            SelectedFamilyThumbnail = null;
            SelectedFamilySymbols = new ObservableCollection<FamilySymbolItemModel>();
        }
    }

    private async System.Threading.Tasks.Task LoadSelectedFamilyThumbnailAsync(FamilyItemModel family, System.Threading.CancellationToken token)
    {
        family.IsLoadingThumbnail = true;
        var sw = System.Diagnostics.Stopwatch.StartNew();
        TransferPlus.Services.LoggerService.LogInfo($"[Thumbnail] Starting preview fetch for family '{family.Name}' (Source: '{family.SourceName}')...");

        try
        {
            var thumbnail = await FamilyThumbnailService.GetPreviewImageAsync(family, token);
            sw.Stop();

            if (!string.IsNullOrWhiteSpace(family.ImagePreviewUrl) && System.IO.File.Exists(family.ImagePreviewUrl))
            {
                var (ver, cat) = RfaMetadataExtractor.ExtractMetadata(family.ImagePreviewUrl);
                if (!string.IsNullOrWhiteSpace(ver)) family.RevitVersion = ver;
                if (!string.IsNullOrWhiteSpace(cat)) family.CategoryName = cat;
                SelectedFamilyRevitVersion = family.RevitVersion;

                try
                {
                    var fi = new System.IO.FileInfo(family.ImagePreviewUrl);
                    if (fi.Exists)
                    {
                        if (!family.FileSizeBytes.HasValue || family.FileSizeBytes <= 0) family.FileSizeBytes = fi.Length;
                        if (!family.LastModified.HasValue) family.LastModified = fi.LastWriteTime;
                    }
                }
                catch { }
            }

            if (token.IsCancellationRequested)
            {
                TransferPlus.Services.LoggerService.LogInfo($"[Thumbnail] Request for '{family.Name}' was cancelled after {sw.ElapsedMilliseconds} ms.");
            }
            else if (thumbnail != null)
            {
                family.Thumbnail = thumbnail;
                if (SelectedFamily == family)
                {
                    SelectedFamilyThumbnail = thumbnail;
                }
                TransferPlus.Services.LoggerService.LogInfo($"[Thumbnail] SUCCESS: Preview for '{family.Name}' rendered in {sw.ElapsedMilliseconds} ms ({thumbnail.PixelWidth}x{thumbnail.PixelHeight} px).");
            }
            else
            {
                TransferPlus.Services.LoggerService.LogWarning($"[Thumbnail] NO IMAGE: Preview extraction for '{family.Name}' returned null after {sw.ElapsedMilliseconds} ms.");
            }
        }
        catch (System.Exception ex)
        {
            sw.Stop();
            TransferPlus.Services.LoggerService.LogError($"[Thumbnail] ERROR for '{family.Name}' after {sw.ElapsedMilliseconds} ms", ex);
        }
        finally
        {
            family.IsLoadingThumbnail = false;
        }
    }

    [ObservableProperty]
    private CadDetailItemModel? _selectedCadDetail;

    [ObservableProperty]
    private object? _selectedCadThumbnail;

    [ObservableProperty]
    private System.Windows.Media.Imaging.BitmapImage? _previewImageSource;

    [ObservableProperty]
    private bool _isLoadingCadThumbnail;

    public bool HasSelectedCadThumbnail => SelectedCadThumbnail != null || PreviewImageSource != null;

    private System.Threading.CancellationTokenSource? _cadThumbnailCts;

    partial void OnSelectedCadDetailChanged(CadDetailItemModel? value)
    {
        _cadThumbnailCts?.Cancel();

        if (value != null)
        {
            if (value.Thumbnail != null)
            {
                SelectedCadThumbnail = value.Thumbnail;
                PreviewImageSource = value.Thumbnail as System.Windows.Media.Imaging.BitmapImage;
                IsLoadingCadThumbnail = false;
            }
            else
            {
                SelectedCadThumbnail = null;
                PreviewImageSource = null;
                IsLoadingCadThumbnail = true;
                _cadThumbnailCts = new System.Threading.CancellationTokenSource();
                _ = LoadSelectedCadThumbnailAsync(value, _cadThumbnailCts.Token);
            }
        }
        else
        {
            SelectedCadThumbnail = null;
            PreviewImageSource = null;
            IsLoadingCadThumbnail = false;
        }

        OnPropertyChanged(nameof(HasSelectedCadThumbnail));
    }

    partial void OnSelectedCadThumbnailChanged(object? value)
    {
        if (value is System.Windows.Media.Imaging.BitmapImage bmp)
        {
            PreviewImageSource = bmp;
        }
        OnPropertyChanged(nameof(HasSelectedCadThumbnail));
    }

    partial void OnPreviewImageSourceChanged(System.Windows.Media.Imaging.BitmapImage? value)
    {
        if (value != null && SelectedCadThumbnail != value)
        {
            SelectedCadThumbnail = value;
        }
        OnPropertyChanged(nameof(HasSelectedCadThumbnail));
    }

    private async System.Threading.Tasks.Task LoadSelectedCadThumbnailAsync(CadDetailItemModel cadItem, System.Threading.CancellationToken token)
    {
        IsLoadingCadThumbnail = true;
        try
        {
            var thumbnail = await CadThumbnailService.GetPreviewImageAsync(cadItem, token);
            if (!token.IsCancellationRequested && thumbnail != null)
            {
                cadItem.Thumbnail = thumbnail;
                if (SelectedCadDetail == cadItem)
                {
                    SelectedCadThumbnail = thumbnail;
                    if (thumbnail is System.Windows.Media.Imaging.BitmapImage bmp)
                    {
                        PreviewImageSource = bmp;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LoggerService.LogError($"Error loading CAD thumbnail for '{cadItem.Name}'", ex);
        }
        finally
        {
            if (!token.IsCancellationRequested)
            {
                IsLoadingCadThumbnail = false;
            }
        }
    }

    partial void OnIncludeSheetsWithViewsChanged(bool oldValue, bool newValue)
    {
        if (newValue)
        {
            AppendSuffix = true;
            KeepOriginal = false;
            AbortTransaction = false;
        }
        else
        {
            UseLegendIfExists = false;
            UseScheduleIfExists = false;
            UseAssemblyViewsIfExists = false;
        }
    }

    partial void OnUseLegendIfExistsChanged(bool oldValue, bool newValue)
    {
        if (newValue) IncludeSheetsWithViews = true;
    }

    partial void OnUseScheduleIfExistsChanged(bool oldValue, bool newValue)
    {
        if (newValue) IncludeSheetsWithViews = true;
    }

    partial void OnUseAssemblyViewsIfExistsChanged(bool oldValue, bool newValue)
    {
        if (newValue) IncludeSheetsWithViews = true;
    }

    public TransferPlusViewModel(UIApplication app, Document targetDoc)
    {
        _app = app;
        _targetDoc = targetDoc;
        _familyRevitService = new FamilyRevitService { RevitApp = app?.Application };
        LoadDocuments();

        // Register to receive messages when elements check state changes
        WeakReferenceMessenger.Default.Register<CheckedItemsChangedMessage>(this, (r, m) =>
        {
            UpdateCheckedCount();
            DeleteSelectedFamiliesCommand.NotifyCanExecuteChanged();
        });
    }

    public string CheckedDestinationsText
    {
        get
        {
            int count = DestinationDocuments.Count(d => d.Checked);
            return count == 1 ? "1 selected model" : $"{count} selected models";
        }
    }

    private void LoadDocuments()
    {
        TransferPlus.Services.LoggerService.LogInfo($"LoadDocuments: Loading open documents and links from Revit Session (IsFamiliesManagerActive={IsFamiliesManagerActive})...");
        SourceDocuments.Clear();
        DestinationDocuments.Clear();

        var addedDocPaths = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        // 1. Load all top-level open documents in the Revit session
        foreach (Document doc in _app.Application.Documents)
        {
            if (doc.IsFamilyDocument) continue;

            var arch = new Archivo(doc);
            if (doc.IsLinked)
            {
                arch.EsVinculo = true;
            }
            arch.Nombre = GetDocumentDisplayName(doc);
            SourceDocuments.Add(arch);

            if (!string.IsNullOrEmpty(doc.PathName))
            {
                addedDocPaths.Add(doc.PathName);
            }
        }

        // 2. Load loaded Revit linked models from the active document (_targetDoc)
        if (_targetDoc != null)
        {
            try
            {
                var linkInstances = new FilteredElementCollector(_targetDoc)
                    .OfClass(typeof(RevitLinkInstance))
                    .WhereElementIsNotElementType()
                    .Cast<RevitLinkInstance>();

                foreach (var linkInst in linkInstances)
                {
                    if (linkInst.IsValidObject)
                    {
                        Document linkDoc = linkInst.GetLinkDocument();
                        if (linkDoc != null)
                        {
                            string pathName = linkDoc.PathName;
                            if (string.IsNullOrEmpty(pathName) || addedDocPaths.Add(pathName))
                            {
                                var arch = new Archivo(linkDoc)
                                {
                                    EsVinculo = true,
                                    Nombre = GetDocumentDisplayName(linkDoc)
                                };
                                SourceDocuments.Add(arch);
                                TransferPlus.Services.LoggerService.LogInfo($"LoadDocuments: Added loaded link '{arch.Nombre}' to dropdown list.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TransferPlus.Services.LoggerService.LogError("LoadDocuments: Error loading linked models", ex);
            }
        }

        // 3. Load active configured family sources ONLY IF Families Manager is ACTIVATED
        if (IsFamiliesManagerActive)
        {
            try
            {
                var activeFamilySources = FamilySourceConfigService.LoadSources().Where(s => s.IsActive).ToList();
                foreach (var familySource in activeFamilySources)
                {
                    string displayName = string.IsNullOrWhiteSpace(familySource.Name) ? familySource.Path : familySource.Name;
                    var arch = new Archivo(displayName, isFamilySource: true);
                    SourceDocuments.Add(arch);
                    TransferPlus.Services.LoggerService.LogInfo($"LoadDocuments: Added active family source '{displayName}' ({familySource.SourceDescription}) to dropdown list.");
                }
            }
            catch (Exception ex)
            {
                TransferPlus.Services.LoggerService.LogError("LoadDocuments: Error loading saved family sources", ex);
            }
        }

        // Default selection to the active target document
        SelectedSourceDocument = SourceDocuments.FirstOrDefault(d => d.Adoc != null && d.Adoc.PathName.Equals(_targetDoc.PathName, StringComparison.OrdinalIgnoreCase))
                                 ?? SourceDocuments.FirstOrDefault();

        OnPropertyChanged(nameof(CheckedDestinationsText));
        TransferPlus.Services.LoggerService.LogInfo($"LoadDocuments: Found {SourceDocuments.Count} source items in dropdown. Selected default source: '{SelectedSourceDocument?.Nombre}'");
    }

    partial void OnSelectedSourceDocumentChanged(Archivo? value)
    {
        TransferPlus.Services.LoggerService.LogInfo($"OnSelectedSourceDocumentChanged: Selected source changed to '{value?.Nombre ?? "null"}' (EsFamilySource={value?.EsFamilySource ?? false})");
        if (value != null)
        {
            if (value.Adoc != null)
            {
                if (IsFamiliesManagerActive)
                {
                    // Families Manager active: Load families from the standard document
                    _ = LoadFamiliesFromSourceAsync(value.Nombre);
                }
                else if (IsCadDetailsManagerActive)
                {
                    // CAD Details Manager active: Load CAD details & drafting views
                    LoadCadItemsFromSource(value.Adoc);
                }
                else
                {
                    // Standard Revit Document source
                    LoadSourceItems(value.Adoc);
                }
            }
            else
            {
                // Family Source (Local Directory, Azure Storage, or Autodesk Docs)
                if (IsFamiliesManagerActive)
                {
                    _ = LoadFamiliesFromSourceAsync(value.Nombre);
                }
                else
                {
                    RootNodes.Clear();
                    _allSourceItems.Clear();
                    _cadItems.Clear();
                    CheckedElementsCount = 0;
                    TransferPlus.Services.LoggerService.LogInfo($"OnSelectedSourceDocumentChanged: Selected family source '{value.Nombre}'. Use 'Activate' button in Families Manager panel to load and transfer families.");
                }
            }

            // Rebuild destination documents for ALL sources (open models and custom family sources):
            // Includes all open non-linked, non-family project documents in session
            DestinationDocuments.Clear();
            foreach (Document doc in _app.Application.Documents)
            {
                if (doc.IsLinked || doc.IsFamilyDocument) continue;
                if (value.Adoc != null && doc.PathName.Equals(value.Adoc.PathName, StringComparison.OrdinalIgnoreCase)) continue;

                var dest = new Archivo(doc) { Checked = true };
                dest.Nombre = GetDocumentDisplayName(doc);
                dest.OnCheckedPropertyChanged = () => OnPropertyChanged(nameof(CheckedDestinationsText));
                DestinationDocuments.Add(dest);
            }
            TransferPlus.Services.LoggerService.LogInfo($"OnSelectedSourceDocumentChanged: Rebuilt destination documents. Target destinations count: {DestinationDocuments.Count}");
        }
        else
        {
            RootNodes.Clear();
            _allSourceItems.Clear();
            _familyItems.Clear();
            _cadItems.Clear();
            CheckedElementsCount = 0;
            DestinationDocuments.Clear();
        }
        OnPropertyChanged(nameof(CheckedDestinationsText));
    }

    private string GetDocumentDisplayName(Document doc)
    {
        if (doc.IsLinked)
        {
            try
            {
                var linkInst = new FilteredElementCollector(_targetDoc)
                    .OfClass(typeof(RevitLinkInstance))
                    .Cast<RevitLinkInstance>()
                    .FirstOrDefault(li => li.GetLinkDocument() != null && li.GetLinkDocument().PathName.Equals(doc.PathName, StringComparison.OrdinalIgnoreCase));

                if (linkInst != null)
                {
                    return $"Link: {linkInst.Name}";
                }
            }
            catch { }

            return "Link: " + doc.Title;
        }
        else if (doc.PathName.Equals(_targetDoc.PathName, StringComparison.OrdinalIgnoreCase))
        {
            return "Active Model: " + doc.Title;
        }
        else
        {
            return "Model: " + doc.Title;
        }
    }

    partial void OnCopyLinksChanged(bool value)
    {
        // If Include Links as Source is turned off, and the selected document is a link, reset selection
        if (!value && SelectedSourceDocument != null && SelectedSourceDocument.EsVinculo)
        {
            SelectedSourceDocument = SourceDocuments.FirstOrDefault(d => !d.EsVinculo);
        }
    }

    // No automatic filtering on property changes (triggered by Apply button only)

    private void LoadSourceItems(Document sourceDoc)
    {
        TransferPlus.Services.LoggerService.LogInfo($"LoadSourceItems: Starting element collection from '{sourceDoc.Title}'...");
        IsBusy = true;
        StatusMessage = "Collecting elements...";
        ProgressPercentage = 0;

        try
        {
            _allSourceItems = DocumentCollector.GetTransferableElements(sourceDoc, (stepName, stepIndex, maxSteps) =>
            {
                StatusMessage = $"{stepName}...";
                ProgressPercentage = (int)((double)stepIndex / maxSteps * 100);
            });
            TransferPlus.Services.LoggerService.LogInfo($"LoadSourceItems: Collection complete. Collected {_allSourceItems.Count} elements. Initiating tree build...");
            BuildTree();
        }
        catch (Exception ex)
        {
            TransferPlus.Services.LoggerService.LogError("LoadSourceItems", ex);
        }
        finally
        {
            IsBusy = false;
            StatusMessage = "Ready";
            ProgressPercentage = 0;
            UpdateCheckedCount();
        }
    }

    private async Task LoadFamiliesFromSourceAsync(string sourceName)
    {
        TransferPlus.Services.LoggerService.LogInfo($"LoadFamiliesFromSourceAsync: Starting family collection from '{sourceName}'...");
        IsBusy = true;
        StatusMessage = "Collecting families...";
        ProgressPercentage = 0;

        try
        {
            var provider = TransferPlus.Services.Providers.FamilyProviderFactory.CreateProvider(sourceName, _targetDoc, _familyRevitService);
            var familyItems = await provider.GetFamiliesAsync();
            _familyItems = familyItems.ToList();
            
            // Set Revit version without extracting thumbnails (Thumbnails load asynchronously on selection)
            foreach (var fam in _familyItems)
            {
                if (fam.NativeFamily is Family nativeFam && _targetDoc != null)
                {
                    fam.RevitVersion = _app.Application.VersionNumber;
                }
            }
            
            TotalFamiliesLoadedCount = _familyItems.Count;
            CounterValue = TotalFamiliesLoadedCount;
            CounterLabelText = "family(ies) loaded";

            TransferPlus.Services.LoggerService.LogInfo($"LoadFamiliesFromSourceAsync: Collection complete. Collected {_familyItems.Count} families. Initiating family tree build...");
            
            System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke(() =>
            {
                BuildFamilyTree();
            });
        }
        catch (Exception ex)
        {
            TransferPlus.Services.LoggerService.LogError("LoadFamiliesFromSourceAsync", ex);
        }
        finally
        {
            IsBusy = false;
            StatusMessage = "Ready";
            ProgressPercentage = 0;
            UpdateCheckedCount();
        }
    }

    private void BuildFamilyTree()
    {
        TransferPlus.Services.LoggerService.LogInfo("BuildFamilyTree: Generating TreeView nodes from collected families...");
        RootNodes.Clear();
        SelectedFamily = null;
        if (!_familyItems.Any()) return;

        // Level 0: All (Root Node)
        var allNode = new TreeItemViewModel("All", "Root", null, null, 0)
        {
            Count = _familyItems.Count,
            IsExpanded = true
        };

        // Group Level 1: Container / SourceName
        var containerGroups = _familyItems
            .GroupBy(x => string.IsNullOrWhiteSpace(x.SourceName) ? "Modelo Origen" : x.SourceName)
            .OrderBy(g => g.Key);

        foreach (var containerGroup in containerGroups)
        {
            var containerNode = new TreeItemViewModel(containerGroup.Key, "Container", null, allNode, 1)
            {
                Count = containerGroup.Count(),
                IsExpanded = true
            };

            // Group Level 2: CategoryName
            var categoryGroups = containerGroup
                .GroupBy(x => string.IsNullOrWhiteSpace(x.CategoryName) ? "Sin Categoría" : x.CategoryName)
                .OrderBy(g => g.Key);

            foreach (var categoryGroup in categoryGroups)
            {
                var categoryNode = new TreeItemViewModel(categoryGroup.Key, "Category", null, containerNode, 2)
                {
                    Count = categoryGroup.Count(),
                    IsExpanded = false
                };

                // Group Level 3: Family
                foreach (var fam in categoryGroup.OrderBy(x => x.Name))
                {
                    var familyNode = new TreeItemViewModel(fam.Name, "Family", fam, categoryNode, 3)
                    {
                        Count = fam.Symbols?.Count > 0 ? fam.Symbols.Count : 1
                    };

                    // Group Level 4: Symbol / Type
                    if (fam.Symbols != null && fam.Symbols.Any())
                    {
                        foreach (var sym in fam.Symbols)
                        {
                            sym.IsChecked = false;
                            var symbolNode = new TreeItemViewModel(sym.Name, "Symbol", sym, familyNode, 4)
                            {
                                Count = 1,
                                IsChecked = false
                            };
                            familyNode.Children.Add(symbolNode);
                        }
                    }

                    categoryNode.Children.Add(familyNode);
                }

                containerNode.Children.Add(categoryNode);
            }

            allNode.Children.Add(containerNode);
        }

        allNode.UpdateRecursiveCounts();
        allNode.SetCheckedState(false);
        RootNodes.Add(allNode);
        TransferPlus.Services.LoggerService.LogInfo($"BuildFamilyTree: Tree built successfully. Total nodes grouped in root: {allNode.Count}");
    }

    private void LoadCadItemsFromSource(Document sourceDoc)
    {
        if (sourceDoc == null) return;

        TransferPlus.Services.LoggerService.LogInfo($"LoadCadItemsFromSource: Starting CAD/Drafting view collection from '{sourceDoc.Title}'...");
        IsBusy = true;
        StatusMessage = "Collecting CAD details...";
        ProgressPercentage = 0;

        try
        {
            if (CadOriginDraftingViews)
            {
                _cadItems = TransferPlus.Services.Providers.DraftingViewProvider.GetDraftingViews(sourceDoc);
            }
            else if (CadOriginLinksAndImports)
            {
                _cadItems = TransferPlus.Services.Providers.CadInstanceProvider.GetCadInstances(sourceDoc);
            }
            else if (CadOriginDetailViewsAndCallouts)
            {
                _cadItems = TransferPlus.Services.Providers.DetailViewProvider.GetDetailViews(sourceDoc);
            }
            else if (CadOriginDetailGroups)
            {
                _cadItems = TransferPlus.Services.Providers.DetailGroupProvider.GetDetailGroups(sourceDoc);
            }
            else if (CadOriginDetailItems)
            {
                _cadItems = TransferPlus.Services.Providers.DetailItemProvider.GetDetailItems(sourceDoc);
            }
            else
            {
                _cadItems = new List<CadDetailItemModel>();
            }

            CounterValue = _cadItems.Count;
            CounterLabelText = _cadItems.Count == 1 ? "CAD item loaded" : "CAD items loaded";

            TransferPlus.Services.LoggerService.LogInfo($"LoadCadItemsFromSource: Collection complete. Collected {_cadItems.Count} items. Initiating tree build...");

            BuildCadTree();
        }
        catch (Exception ex)
        {
            TransferPlus.Services.LoggerService.LogError("LoadCadItemsFromSource", ex);
        }
        finally
        {
            IsBusy = false;
            StatusMessage = "Ready";
            ProgressPercentage = 0;
            UpdateCheckedCount();
        }
    }

    private void BuildCadTree()
    {
        TransferPlus.Services.LoggerService.LogInfo("BuildCadTree: Generating TreeView nodes from collected CAD details...");
        RootNodes.Clear();
        if (!_cadItems.Any()) return;

        // Level 0: All (Root Node)
        var allNode = new TreeItemViewModel("All", "Root", null, null, 0)
        {
            Count = _cadItems.Count,
            IsExpanded = true
        };

        if (CadSortBySheet)
        {
            // Group by Sheet -> View -> Item
            var sheetGroups = _cadItems
                .GroupBy(x => string.IsNullOrWhiteSpace(x.SheetName) ? "(No Sheet / Standalone)" : x.SheetName)
                .OrderBy(g => g.Key);

            foreach (var sheetGroup in sheetGroups)
            {
                var sheetNode = new TreeItemViewModel(sheetGroup.Key, "Sheet", null, allNode, 1)
                {
                    Count = sheetGroup.Count(),
                    IsExpanded = true
                };

                var viewGroups = sheetGroup
                    .GroupBy(x => string.IsNullOrWhiteSpace(x.ViewName) ? "(Unassigned View)" : x.ViewName)
                    .OrderBy(g => g.Key);

                foreach (var viewGroup in viewGroups)
                {
                    var viewNode = new TreeItemViewModel(viewGroup.Key, "View", null, sheetNode, 2)
                    {
                        Count = viewGroup.Count(),
                        IsExpanded = false
                    };

                    foreach (var cadItem in viewGroup.OrderBy(x => x.Name))
                    {
                        var itemNode = new TreeItemViewModel(cadItem.Name, cadItem.DisplayCategory, cadItem, viewNode, 3)
                        {
                            Count = 1,
                            IsChecked = false
                        };
                        viewNode.Children.Add(itemNode);
                    }

                    sheetNode.Children.Add(viewNode);
                }

                allNode.Children.Add(sheetNode);
            }
        }
        else if (CadSortByView)
        {
            // Group by View -> Item
            var viewGroups = _cadItems
                .GroupBy(x => string.IsNullOrWhiteSpace(x.ViewName) ? "(Unassigned View)" : x.ViewName)
                .OrderBy(g => g.Key);

            foreach (var viewGroup in viewGroups)
            {
                string viewDisplayName = viewGroup.Key;
                var firstWithSheet = viewGroup.FirstOrDefault(x => !string.IsNullOrWhiteSpace(x.SheetName));
                if (firstWithSheet != null && !string.IsNullOrWhiteSpace(firstWithSheet.SheetName))
                {
                    viewDisplayName = $"{viewGroup.Key} [{firstWithSheet.SheetName}]";
                }

                var viewNode = new TreeItemViewModel(viewDisplayName, "View", null, allNode, 1)
                {
                    Count = viewGroup.Count(),
                    IsExpanded = false
                };

                foreach (var cadItem in viewGroup.OrderBy(x => x.Name))
                {
                    var itemNode = new TreeItemViewModel(cadItem.Name, cadItem.DisplayCategory, cadItem, viewNode, 2)
                    {
                        Count = 1,
                        IsChecked = false
                    };
                    viewNode.Children.Add(itemNode);
                }

                allNode.Children.Add(viewNode);
            }
        }
        else // CadSortByName
        {
            // Group by Category (Drafting Views / CAD Links / CAD Imports) -> Item
            var catGroups = _cadItems
                .GroupBy(x => x.DisplayCategory)
                .OrderBy(g => g.Key);

            foreach (var catGroup in catGroups)
            {
                var catNode = new TreeItemViewModel(catGroup.Key, "Category", null, allNode, 1)
                {
                    Count = catGroup.Count(),
                    IsExpanded = true
                };

                foreach (var cadItem in catGroup.OrderBy(x => x.Name))
                {
                    string itemLabel = cadItem.Name;
                    if (!string.IsNullOrWhiteSpace(cadItem.ViewName) && !cadItem.IsDraftingView)
                    {
                        itemLabel = $"{cadItem.Name} ({cadItem.ViewName})";
                    }

                    var itemNode = new TreeItemViewModel(itemLabel, cadItem.DisplayCategory, cadItem, catNode, 2)
                    {
                        Count = 1,
                        IsChecked = false
                    };
                    catNode.Children.Add(itemNode);
                }

                allNode.Children.Add(catNode);
            }
        }

        allNode.UpdateRecursiveCounts();
        allNode.SetCheckedState(false);
        RootNodes.Add(allNode);
        TransferPlus.Services.LoggerService.LogInfo($"BuildCadTree: CAD tree built successfully. Total nodes grouped in root: {allNode.Count}");
    }

    private void BuildTree()
    {
        TransferPlus.Services.LoggerService.LogInfo("BuildTree: Generating TreeView nodes from collected elements...");
        RootNodes.Clear();
        if (!_allSourceItems.Any()) return;

        var allNode = new TreeItemViewModel("All", "Root", null, null, 0)
        {
            Count = _allSourceItems.Count,
            IsExpanded = true
        };

        var groups = _allSourceItems.GroupBy(x => x.Categoria).OrderBy(g => g.Key);

        foreach (var group in groups)
        {
            var categoryNode = new TreeItemViewModel(group.Key, "Category", null, allNode, 1)
            {
                Count = group.Count(),
                IsExpanded = false
            };
            
            if (group.Key == "Views" || group.Key == "View Templates")
            {
                var disciplineGroups = group.GroupBy(x => string.IsNullOrEmpty(x.Discipline) || x.Discipline == "Undefined" ? "Coordination" : x.Discipline).OrderBy(g => g.Key);
                foreach (var discGroup in disciplineGroups)
                {
                    var disciplineNode = new TreeItemViewModel(discGroup.Key, "Discipline", null, categoryNode, 2)
                    {
                        Count = discGroup.Count()
                    };
                    
                    var familyGroups = discGroup.GroupBy(x => x.Familia).OrderBy(g => g.Key);
                    foreach (var famGroup in familyGroups)
                    {
                        var familyNode = new TreeItemViewModel(famGroup.Key, "Family", null, disciplineNode, 3)
                        {
                            Count = famGroup.Count()
                        };
                        
                        foreach (var item in famGroup.OrderBy(x => x.Nombre))
                        {
                            var itemNode = new TreeItemViewModel(item.Nombre, item.Tipo ?? "Undefined", item, familyNode, 4)
                            {
                                Count = 1
                            };
                            familyNode.Children.Add(itemNode);
                        }
                        disciplineNode.Children.Add(familyNode);
                    }
                    categoryNode.Children.Add(disciplineNode);
                }
            }
            else
            {
                var familyGroups = group.GroupBy(x => x.Familia).OrderBy(g => g.Key);
                foreach (var famGroup in familyGroups)
                {
                    var familyNode = new TreeItemViewModel(famGroup.Key, "Family", null, categoryNode, 2)
                    {
                        Count = famGroup.Count()
                    };
                    
                    foreach (var item in famGroup.OrderBy(x => x.Nombre))
                    {
                        var itemNode = new TreeItemViewModel(item.Nombre, item.Tipo ?? "Undefined", item, familyNode, 3)
                        {
                            Count = 1
                        };
                        familyNode.Children.Add(itemNode);
                    }
                    categoryNode.Children.Add(familyNode);
                }
            }
            allNode.Children.Add(categoryNode);
        }
        allNode.UpdateRecursiveCounts();
        allNode.SetCheckedState(false);
        RootNodes.Add(allNode);
        TransferPlus.Services.LoggerService.LogInfo($"BuildTree: Tree built successfully. Total nodes grouped in root: {allNode.Count}");
    }

    private bool CanFilterTree() => !string.IsNullOrWhiteSpace(SearchFilter);

    [RelayCommand(CanExecute = nameof(CanFilterTree))]
    private void FilterTree()
    {
        string searchText = SearchFilter;
        if (string.IsNullOrWhiteSpace(searchText)) return;

        TransferPlus.Services.LoggerService.LogInfo($"FilterTree: Applying filter '{searchText}' (Regex: {FilterUseRegex}, Only Names: {FilterOnlyNames}, Use OR: {FilterUseOr})");
        StatusMessage = "Applying search filter...";
        IsBusy = true;

        System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke(
            System.Windows.Threading.DispatcherPriority.Background,
            new Action(delegate { }));

        try
        {
            Regex? searchRegex = null;

            if (FilterUseRegex)
            {
                try
                {
                    searchRegex = new Regex(
                        searchText, 
                        RegexOptions.IgnoreCase | RegexOptions.Compiled,
                        TimeSpan.FromSeconds(2));
                }
                catch (Exception ex)
                {
                    TransferPlus.Services.LoggerService.LogError("FilterTree (Regex Compile)", ex);
                    StatusMessage = "Invalid Regex Pattern";
                    return;
                }
            }
            else
            {
                searchText = searchText.ToLowerInvariant();
            }

            TreeItemViewModel.IsBulkUpdating = true;

            // If Use OR is OFF, the new search replaces the current selection.
            if (!FilterUseOr)
            {
                foreach (var node in RootNodes)
                {
                    node.SetCheckedState(false);
                }
            }

            // Apply the current search matches on the nodes shown in the explorer
            foreach (var node in RootNodes)
            {
                FilterNode(node, searchText, searchRegex);
            }

            // Ensure parent nodes reflect child states properly
            foreach (var node in RootNodes)
            {
                node.RefreshState();
            }

            TreeItemViewModel.IsBulkUpdating = false;
            UpdateCheckedCount();

            // Clear the text box after applying
            SearchFilter = string.Empty;
            TransferPlus.Services.LoggerService.LogInfo($"FilterTree: Filter applied successfully. Elements checked count is now {CheckedElementsCount}");
        }
        catch (Exception ex)
        {
            TransferPlus.Services.LoggerService.LogError("FilterTree", ex);
        }
        finally
        {
            IsBusy = false;
            StatusMessage = "Ready";
        }
    }

    private void FilterNode(TreeItemViewModel node, string searchText, Regex? searchRegex)
    {
        bool match = false;
        if (node.Level > 0)
        {
            try
            {
                if (searchRegex != null)
                {
                    match = searchRegex.IsMatch(node.Name);
                    if (!match && !FilterOnlyNames)
                    {
                        match = searchRegex.IsMatch(node.Category);
                        if (!match && node.Item != null)
                        {
                            if (node.Item is Elemento elm)
                            {
                                if (elm.Familia != null) match = searchRegex.IsMatch(elm.Familia);
                                if (!match && elm.Tipo != null) match = searchRegex.IsMatch(elm.Tipo);
                            }
                            else if (node.Item is FamilyItemModel fam)
                            {
                                if (fam.Name != null) match = searchRegex.IsMatch(fam.Name);
                                if (!match && fam.CategoryName != null) match = searchRegex.IsMatch(fam.CategoryName);
                                if (!match && fam.RevitVersion != null) match = searchRegex.IsMatch(fam.RevitVersion);
                                if (!match && fam.Symbols != null)
                                {
                                    foreach (var sym in fam.Symbols)
                                    {
                                        if (sym.Name != null && searchRegex.IsMatch(sym.Name)) { match = true; break; }
                                    }
                                }
                            }
                            else if (node.Item is FamilySymbolItemModel symItem)
                            {
                                if (symItem.Name != null) match = searchRegex.IsMatch(symItem.Name);
                                if (!match && symItem.FamilyName != null) match = searchRegex.IsMatch(symItem.FamilyName);
                            }
                            else if (node.Item is CadDetailItemModel cadItem)
                            {
                                if (cadItem.Name != null) match = searchRegex.IsMatch(cadItem.Name);
                                if (!match && cadItem.ViewName != null) match = searchRegex.IsMatch(cadItem.ViewName);
                                if (!match && cadItem.SheetName != null) match = searchRegex.IsMatch(cadItem.SheetName);
                            }
                        }
                    }
                }
                else
                {
                    match = node.Name.ToLowerInvariant().Contains(searchText);
                    if (!match && !FilterOnlyNames)
                    {
                        match = node.Category.ToLowerInvariant().Contains(searchText);
                        if (!match && node.Item != null)
                        {
                            if (node.Item is Elemento elm)
                            {
                                if (elm.Familia != null) match = elm.Familia.ToLowerInvariant().Contains(searchText);
                                if (!match && elm.Tipo != null) match = elm.Tipo.ToLowerInvariant().Contains(searchText);
                            }
                            else if (node.Item is FamilyItemModel fam)
                            {
                                if (fam.Name != null) match = fam.Name.ToLowerInvariant().Contains(searchText);
                                if (!match && fam.CategoryName != null) match = fam.CategoryName.ToLowerInvariant().Contains(searchText);
                                if (!match && fam.RevitVersion != null) match = fam.RevitVersion.ToLowerInvariant().Contains(searchText);
                                if (!match && fam.Symbols != null)
                                {
                                    foreach (var sym in fam.Symbols)
                                    {
                                        if (sym.Name != null && sym.Name.ToLowerInvariant().Contains(searchText)) { match = true; break; }
                                    }
                                }
                            }
                            else if (node.Item is FamilySymbolItemModel symItem)
                            {
                                if (symItem.Name != null) match = symItem.Name.ToLowerInvariant().Contains(searchText);
                                if (!match && symItem.FamilyName != null) match = symItem.FamilyName.ToLowerInvariant().Contains(searchText);
                            }
                            else if (node.Item is CadDetailItemModel cadItem)
                            {
                                if (cadItem.Name != null) match = cadItem.Name.ToLowerInvariant().Contains(searchText);
                                if (!match && cadItem.ViewName != null) match = cadItem.ViewName.ToLowerInvariant().Contains(searchText);
                                if (!match && cadItem.SheetName != null) match = cadItem.SheetName.ToLowerInvariant().Contains(searchText);
                            }
                        }
                    }
                }
            }
            catch {}
        }

        if (match)
        {
            node.SetCheckedState(true);
            node.IsExpanded = true;
            ExpandParents(node);
        }

        foreach (var child in node.Children)
        {
            FilterNode(child, searchText, searchRegex);
        }
    }

    private void ExpandParents(TreeItemViewModel node)
    {
        var parent = node.Parent;
        while (parent != null)
        {
            parent.IsExpanded = true;
            parent = parent.Parent;
        }
    }

    [RelayCommand(CanExecute = nameof(HasCheckedElements))]
    private void ClearFilter()
    {
        SearchFilter = string.Empty;
        FilterUseOr = false;
        FilterOnlyNames = false;
        FilterUseRegex = false;

        if (RootNodes != null)
        {
            TreeItemViewModel.IsBulkUpdating = true;
            foreach (var node in RootNodes)
            {
                node.SetCheckedState(false);
            }
            TreeItemViewModel.IsBulkUpdating = false;
            UpdateCheckedCount();
        }
    }

    [RelayCommand]
    private void ExpandAll()
    {
        if (RootNodes == null || !RootNodes.Any()) return;
        
        int targetLevel = FindLowestUnexpandedLevel(RootNodes);
        if (targetLevel != int.MaxValue)
        {
            if (targetLevel == 0)
            {
                ForceCollapseAll(RootNodes.SelectMany(r => r.Children));
            }
            SetExpandedStateAtLevel(RootNodes, targetLevel, true);
        }
    }

    [RelayCommand]
    private void CollapseAll()
    {
        if (RootNodes == null || !RootNodes.Any()) return;

        int targetLevel = FindHighestExpandedLevel(RootNodes);
        if (targetLevel > 0) // Never collapse Level 0 (Root "All")
        {
            SetExpandedStateAtLevel(RootNodes, targetLevel, false);
        }
    }

    private int FindLowestUnexpandedLevel(IEnumerable<TreeItemViewModel> nodes)
    {
        int lowest = int.MaxValue;
        foreach (var node in nodes)
        {
            if (node.Children.Count > 0)
            {
                if (!node.IsExpanded)
                {
                    if (node.Level < lowest) lowest = node.Level;
                }
                else
                {
                    int childLowest = FindLowestUnexpandedLevel(node.Children);
                    if (childLowest < lowest) lowest = childLowest;
                }
            }
        }
        return lowest;
    }

    private int FindHighestExpandedLevel(IEnumerable<TreeItemViewModel> nodes)
    {
        int highest = -1;
        foreach (var node in nodes)
        {
            if (node.IsExpanded && node.Children.Count > 0)
            {
                if (node.Level > highest) highest = node.Level;
                int childHighest = FindHighestExpandedLevel(node.Children);
                if (childHighest > highest) highest = childHighest;
            }
        }
        return highest;
    }

    private void SetExpandedStateAtLevel(IEnumerable<TreeItemViewModel> nodes, int targetLevel, bool state)
    {
        foreach (var node in nodes)
        {
            if (node.Level == targetLevel)
            {
                if (node.Children.Count > 0) node.IsExpanded = state;
            }
            else if (node.Level < targetLevel)
            {
                SetExpandedStateAtLevel(node.Children, targetLevel, state);
            }
        }
    }

    private void ForceCollapseAll(IEnumerable<TreeItemViewModel> nodes)
    {
        foreach (var node in nodes)
        {
            node.IsExpanded = false;
            ForceCollapseAll(node.Children);
        }
    }

    private void SyncConfig()
    {
        _config.cf_rbKeepOriginal = KeepOriginal;
        _config.cf_rbAbortTransaction = AbortTransaction;
        _config.cf_rbAppendSuffix = AppendSuffix;
        _config.cf_suffixText = DuplicatesSuffixText;
        _config.cf_chk_Callout = IncludeCallouts;
        _config.cf_chk_Section = IncludeSections;
        _config.cf_chk_ViewElements = IncludeViewElements;
        _config.cf_chk_SheetWithViews = IncludeSheetsWithViews;
        _config.cf_chk_UseLegendIfExists = UseLegendIfExists;
        _config.cf_chk_UseScheduleIfExists = UseScheduleIfExists;
        _config.cf_chk_UseAssemblyViewsIfExists = UseAssemblyViewsIfExists;
        _config.cf_chk_ForceLevelInLevelBaseViews = ForceLevelInLevelBaseViews;
        _config.cf_chk_Links = CopyLinks;
        _config.cf_chk_GetTransformNone = TransformNone;
        _config.cf_chk_GetTransformLink = TransformLink;
        _config.cf_chk_GetTransformShared = TransformShared;
        _config.cf_chk_AcceptAll = AcceptAllWarnings;
    }

    [RelayCommand(CanExecute = nameof(HasCheckedElements))]
    private void Transfer()
    {
        if (SelectedSourceDocument == null) return;

        TransferPlus.Services.LoggerService.LogInfo($"Transfer: Initiating transfer from '{SelectedSourceDocument.Nombre}'...");
        SyncConfig();

        if (IsFamiliesManagerActive)
        {
            var checkedFamilies = new List<FamilyItemModel>();
            CollectCheckedFamilies(RootNodes, checkedFamilies);

            if (!checkedFamilies.Any())
            {
                TransferPlus.Services.LoggerService.LogInfo("Transfer: Operation aborted. No families have their checkbox marked for transfer.");
                TaskDialog.Show("TransferPlus", "No items selected to transfer. Please check the checkbox of the families you wish to transfer.");
                return;
            }

            var targetDestinations = DestinationDocuments.Where(d => d.Checked && d.Adoc != null).ToList();
            if (!targetDestinations.Any())
            {
                TaskDialog.Show("TransferPlus", "Please select at least one destination model.");
                return;
            }

            IsBusy = true;
            StatusMessage = "Transferring families...";

            try
            {
            var familyService = new FamilyRevitService();

            // -------------------------------------------------------------
            // ON DUPLICATES CHECK: ABORT TRANSACTION
            // -------------------------------------------------------------
            if (AbortTransaction)
            {
                bool duplicateFound = false;
                string duplicateInfo = string.Empty;

                foreach (var destDoc in targetDestinations)
                {
                    foreach (var fam in checkedFamilies)
                    {
                        var existingFam = familyService.GetExistingFamily(destDoc.Adoc, fam.Name);
                        if (existingFam != null)
                        {
                            duplicateFound = true;
                            duplicateInfo = $"Family '{fam.Name}' already exists in target model '{destDoc.Nombre}'.";
                            break;
                        }

                        if (fam.Symbols != null && fam.Symbols.Any(s => s.IsActive))
                        {
                            var selectedActiveSymbols = fam.Symbols.Where(s => s.IsActive).Select(s => s.Name).ToHashSet(StringComparer.OrdinalIgnoreCase);
                            var existingFamilySymbols = new FilteredElementCollector(destDoc.Adoc)
                                .OfClass(typeof(FamilySymbol))
                                .Cast<FamilySymbol>()
                                .Where(s => selectedActiveSymbols.Contains(s.Name))
                                .ToList();

                            if (existingFamilySymbols.Any())
                            {
                                duplicateFound = true;
                                duplicateInfo = $"Type '{existingFamilySymbols.First().Name}' already exists in target model '{destDoc.Nombre}'.";
                                break;
                            }
                        }
                    }
                    if (duplicateFound) break;
                }

                if (duplicateFound)
                {
                    TransferPlus.Services.LoggerService.LogInfo($"Transfer: Aborted due to duplicates. {duplicateInfo}");
                    TaskDialog.Show("TransferPlus - Operation Aborted",
                        $"The transfer operation was aborted because one or more selected families or types already exist in the target model:\n\n{duplicateInfo}");
                    return;
                }
            }

            TransferPlus.Services.Providers.IFamilyProvider provider = TransferPlus.Services.Providers.FamilyProviderFactory.CreateProvider(
                SelectedSourceDocument.Nombre,
                SelectedSourceDocument.Adoc,
                familyService);

                var renameFamilyMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                var renameSymbolMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

                if (IsRenamePanelOpen || RenamePreviewItems.Any())
                {
                    foreach (var pItem in RenamePreviewItems)
                    {
                        if (pItem.IsSelected && !string.IsNullOrWhiteSpace(pItem.NewName) && !pItem.NewName.Equals(pItem.OriginalName, StringComparison.OrdinalIgnoreCase))
                        {
                            if (pItem.IsType)
                            {
                                renameSymbolMap[pItem.OriginalName] = pItem.NewName;
                            }
                            else
                            {
                                renameFamilyMap[pItem.OriginalName] = pItem.NewName;
                            }
                        }
                    }
                }

                int transferredCount = 0;
                foreach (var destDoc in targetDestinations)
                {
                    foreach (var fam in checkedFamilies)
                    {
                        string? overrideFamilyName = null;
                        if (renameFamilyMap.TryGetValue(fam.Name, out var renamedFamName))
                        {
                            overrideFamilyName = renamedFamName;
                        }

                        var existingFam = familyService.GetExistingFamily(destDoc.Adoc, overrideFamilyName ?? fam.Name);

                        // -------------------------------------------------------------
                        // ON DUPLICATES CHECK: KEEP ORIGINAL
                        // -------------------------------------------------------------
                        if (KeepOriginal && existingFam != null)
                        {
                            var existingSymbolNames = familyService.GetExistingSymbolNames(destDoc.Adoc, existingFam);
                            var selectedSymbols = fam.Symbols?.Where(s => s.IsActive).ToList() ?? new List<FamilySymbolItemModel>();

                            if (selectedSymbols.Any())
                            {
                                var missingSymbols = selectedSymbols.Where(s => !existingSymbolNames.Contains(s.Name)).ToList();

                                if (!missingSymbols.Any())
                                {
                                    // ALL selected types already exist in the destination family. Skip this family!
                                    TransferPlus.Services.LoggerService.LogInfo($"Transfer: Skipped family '{fam.Name}' in '{destDoc.Nombre}' because all selected types already exist (Keep Original).");
                                    continue;
                                }

                                // Create a cloned family item containing ONLY missing symbols to transfer
                                var clonedFam = new FamilyItemModel
                                {
                                    Name = fam.Name,
                                    CategoryName = fam.CategoryName,
                                    SourceName = fam.SourceName,
                                    ImagePreviewUrl = fam.ImagePreviewUrl,
                                    NativeFamily = fam.NativeFamily,
                                    RevitVersion = fam.RevitVersion,
                                    FileSizeBytes = fam.FileSizeBytes,
                                    LastModified = fam.LastModified,
                                    Symbols = missingSymbols
                                };

                                StatusMessage = $"Transferring {missingSymbols.Count} missing type(s) for family '{fam.Name}' to '{destDoc.Nombre}'...";
                                bool okMissing = provider.TransferFamilyAsync(clonedFam, destDoc.Adoc, overrideFamilyName).GetAwaiter().GetResult();
                                if (okMissing) transferredCount++;
                                continue;
                            }
                            else
                            {
                                // No specific active symbols defined and family exists -> Skip (Keep Original)
                                TransferPlus.Services.LoggerService.LogInfo($"Transfer: Skipped family '{fam.Name}' in '{destDoc.Nombre}' (Keep Original).");
                                continue;
                            }
                        }

                        // -------------------------------------------------------------
                        // ON DUPLICATES CHECK: APPEND SUFFIX
                        // -------------------------------------------------------------
                        Dictionary<string, string>? symbolRenameMap = null;
                        if (AppendSuffix && existingFam != null)
                        {
                            string suffix = string.IsNullOrWhiteSpace(DuplicatesSuffixText) ? "_Copy" : DuplicatesSuffixText;
                            var existingSymbolNames = familyService.GetExistingSymbolNames(destDoc.Adoc, existingFam);
                            var selectedSymbols = fam.Symbols?.Where(s => s.IsActive).ToList() ?? new List<FamilySymbolItemModel>();

                            symbolRenameMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

                            foreach (var sym in selectedSymbols)
                            {
                                if (existingSymbolNames.Contains(sym.Name))
                                {
                                    string newSymName = sym.Name + suffix;
                                    int counter = 1;
                                    while (existingSymbolNames.Contains(newSymName))
                                    {
                                        newSymName = $"{sym.Name}{suffix}{counter++}";
                                    }
                                    symbolRenameMap[sym.Name] = newSymName;
                                    TransferPlus.Services.LoggerService.LogInfo($"Transfer: Appending suffix to duplicated type '{sym.Name}' -> '{newSymName}' in existing family '{fam.Name}'.");
                                }
                            }

                            // La familia NO se renombra. Se insertan los tipos dentro de la familia existente.
                            overrideFamilyName = null;
                        }

                        if (symbolRenameMap == null && renameSymbolMap.Any())
                        {
                            symbolRenameMap = new Dictionary<string, string>(renameSymbolMap, StringComparer.OrdinalIgnoreCase);
                        }
                        else if (symbolRenameMap != null && renameSymbolMap.Any())
                        {
                            foreach (var kvp in renameSymbolMap)
                            {
                                symbolRenameMap[kvp.Key] = kvp.Value;
                            }
                        }

                        StatusMessage = $"Transferring family '{overrideFamilyName ?? fam.Name}' to '{destDoc.Nombre}'...";
                        bool ok = provider.TransferFamilyAsync(fam, destDoc.Adoc, overrideFamilyName, symbolRenameMap).GetAwaiter().GetResult();
                        if (ok) transferredCount++;
                    }
                }

                TransferPlus.Services.LoggerService.LogInfo($"Transfer: Completed family transfer. Transferred {transferredCount} family item(s).");
                TaskDialog.Show("TransferPlus", $"Family transfer completed successfully! Transferred {transferredCount} family/families.");
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogError("Error during family transfer", ex);
                TaskDialog.Show("TransferPlus Error", $"An error occurred during family transfer: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }

            return;
        }

        if (IsCadDetailsManagerActive)
        {
            var checkedCadItems = new List<CadDetailItemModel>();
            CollectCheckedCadItems(RootNodes, checkedCadItems);

            if (!checkedCadItems.Any())
            {
                TransferPlus.Services.LoggerService.LogInfo("Transfer: Operation aborted. No CAD details / drafting views are checked for transfer.");
                TaskDialog.Show("TransferPlus", "No items selected to transfer. Please check the checkbox of the CAD details or drafting views you wish to transfer.");
                return;
            }

            var targetDestinations = DestinationDocuments.Where(d => d.Checked && d.Adoc != null).ToList();
            if (!targetDestinations.Any())
            {
                TaskDialog.Show("TransferPlus", "Please select at least one destination model.");
                return;
            }

            if (SelectedSourceDocument?.Adoc == null)
            {
                TaskDialog.Show("TransferPlus", "Selected source document is invalid or not available.");
                return;
            }

            IsBusy = true;
            StatusMessage = "Transferring CAD details...";

            try
            {
                int totalTransferred = 0;
                var familyService = new FamilyRevitService();

                var draftingViewIds = checkedCadItems
                    .Where(x => (x.IsDraftingView || x.NativeElement is View) && x.ElementId != null)
                    .Select(x => x.ElementId!)
                    .ToList();

                var cadInstanceIds = checkedCadItems
                    .Where(x => !x.IsDraftingView && x.NativeElement is ImportInstance && x.ElementId != null)
                    .Select(x => x.ElementId!)
                    .ToList();

                var otherElementIds = checkedCadItems
                    .Where(x => !draftingViewIds.Contains(x.ElementId!) && !cadInstanceIds.Contains(x.ElementId!) && x.ElementId != null)
                    .Select(x => x.ElementId!)
                    .ToList();

                foreach (var destDoc in targetDestinations)
                {
                    StatusMessage = $"Transferring to '{destDoc.Nombre}'...";

                    if (draftingViewIds.Any())
                    {
                        int count = familyService.TransferDraftingViews(SelectedSourceDocument.Adoc, destDoc.Adoc, draftingViewIds);
                        totalTransferred += count;
                    }

                    if (cadInstanceIds.Any())
                    {
                        int count = familyService.TransferCadInstancesToDraftingViews(SelectedSourceDocument.Adoc, destDoc.Adoc, cadInstanceIds);
                        totalTransferred += count;
                    }

                    if (otherElementIds.Any())
                    {
                        int count = familyService.TransferDraftingViews(SelectedSourceDocument.Adoc, destDoc.Adoc, otherElementIds);
                        totalTransferred += count;
                    }
                }

                TransferPlus.Services.LoggerService.LogInfo($"Transfer: Completed CAD details transfer. Transferred {totalTransferred} item(s).");
                TaskDialog.Show("TransferPlus", $"CAD details transfer completed successfully! Transferred {totalTransferred} item(s) to destination model(s).");
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogError("Error during CAD details transfer", ex);
                TaskDialog.Show("TransferPlus Error", $"An error occurred during CAD details transfer: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }

            return;
        }

        var checkedItems = new List<Elemento>();
        CollectCheckedItems(RootNodes, checkedItems);

        if (!checkedItems.Any())
        {
            TransferPlus.Services.LoggerService.LogInfo("Transfer: Operation aborted. No items are checked for transfer.");
            TaskDialog.Show("TransferPlus", "No items selected to transfer.");
            return;
        }

        var elementsToCopy = checkedItems;
        TransferPlus.Services.LoggerService.LogInfo($"Transfer: Collected {elementsToCopy.Count} elements to transfer.");

        // Pre-flight check: Worksets on Non-Workshared Destination Models
        bool hasWorksetsSelected = elementsToCopy.Any(x => x.IsWorkset || x.Categoria == "Worksets" || (x.wID != null && x.wID != WorksetId.InvalidWorksetId));
        if (hasWorksetsSelected)
        {
            var invalidDestinations = DestinationDocuments.Where(d => d.Checked && d.Adoc != null && !d.Adoc.IsWorkshared).ToList();
            if (invalidDestinations.Any())
            {
                string targetTitles = string.Join(", ", invalidDestinations.Select(d => $"'{d.Nombre}'"));
                TransferPlus.Services.LoggerService.LogWarning($"Transfer Aborted: Cannot transfer worksets to non-workshared destination model(s): {targetTitles}");

                TaskDialog mainDialog = new TaskDialog("TransferPlus - Warning")
                {
                    MainInstruction = "Transfer Canceled - Worksets Selected",
                    MainContent = $"Revit does not allow transferring worksets to projects that are not workshared.\n\nThe destination model(s) {targetTitles} are not in collaborative (workshared) mode. Because worksets were included in the selection, the transfer of ALL elements has been canceled.\n\nPlease enable worksharing on the destination project(s) first, or uncheck worksets from the transfer selection to proceed.",
                    CommonButtons = TaskDialogCommonButtons.Ok,
                    MainIcon = TaskDialogIcon.TaskDialogIconWarning
                };
                mainDialog.Show();
                return;
            }
        }

        IsBusy = true;
        StatusMessage = "Transferring elements...";
        ProgressPercentage = 0;

        try
        {
            // Diccionario de renombrado
            Dictionary<ElementId, string>? customNames = null;
            if (IsRenamePanelOpen && RenamePreviewItems.Any())
            {
                customNames = new Dictionary<ElementId, string>();
                foreach (var item in RenamePreviewItems)
                {
                    if (item.IsSelected && item.NewName != item.OriginalName)
                    {
                        customNames[item.SourceId] = item.NewName;
                    }
                }
                if (!customNames.Any()) customNames = null;
            }

            int transferTargetCount = 0;
            foreach (var destDoc in DestinationDocuments)
            {
                if (destDoc.Checked)
                {
                    Dictionary<string, string>? levelMappings = null;
                    if (ForceLevelInLevelBaseViews)
                    {
                        var missingLevels = DetectMissingLevels(SelectedSourceDocument.Adoc, elementsToCopy, destDoc.Adoc);
                        if (missingLevels.Any())
                        {
                            var levelView = new TransferPlus.Views.LevelMappingView(missingLevels);
                            if (levelView.ShowDialog() == true)
                            {
                                var vm = levelView.DataContext as LevelMappingViewModel;
                                if (vm != null)
                                {
                                    levelMappings = new Dictionary<string, string>();
                                    foreach (var conflict in vm.Conflicts)
                                    {
                                        if (conflict.SelectedAction == LevelMappingAction.CreateNew)
                                        {
                                            levelMappings[conflict.SourceLevelName] = "CREATE_NEW:" + conflict.NewLevelName;
                                        }
                                        else if (conflict.SelectedAction == LevelMappingAction.MapToExisting && !string.IsNullOrEmpty(conflict.SelectedTargetLevelName))
                                        {
                                            levelMappings[conflict.SourceLevelName] = conflict.SelectedTargetLevelName;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                TransferPlus.Services.LoggerService.LogInfo($"Transfer: Operation canceled by user at level mapping phase for '{destDoc.Nombre}'.");
                                continue;
                            }
                        }
                    }

                    transferTargetCount++;
                    TransferPlus.Services.LoggerService.LogInfo($"Transfer: Copying elements to target model '{destDoc.Nombre}'...");
                    TransferOrchestrator.TransferElements(SelectedSourceDocument.Adoc, destDoc.Adoc, elementsToCopy, _config, (msg, current, total) =>
                    {
                        StatusMessage = $"{msg}...";
                        ProgressPercentage = (int)((double)current / total * 100);
                        if (current % 10 == 0 || current == total)
                        {
                            TransferPlus.Services.LoggerService.LogInfo($"Transfer: [{msg}] {current}/{total} elements processed ({ProgressPercentage}%)");
                        }
                    }, customNames, levelMappings);
                }
            }

            TransferPlus.Services.LoggerService.LogInfo($"Transfer: Completed successfully. Transferred to {transferTargetCount} destination models.");
            TaskDialog.Show("TransferPlus", "Transfer complete!");
        }
        catch (OperationCanceledException cancelEx)
        {
            TransferPlus.Services.LoggerService.LogExceptionSilently("Transfer Canceled", cancelEx);
            if (cancelEx.Data.Contains("NotWorkshared"))
            {
                string targetTitle = cancelEx.Data["NotWorkshared"]?.ToString() ?? "Destination Document";
                TaskDialog mainDialog = new TaskDialog("TransferPlus - Warning")
                {
                    MainInstruction = "Transfer Canceled - Worksets Selected",
                    MainContent = $"Revit does not allow transferring worksets to projects that are not workshared.\n\nThe destination model '{targetTitle}' is not in collaborative (workshared) mode. Because worksets were included in the selection, the transfer of ALL elements has been canceled.\n\nPlease enable worksharing on the destination project first, or uncheck worksets from the transfer selection to proceed.",
                    CommonButtons = TaskDialogCommonButtons.Ok,
                    MainIcon = TaskDialogIcon.TaskDialogIconWarning
                };
                mainDialog.Show();
            }
            else if (cancelEx.Data.Contains("Duplicates"))
            {
                var dupsObj = cancelEx.Data["Duplicates"];
                if (dupsObj is List<TransferPlus.Models.DuplicateElementInfo> dupInfos && dupInfos.Any())
                {
                    try
                    {
                        var view = new TransferPlus.Views.DuplicatesAbortView(dupInfos);
                        view.ShowDialog();
                    }
                    catch
                    {
                        TaskDialog.Show("TransferPlus", "Transfer canceled due to duplicate element names in the destination document.");
                    }
                }
                else if (dupsObj is List<string> dups && dups.Any())
                {
                    try
                    {
                        var view = new TransferPlus.Views.DuplicatesAbortView(dups);
                        view.ShowDialog();
                    }
                    catch
                    {
                        TaskDialog.Show("TransferPlus", "Transfer canceled due to duplicate element names in the destination document.");
                    }
                }
            }
            else
            {
                TaskDialog.Show("TransferPlus", "Transfer canceled due to duplicate element names in the destination document.");
            }
        }
        catch (Exception ex)
        {
            TransferPlus.Services.LoggerService.LogError("Transfer Error", ex);
            TaskDialog.Show("TransferPlus", $"Error during transfer: {ex.Message}");
        }
        finally
        {
            IsBusy = false;
            StatusMessage = "Ready";
            ProgressPercentage = 0;
            BringMainWindowToFront();
        }
    }

    private void BringMainWindowToFront()
    {
        var activeWindow = System.Windows.Application.Current?.Windows.OfType<System.Windows.Window>()
            .FirstOrDefault(w => w is TransferPlus.Views.TransferPlusView);
        if (activeWindow != null)
        {
            activeWindow.Activate();
            activeWindow.Focus();
        }
    }

    private void CollectCheckedItems(IEnumerable<TreeItemViewModel> nodes, List<Elemento> list)
    {
        foreach (var node in nodes)
        {
            if (node.Item is Elemento elm && node.IsChecked == true)
            {
                list.Add(elm);
            }
            CollectCheckedItems(node.Children, list);
        }
    }

    private bool HasCheckedElements()
    {
        if (IsFamiliesManagerActive) return SelectedFamilyCount > 0;
        return CheckedElementsCount > 0;
    }

    private void CollectCheckedFamilies(IEnumerable<TreeItemViewModel> nodes, List<FamilyItemModel> list)
    {
        foreach (var node in nodes)
        {
            if (node.Item is FamilyItemModel fam && node.IsChecked != false)
            {
                var checkedSymbolNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                bool hasChildSymbolNodes = false;

                foreach (var childNode in node.Children)
                {
                    if (childNode.Item is FamilySymbolItemModel symItem)
                    {
                        hasChildSymbolNodes = true;
                        if (childNode.IsChecked == true)
                        {
                            checkedSymbolNames.Add(symItem.Name);
                        }
                    }
                }

                List<FamilySymbolItemModel> filteredSymbols;
                if (hasChildSymbolNodes && checkedSymbolNames.Any())
                {
                    filteredSymbols = fam.Symbols?.Where(s => checkedSymbolNames.Contains(s.Name)).ToList() 
                                      ?? new List<FamilySymbolItemModel>();
                }
                else
                {
                    filteredSymbols = fam.Symbols ?? new List<FamilySymbolItemModel>();
                }

                var filteredFam = new FamilyItemModel
                {
                    Name = fam.Name,
                    CategoryName = fam.CategoryName,
                    SourceName = fam.SourceName,
                    StatusMessage = fam.StatusMessage,
                    Symbols = filteredSymbols,
                    NativeFamily = fam.NativeFamily,
                    SourceDocument = fam.SourceDocument,
                    HostTypeDescription = fam.HostTypeDescription,
                    ImagePreviewUrl = fam.ImagePreviewUrl,
                    RevitVersion = fam.RevitVersion,
                    FileSizeBytes = fam.FileSizeBytes,
                    LastModified = fam.LastModified
                };

                if (!list.Any(f => f.Name == filteredFam.Name && f.SourceName == filteredFam.SourceName))
                {
                    list.Add(filteredFam);
                }
            }
            CollectCheckedFamilies(node.Children, list);
        }
    }

    private void CollectCheckedCadItems(IEnumerable<TreeItemViewModel> nodes, List<CadDetailItemModel> list)
    {
        foreach (var node in nodes)
        {
            if (node.Item is CadDetailItemModel item && node.IsChecked == true)
            {
                if (!list.Any(c => c.ElementId == item.ElementId && c.Name == item.Name))
                {
                    list.Add(item);
                }
            }
            CollectCheckedCadItems(node.Children, list);
        }
    }

    private void UpdateCheckedCount()
    {
        var checkedItems = new List<Elemento>();
        
        if (IsFamiliesManagerActive)
        {
            var checkedFamilies = new List<FamilyItemModel>();
            CollectCheckedFamilies(RootNodes, checkedFamilies);
            
            SelectedFamilyCount = checkedFamilies.Count;
            CounterValue = SelectedFamilyCount;
            CounterLabelText = SelectedFamilyCount == 1 ? "family checked" : "families checked";
            
            IsSingleFamilySelected = SelectedFamilyCount == 1;
            
            // Sync Category Count
            var categories = new HashSet<string>();
            foreach (var fam in checkedFamilies)
            {
                categories.Add(fam.CategoryName);
            }
            SelectedCategoryCount = categories.Count;
        }
        else if (IsCadDetailsManagerActive)
        {
            var checkedCadItems = new List<CadDetailItemModel>();
            CollectCheckedCadItems(RootNodes, checkedCadItems);

            CheckedElementsCount = checkedCadItems.Count;
            CounterValue = CheckedElementsCount;
            CounterLabelText = CheckedElementsCount == 1 ? "CAD detail checked" : "CAD details checked";

            if (checkedCadItems.Count == 1)
            {
                SelectedCadDetail = checkedCadItems.First();
            }
            else if (checkedCadItems.Count > 1)
            {
                if (SelectedCadDetail == null || !checkedCadItems.Contains(SelectedCadDetail))
                {
                    SelectedCadDetail = checkedCadItems.Last();
                }
            }
        }
        else
        {
            CollectCheckedItems(RootNodes, checkedItems);
            CheckedElementsCount = checkedItems.Count;
            CounterValue = CheckedElementsCount;
            CounterLabelText = CheckedElementsCount == 1 ? "element checked" : "elements checked";
        }
        
        TransferCommand.NotifyCanExecuteChanged();
        OpenRenamePanelCommand.NotifyCanExecuteChanged();
        ClearFilterCommand.NotifyCanExecuteChanged();
        
        // Sincronización dinámica con la paleta si está abierta o hay datos
        if (IsRenamePanelOpen || RenamePreviewItems.Any())
        {
            if (IsFamiliesManagerActive)
            {
                var checkedFamilies = new List<FamilyItemModel>();
                CollectCheckedFamilies(RootNodes, checkedFamilies);
                
                var currentPreviewIds = RenamePreviewItems.Select(x => x.FamilyIdentifier).Where(x => x != null).ToHashSet();
                var newCheckedIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                foreach (var fam in checkedFamilies)
                {
                    newCheckedIds.Add("FAM:" + fam.Name);
                    if (fam.Symbols != null)
                    {
                        foreach (var sym in fam.Symbols)
                        {
                            newCheckedIds.Add("SYM:" + fam.Name + "::" + sym.Name);
                        }
                    }
                }

                // Eliminar los que ya no están seleccionados
                for (int i = RenamePreviewItems.Count - 1; i >= 0; i--)
                {
                    if (RenamePreviewItems[i].FamilyIdentifier == null || !newCheckedIds.Contains(RenamePreviewItems[i].FamilyIdentifier!))
                    {
                        RenamePreviewItems[i].PropertyChanged -= PreviewItem_PropertyChanged;
                        RenamePreviewItems.RemoveAt(i);
                    }
                }

                // Añadir los nuevos seleccionados (Familias y Tipos)
                foreach (var fam in checkedFamilies)
                {
                    string famId = "FAM:" + fam.Name;
                    if (!currentPreviewIds.Contains(famId))
                    {
                        var pItem = new RenamePreviewItem(famId, fam.Name, isType: false, parentFamilyName: fam.Name);
                        pItem.PropertyChanged += PreviewItem_PropertyChanged;
                        RenamePreviewItems.Add(pItem);
                    }

                    if (fam.Symbols != null)
                    {
                        foreach (var sym in fam.Symbols)
                        {
                            string symId = "SYM:" + fam.Name + "::" + sym.Name;
                            if (!currentPreviewIds.Contains(symId))
                            {
                                var pItem = new RenamePreviewItem(symId, sym.Name, isType: true, parentFamilyName: fam.Name);
                                pItem.PropertyChanged += PreviewItem_PropertyChanged;
                                RenamePreviewItems.Add(pItem);
                            }
                        }
                    }
                }
            }
            else
            {
                var currentPreviewIds = RenamePreviewItems.Select(x => x.SourceId).Where(x => x != null).ToHashSet();
                var newCheckedIds = checkedItems.Select(x => x.eID).ToHashSet();

                // Eliminar los que ya no están seleccionados
                for (int i = RenamePreviewItems.Count - 1; i >= 0; i--)
                {
                    if (RenamePreviewItems[i].SourceId == null || !newCheckedIds.Contains(RenamePreviewItems[i].SourceId))
                    {
                        RenamePreviewItems[i].PropertyChanged -= PreviewItem_PropertyChanged;
                        RenamePreviewItems.RemoveAt(i);
                    }
                }

                // Añadir los nuevos seleccionados
                foreach (var item in checkedItems)
                {
                    if (!currentPreviewIds.Contains(item.eID))
                    {
                        var pItem = new RenamePreviewItem(item.eID, item.Nombre);
                        pItem.PropertyChanged += PreviewItem_PropertyChanged;
                        RenamePreviewItems.Add(pItem);
                    }
                }
            }

            // Recalcular SelectAllRenameItems
            _isUpdatingSelectAll = true;
            try
            {
                SelectAllRenameItems = RenamePreviewItems.All(x => x.IsSelected);
            }
            finally
            {
                _isUpdatingSelectAll = false;
            }

            UpdateRenamePreviews();
        }
    }

    // PowerRename Properties and Commands
    [ObservableProperty]
    private bool _isRenamePanelOpen;

    [ObservableProperty]
    private string _renameSearchText = string.Empty;

    [ObservableProperty]
    private string _renameReplaceText = string.Empty;

    [ObservableProperty]
    private bool _renameUseRegex;

    [ObservableProperty]
    private bool _renameMatchCase;

    [ObservableProperty]
    private bool _renameMatchAllOccurrences = true;

    [ObservableProperty]
    private bool _renameEnumerateItems;

    [ObservableProperty]
    private bool _renameRandomizeItems;

    [ObservableProperty]
    private bool _isFormatLowercase;

    [ObservableProperty]
    private bool _isFormatUppercase;

    [ObservableProperty]
    private bool _isFormatTitleCase;

    [ObservableProperty]
    private bool _isFormatCapitalizeEach;

    [ObservableProperty]
    private bool _renameApplyAll = true;

    [ObservableProperty]
    private bool _renameApplyOnlyFiltered;

    // Active Numbering Sequence Settings
    [ObservableProperty]
    private bool _numTypeNumeric = true;

    [ObservableProperty]
    private bool _numTypeAlphanumeric;

    [ObservableProperty]
    private bool _numOrderAscending = true;

    [ObservableProperty]
    private bool _numOrderDescending;

    [ObservableProperty]
    private string _numMinDigits = "3";

    [ObservableProperty]
    private string _numStartNumber = "1";

    [ObservableProperty]
    private string _numStartLetter = "A";

    [ObservableProperty]
    private string _numPrefix = "-";

    [ObservableProperty]
    private string _numSuffix = string.Empty;

    [ObservableProperty]
    private bool _numLocationBeginning;

    [ObservableProperty]
    private bool _numLocationEnd = true;

    [ObservableProperty]
    private string _numCustomSequence = string.Empty;

    // Editing Numbering Sequence Settings
    [ObservableProperty]
    private bool _editNumTypeNumeric;

    [ObservableProperty]
    private bool _editNumTypeAlphanumeric;

    [ObservableProperty]
    private bool _editNumOrderAscending;

    [ObservableProperty]
    private bool _editNumOrderDescending;

    [ObservableProperty]
    private string _editNumMinDigits = string.Empty;

    [ObservableProperty]
    private string _editNumStartNumber = string.Empty;

    [ObservableProperty]
    private string _editNumStartLetter = string.Empty;

    [ObservableProperty]
    private string _editNumPrefix = string.Empty;

    [ObservableProperty]
    private string _editNumSuffix = string.Empty;

    [ObservableProperty]
    private bool _editNumLocationBeginning;

    [ObservableProperty]
    private bool _editNumLocationEnd;

    [ObservableProperty]
    private string _editNumCustomSequence = string.Empty;

    [ObservableProperty]
    private bool _selectAllRenameItems = true;

    private bool _isUpdatingSelectAll;

    partial void OnSelectAllRenameItemsChanged(bool value)
    {
        if (_isUpdatingSelectAll) return;
        _isUpdatingSelectAll = true;
        try
        {
            foreach (var item in RenamePreviewItems)
            {
                item.IsSelected = value;
            }
        }
        finally
        {
            _isUpdatingSelectAll = false;
        }
        UpdateRenamePreviews();
    }

    private void PreviewItem_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(RenamePreviewItem.IsSelected))
        {
            if (_isUpdatingSelectAll) return;
            _isUpdatingSelectAll = true;
            try
            {
                SelectAllRenameItems = RenamePreviewItems.All(x => x.IsSelected);
            }
            finally
            {
                _isUpdatingSelectAll = false;
            }
            UpdateRenamePreviews();
        }
    }

    public ObservableCollection<RenamePreviewItem> RenamePreviewItems { get; } = new();

    private bool _isReplaceEmptyAllowed;

    partial void OnRenameSearchTextChanged(string value) => UpdateRenamePreviews();
    partial void OnRenameReplaceTextChanged(string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            _isReplaceEmptyAllowed = false;
        }
        ApplyRenameReplaceCommand.NotifyCanExecuteChanged();
        UpdateRenamePreviews();
    }

    private bool CanApplyRenameReplace() => !string.IsNullOrWhiteSpace(RenameReplaceText) || _isReplaceEmptyAllowed;

    [RelayCommand(CanExecute = nameof(CanApplyRenameReplace))]
    private void ApplyRenameReplace()
    {
        foreach (var item in RenamePreviewItems)
        {
            if (item.IsSelected)
            {
                item.WorkingName = item.NewName;
            }
        }

        _isReplaceEmptyAllowed = false;
        RenameSearchText = string.Empty;
        RenameReplaceText = string.Empty;
        ApplyRenameReplaceCommand.NotifyCanExecuteChanged();
        UpdateRenamePreviews();
    }

    partial void OnRenameUseRegexChanged(bool value) => UpdateRenamePreviews();
    partial void OnRenameMatchCaseChanged(bool value) => UpdateRenamePreviews();
    partial void OnRenameMatchAllOccurrencesChanged(bool value) => UpdateRenamePreviews();
    partial void OnRenameEnumerateItemsChanged(bool value) => UpdateRenamePreviews();
    partial void OnRenameRandomizeItemsChanged(bool value) => UpdateRenamePreviews();
    partial void OnRenameApplyAllChanged(bool value) => UpdateRenamePreviews();
    partial void OnRenameApplyOnlyFilteredChanged(bool value) => UpdateRenamePreviews();

    partial void OnIsFormatLowercaseChanged(bool value)
    {
        if (value) { IsFormatUppercase = false; IsFormatTitleCase = false; IsFormatCapitalizeEach = false; }
        UpdateRenamePreviews();
    }
    partial void OnIsFormatUppercaseChanged(bool value)
    {
        if (value) { IsFormatLowercase = false; IsFormatTitleCase = false; IsFormatCapitalizeEach = false; }
        UpdateRenamePreviews();
    }
    partial void OnIsFormatTitleCaseChanged(bool value)
    {
        if (value) { IsFormatLowercase = false; IsFormatUppercase = false; IsFormatCapitalizeEach = false; }
        UpdateRenamePreviews();
    }
    partial void OnIsFormatCapitalizeEachChanged(bool value)
    {
        if (value) { IsFormatLowercase = false; IsFormatUppercase = false; IsFormatTitleCase = false; }
        UpdateRenamePreviews();
    }

    [RelayCommand(CanExecute = nameof(HasCheckedElements))]
    private void OpenRenamePanel()
    {
        if (SelectedSourceDocument == null) return;

        RenamePreviewItems.Clear();

        if (IsFamiliesManagerActive)
        {
            var checkedFamilies = new List<FamilyItemModel>();
            CollectCheckedFamilies(RootNodes, checkedFamilies);

            if (!checkedFamilies.Any())
            {
                TaskDialog.Show("TransferPlus", "No elements checked for renaming.");
                return;
            }

            foreach (var item in checkedFamilies)
            {
                var famItem = new RenamePreviewItem("FAM:" + item.Name, item.Name, isType: false, parentFamilyName: item.Name);
                famItem.PropertyChanged += PreviewItem_PropertyChanged;
                RenamePreviewItems.Add(famItem);

                if (item.Symbols != null)
                {
                    foreach (var sym in item.Symbols)
                    {
                        var symItem = new RenamePreviewItem("SYM:" + item.Name + "::" + sym.Name, sym.Name, isType: true, parentFamilyName: item.Name);
                        symItem.PropertyChanged += PreviewItem_PropertyChanged;
                        RenamePreviewItems.Add(symItem);
                    }
                }
            }
        }
        else
        {
            var checkedItems = new List<Elemento>();
            CollectCheckedItems(RootNodes, checkedItems);

            if (!checkedItems.Any())
            {
                TaskDialog.Show("TransferPlus", "No elements checked for renaming.");
                return;
            }

            foreach (var item in checkedItems)
            {
                var pItem = new RenamePreviewItem(item.eID, item.Nombre);
                pItem.PropertyChanged += PreviewItem_PropertyChanged;
                RenamePreviewItems.Add(pItem);
            }
        }
        
        SelectAllRenameItems = true;
        IsRenamePanelOpen = true;
        UpdateRenamePreviews();
    }

    [RelayCommand]
    private void CloseRenamePanel()
    {
        _isReplaceEmptyAllowed = false;
        IsRenamePanelOpen = false;
        RenameSearchText = string.Empty;
        RenameReplaceText = string.Empty;
        RenamePreviewItems.Clear();
    }

    [ObservableProperty]
    private bool _isFamiliesManagerActive;

    private bool CanActivateFamiliesManager() => !IsFamiliesManagerActive;
    private bool CanDeactivateFamiliesManager() => IsFamiliesManagerActive;

    [RelayCommand(CanExecute = nameof(CanActivateFamiliesManager))]
    private void ActivateFamiliesManager()
    {
        if (IsCadDetailsManagerActive)
        {
            IsCadDetailsManagerActive = false;
        }
        IsFamiliesManagerActive = true;
    }

    [RelayCommand(CanExecute = nameof(CanDeactivateFamiliesManager))]
    private void DeactivateFamiliesManager()
    {
        IsFamiliesManagerActive = false;
    }

    partial void OnIsFamiliesManagerActiveChanged(bool value)
    {
        ActivateFamiliesManagerCommand.NotifyCanExecuteChanged();
        DeactivateFamiliesManagerCommand.NotifyCanExecuteChanged();
        ActivateCadDetailsManagerCommand.NotifyCanExecuteChanged();
        DeactivateCadDetailsManagerCommand.NotifyCanExecuteChanged();
        LoadDocuments();
    }

    [ObservableProperty]
    private bool _isCadDetailsManagerActive;

    private bool CanActivateCadDetailsManager() => !IsCadDetailsManagerActive;
    private bool CanDeactivateCadDetailsManager() => IsCadDetailsManagerActive;

    [RelayCommand(CanExecute = nameof(CanActivateCadDetailsManager))]
    private void ActivateCadDetailsManager()
    {
        if (IsFamiliesManagerActive)
        {
            IsFamiliesManagerActive = false;
        }
        IsCadDetailsManagerActive = true;
    }

    [RelayCommand(CanExecute = nameof(CanDeactivateCadDetailsManager))]
    private void DeactivateCadDetailsManager()
    {
        IsCadDetailsManagerActive = false;
    }

    partial void OnIsCadDetailsManagerActiveChanged(bool value)
    {
        ActivateCadDetailsManagerCommand.NotifyCanExecuteChanged();
        DeactivateCadDetailsManagerCommand.NotifyCanExecuteChanged();
        ActivateFamiliesManagerCommand.NotifyCanExecuteChanged();
        DeactivateFamiliesManagerCommand.NotifyCanExecuteChanged();
        LoadDocuments();
    }

    [RelayCommand]
    private void OpenSourcesWindow()
    {
        try
        {
            var vm = new FamilySourcesViewModel();
            var view = new Views.FamilySourcesWindow { DataContext = vm };
            if (view.ShowDialog() == true)
            {
                LoadDocuments();
                TransferPlus.Services.LoggerService.LogInfo("OpenSourcesWindow: Configuración de fuentes guardada. Desplegable 'Apply transfer from' actualizado.");
            }
        }
        catch (Exception ex)
        {
            TransferPlus.Services.LoggerService.LogError("OpenSourcesWindow", ex);
        }
    }

    [RelayCommand]
    private void InsertRegexHelper(string snippet)
    {
        RenameSearchText += snippet;
        RenameUseRegex = true;
    }

    [RelayCommand]
    private void InsertFilterRegexHelper(string snippet)
    {
        SearchFilter = (SearchFilter ?? string.Empty) + snippet;
        FilterUseRegex = true;
    }

    [RelayCommand]
    private void InsertEmptyReplaceHelper()
    {
        _isReplaceEmptyAllowed = true;
        RenameReplaceText = string.Empty;
        ApplyRenameReplaceCommand.NotifyCanExecuteChanged();
        UpdateRenamePreviews();
    }

    [RelayCommand]
    private void InsertDateHelper(string snippet)
    {
        RenameReplaceText += snippet;

        if (snippet.Contains("$1"))
        {
            if (string.IsNullOrEmpty(RenameSearchText) || !RenameSearchText.Contains("(.*)"))
            {
                RenameSearchText = "(.*)";
            }
            RenameUseRegex = true;
        }
    }

    private void UpdateRenamePreviews()
    {
        if (string.IsNullOrEmpty(RenameSearchText))
        {
            foreach (var item in RenamePreviewItems)
            {
                item.IsMatchingFilter = false;
                item.NewName = item.WorkingName;
            }
        }

        RegexOptions options = RenameMatchCase ? RegexOptions.None : RegexOptions.IgnoreCase;
        Regex? regex = null;

        if (RenameUseRegex && !string.IsNullOrEmpty(RenameSearchText))
        {
            try
            {
                regex = new Regex(RenameSearchText, options, TimeSpan.FromMilliseconds(500));
            }
            catch
            {
                // Incomplete regex, do not apply changes yet
                return;
            }
        }

        int selectedItemIndex = 0;
        foreach (var item in RenamePreviewItems)
        {
            // First, calculate if it matches the Find text (strictly against OriginalName)
            bool isMatch = false;
            if (!string.IsNullOrEmpty(RenameSearchText))
            {
                if (RenameUseRegex && regex != null)
                {
                    try
                    {
                        isMatch = regex.IsMatch(item.OriginalName);
                    }
                    catch { }
                }
                else
                {
                    string literalPattern = Regex.Escape(RenameSearchText);
                    var re = new Regex(literalPattern, options, TimeSpan.FromMilliseconds(500));
                    isMatch = re.IsMatch(item.OriginalName);
                }
            }
            item.IsMatchingFilter = isMatch;

            // If the item is unchecked, revert to its last applied WorkingName
            if (!item.IsSelected)
            {
                item.NewName = item.WorkingName;
                continue;
            }

            // Determine if we should apply formatting to this item
            bool shouldFormat = RenameApplyAll || (RenameApplyOnlyFiltered && isMatch);

            // Evaluate the replacement template per selected item index
            string evaluatedReplaceText = EvaluateReplacementTemplate(RenameReplaceText, selectedItemIndex);

            string newName = item.WorkingName;
            if (isMatch)
            {
                if (RenameUseRegex && regex != null)
                {
                    try
                    {
                        newName = RenameMatchAllOccurrences ? regex.Replace(item.WorkingName, evaluatedReplaceText) : regex.Replace(item.WorkingName, evaluatedReplaceText, 1);
                    }
                    catch { }
                }
                else
                {
                    string literalPattern = Regex.Escape(RenameSearchText);
                    var re = new Regex(literalPattern, options, TimeSpan.FromMilliseconds(500));
                    newName = RenameMatchAllOccurrences ? re.Replace(item.WorkingName, evaluatedReplaceText) : re.Replace(item.WorkingName, evaluatedReplaceText, 1);
                }
            }

            // Apply casing only if shouldFormat is true
            if (shouldFormat)
            {
                if (IsFormatLowercase) newName = newName.ToLower();
                else if (IsFormatUppercase) newName = newName.ToUpper();
                else if (IsFormatTitleCase && newName.Length > 0) newName = char.ToUpper(newName[0]) + newName.Substring(1).ToLower();
                else if (IsFormatCapitalizeEach) newName = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(newName.ToLower());
            }

            item.NewName = newName;
            selectedItemIndex++;
        }

        // Collect items that will actually be formatted
        var itemsToFormat = new List<RenamePreviewItem>();
        foreach (var item in RenamePreviewItems)
        {
            if (item.IsSelected)
            {
                bool shouldFormat = RenameApplyAll || (RenameApplyOnlyFiltered && item.IsMatchingFilter);
                if (shouldFormat)
                {
                    itemsToFormat.Add(item);
                }
            }
        }
        int N = itemsToFormat.Count;

        // Apply enumeration and randomizing
        if (RenameEnumerateItems && N > 0)
        {
            var customVals = new List<string>();
            if (!string.IsNullOrWhiteSpace(NumCustomSequence))
            {
                customVals = NumCustomSequence.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                             .Select(s => s.Trim())
                                             .ToList();
            }

            bool useCustom = customVals.Any();

            if (useCustom)
            {
                for (int i = 0; i < N; i++)
                {
                    string baseVal = customVals[i % customVals.Count];
                    string seqString = (NumPrefix ?? string.Empty) + baseVal + (NumSuffix ?? string.Empty);
                    
                    if (NumLocationBeginning)
                        itemsToFormat[i].NewName = seqString + itemsToFormat[i].NewName;
                    else
                        itemsToFormat[i].NewName += seqString;
                }
            }
            else
            {
                int.TryParse(NumMinDigits, out int minDigits);
                if (minDigits <= 0) minDigits = 1;

                if (NumTypeNumeric)
                {
                    bool hasStartNum = !string.IsNullOrWhiteSpace(NumStartNumber);
                    int startVal = 1;
                    if (hasStartNum && int.TryParse(NumStartNumber, out int parsed))
                        startVal = parsed;
                    if (startVal < 0) startVal = 1;

                    for (int i = 0; i < N; i++)
                    {
                        int currentVal;
                        if (NumOrderAscending)
                        {
                            currentVal = startVal + i;
                        }
                        else
                        {
                            if (hasStartNum)
                                currentVal = startVal - i;
                            else
                                currentVal = N - i;
                        }

                        if (currentVal < 0) currentVal = 0;

                        string baseVal = currentVal.ToString().PadLeft(minDigits, '0');
                        string seqString = (NumPrefix ?? string.Empty) + baseVal + (NumSuffix ?? string.Empty);
                        
                        if (NumLocationBeginning)
                            itemsToFormat[i].NewName = seqString + itemsToFormat[i].NewName;
                        else
                            itemsToFormat[i].NewName += seqString;
                    }
                }
                else // NumTypeAlphanumeric
                {
                    bool hasStartLetter = !string.IsNullOrWhiteSpace(NumStartLetter);
                    int startIndex = 0;

                    if (hasStartLetter)
                    {
                        string letter = NumStartLetter.Trim().ToUpperInvariant();
                        if (letter.Length < minDigits)
                        {
                            char padChar = NumOrderAscending ? 'A' : 'Z';
                            letter = letter.PadRight(minDigits, padChar);
                        }
                        startIndex = ParseFixedBase26(letter, minDigits);
                    }
                    else
                    {
                        startIndex = 0;
                    }

                    for (int i = 0; i < N; i++)
                    {
                        int currentIndex;
                        if (NumOrderAscending)
                        {
                            currentIndex = startIndex + i;
                        }
                        else
                        {
                            if (hasStartLetter)
                                currentIndex = startIndex - i;
                            else
                                currentIndex = (N - 1) - i;
                        }
                        
                        string baseVal = IndexToFixedBase26(currentIndex, minDigits);
                        string seqString = (NumPrefix ?? string.Empty) + baseVal + (NumSuffix ?? string.Empty);
                        
                        if (NumLocationBeginning)
                            itemsToFormat[i].NewName = seqString + itemsToFormat[i].NewName;
                        else
                            itemsToFormat[i].NewName += seqString;
                    }
                }
            }
        }

        if (RenameRandomizeItems && N > 0)
        {
            var rnd = new Random();
            int.TryParse(NumMinDigits, out int minDigits);
            if (minDigits <= 0) minDigits = 1;

            for (int i = 0; i < N; i++)
            {
                string baseVal = NumTypeNumeric ? GenerateRandomNumeric(minDigits, rnd) : GenerateRandomAlphanumeric(minDigits, rnd);
                string seqString = (NumPrefix ?? string.Empty) + baseVal + (NumSuffix ?? string.Empty);
                
                if (NumLocationBeginning)
                    itemsToFormat[i].NewName = seqString + itemsToFormat[i].NewName;
                else
                    itemsToFormat[i].NewName += seqString;
            }
        }
    }

    private int ParseFixedBase26(string letter, int length)
    {
        if (string.IsNullOrWhiteSpace(letter)) return 0;
        string clean = letter.Trim().ToUpperInvariant();
        int val = 0;
        foreach (char c in clean)
        {
            if (c >= 'A' && c <= 'Z')
            {
                val = val * 26 + (c - 'A');
            }
        }
        return val;
    }

    private string IndexToFixedBase26(int value, int length)
    {
        if (length <= 0) length = 1;
        long baseVal = 1;
        for (int i = 0; i < length; i++) baseVal *= 26;
        
        long longVal = value;
        if (longVal < 0)
        {
            longVal = baseVal + (longVal % baseVal);
        }
        longVal = longVal % baseVal;

        char[] chars = new char[length];
        for (int i = length - 1; i >= 0; i--)
        {
            int digit = (int)(longVal % 26);
            chars[i] = (char)('A' + digit);
            longVal /= 26;
        }
        return new string(chars);
    }

    private string GenerateRandomNumeric(int length, Random rnd)
    {
        if (length <= 0) length = 1;
        char[] chars = new char[length];
        for (int i = 0; i < length; i++)
        {
            chars[i] = (char)('0' + rnd.Next(0, 10));
        }
        return new string(chars);
    }

    private string GenerateRandomAlphanumeric(int length, Random rnd)
    {
        if (length <= 0) length = 1;
        char[] chars = new char[length];
        for (int i = 0; i < length; i++)
        {
            chars[i] = (char)('A' + rnd.Next(0, 26));
        }
        return new string(chars);
    }

    private string EvaluateReplacementTemplate(string template, int itemIndex)
    {
        if (string.IsNullOrEmpty(template)) return template;

        string result = template;
        DateTime now = DateTime.Now;

        // 1. Evaluate Date/Time
        // Replace in order from longest token to shortest to avoid nested replacement issues
        var dateReplacements = new (string Token, string Format)[]
        {
            ("$YYYY", "yyyy"), ("$MMMM", "MMMM"), ("$DDDD", "dddd"),
            ("$MMM", "MMM"), ("$DDD", "ddd"), ("$fff", "fff"),
            ("$YY", "yy"), ("$MM", "MM"), ("$DD", "dd"),
            ("$HH", "HH"), ("$hh", "hh"), ("$mm", "mm"), ("$ss", "ss"),
            ("$ff", "ff"), ("$TT", "tt"), ("$tt", "tt"),
            ("$Y", "y"), ("$M", "M"), ("$D", "d"),
            ("$H", "H"), ("$h", "h"), ("$m", "m"), ("$s", "s"),
            ("$f", "f")
        };

        foreach (var pair in dateReplacements)
        {
            if (result.Contains(pair.Token))
            {
                result = result.Replace(pair.Token, now.ToString(pair.Format));
            }
        }

        // 2. Evaluate Counters and Random variables: ${...}
        var counterRegex = new Regex(@"\$\{(.*?)\}");
        result = counterRegex.Replace(result, match =>
        {
            string content = match.Groups[1].Value.Trim();
            
            // Check for UUID or Random strings
            if (content.Equals("ruuidv4", StringComparison.OrdinalIgnoreCase))
            {
                return Guid.NewGuid().ToString();
            }
            else if (content.StartsWith("rstringalpha=", StringComparison.OrdinalIgnoreCase))
            {
                if (int.TryParse(content.Substring("rstringalpha=".Length), out int len))
                    return GenerateRandomString(len, true, false);
                return match.Value;
            }
            else if (content.StartsWith("rstringalphanum=", StringComparison.OrdinalIgnoreCase))
            {
                if (int.TryParse(content.Substring("rstringalphanum=".Length), out int len))
                    return GenerateRandomString(len, true, true);
                return match.Value;
            }
            else if (content.StartsWith("rstringdigit=", StringComparison.OrdinalIgnoreCase))
            {
                if (int.TryParse(content.Substring("rstringdigit=".Length), out int len))
                    return GenerateRandomString(len, false, true);
                return match.Value;
            }

            // Default to counter parsing
            int start = 1;
            int increment = 1;
            int padding = 0;

            if (!string.IsNullOrEmpty(content))
            {
                var parts = content.Split(',');
                foreach (var part in parts)
                {
                    var kvp = part.Split('=');
                    if (kvp.Length == 2)
                    {
                        string key = kvp[0].Trim().ToLower();
                        string valStr = kvp[1].Trim();
                        if (int.TryParse(valStr, out int val))
                        {
                            if (key == "start") start = val;
                            else if (key == "increment") increment = val;
                            else if (key == "padding") padding = Math.Min(Math.Max(0, val), 100);
                        }
                    }
                }
            }

            int currentValue = start + itemIndex * increment;
            return currentValue.ToString().PadLeft(padding, '0');
        });

        return result;
    }

    private string GenerateRandomString(int length, bool includeLetters, bool includeDigits)
    {
        length = Math.Min(Math.Max(0, length), 100); // Clamp to prevent OutOfMemoryException
        const string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string digits = "0123456789";
        string pool = "";
        if (includeLetters) pool += letters;
        if (includeDigits) pool += digits;

        if (string.IsNullOrEmpty(pool)) return "";

        var rnd = new Random();
        var chars = new char[length];
        for (int i = 0; i < length; i++)
        {
            chars[i] = pool[rnd.Next(pool.Length)];
        }
        return new string(chars);
    }

    [RelayCommand]
    private void DeleteElements()
    {
        if (SelectedSourceDocument == null) return;

        var checkedItems = new List<Elemento>();
        CollectCheckedItems(RootNodes, checkedItems);

        if (!checkedItems.Any())
        {
            TaskDialog.Show("TransferPlus", "No elements checked for deletion.");
            return;
        }

        Document document = SelectedSourceDocument.Adoc;
        if (document.IsLinked)
        {
            TaskDialog.Show("TransferPlus", "Cannot delete elements from a linked document.");
            return;
        }

        var result = TaskDialog.Show("TransferPlus", $"Are you sure you want to delete {checkedItems.Count} elements from the source document?", TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No);
        if (result != TaskDialogResult.Yes) return;

        int deletedCount = 0;

        using (Transaction transaction = new Transaction(document, "TransferPlus: Delete Elements"))
        {
            transaction.Start();
            WarningSwallower.AttachToTransaction(transaction);

            foreach (var item in checkedItems)
            {
                try
                {
                    document.Delete(item.eID);
                    deletedCount++;
                }
                catch { }
            }
            transaction.Commit();
        }

        TaskDialog.Show("TransferPlus", $"Deleted {deletedCount} elements.");
        LoadSourceItems(document);
    }

    [RelayCommand]
    private void OpenConfiguration()
    {
        var existingConfig = System.Windows.Application.Current?.Windows?.OfType<Views.ConfigurationView>()?.FirstOrDefault();
        if (existingConfig != null)
        {
            existingConfig.Activate();
            return;
        }

        var mainView = System.Windows.Application.Current?.Windows?.OfType<Views.TransferPlusView>()?.FirstOrDefault();
        var configView = new Views.ConfigurationView();
        if (mainView != null)
        {
            configView.Owner = mainView;
        }
        configView.Topmost = true;
        configView.Show();
    }

    [RelayCommand]
    private void OpenNumberingSettings()
    {
        try
        {
            TransferPlus.Services.LoggerService.LogInfo("OpenNumberingSettings: Initializing configurations copy...");
            // Copy active to editing
            EditNumTypeNumeric = NumTypeNumeric;
            EditNumTypeAlphanumeric = NumTypeAlphanumeric;
            EditNumOrderAscending = NumOrderAscending;
            EditNumOrderDescending = NumOrderDescending;
            EditNumMinDigits = NumMinDigits;
            EditNumStartNumber = NumStartNumber;
            EditNumStartLetter = NumStartLetter;
            EditNumPrefix = NumPrefix;
            EditNumSuffix = NumSuffix;
            EditNumLocationBeginning = NumLocationBeginning;
            EditNumLocationEnd = NumLocationEnd;
            EditNumCustomSequence = NumCustomSequence;

            TransferPlus.Services.LoggerService.LogInfo("OpenNumberingSettings: Instantiating NumberingSettingsView...");
            // Open Dialog
            var view = new NumberingSettingsView(this);
            TransferPlus.Services.LoggerService.LogInfo("OpenNumberingSettings: Showing NumberingSettingsView Dialog...");
            bool? result = view.ShowDialog();
            TransferPlus.Services.LoggerService.LogInfo($"OpenNumberingSettings: DialogResult is {result}");
            if (result == true)
            {
                // Copy editing back to active
                NumTypeNumeric = EditNumTypeNumeric;
                NumTypeAlphanumeric = EditNumTypeAlphanumeric;
                NumOrderAscending = EditNumOrderAscending;
                NumOrderDescending = EditNumOrderDescending;
                NumMinDigits = EditNumMinDigits;
                NumStartNumber = EditNumStartNumber;
                NumStartLetter = EditNumStartLetter;
                NumPrefix = EditNumPrefix;
                NumSuffix = EditNumSuffix;
                NumLocationBeginning = EditNumLocationBeginning;
                NumLocationEnd = EditNumLocationEnd;
                NumCustomSequence = EditNumCustomSequence;

                TransferPlus.Services.LoggerService.LogInfo("OpenNumberingSettings: Committing edit changes and updating previews...");
                UpdateRenamePreviews();
            }
        }
        catch (Exception ex)
        {
            TransferPlus.Services.LoggerService.LogError("OpenNumberingSettings", ex);
        }
    }

    private List<LevelConflict> DetectMissingLevels(Document sourceDoc, List<Elemento> checkedItems, Document targetDoc)
    {
        var missingConflicts = new List<LevelConflict>();
        var checkedViews = checkedItems.Where(i => i.IsView).ToList();
        if (!checkedViews.Any()) return missingConflicts;

        var targetLevels = new FilteredElementCollector(targetDoc)
            .OfClass(typeof(Level))
            .Cast<Level>()
            .ToList();

        var targetLevelNames = targetLevels.Select(l => l.Name).ToList();

        // Find all levels required by the checked plan views or plan views placed on checked sheets
        var neededSourceLevels = new Dictionary<string, Level>();
        foreach (var item in checkedItems)
        {
            Element elem = sourceDoc.GetElement(item.eID);
            if (elem is ViewPlan viewPlan && viewPlan.GenLevel != null)
            {
                var srcLevel = viewPlan.GenLevel;
                if (!neededSourceLevels.ContainsKey(srcLevel.Name))
                {
                    neededSourceLevels[srcLevel.Name] = srcLevel;
                }
            }
            else if (elem is ViewSheet viewSheet)
            {
                foreach (ElementId pvId in viewSheet.GetAllPlacedViews())
                {
                    if (sourceDoc.GetElement(pvId) is ViewPlan sheetViewPlan && sheetViewPlan.GenLevel != null)
                    {
                        var srcLevel = sheetViewPlan.GenLevel;
                        if (!neededSourceLevels.ContainsKey(srcLevel.Name))
                        {
                            neededSourceLevels[srcLevel.Name] = srcLevel;
                        }
                    }
                }
            }
        }

        foreach (var kvp in neededSourceLevels)
        {
            var srcLevel = kvp.Value;
            if (!targetLevelNames.Contains(srcLevel.Name, StringComparer.OrdinalIgnoreCase))
            {
                // Conflict found!
                double elev = srcLevel.ProjectElevation; // in feet
                // Convert elevation to formatted string
                string elevText;
                try
                {
                    double meters = elev * 0.3048;
                    elevText = $"{meters:N3} m";
                }
                catch
                {
                    elevText = $"{elev:N3} ft";
                }

                // Find exact match, closest lower, closest upper
                string? exactMatch = null;
                string? closestLower = null;
                string? closestUpper = null;
                double lowerDiff = double.MaxValue;
                double upperDiff = double.MaxValue;

                foreach (var tl in targetLevels)
                {
                    double diff = tl.ProjectElevation - srcLevel.ProjectElevation;
                    if (Math.Abs(diff) < 0.001)
                    {
                        exactMatch = tl.Name;
                    }
                    else if (diff < 0)
                     {
                         double absDiff = Math.Abs(diff);
                         if (absDiff < lowerDiff)
                         {
                             lowerDiff = absDiff;
                             closestLower = tl.Name;
                         }
                     }
                     else if (diff > 0)
                     {
                         if (diff < upperDiff)
                         {
                             upperDiff = diff;
                             closestUpper = tl.Name;
                         }
                     }
                }

                var conflict = new LevelConflict
                {
                    SourceLevelName = srcLevel.Name,
                    SourceElevation = srcLevel.ProjectElevation,
                    SourceElevationText = elevText,
                    AvailableTargetLevels = targetLevelNames,
                    ExactMatchLevelName = exactMatch,
                    ClosestLowerLevelName = closestLower,
                    ClosestUpperLevelName = closestUpper,
                    SelectedTargetLevelName = exactMatch ?? closestLower ?? closestUpper ?? targetLevelNames.FirstOrDefault()
                };

                missingConflicts.Add(conflict);
            }
        }

        return missingConflicts;
    }

    private static string? PromptFolderBrowserDialog(string description)
    {
        string? selectedFolder = null;
        var folderBrowserType = Type.GetType("System.Windows.Forms.FolderBrowserDialog, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")
            ?? Type.GetType("System.Windows.Forms.FolderBrowserDialog, System.Windows.Forms");

        if (folderBrowserType != null)
        {
            var instance = Activator.CreateInstance(folderBrowserType);
            if (instance != null)
            {
                folderBrowserType.GetProperty("Description")?.SetValue(instance, description);
                var showDialogMethod = folderBrowserType.GetMethod("ShowDialog", Type.EmptyTypes);
                var result = showDialogMethod?.Invoke(instance, null);
                if (result?.ToString() == "OK" || result?.ToString() == "1")
                {
                    selectedFolder = folderBrowserType.GetProperty("SelectedPath")?.GetValue(instance) as string;
                }
            }
        }
        return selectedFolder;
    }

    private void SetRevitStatusBarText(string text)
    {
        try
        {
            var componentManagerType = Type.GetType("Autodesk.Windows.ComponentManager, AdWindows");
            if (componentManagerType != null)
            {
                var prop = componentManagerType.GetProperty("StatusBarText", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                prop?.SetValue(null, text);
            }
        }
        catch
        {
            // Ignore if StatusBarText is unsupported in current API context
        }
    }

    [RelayCommand]
    private async Task DownloadSelectedFamiliesAsync()
    {
        if (SelectedSourceDocument == null)
        {
            TaskDialog.Show("TransferPlus", "No source document selected.");
            return;
        }

        // 1. Obtener carpetas/familias marcadas en el TreeView de familias
        var familiesToDownload = new List<(FamilyItemModel family, List<string> activeSymbols)>();

        var familyNodes = GetAllDescendantNodes(RootNodes)
            .Where(n => n.Category == "Family" || n.Item is FamilyItemModel);

        foreach (var familyNode in familyNodes)
        {
            if (familyNode.IsChecked == true || familyNode.IsChecked == null)
            {
                var activeSymbols = familyNode.Children
                    .Where(c => c.IsChecked == true || c.IsChecked == null)
                    .Select(c => c.Name)
                    .ToList();

                var familyModel = familyNode.Item as FamilyItemModel
                    ?? _familyItems.FirstOrDefault(f => f.Name.Equals(familyNode.Name, StringComparison.OrdinalIgnoreCase));

                if (familyModel != null)
                {
                    if (!activeSymbols.Any() && familyModel.Symbols != null)
                    {
                        activeSymbols = familyModel.Symbols.Select(s => s.Name).ToList();
                    }

                    if (activeSymbols.Any())
                    {
                        familiesToDownload.Add((familyModel, activeSymbols));
                    }
                }
            }
        }

        // Si no se han marcado tipos en el árbol pero hay una familia seleccionada en el panel de detalles, se procesa la seleccionada
        if (!familiesToDownload.Any() && SelectedFamily != null)
        {
            var activeSymbols = SelectedFamilySymbols
                .Where(s => s.IsActive)
                .Select(s => s.Name)
                .ToList();

            if (!activeSymbols.Any())
            {
                activeSymbols = SelectedFamilySymbols.Select(s => s.Name).ToList();
            }

            familiesToDownload.Add((SelectedFamily, activeSymbols));
        }

        if (!familiesToDownload.Any())
        {
            TaskDialog.Show("TransferPlus", "Please select at least one family and type to download.");
            return;
        }

        // 2. Diálogo de selección de carpeta de Windows para los archivos .rfa
        string? selectedFolder = PromptFolderBrowserDialog("Select destination folder to download family (.rfa) files");

        if (string.IsNullOrWhiteSpace(selectedFolder))
        {
            return;
        }

        IsBusy = true;
        StatusMessage = "Downloading families...";
        ProgressPercentage = 0;
        int total = familiesToDownload.Count;
        int countSuccess = 0;

        var logEntries = new List<ExportLogFamilyEntry>();
        bool shouldExportLog = ExportLogOnDownload && !string.IsNullOrWhiteSpace(ExportLogFolderPath);

        var familyRenameMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var symbolRenameMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        if (IsRenamePanelOpen || RenamePreviewItems.Any())
        {
            foreach (var pItem in RenamePreviewItems)
            {
                if (pItem.IsSelected && !string.IsNullOrWhiteSpace(pItem.NewName) && !pItem.NewName.Equals(pItem.OriginalName, StringComparison.OrdinalIgnoreCase))
                {
                    if (pItem.IsType)
                    {
                        symbolRenameMap[pItem.OriginalName] = pItem.NewName;
                    }
                    else
                    {
                        familyRenameMap[pItem.OriginalName] = pItem.NewName;
                    }
                }
            }
        }

        try
        {
            for (int i = 0; i < total; i++)
            {
                var (family, activeSymbols) = familiesToDownload[i];
                string overrideFamName = familyRenameMap.TryGetValue(family.Name, out var renamedFam) ? renamedFam : null;
                string currentStatusText = $"Downloading family '{overrideFamName ?? family.Name}' ({i + 1}/{total})...";
                StatusMessage = currentStatusText;
                ProgressPercentage = (int)((double)(i + 1) / total * 100);

                SetRevitStatusBarText($"TransferPlus: {currentStatusText}");

                System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke(
                    System.Windows.Threading.DispatcherPriority.Background,
                    new Action(() => { }));

                string targetFolderForFamily = selectedFolder;
                if (SaveInSubfoldersOnDownload)
                {
                    string catName = !string.IsNullOrWhiteSpace(family.CategoryName) ? family.CategoryName : "Uncategorized";
                    string safeCatFolder = SanitizeFolderName(catName);
                    targetFolderForFamily = System.IO.Path.Combine(selectedFolder, safeCatFolder);
                    if (!System.IO.Directory.Exists(targetFolderForFamily))
                    {
                        System.IO.Directory.CreateDirectory(targetFolderForFamily);
                    }
                }

                string errorMsg = string.Empty;
                bool ok = false;
                try
                {
                    ok = _familyRevitService.ExportSelectiveFamilyToFolder(
                        _app,
                        SelectedSourceDocument.Adoc,
                        family,
                        targetFolderForFamily,
                        activeSymbols,
                        overrideFamName,
                        symbolRenameMap.Any() ? symbolRenameMap : null,
                        SetDefaultView3DOnDownload);
                }
                catch (Exception ex)
                {
                    errorMsg = ex.Message;
                    ok = false;
                }

                if (ok) countSuccess++;

                if (shouldExportLog)
                {
                    var exportedSymbolDisplayList = activeSymbols
                        .Select(s => symbolRenameMap.TryGetValue(s, out var newSymName) ? newSymName : s)
                        .ToList();

                    logEntries.Add(new ExportLogFamilyEntry
                    {
                        FamilyName = overrideFamName ?? family.Name,
                        CategoryName = family.CategoryName,
                        RevitVersion = family.RevitVersion,
                        ExportedSymbols = exportedSymbolDisplayList,
                        IsSuccess = ok,
                        ErrorMessage = ok ? string.Empty : (string.IsNullOrWhiteSpace(errorMsg) ? "Export failed or family file unreadable." : errorMsg)
                    });
                }
            }

            string? createdLogPath = null;
            if (shouldExportLog && !string.IsNullOrWhiteSpace(ExportLogFolderPath))
            {
                createdLogPath = ExportLoggerService.SaveDownloadLog(
                    ExportLogFolderPath,
                    SelectedSourceDocument.Nombre,
                    logEntries);
            }

            StatusMessage = $"Downloaded {countSuccess} family(ies) to '{selectedFolder}'.";

            string resultMsg = $"Successfully downloaded {countSuccess} family file(s) to:\n{selectedFolder}";
            if (!string.IsNullOrWhiteSpace(createdLogPath))
            {
                resultMsg += $"\n\nDownload export log saved to:\n{createdLogPath}";
            }
            TaskDialog.Show("TransferPlus", resultMsg);
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("DownloadSelectedFamiliesAsync", ex);
            TaskDialog.Show("TransferPlus", $"Error downloading families: {ex.Message}");
        }
        finally
        {
            IsBusy = false;
            StatusMessage = "Ready";
            ProgressPercentage = 0;
            SetRevitStatusBarText("Ready");
        }
    }

    private bool CanDeleteSelectedFamilies()
    {
        if (!IsFamiliesManagerActive) return false;
        if (SelectedSourceDocument == null) return false;
        if (SelectedSourceDocument.Adoc == null) return false; // Local folders, Azure, Autodesk Docs have Adoc == null
        if (SelectedSourceDocument.EsVinculo) return false; // Linked models cannot be mutated
        if (SelectedSourceDocument.Adoc.IsReadOnly) return false;

        // Must have at least 1 checked family or type node in tree, OR a selected family/symbol
        var checkedFamilyNodes = GetAllDescendantNodes(RootNodes)
            .Where(n => (n.IsChecked == true || n.IsChecked == null) && (n.Category == "Family" || n.Item is FamilyItemModel));

        if (checkedFamilyNodes.Any()) return true;

        if (SelectedFamily != null) return true;

        return false;
    }

    [RelayCommand(CanExecute = nameof(CanDeleteSelectedFamilies))]
    private async Task DeleteSelectedFamiliesAsync()
    {
        if (SelectedSourceDocument == null || SelectedSourceDocument.Adoc == null || SelectedSourceDocument.EsVinculo)
        {
            return;
        }

        var doc = SelectedSourceDocument.Adoc;

        // Collect families and types to delete
        var familiesToDelete = new List<(FamilyItemModel familyModel, Family familyElem, bool deleteAllTypes, List<FamilySymbolItemModel> selectedSymbols)>();

        var familyNodes = GetAllDescendantNodes(RootNodes)
            .Where(n => n.Category == "Family" || n.Item is FamilyItemModel);

        foreach (var familyNode in familyNodes)
        {
            if (familyNode.IsChecked == true || familyNode.IsChecked == null)
            {
                var familyModel = familyNode.Item as FamilyItemModel
                    ?? _familyItems.FirstOrDefault(f => f.Name.Equals(familyNode.Name, StringComparison.OrdinalIgnoreCase));

                if (familyModel != null)
                {
                    // Find actual Revit Family element in active model
                    var revitFamily = new FilteredElementCollector(doc)
                        .OfClass(typeof(Family))
                        .Cast<Family>()
                        .FirstOrDefault(f => f.Name.Equals(familyModel.Name, StringComparison.OrdinalIgnoreCase));

                    if (revitFamily != null)
                    {
                        var checkedChildNodes = familyNode.Children.Where(c => c.IsChecked == true).Select(c => c.Name).ToHashSet();
                        bool allChildTypesChecked = familyNode.IsChecked == true || (familyNode.Children.Any() && familyNode.Children.All(c => c.IsChecked == true));

                        var selectedSymbolModels = (familyModel.Symbols ?? new List<FamilySymbolItemModel>())
                            .Where(s => checkedChildNodes.Contains(s.Name))
                            .ToList();

                        familiesToDelete.Add((familyModel, revitFamily, allChildTypesChecked, selectedSymbolModels));
                    }
                }
            }
        }

        // Fallback: If no tree checkboxes marked but a family/symbol is selected in details panel
        if (!familiesToDelete.Any() && SelectedFamily != null)
        {
            var revitFamily = new FilteredElementCollector(doc)
                .OfClass(typeof(Family))
                .Cast<Family>()
                .FirstOrDefault(f => f.Name.Equals(SelectedFamily.Name, StringComparison.OrdinalIgnoreCase));

            if (revitFamily != null)
            {
                var selectedSymbols = SelectedFamilySymbols.Where(s => s.IsActive).ToList();
                bool allTypesSelected = !selectedSymbols.Any() || selectedSymbols.Count == SelectedFamilySymbols.Count;
                familiesToDelete.Add((SelectedFamily, revitFamily, allTypesSelected, selectedSymbols));
            }
        }

        if (!familiesToDelete.Any())
        {
            TaskDialog.Show("TransferPlus", "No matching families or types found in the active model to delete.");
            return;
        }

        // Count total full families and individual types to delete
        int fullFamiliesCount = familiesToDelete.Count(f => f.deleteAllTypes);
        int partialTypesCount = familiesToDelete.Where(f => !f.deleteAllTypes).Sum(f => f.selectedSymbols.Count);

        string warningMessage = $"You are about to delete {fullFamiliesCount} family(ies) and {partialTypesCount} type(s) from the active model.\n\n" +
                                "Warning: Deleting families or types will also permanently remove any placed instances of these elements from the active document.\n\n" +
                                "Do you want to proceed with the deletion?";

        var confirmResult = System.Windows.MessageBox.Show(
            warningMessage,
            "Confirm Element Deletion",
            System.Windows.MessageBoxButton.YesNo,
            System.Windows.MessageBoxImage.Warning);

        if (confirmResult != System.Windows.MessageBoxResult.Yes)
        {
            return;
        }

        IsBusy = true;
        StatusMessage = "Deleting elements from active model...";

        int deletedFamiliesCount = 0;
        int deletedTypesCount = 0;

        try
        {
            using (var t = new Transaction(doc, "Delete Families and Types"))
            {
                t.Start();

                foreach (var (familyModel, revitFamily, deleteAllTypes, selectedSymbols) in familiesToDelete)
                {
                    if (deleteAllTypes)
                    {
                        // Delete entire Family
                        try
                        {
                            doc.Delete(revitFamily.Id);
                            deletedFamiliesCount++;
                        }
                        catch (Exception ex)
                        {
                            LoggerService.LogError($"Error deleting family '{revitFamily.Name}'", ex);
                        }
                    }
                    else
                    {
                        // Delete only specific FamilySymbol (types)
                        foreach (var symModel in selectedSymbols)
                        {
                            var symbolElem = new FilteredElementCollector(doc)
                                .OfClass(typeof(FamilySymbol))
                                .Cast<FamilySymbol>()
                                .FirstOrDefault(s => s.Family.Id == revitFamily.Id && s.Name.Equals(symModel.Name, StringComparison.OrdinalIgnoreCase));

                            if (symbolElem != null)
                            {
                                try
                                {
                                    doc.Delete(symbolElem.Id);
                                    deletedTypesCount++;
                                }
                                catch (Exception ex)
                                {
                                    LoggerService.LogError($"Error deleting type '{symModel.Name}' of family '{revitFamily.Name}'", ex);
                                }
                            }
                        }
                    }
                }

                t.Commit();
            }

            LoggerService.LogInfo($"[Delete] Deleted {deletedFamiliesCount} full family(ies) and {deletedTypesCount} type(s) from model '{SelectedSourceDocument.Nombre}'.");
            StatusMessage = $"Deleted {deletedFamiliesCount} family(ies) and {deletedTypesCount} type(s).";

            // Refresh tree to reflect deleted items in active model
            await LoadFamiliesFromSourceAsync(SelectedSourceDocument.Nombre);
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("DeleteSelectedFamiliesAsync", ex);
            TaskDialog.Show("TransferPlus", $"Error deleting elements: {ex.Message}");
        }
        finally
        {
            IsBusy = false;
            StatusMessage = "Ready";
        }
    }

    private static IEnumerable<TreeItemViewModel> GetAllDescendantNodes(IEnumerable<TreeItemViewModel> nodes)
    {
        foreach (var node in nodes)
        {
            yield return node;
            if (node.Children != null && node.Children.Any())
            {
                foreach (var child in GetAllDescendantNodes(node.Children))
                {
                    yield return child;
                }
            }
        }
    }

    private static string SanitizeFolderName(string folderName)
    {
        if (string.IsNullOrWhiteSpace(folderName)) return "Uncategorized";
        var invalidChars = System.IO.Path.GetInvalidFileNameChars()
            .Concat(System.IO.Path.GetInvalidPathChars())
            .Distinct();
        foreach (var c in invalidChars)
        {
            folderName = folderName.Replace(c.ToString(), "_");
        }
        return folderName.Trim();
    }
}