using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TransferPlus.Models;

namespace TransferPlus.ViewModels;

public partial class FamilySourceTypeViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isAutodeskDocsSelected = true;

    [ObservableProperty]
    private bool _isAzureStorageSelected;

    [ObservableProperty]
    private bool _isDirectorySelected;

    public FamilySourceType SelectedSourceType
    {
        get
        {
            if (IsAutodeskDocsSelected) return FamilySourceType.AutodeskDocs;
            if (IsAzureStorageSelected) return FamilySourceType.AzureStorage;
            return FamilySourceType.Directory;
        }
        set
        {
            IsAutodeskDocsSelected = (value == FamilySourceType.AutodeskDocs);
            IsAzureStorageSelected = (value == FamilySourceType.AzureStorage);
            IsDirectorySelected = (value == FamilySourceType.Directory);
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
