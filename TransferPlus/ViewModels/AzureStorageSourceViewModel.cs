using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TransferPlus.Models;
using TransferPlus.Services;

namespace TransferPlus.ViewModels;

public partial class AzureStorageSourceViewModel : ObservableObject
{
    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private string _connectionString = string.Empty;

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
    private bool _isTestingConnection;

    [ObservableProperty]
    private bool? _dialogResult;

    public List<string> EndpointPresets { get; } = new()
    {
        "http://127.0.0.1:10000",
        "https://core.windows.net"
    };

    public AzureStorageSourceViewModel(FamilySourceItemModel? model = null)
    {
        if (model != null)
        {
            Name = model.Name;
            ConnectionString = model.ConnectionString;
            EndpointUrl = model.EndpointUrl;
            ClientId = model.ClientId;
            TenantId = model.TenantId;
            ContainerName = model.ContainerName;
            RootPath = model.RootPath;
            IsActive = model.IsActive;
        }
    }

    [RelayCommand]
    private async Task TestConnectionAsync()
    {
        IsTestingConnection = true;
        SignedInStatus = "Testing connection...";

        try
        {
            var (success, message) = await AzureStorageService.TestConnectionAsync(ConnectionString, ContainerName);
            SignedInStatus = success ? "Connected successfully! ✓" : $"Connection failed: {message}";
            
            System.Windows.MessageBox.Show(message, success ? "Connection Test" : "Connection Failed",
                System.Windows.MessageBoxButton.OK,
                success ? System.Windows.MessageBoxImage.Information : System.Windows.MessageBoxImage.Error);
        }
        catch (Exception ex)
        {
            SignedInStatus = $"Error: {ex.Message}";
            TelemetryLogger.LogError("Error during connection test", ex);
        }
        finally
        {
            IsTestingConnection = false;
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

        if (string.IsNullOrWhiteSpace(ContainerName))
        {
            System.Windows.MessageBox.Show("Please enter a valid container name.", "Validation Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
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
            ConnectionString = ConnectionString.Trim(),
            EndpointUrl = EndpointUrl.Trim(),
            ClientId = ClientId.Trim(),
            TenantId = TenantId.Trim(),
            ContainerName = ContainerName.Trim(),
            RootPath = RootPath.Trim(),
            IsActive = IsActive
        };
    }
}
