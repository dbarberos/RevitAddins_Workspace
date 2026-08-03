using System;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TransferPlus.Models;
using TransferPlus.Services;

namespace TransferPlus.ViewModels;

public partial class DirectorySourceViewModel : ObservableObject
{
    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private string _directory = string.Empty;

    [ObservableProperty]
    private bool _isActive = true;

    [ObservableProperty]
    private bool? _dialogResult;

    public DirectorySourceViewModel(FamilySourceItemModel? model = null)
    {
        if (model != null)
        {
            Name = model.Name;
            Directory = model.Path;
            IsActive = model.IsActive;
        }
    }

    [RelayCommand]
    private void BrowseDirectory()
    {
        try
        {
            // 1. Try Microsoft.Win32.OpenFolderDialog (.NET 8 / modern WPF)
            var openFolderDialogType = Type.GetType("Microsoft.Win32.OpenFolderDialog, PresentationFramework");
            if (openFolderDialogType != null)
            {
                var instance = Activator.CreateInstance(openFolderDialogType);
                if (instance != null)
                {
                    openFolderDialogType.GetProperty("Title")?.SetValue(instance, "Select Revit Family Directory");
                    var showDialogMethod = openFolderDialogType.GetMethod("ShowDialog", Type.EmptyTypes);
                    var result = showDialogMethod?.Invoke(instance, null);
                    if (result is true)
                    {
                        var folderName = openFolderDialogType.GetProperty("FolderName")?.GetValue(instance) as string;
                        if (!string.IsNullOrWhiteSpace(folderName))
                        {
                            Directory = folderName;
                            return;
                        }
                    }
                }
            }

            // 2. Fallback: Microsoft.Win32.OpenFileDialog
            var ofd = new Microsoft.Win32.OpenFileDialog
            {
                Title = "Select a family file inside target directory",
                Filter = "Revit Family Files (*.rfa)|*.rfa|All Files (*.*)|*.*",
                CheckFileExists = false
            };
            if (ofd.ShowDialog() == true)
            {
                Directory = Path.GetDirectoryName(ofd.FileName) ?? string.Empty;
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error browsing directory for family source", ex);
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

        if (string.IsNullOrWhiteSpace(Directory))
        {
            System.Windows.MessageBox.Show("Please select a valid directory path.", "Validation Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
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
            SourceType = FamilySourceType.Directory,
            Path = Directory.Trim(),
            IsActive = IsActive
        };
    }
}
