using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TablePlus.Models;

namespace TablePlus.ViewModels;

public partial class TableSourceTypeViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isAutodeskDocsSelected = true;

    [ObservableProperty]
    private bool _isAzureStorageSelected;

    [ObservableProperty]
    private bool _isAwsS3Selected;

    [ObservableProperty]
    private bool _isDirectorySelected;

    public ExternalTableSourceType SelectedSourceType
    {
        get
        {
            if (IsAutodeskDocsSelected) return ExternalTableSourceType.AutodeskDocs;
            if (IsAzureStorageSelected) return ExternalTableSourceType.AzureStorage;
            if (IsAwsS3Selected) return ExternalTableSourceType.AwsS3;
            return ExternalTableSourceType.Directory;
        }
        set
        {
            IsAutodeskDocsSelected = (value == ExternalTableSourceType.AutodeskDocs);
            IsAzureStorageSelected = (value == ExternalTableSourceType.AzureStorage);
            IsAwsS3Selected = (value == ExternalTableSourceType.AwsS3);
            IsDirectorySelected = (value == ExternalTableSourceType.Directory);
        }
    }

    [ObservableProperty]
    private bool? _dialogResult;

    [RelayCommand]
    private void Ok(object? window)
    {
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
}
