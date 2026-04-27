using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FilterPlus.Models;
using FilterPlus.Services;

namespace FilterPlus.ViewModels;

public partial class ConfigurationViewModel : ObservableObject
{
    private readonly FilterPlusSettings _originalSettings;
    
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

        var newSettings = new FilterPlusSettings
        {
            SelectedTabOption = selectedOption,
            CustomTabName = CustomTabName,
            UseAsContextualFilter = UseAsContextualFilter
        };

        SettingsService.Save(newSettings);
        
        // Cierra la ventana
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
}
