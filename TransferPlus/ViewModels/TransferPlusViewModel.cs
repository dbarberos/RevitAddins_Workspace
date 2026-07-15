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
    private bool _overrideDuplicates = true;

    [ObservableProperty]
    private bool _cancelDuplicates;

    [ObservableProperty]
    private bool _askDuplicates;

    [ObservableProperty]
    private bool _includeCallouts;

    [ObservableProperty]
    private bool _includeViewElements;

    [ObservableProperty]
    private bool _includeSheetsWithViews;

    // Sub-options for Sheets
    [ObservableProperty]
    private bool _useLegendIfExists = true;

    [ObservableProperty]
    private bool _useScheduleIfExists = true;

    [ObservableProperty]
    private bool _useAssemblyViewsIfExists = true;

    [ObservableProperty]
    private bool _copyLinks;

    [ObservableProperty]
    private bool _transformNone;

    [ObservableProperty]
    private bool _transformLink = true;

    [ObservableProperty]
    private bool _transformShared;

    [ObservableProperty]
    private bool _acceptAllWarnings = true;

    [ObservableProperty]
    private bool _forceLevelInLevelBaseViews;

    private List<Elemento> _allSourceItems = new();
    private Configuraciones _config = new();

    public TransferPlusViewModel(UIApplication app, Document targetDoc)
    {
        _app = app;
        _targetDoc = targetDoc;
        LoadDocuments();

        // Register to receive messages when elements check state changes
        WeakReferenceMessenger.Default.Register<CheckedItemsChangedMessage>(this, (r, m) => UpdateCheckedCount());
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
        SourceDocuments.Clear();
        DestinationDocuments.Clear();

        // Load all documents in the session, including links
        foreach (Document doc in _app.Application.Documents)
        {
            var arch = new Archivo(doc);
            if (doc.IsLinked)
            {
                arch.EsVinculo = true;
            }
            arch.Nombre = GetDocumentDisplayName(doc);
            SourceDocuments.Add(arch);
        }

        // Default selection to the active target document
        SelectedSourceDocument = SourceDocuments.FirstOrDefault(d => d.Adoc.PathName.Equals(_targetDoc.PathName, StringComparison.OrdinalIgnoreCase))
                                 ?? SourceDocuments.FirstOrDefault();

        OnPropertyChanged(nameof(CheckedDestinationsText));
    }

    partial void OnSelectedSourceDocumentChanged(Archivo? value)
    {
        if (value != null)
        {
            LoadSourceItems(value.Adoc);

            // Rebuild destination documents: all open non-linked documents except the selected source
            DestinationDocuments.Clear();
            foreach (Document doc in _app.Application.Documents)
            {
                if (doc.IsLinked) continue;
                if (doc.PathName.Equals(value.Adoc.PathName, StringComparison.OrdinalIgnoreCase)) continue;

                var dest = new Archivo(doc) { Checked = true };
                dest.Nombre = GetDocumentDisplayName(doc);
                dest.OnCheckedPropertyChanged = () => OnPropertyChanged(nameof(CheckedDestinationsText));
                DestinationDocuments.Add(dest);
            }
        }
        else
        {
            RootNodes.Clear();
            _allSourceItems.Clear();
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
            BuildTree();
        }
        catch (Exception ex)
        {
            TaskDialog.Show("TransferPlus", "Error collecting elements: " + ex.Message);
        }
        finally
        {
            IsBusy = false;
            StatusMessage = "Ready";
            ProgressPercentage = 0;
            UpdateCheckedCount();
        }
    }

    private void BuildTree()
    {
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
                Count = group.Count()
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
        RootNodes.Add(allNode);
    }

    [RelayCommand]
    private void FilterTree()
    {
        string searchText = SearchFilter;
        if (string.IsNullOrWhiteSpace(searchText)) return;

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
                catch
                {
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
        }
        catch (Exception ex)
        {
            TaskDialog.Show("TransferPlus", "Error applying filter: " + ex.Message);
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
                            if (node.Item.Familia != null) match = searchRegex.IsMatch(node.Item.Familia);
                            if (!match && node.Item.Tipo != null) match = searchRegex.IsMatch(node.Item.Tipo);
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
                            if (node.Item.Familia != null) match = node.Item.Familia.ToLowerInvariant().Contains(searchText);
                            if (!match && node.Item.Tipo != null) match = node.Item.Tipo.ToLowerInvariant().Contains(searchText);
                        }
                    }
                }
            }
            catch {}
        }

        if (match)
        {
            node.SetCheckedState(true);
        }

        foreach (var child in node.Children)
        {
            FilterNode(child, searchText, searchRegex);
        }
    }

    [RelayCommand]
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
        _config.cf_rbOverride = OverrideDuplicates;
        _config.cf_rbCancel = CancelDuplicates;
        _config.cf_rbAsk = AskDuplicates;
        _config.cf_chk_Callout = IncludeCallouts;
        _config.cf_chk_ViewElements = IncludeViewElements;
        _config.cf_chk_SheetWithViews = IncludeSheetsWithViews;
        _config.cf_chk_Links = CopyLinks;
        _config.cf_chk_GetTransformNone = TransformNone;
        _config.cf_chk_GetTransformLink = TransformLink;
        _config.cf_chk_GetTransformShared = TransformShared;
        _config.cf_chk_AcceptAll = AcceptAllWarnings;
    }

    [RelayCommand]
    private void Transfer()
    {
        if (SelectedSourceDocument == null) return;

        SyncConfig();

        var checkedItems = new List<Elemento>();
        CollectCheckedItems(RootNodes, checkedItems);

        if (!checkedItems.Any())
        {
            TaskDialog.Show("TransferPlus", "No items selected to transfer.");
            return;
        }

        var elementsToCopy = checkedItems;

        IsBusy = true;
        StatusMessage = "Transferring elements...";
        ProgressPercentage = 0;

        try
        {
            foreach (var destDoc in DestinationDocuments)
            {
                if (destDoc.Checked)
                {
                    TransferOrchestrator.TransferElements(SelectedSourceDocument.Adoc, destDoc.Adoc, elementsToCopy, _config, (msg, current, total) =>
                    {
                        StatusMessage = $"{msg}...";
                        ProgressPercentage = (int)((double)current / total * 100);
                    });
                }
            }
            TaskDialog.Show("TransferPlus", "Transfer complete!");
        }
        catch (Exception ex)
        {
            TaskDialog.Show("TransferPlus", "Error during transfer: " + ex.Message);
        }
        finally
        {
            IsBusy = false;
            StatusMessage = "Ready";
            ProgressPercentage = 0;
        }
    }

    private void CollectCheckedItems(IEnumerable<TreeItemViewModel> nodes, List<Elemento> list)
    {
        foreach (var node in nodes)
        {
            if (node.Item != null && node.IsChecked == true)
            {
                list.Add(node.Item);
            }
            CollectCheckedItems(node.Children, list);
        }
    }

    private void UpdateCheckedCount()
    {
        var checkedItems = new List<Elemento>();
        CollectCheckedItems(RootNodes, checkedItems);
        CheckedElementsCount = checkedItems.Count;
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

    public ObservableCollection<RenamePreviewItem> RenamePreviewItems { get; } = new();

    partial void OnRenameSearchTextChanged(string value) => UpdateRenamePreviews();
    partial void OnRenameReplaceTextChanged(string value) => UpdateRenamePreviews();
    partial void OnRenameUseRegexChanged(bool value) => UpdateRenamePreviews();
    partial void OnRenameMatchCaseChanged(bool value) => UpdateRenamePreviews();
    partial void OnRenameMatchAllOccurrencesChanged(bool value) => UpdateRenamePreviews();
    partial void OnRenameEnumerateItemsChanged(bool value) => UpdateRenamePreviews();
    partial void OnRenameRandomizeItemsChanged(bool value) => UpdateRenamePreviews();

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

    [RelayCommand]
    private void OpenRenamePanel()
    {
        if (SelectedSourceDocument == null) return;

        var checkedItems = new List<Elemento>();
        CollectCheckedItems(RootNodes, checkedItems);

        if (!checkedItems.Any())
        {
            TaskDialog.Show("TransferPlus", "No elements checked for renaming.");
            return;
        }

        RenamePreviewItems.Clear();
        foreach (var item in checkedItems)
        {
            RenamePreviewItems.Add(new RenamePreviewItem(item.eID, item.Nombre));
        }

        IsRenamePanelOpen = true;
        UpdateRenamePreviews();
    }

    [RelayCommand]
    private void CloseRenamePanel()
    {
        IsRenamePanelOpen = false;
    }

    [RelayCommand]
    private void TransferAndRename()
    {
        // Placeholder for the actual transfer and rename logic
        TaskDialog.Show("TransferPlus", "Transfer & Rename logic will be implemented in the next step!");
        IsRenamePanelOpen = false;
    }

    private void UpdateRenamePreviews()
    {
        if (string.IsNullOrEmpty(RenameSearchText))
        {
            foreach (var item in RenamePreviewItems)
            {
                item.NewName = item.OriginalName;
            }
            return;
        }

        RegexOptions options = RenameMatchCase ? RegexOptions.None : RegexOptions.IgnoreCase;
        Regex? regex = null;

        if (RenameUseRegex)
        {
            try
            {
                regex = new Regex(RenameSearchText, options);
            }
            catch
            {
                // Incomplete regex, do not apply changes yet
                return;
            }
        }

        foreach (var item in RenamePreviewItems)
        {
            string newName = item.OriginalName;

            if (!string.IsNullOrEmpty(RenameSearchText))
            {
                if (RenameUseRegex && regex != null)
                {
                    try
                    {
                        newName = RenameMatchAllOccurrences ? regex.Replace(item.OriginalName, RenameReplaceText) : regex.Replace(item.OriginalName, RenameReplaceText, 1);
                    }
                    catch { }
                }
                else
                {
                    string literalPattern = Regex.Escape(RenameSearchText);
                    var re = new Regex(literalPattern, options);
                    newName = RenameMatchAllOccurrences ? re.Replace(item.OriginalName, RenameReplaceText) : re.Replace(item.OriginalName, RenameReplaceText, 1);
                }
            }

            // Apply casing
            if (IsFormatLowercase) newName = newName.ToLower();
            else if (IsFormatUppercase) newName = newName.ToUpper();
            else if (IsFormatTitleCase && newName.Length > 0) newName = char.ToUpper(newName[0]) + newName.Substring(1).ToLower();
            else if (IsFormatCapitalizeEach) newName = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(newName.ToLower());

            item.NewName = newName;
        }

        // Apply enumeration and randomizing
        if (RenameEnumerateItems)
        {
            for (int i = 0; i < RenamePreviewItems.Count; i++)
            {
                RenamePreviewItems[i].NewName += $" - {(i + 1):D2}";
            }
        }
        if (RenameRandomizeItems)
        {
            var rnd = new Random();
            foreach (var item in RenamePreviewItems)
            {
                item.NewName += $"_{rnd.Next(1000, 9999)}";
            }
        }
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
        var configView = new ConfigurationView();
        configView.ShowDialog();
    }
}