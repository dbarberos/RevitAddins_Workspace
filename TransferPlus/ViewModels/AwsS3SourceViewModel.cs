using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TransferPlus.Models;
using TransferPlus.Services;

namespace TransferPlus.ViewModels;

public partial class AwsS3SourceViewModel : ObservableObject
{
    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private string _bucketName = string.Empty;

    [ObservableProperty]
    private string _region = "eu-west-1";

    [ObservableProperty]
    private string _endpointUrl = "http://localhost:4566";

    [ObservableProperty]
    private string _accessKey = "test";

    [ObservableProperty]
    private string _secretKey = "test";

    [ObservableProperty]
    private string _rootPath = string.Empty;

    [ObservableProperty]
    private bool _isActive = true;

    [ObservableProperty]
    private string _signedInStatus = "Not connected.";

    [ObservableProperty]
    private bool _isTestingConnection;

    [ObservableProperty]
    private bool? _dialogResult;

    public List<string> EndpointPresets { get; } = new()
    {
        "http://localhost:4566",
        "https://s3.amazonaws.com"
    };

    public AwsS3SourceViewModel(FamilySourceItemModel? model = null)
    {
        if (model != null)
        {
            Name = model.Name;
            BucketName = model.BucketName;
            Region = string.IsNullOrWhiteSpace(model.Region) ? "eu-west-1" : model.Region;
            EndpointUrl = string.IsNullOrWhiteSpace(model.EndpointUrl) ? "http://localhost:4566" : model.EndpointUrl;
            AccessKey = string.IsNullOrWhiteSpace(model.AccessKey) ? "test" : model.AccessKey;
            SecretKey = string.IsNullOrWhiteSpace(model.SecretKey) ? "test" : model.SecretKey;
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
            var tempModel = ToModel();
            var (success, message, isFloci) = await AwsS3StorageService.TestConnectionAsync(tempModel);

            SignedInStatus = success
                ? (isFloci ? "Connected to Floci (AWS local) ✓" : "Connected to AWS S3 real ✓")
                : $"Connection failed: {message}";

            System.Windows.MessageBox.Show(message, success ? "Connection Test" : "Connection Failed",
                System.Windows.MessageBoxButton.OK,
                success ? System.Windows.MessageBoxImage.Information : System.Windows.MessageBoxImage.Error);
        }
        catch (Exception ex)
        {
            SignedInStatus = $"Error: {ex.Message}";
            TelemetryLogger.LogError("Error testing AWS S3 connection", ex);
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

        if (string.IsNullOrWhiteSpace(BucketName))
        {
            System.Windows.MessageBox.Show("Please enter a valid S3 Bucket name.", "Validation Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
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
            SourceType = FamilySourceType.AwsS3,
            BucketName = BucketName.Trim(),
            Region = Region.Trim(),
            EndpointUrl = EndpointUrl.Trim(),
            AccessKey = AccessKey.Trim(),
            SecretKey = SecretKey.Trim(),
            RootPath = RootPath.Trim(),
            IsActive = IsActive
        };
    }
}
