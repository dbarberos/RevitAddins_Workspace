using System;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TablePlus.Models;
using TablePlus.Services;

namespace TablePlus.ViewModels;

public partial class ConfigurationViewModel : ObservableObject
{
    private readonly TablePlusSettings _originalSettings;

    [ObservableProperty]
    private bool _isAddInsDefaultTabSelected;

    [ObservableProperty]
    private bool _isRevitDefaultSelected;

    [ObservableProperty]
    private bool _isCustomSelected;

    [ObservableProperty]
    private string _customTabName = "";

    [ObservableProperty]
    private bool _useAsContextualFilter;

    [ObservableProperty]
    private System.Collections.ObjectModel.ObservableCollection<TableSourceItemModel> _sources = new();

    [ObservableProperty]
    private TableSourceItemModel? _selectedSource;

    public ConfigurationViewModel()
    {
        _originalSettings = SettingsService.Load();

        IsAddInsDefaultTabSelected = _originalSettings.SelectedTabOption == TabOption.AddInsDefaultTab || _originalSettings.SelectedTabOption == TabOption.DBDevDefault;
        IsRevitDefaultSelected = _originalSettings.SelectedTabOption == TabOption.RevitDefault;
        IsCustomSelected = _originalSettings.SelectedTabOption == TabOption.Custom;
        CustomTabName = _originalSettings.CustomTabName;
        UseAsContextualFilter = _originalSettings.UseAsContextualFilter;

        LoadSources();
    }

    private void LoadSources()
    {
        var items = TableSourceConfigService.LoadSources();
        Sources = new System.Collections.ObjectModel.ObservableCollection<TableSourceItemModel>(items);
        if (Sources.Count > 0)
        {
            SelectedSource = Sources[0];
        }
    }

    [RelayCommand]
    private void AddSource(Window? ownerWindow)
    {
        try
        {
            var typeVm = new TableSourceTypeViewModel();
            var typeWin = new Views.TableSourceTypeWindow { DataContext = typeVm, Owner = ownerWindow };

            if (typeWin.ShowDialog() == true)
            {
                if (typeVm.SelectedSourceType == ExternalTableSourceType.AutodeskDocs)
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
                else if (typeVm.SelectedSourceType == ExternalTableSourceType.Directory)
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
                else if (typeVm.SelectedSourceType == ExternalTableSourceType.AwsS3)
                {
                    var awsVm = new AwsS3SourceViewModel();
                    var awsWin = new Views.AwsS3SourceWindow { DataContext = awsVm, Owner = ownerWindow };
                    if (awsWin.ShowDialog() == true)
                    {
                        var newModel = awsVm.ToModel();
                        Sources.Add(newModel);
                        SelectedSource = newModel;
                    }
                }
                else if (typeVm.SelectedSourceType == ExternalTableSourceType.AzureStorage)
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

                TableSourceConfigService.SaveSources(Sources);
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error adding Table source", ex);
        }
    }

    [RelayCommand]
    private void EditSource(Window? ownerWindow)
    {
        if (SelectedSource == null) return;

        try
        {
            if (SelectedSource.SourceType == ExternalTableSourceType.AutodeskDocs)
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
            else if (SelectedSource.SourceType == ExternalTableSourceType.Directory)
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
            else if (SelectedSource.SourceType == ExternalTableSourceType.AwsS3)
            {
                var awsVm = new AwsS3SourceViewModel(SelectedSource);
                var awsWin = new Views.AwsS3SourceWindow { DataContext = awsVm, Owner = ownerWindow };
                if (awsWin.ShowDialog() == true)
                {
                    var updated = awsVm.ToModel(SelectedSource.Id);
                    int index = Sources.IndexOf(SelectedSource);
                    if (index >= 0)
                    {
                        Sources[index] = updated;
                        SelectedSource = updated;
                    }
                }
            }
            else if (SelectedSource.SourceType == ExternalTableSourceType.AzureStorage)
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

            TableSourceConfigService.SaveSources(Sources);
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error editing Table source", ex);
        }
    }

    [RelayCommand]
    private void RemoveSource()
    {
        if (SelectedSource == null) return;

        var result = MessageBox.Show(
            $"Are you sure you want to remove the table source '{SelectedSource.Name}'?",
            "Remove Table Source",
            MessageBoxButton.YesNo,
            MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            Sources.Remove(SelectedSource);
            SelectedSource = Sources.Count > 0 ? Sources[0] : null;
            TableSourceConfigService.SaveSources(Sources);
        }
    }

    [RelayCommand]
    private void Save(Window window)
    {
        TabOption selectedOption = TabOption.AddInsDefaultTab;
        if (IsRevitDefaultSelected) selectedOption = TabOption.RevitDefault;
        else if (IsCustomSelected) selectedOption = TabOption.Custom;

        // Security Hardening: Sanitize custom tab name
        string sanitizedTabName = SecurityUtils.SanitizeInput(CustomTabName);

        var newSettings = new TablePlusSettings
        {
            SelectedTabOption = selectedOption,
            CustomTabName = string.IsNullOrWhiteSpace(sanitizedTabName) ? "TablePlus" : sanitizedTabName,
            UseAsContextualFilter = UseAsContextualFilter
        };

        SettingsService.Save(newSettings);

        // Save Table Sources
        TableSourceConfigService.SaveSources(Sources);

        // Close window
        window?.Close();
    }

    [RelayCommand]
    private void Cancel(Window window)
    {
        window?.Close();
    }

    [RelayCommand]
    private void ShowHelpDialog()
    {
        MessageBox.Show("The contextual menu feature requires Revit 2025 or newer.\n\n" +
                        "In Revit 2024 and older versions, Autodesk did not provide a public API " +
                        "to modify the right-click canvas context menu. This checkbox will be ignored " +
                        "unless you are running the add-in in Revit 2025+.",
                        "Contextual Menu Limitation",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
    }

    [RelayCommand]
    private void ToggleDebugWindow()
    {
        try
        {
            LoggerService.LogInfo("ConfigurationViewModel: Executing ToggleDebugWindow...");
            TablePlus.Application.ToggleDebugLogWindow();
        }
        catch (Exception ex)
        {
            LoggerService.LogError("ConfigurationViewModel: Error toggling debug window", ex);
        }
    }

    [RelayCommand]
    private void OpenPrivacyPolicy()
    {
        try
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://dbdev-dbarberos.github.io/PrivacyPolicy/TablePlus/",
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show("Could not open the privacy policy link: " + ex.Message);
        }
    }
}
