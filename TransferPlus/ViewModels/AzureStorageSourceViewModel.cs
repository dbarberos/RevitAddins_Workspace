using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TransferPlus.Models;

namespace TransferPlus.ViewModels;

public partial class AzureStorageSourceViewModel : ObservableObject
{
    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private string _endpointUrl = string.Empty;

    [ObservableProperty]
    private string _clientId = string.Empty;

    [ObservableProperty]
    private string _tenantId = string.Empty;

    [ObservableProperty]
    private string _containerName = string.Empty;

    [ObservableProperty]
    private string _rootPath = string.Empty;

    [ObservableProperty]
    private bool _isActive = true;

    [ObservableProperty]
    private string _signedInStatus = "Not signed in.";

    [ObservableProperty]
    private bool? _dialogResult;

    public AzureStorageSourceViewModel(FamilySourceItemModel? model = null)
    {
        if (model != null)
        {
            Name = model.Name;
            EndpointUrl = model.EndpointUrl;
            ClientId = model.ClientId;
            TenantId = model.TenantId;
            ContainerName = model.ContainerName;
            RootPath = model.RootPath;
            IsActive = model.IsActive;
        }
    }

    [RelayCommand]
    private void Ok(object? window)
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            System.Windows.MessageBox.Show("Please enter a family source name.", "Validation Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
            return;
        }

        DialogResult = true;
        if (window is System.Windows.Window w)
        {
            w.DialogResult = true;
            w.Close();
        }
    }

    [RelayCommand]
    private void Cancel(object? window)
    {
        DialogResult = false;
        if (window is System.Windows.Window w)
        {
            w.DialogResult = false;
            w.Close();
        }
    }

    public FamilySourceItemModel ToModel(string? existingId = null)
    {
        return new FamilySourceItemModel
        {
            Id = existingId ?? Guid.NewGuid().ToString(),
            Name = Name.Trim(),
            SourceType = FamilySourceType.AzureStorage,
            EndpointUrl = EndpointUrl.Trim(),
            ClientId = ClientId.Trim(),
            TenantId = TenantId.Trim(),
            ContainerName = ContainerName.Trim(),
            RootPath = RootPath.Trim(),
            IsActive = IsActive
        };
    }
}
