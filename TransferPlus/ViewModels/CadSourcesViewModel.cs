using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TransferPlus.Models;
using TransferPlus.Services;

namespace TransferPlus.ViewModels;

public partial class CadSourcesViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<CadSourceItemModel> _sources = new();

    [ObservableProperty]
    private CadSourceItemModel? _selectedSource;

    [ObservableProperty]
    private bool? _dialogResult;

    public CadSourcesViewModel()
    {
        LoadData();
    }

    private void LoadData()
    {
        var items = CadSourceConfigService.LoadSources();
        Sources = new ObservableCollection<CadSourceItemModel>(items);
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
            var typeVm = new CadSourceTypeViewModel();
            var typeWin = new Views.CadSourceTypeWindow { DataContext = typeVm, Owner = ownerWindow };
            
            if (typeWin.ShowDialog() == true)
            {
                if (typeVm.SelectedSourceType == CadSourceType.AutodeskDocs)
                {
                    var accVm = new AutodeskDocsSourceViewModel();
                    var accWin = new Views.AutodeskDocsSourceWindow { DataContext = accVm, Owner = ownerWindow };
                    if (accWin.ShowDialog() == true)
                    {
                        var newModel = accVm.ToCadModel();
                        Sources.Add(newModel);
                        SelectedSource = newModel;
                    }
                }
                else if (typeVm.SelectedSourceType == CadSourceType.Directory)
                {
                    var dirVm = new DirectorySourceViewModel();
                    var dirWin = new Views.DirectorySourceWindow { DataContext = dirVm, Owner = ownerWindow };
                    if (dirWin.ShowDialog() == true)
                    {
                        var newModel = dirVm.ToCadModel();
                        Sources.Add(newModel);
                        SelectedSource = newModel;
                    }
                }
                else if (typeVm.SelectedSourceType == CadSourceType.AwsS3)
                {
                    var awsVm = new AwsS3SourceViewModel();
                    var awsWin = new Views.AwsS3SourceWindow { DataContext = awsVm, Owner = ownerWindow };
                    if (awsWin.ShowDialog() == true)
                    {
                        var newModel = awsVm.ToCadModel();
                        Sources.Add(newModel);
                        SelectedSource = newModel;
                    }
                }
                else if (typeVm.SelectedSourceType == CadSourceType.AzureStorage)
                {
                    var azureVm = new AzureStorageSourceViewModel();
                    var azureWin = new Views.AzureStorageSourceWindow { DataContext = azureVm, Owner = ownerWindow };
                    if (azureWin.ShowDialog() == true)
                    {
                        var newModel = azureVm.ToCadModel();
                        Sources.Add(newModel);
                        SelectedSource = newModel;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error adding CAD source", ex);
        }
    }

    [RelayCommand]
    private void EditSource(Window? ownerWindow)
    {
        if (SelectedSource == null) return;

        try
        {
            if (SelectedSource.SourceType == CadSourceType.AutodeskDocs)
            {
                var accVm = new AutodeskDocsSourceViewModel(SelectedSource);
                var accWin = new Views.AutodeskDocsSourceWindow { DataContext = accVm, Owner = ownerWindow };
                if (accWin.ShowDialog() == true)
                {
                    var updated = accVm.ToCadModel(SelectedSource.Id);
                    int index = Sources.IndexOf(SelectedSource);
                    if (index >= 0)
                    {
                        Sources[index] = updated;
                        SelectedSource = updated;
                    }
                }
            }
            else if (SelectedSource.SourceType == CadSourceType.Directory)
            {
                var dirVm = new DirectorySourceViewModel(SelectedSource);
                var dirWin = new Views.DirectorySourceWindow { DataContext = dirVm, Owner = ownerWindow };
                if (dirWin.ShowDialog() == true)
                {
                    var updated = dirVm.ToCadModel(SelectedSource.Id);
                    int index = Sources.IndexOf(SelectedSource);
                    if (index >= 0)
                    {
                        Sources[index] = updated;
                        SelectedSource = updated;
                    }
                }
            }
            else if (SelectedSource.SourceType == CadSourceType.AwsS3)
            {
                var awsVm = new AwsS3SourceViewModel(SelectedSource);
                var awsWin = new Views.AwsS3SourceWindow { DataContext = awsVm, Owner = ownerWindow };
                if (awsWin.ShowDialog() == true)
                {
                    var updated = awsVm.ToCadModel(SelectedSource.Id);
                    int index = Sources.IndexOf(SelectedSource);
                    if (index >= 0)
                    {
                        Sources[index] = updated;
                        SelectedSource = updated;
                    }
                }
            }
            else if (SelectedSource.SourceType == CadSourceType.AzureStorage)
            {
                var azureVm = new AzureStorageSourceViewModel(SelectedSource);
                var azureWin = new Views.AzureStorageSourceWindow { DataContext = azureVm, Owner = ownerWindow };
                if (azureWin.ShowDialog() == true)
                {
                    var updated = azureVm.ToCadModel(SelectedSource.Id);
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
            TelemetryLogger.LogError("Error editing CAD source", ex);
        }
    }

    [RelayCommand]
    private void RemoveSource()
    {
        if (SelectedSource == null) return;

        var result = MessageBox.Show(
            $"Are you sure you want to remove the CAD source '{SelectedSource.Name}'?",
            "Remove CAD Source",
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
        CadSourceConfigService.SaveSources(Sources);
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
