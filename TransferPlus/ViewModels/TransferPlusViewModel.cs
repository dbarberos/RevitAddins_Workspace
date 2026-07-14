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

    partial void OnSearchFilterChanged(string value) => FilterTree();
    partial void OnFilterUseOrChanged(bool value) => FilterTree();
    partial void OnFilterOnlyNamesChanged(bool value) => FilterTree();
    partial void OnFilterUseRegexChanged(bool value) => FilterTree();

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

    private void FilterTree()
    {
        if (string.IsNullOrWhiteSpace(SearchFilter))
        {
            BuildTree();
            return;
        }

        var query = SearchFilter;
        RootNodes.Clear();

        Func<Elemento, bool> predicate;

        if (FilterUseRegex)
        {
            try
            {
                var regex = new Regex(query, RegexOptions.IgnoreCase);
                predicate = x => regex.IsMatch(x.Nombre) || (!FilterOnlyNames && (regex.IsMatch(x.Categoria) || regex.IsMatch(x.Familia)));
            }
            catch
            {
                predicate = x => x.Nombre.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0;
            }
        }
        else if (FilterUseOr)
        {
            var terms = query.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            predicate = x => terms.Any(t => x.Nombre.IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0 || (!FilterOnlyNames && (x.Categoria.IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0 || x.Familia.IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0)));
        }
        else
        {
            var terms = query.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            predicate = x => terms.All(t => x.Nombre.IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0 || (!FilterOnlyNames && (x.Categoria.IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0 || x.Familia.IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0)));
        }

        var filteredItems = _allSourceItems.Where(predicate).ToList();

        var allNode = new TreeItemViewModel("All", "Root", null, null, 0)
        {
            Count = filteredItems.Count,
            IsExpanded = true
        };

        var groups = filteredItems.GroupBy(x => x.Categoria).OrderBy(g => g.Key);

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
        UpdateCheckedCount();
    }

    [RelayCommand]
    private void ClearFilter()
    {
        SearchFilter = string.Empty;
        FilterUseOr = false;
        FilterOnlyNames = false;
        FilterUseRegex = false;
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

    // Text Rename Operations
    [RelayCommand]
    private void AddPrefix()
    {
        if (SelectedSourceDocument == null) return;

        var takeText = new TakeTextView { Title = "Add Prefix" };
        if (takeText.ShowDialog() != true || string.IsNullOrEmpty(TakeTextView.texto_out)) return;

        ExecuteRenameOperation(name => TakeTextView.texto_out + name, "Add Prefix");
    }

    [RelayCommand]
    private void AddSuffix()
    {
        if (SelectedSourceDocument == null) return;

        var takeText = new TakeTextView { Title = "Add Suffix" };
        if (takeText.ShowDialog() != true || string.IsNullOrEmpty(TakeTextView.texto_out)) return;

        ExecuteRenameOperation(name => name + TakeTextView.texto_out, "Add Suffix");
    }

    [RelayCommand]
    private void FindReplace()
    {
        if (SelectedSourceDocument == null) return;

        var renameText = new RenameTextView();
        if (renameText.ShowDialog() != true || string.IsNullOrEmpty(RenameTextView.textofind_out)) return;

        string find = RenameTextView.textofind_out;
        string replace = RenameTextView.textoreplace_out;
        bool useRegex = RenameTextView.usaregex;

        ExecuteRenameOperation(name =>
        {
            if (useRegex)
            {
                return Regex.Replace(name, find, replace);
            }
            return name.Replace(find, replace);
        }, "Find & Replace");
    }

    [RelayCommand]
    private void ChangeCase(string mode)
    {
        if (SelectedSourceDocument == null) return;

        ExecuteRenameOperation(name =>
        {
            return mode switch
            {
                "upper" => name.ToUpperInvariant(),
                "lower" => name.ToLowerInvariant(),
                "proper" => ProperCase(name),
                _ => name
            };
        }, "Change Case");
    }

    private string ProperCase(string text)
    {
        string[] array = text.Split(' ');
        for (int i = 0; i < array.Length; i++)
        {
            if (!Regex.IsMatch(array[i], "^\\d+"))
            {
                array[i] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(array[i].ToLower());
            }
        }
        return string.Join(" ", array);
    }

    private void ExecuteRenameOperation(Func<string, string> renameFunc, string operationName)
    {
        var checkedItems = new List<Elemento>();
        CollectCheckedItems(RootNodes, checkedItems);

        if (!checkedItems.Any())
        {
            TaskDialog.Show("TransferPlus", "No elements checked for renaming.");
            return;
        }

        Document document = SelectedSourceDocument!.Adoc;
        int successCount = 0;

        using (Transaction transaction = new Transaction(document, "TransferPlus: " + operationName))
        {
            transaction.Start();
            WarningSwallower.AttachToTransaction(transaction);

            foreach (var item in checkedItems)
            {
                Element element = document.GetElement(item.eID);
                if (element != null)
                {
                    string oldName = element.Name;
                    string newName = renameFunc(oldName);

                    if (!oldName.Equals(newName))
                    {
                        try
                        {
                            element.Name = newName;
                            successCount++;
                        }
                        catch { }
                    }
                }
            }
            transaction.Commit();
        }

        TaskDialog.Show("TransferPlus", $"Operation '{operationName}' complete.\nChanged: {successCount} of {checkedItems.Count} elements.");
        LoadSourceItems(document);
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

        var result = TaskDialog.Show("TransferPlus", $"Are you sure you want to delete {checkedItems.Count} elements from the source document?", TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No);
        if (result != TaskDialogResult.Yes) return;

        Document document = SelectedSourceDocument.Adoc;
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