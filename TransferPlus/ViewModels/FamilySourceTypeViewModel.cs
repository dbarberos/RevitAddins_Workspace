using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TransferPlus.Models;

namespace TransferPlus.ViewModels;

public partial class FamilySourceTypeViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isDirectorySelected = true;

    [ObservableProperty]
    private bool _isAzureStorageSelected;

    public FamilySourceType SelectedSourceType
    {
        get => IsDirectorySelected ? FamilySourceType.Directory : FamilySourceType.AzureStorage;
        set
        {
            if (value == FamilySourceType.Directory)
            {
                IsDirectorySelected = true;
                IsAzureStorageSelected = false;
            }
            else
            {
                IsDirectorySelected = false;
                IsAzureStorageSelected = true;
            }
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
