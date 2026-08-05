using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TransferPlus.Models;
using TransferPlus.Services;

namespace TransferPlus.ViewModels;

public partial class FamilySourcesViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<FamilySourceItemModel> _sources = new();

    [ObservableProperty]
    private FamilySourceItemModel? _selectedSource;

    [ObservableProperty]
    private bool? _dialogResult;

    public FamilySourcesViewModel()
    {
        LoadData();
    }

    private void LoadData()
    {
        var items = FamilySourceConfigService.LoadSources();
        Sources = new ObservableCollection<FamilySourceItemModel>(items);
        if (Sources.Count > 0)
        {
            SelectedSource = Sources.First();
        }
    }

    [RelayCommand]
    private void AddSource(Window? ownerWindow)
    {
        try
        {
            var typeVm = new FamilySourceTypeViewModel();
            var typeWin = new Views.FamilySourceTypeWindow { DataContext = typeVm, Owner = ownerWindow };
            
            if (typeWin.ShowDialog() == true)
            {
                if (typeVm.SelectedSourceType == FamilySourceType.AutodeskDocs)
                {
                    var accVm = new AutodeskDocsSourceViewModel();
                    var accWin = new Views.AutodeskDocsSourceWindow { DataContext = accVm, Owner = ownerWindow };
                    if (accWin.ShowDialog() == true)
                    {
                        var newModel = accVm.ToModel();
                        Sources.Add(newModel);
                        SelectedSource = newModel;
                    }
                }
                else if (typeVm.SelectedSourceType == FamilySourceType.Directory)
                {
                    var dirVm = new DirectorySourceViewModel();
                    var dirWin = new Views.DirectorySourceWindow { DataContext = dirVm, Owner = ownerWindow };
                    if (dirWin.ShowDialog() == true)
                    {
                        var newModel = dirVm.ToModel();
                        Sources.Add(newModel);
                        SelectedSource = newModel;
                    }
                }
                else
                {
                    var azureVm = new AzureStorageSourceViewModel();
                    var azureWin = new Views.AzureStorageSourceWindow { DataContext = azureVm, Owner = ownerWindow };
                    if (azureWin.ShowDialog() == true)
                    {
                        var newModel = azureVm.ToModel();
                        Sources.Add(newModel);
                        SelectedSource = newModel;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error adding family source", ex);
        }
    }

    [RelayCommand]
    private void EditSource(Window? ownerWindow)
    {
        if (SelectedSource == null) return;

        try
        {
            if (SelectedSource.SourceType == FamilySourceType.AutodeskDocs)
            {
                var accVm = new AutodeskDocsSourceViewModel(SelectedSource);
                var accWin = new Views.AutodeskDocsSourceWindow { DataContext = accVm, Owner = ownerWindow };
                if (accWin.ShowDialog() == true)
                {
                    var updated = accVm.ToModel(SelectedSource.Id);
                    int index = Sources.IndexOf(SelectedSource);
                    if (index >= 0)
                    {
                        Sources[index] = updated;
                        SelectedSource = updated;
                    }
                }
            }
            else if (SelectedSource.SourceType == FamilySourceType.Directory)
            {
                var dirVm = new DirectorySourceViewModel(SelectedSource);
                var dirWin = new Views.DirectorySourceWindow { DataContext = dirVm, Owner = ownerWindow };
                if (dirWin.ShowDialog() == true)
                {
                    var updated = dirVm.ToModel(SelectedSource.Id);
                    int index = Sources.IndexOf(SelectedSource);
                    if (index >= 0)
                    {
                        Sources[index] = updated;
                        SelectedSource = updated;
                    }
                }
            }
            else
            {
                var azureVm = new AzureStorageSourceViewModel(SelectedSource);
                var azureWin = new Views.AzureStorageSourceWindow { DataContext = azureVm, Owner = ownerWindow };
                if (azureWin.ShowDialog() == true)
                {
                    var updated = azureVm.ToModel(SelectedSource.Id);
                    int index = Sources.IndexOf(SelectedSource);
                    if (index >= 0)
                    {
                        Sources[index] = updated;
                        SelectedSource = updated;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error editing family source", ex);
        }
    }

    [RelayCommand]
    private void RemoveSource()
    {
        if (SelectedSource == null) return;

        var result = MessageBox.Show(
            $"Are you sure you want to remove the source '{SelectedSource.Name}'?",
            "Remove Source",
            MessageBoxButton.YesNo,
            MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            Sources.Remove(SelectedSource);
            SelectedSource = Sources.FirstOrDefault();
        }
    }

    [RelayCommand]
    private void Save(Window? window)
    {
        FamilySourceConfigService.SaveSources(Sources);
        DialogResult = true;
        if (window != null)
        {
            window.DialogResult = true;
            window.Close();
        }
    }

    [RelayCommand]
    private void Cancel(Window? window)
    {
        DialogResult = false;
        if (window != null)
        {
            window.DialogResult = false;
            window.Close();
        }
    }
}
