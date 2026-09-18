using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TransferPlus.Models;

namespace TransferPlus.ViewModels;

public partial class CadSourceTypeViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isAutodeskDocsSelected = true;

    [ObservableProperty]
    private bool _isAzureStorageSelected;

    [ObservableProperty]
    private bool _isAwsS3Selected;

    [ObservableProperty]
    private bool _isDirectorySelected;

    public CadSourceType SelectedSourceType
    {
        get
        {
            if (IsAutodeskDocsSelected) return CadSourceType.AutodeskDocs;
            if (IsAzureStorageSelected) return CadSourceType.AzureStorage;
            if (IsAwsS3Selected) return CadSourceType.AwsS3;
            return CadSourceType.Directory;
        }
        set
        {
            IsAutodeskDocsSelected = (value == CadSourceType.AutodeskDocs);
            IsAzureStorageSelected = (value == CadSourceType.AzureStorage);
            IsAwsS3Selected = (value == CadSourceType.AwsS3);
            IsDirectorySelected = (value == CadSourceType.Directory);
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
