using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TransferPlus.Models;
using TransferPlus.Services;

namespace TransferPlus.ViewModels;

public partial class TransferPlusViewModel : ObservableObject
{
    private readonly Document _targetDoc;
    private readonly UIApplication _app;

    [ObservableProperty]
    private ObservableCollection<TargetDocumentItem> _openDocuments = new();

    [ObservableProperty]
    private TargetDocumentItem? _selectedSourceDocument;

    [ObservableProperty]
    private ObservableCollection<TreeItemViewModel> _rootNodes = new();

    [ObservableProperty]
    private string _searchFilter = string.Empty;

    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private string _statusMessage = "Ready";

    [ObservableProperty]
    private bool _overrideDuplicates = true;

    private List<TransferItem> _allSourceItems = new();

    public TransferPlusViewModel(UIApplication app, Document targetDoc)
    {
        _app = app;
        _targetDoc = targetDoc;
        LoadOpenDocuments();
    }

    private void LoadOpenDocuments()
    {
        OpenDocuments.Clear();
        foreach (Document doc in _app.Application.Documents)
        {
            if (doc.PathName != _targetDoc.PathName)
            {
                OpenDocuments.Add(new TargetDocumentItem
                {
                    Document = doc,
                    Title = string.IsNullOrEmpty(doc.Title) ? "Untitled" : doc.Title,
                    IsLink = doc.IsLinked
                });
            }
        }
        SelectedSourceDocument = OpenDocuments.FirstOrDefault();
    }

    partial void OnSelectedSourceDocumentChanged(TargetDocumentItem? value)
    {
        if (value != null)
        {
            LoadSourceItems(value.Document);
        }
        else
        {
            RootNodes.Clear();
            _allSourceItems.Clear();
        }
    }

    partial void OnSearchFilterChanged(string value)
    {
        FilterTree();
    }

    private void LoadSourceItems(Document sourceDoc)
    {
        IsBusy = true;
        StatusMessage = "Collecting elements...";
        
        try
        {
            _allSourceItems = DocumentCollector.GetTransferableElements(sourceDoc);
            BuildTree();
        }
        finally
        {
            IsBusy = false;
            StatusMessage = "Ready";
        }
    }

    private void BuildTree()
    {
        RootNodes.Clear();
        var groups = _allSourceItems.GroupBy(x => x.Category).OrderBy(g => g.Key);

        foreach (var group in groups)
        {
            var categoryNode = new TreeItemViewModel(group.Key, "Category");
            
            var familyGroups = group.GroupBy(x => x.Family).OrderBy(g => g.Key);
            foreach (var famGroup in familyGroups)
            {
                var familyNode = new TreeItemViewModel(famGroup.Key, "Family") { Parent = categoryNode };
                
                foreach (var item in famGroup.OrderBy(x => x.Name))
                {
                    var itemNode = new TreeItemViewModel(item.Name, "Type", item) { Parent = familyNode };
                    familyNode.Children.Add(itemNode);
                }
                categoryNode.Children.Add(familyNode);
            }
            RootNodes.Add(categoryNode);
        }
    }

    private void FilterTree()
    {
        if (string.IsNullOrWhiteSpace(SearchFilter))
        {
            BuildTree();
            return;
        }

        var filterLower = SearchFilter.ToLowerInvariant();
        
        RootNodes.Clear();
        var groups = _allSourceItems.Where(x => x.Name.ToLowerInvariant().Contains(filterLower)).GroupBy(x => x.Category).OrderBy(g => g.Key);

        foreach (var group in groups)
        {
            var categoryNode = new TreeItemViewModel(group.Key, "Category");
            var familyGroups = group.GroupBy(x => x.Family).OrderBy(g => g.Key);
            foreach (var famGroup in familyGroups)
            {
                var familyNode = new TreeItemViewModel(famGroup.Key, "Family") { Parent = categoryNode };
                foreach (var item in famGroup.OrderBy(x => x.Name))
                {
                    var itemNode = new TreeItemViewModel(item.Name, "Type", item) { Parent = familyNode };
                    familyNode.Children.Add(itemNode);
                }
                categoryNode.Children.Add(familyNode);
            }
            categoryNode.IsExpanded = true;
            RootNodes.Add(categoryNode);
        }
    }

    [RelayCommand]
    private void Transfer()
    {
        if (SelectedSourceDocument == null) return;

        var itemsToTransfer = new List<TransferItem>();
        CollectCheckedItems(RootNodes, itemsToTransfer);

        if (!itemsToTransfer.Any()) return;

        IsBusy = true;
        StatusMessage = $"Transferring {itemsToTransfer.Count} elements...";

        try
        {
            TransferOrchestrator.TransferElements(SelectedSourceDocument.Document, _targetDoc, itemsToTransfer, OverrideDuplicates);
            StatusMessage = "Transfer complete.";
        }
        catch (Exception ex)
        {
            StatusMessage = "Error: " + ex.Message;
        }
        finally
        {
            IsBusy = false;
        }
    }

    private void CollectCheckedItems(IEnumerable<TreeItemViewModel> nodes, List<TransferItem> list)
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
}