using System;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TablePlus.Models;
using TablePlus.Services;

namespace TablePlus.ViewModels;

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

    public DirectorySourceViewModel(TableSourceItemModel? model = null)
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
            TelemetryLogger.LogInfo("Starting folder browser for TablePlus directory source...");

            // 1. Try System.Windows.Forms.FolderBrowserDialog via Reflection (Native folder picker on .NET 4.8 & .NET 8)
            var folderBrowserType = Type.GetType("System.Windows.Forms.FolderBrowserDialog, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")
                ?? Type.GetType("System.Windows.Forms.FolderBrowserDialog, System.Windows.Forms");

            if (folderBrowserType != null)
            {
                var instance = Activator.CreateInstance(folderBrowserType);
                if (instance != null)
                {
                    folderBrowserType.GetProperty("Description")?.SetValue(instance, "Select folder containing table spreadsheets (.xlsx, .xlsm, .xls, .csv)");
                    if (!string.IsNullOrWhiteSpace(Directory) && System.IO.Directory.Exists(Directory))
                    {
                        folderBrowserType.GetProperty("SelectedPath")?.SetValue(instance, Directory);
                    }

                    var showDialogMethod = folderBrowserType.GetMethod("ShowDialog", Type.EmptyTypes);
                    var result = showDialogMethod?.Invoke(instance, null);
                    if (result?.ToString() == "OK" || result?.ToString() == "1")
                    {
                        var selectedPath = folderBrowserType.GetProperty("SelectedPath")?.GetValue(instance) as string;
                        if (!string.IsNullOrWhiteSpace(selectedPath))
                        {
                            Directory = selectedPath!;
                            if (string.IsNullOrWhiteSpace(Name))
                            {
                                Name = System.IO.Path.GetFileName(selectedPath!.TrimEnd('\\', '/')) ?? "Directory";
                            }
                            TelemetryLogger.LogInfo($"Directory selected: '{Directory}'");
                            return;
                        }
                    }
                    else
                    {
                        TelemetryLogger.LogInfo("Folder browsing cancelled by user.");
                        return;
                    }
                }
            }

            // 2. Try Microsoft.Win32.OpenFolderDialog (.NET 8 WPF)
            var openFolderDialogType = Type.GetType("Microsoft.Win32.OpenFolderDialog, PresentationFramework");
            if (openFolderDialogType != null)
            {
                var instance = Activator.CreateInstance(openFolderDialogType);
                if (instance != null)
                {
                    openFolderDialogType.GetProperty("Title")?.SetValue(instance, "Select folder containing table spreadsheets (.xlsx, .xlsm, .xls, .csv)");
                    var showDialogMethod = openFolderDialogType.GetMethod("ShowDialog", Type.EmptyTypes);
                    var result = showDialogMethod?.Invoke(instance, null);
                    if (result is true)
                    {
                        var folderName = openFolderDialogType.GetProperty("FolderName")?.GetValue(instance) as string;
                        if (!string.IsNullOrWhiteSpace(folderName))
                        {
                            Directory = folderName!;
                            if (string.IsNullOrWhiteSpace(Name))
                            {
                                Name = System.IO.Path.GetFileName(folderName!.TrimEnd('\\', '/')) ?? "Directory";
                            }
                            TelemetryLogger.LogInfo($"Directory selected via OpenFolderDialog: '{Directory}'");
                            return;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error opening directory browser dialog", ex);
        }
    }

    [RelayCommand]
    private void Ok(object? window)
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            System.Windows.MessageBox.Show("Please enter a table source name.", "Validation Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
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

    public TableSourceItemModel ToModel(string? existingId = null)
    {
        return new TableSourceItemModel
        {
            Id = existingId ?? Guid.NewGuid().ToString(),
            Name = Name.Trim(),
            SourceType = ExternalTableSourceType.Directory,
            Path = Directory.Trim(),
            IsActive = IsActive
        };
    }
}
