using System;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TransferPlus.Models;
using TransferPlus.Services;

namespace TransferPlus.ViewModels;

public partial class ConfigurationViewModel : ObservableObject
{
    private readonly TransferPlusSettings _originalSettings;
    
    [ObservableProperty]
    private bool _isDBDevSelected;

    [ObservableProperty]
    private bool _isRevitDefaultSelected;

    [ObservableProperty]
    private bool _isCustomSelected;

    [ObservableProperty]
    private string _customTabName = "";

    [ObservableProperty]
    private bool _useAsContextualFilter;

    public ConfigurationViewModel()
    {
        _originalSettings = SettingsService.Load();
        
        IsDBDevSelected = _originalSettings.SelectedTabOption == TabOption.DBDevDefault;
        IsRevitDefaultSelected = _originalSettings.SelectedTabOption == TabOption.RevitDefault;
        IsCustomSelected = _originalSettings.SelectedTabOption == TabOption.Custom;
        CustomTabName = _originalSettings.CustomTabName;
        UseAsContextualFilter = _originalSettings.UseAsContextualFilter;
    }

    [RelayCommand]
    private void Save(Window window)
    {
        TabOption selectedOption = TabOption.DBDevDefault;
        if (IsRevitDefaultSelected) selectedOption = TabOption.RevitDefault;
        else if (IsCustomSelected) selectedOption = TabOption.Custom;

        // Security Hardening: Sanitize custom tab name
        string sanitizedTabName = SecurityUtils.SanitizeInput(CustomTabName);

        var newSettings = new TransferPlusSettings
        {
            SelectedTabOption = selectedOption,
            CustomTabName = sanitizedTabName,
            UseAsContextualFilter = UseAsContextualFilter
        };

        SettingsService.Save(newSettings);
        
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
                        "Contextual Filter Limitation", 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Information);
    }

    public static Action? ToggleDebugWindowAction { get; set; }

    [RelayCommand]
    private void ToggleDebugWindow()
    {
        try
        {
            TelemetryLogger.LogInfo("ConfigurationViewModel: Executing ToggleDebugWindowAction...");
            ToggleDebugWindowAction?.Invoke();
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("ConfigurationViewModel: Error toggling debug window", ex);
        }
    }

    [RelayCommand]
    private void OpenPrivacyPolicy()
    {
        try
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://dbdev-dbarberos.github.io/PrivacyPolicy/",
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show("Could not open the privacy policy link: " + ex.Message);
        }
    }
}
