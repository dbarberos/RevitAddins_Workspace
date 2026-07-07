using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FilterPlus.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using Autodesk.Revit.UI;

namespace FilterPlus.ViewModels
{
    public partial class SaveSelectionViewModel : ObservableObject
    {
        private readonly Action<string> _onSaveNew;
        private readonly Action<SavedSelection> _onOverwrite;
        private readonly Action _onCancel;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNewNameValid))]
        private string _newSelectionName = string.Empty;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsExistingSelectionSelected))]
        private SavedSelection _selectedExistingSelection;

        public ObservableCollection<SavedSelection> ExistingSelections { get; }

        public bool IsNewNameValid => !string.IsNullOrWhiteSpace(NewSelectionName);
        public bool IsExistingSelectionSelected => SelectedExistingSelection != null;

        public SaveSelectionViewModel(
            System.Collections.Generic.List<SavedSelection> existingSelections,
            Action<string> onSaveNew,
            Action<SavedSelection> onOverwrite,
            Action onCancel)
        {
            FilterPlus.Services.LoggerService.LogInfo($"SaveSelectionViewModel: Initializing. Existing selections: {existingSelections?.Count ?? 0}.");
            ExistingSelections = new ObservableCollection<SavedSelection>(existingSelections);
            _onSaveNew = onSaveNew;
            _onOverwrite = onOverwrite;
            _onCancel = onCancel;
        }

        [RelayCommand]
        private void SaveNew(object windowObj)
        {
            FilterPlus.Services.LoggerService.LogInfo($"SaveSelectionViewModel: SaveNew clicked. NewSelectionName: '{NewSelectionName}'. Valid? {IsNewNameValid}");
            if (!IsNewNameValid) return;

            FilterPlus.Services.LoggerService.LogInfo("SaveSelectionViewModel: Showing confirmation dialog...");
            
            var ownerWin = windowObj as Window;
            var res = System.Windows.MessageBox.Show(
                ownerWin,
                "Save the Selection?", 
                "FilterPlus", 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Question);
                
            FilterPlus.Services.LoggerService.LogInfo($"SaveSelectionViewModel: Confirmation result: {res}");
            if (res == MessageBoxResult.Yes)
            {
                FilterPlus.Services.LoggerService.LogInfo($"SaveSelectionViewModel: Invoking _onSaveNew callback for '{NewSelectionName}'...");
                _onSaveNew?.Invoke(NewSelectionName.Trim());
                CloseWindow(windowObj);
            }
        }

        [RelayCommand]
        private void Overwrite(object windowObj)
        {
            FilterPlus.Services.LoggerService.LogInfo($"SaveSelectionViewModel: Overwrite clicked. SelectedExistingSelection: '{SelectedExistingSelection?.Name}'. Valid? {IsExistingSelectionSelected}");
            if (!IsExistingSelectionSelected) return;

            FilterPlus.Services.LoggerService.LogInfo("SaveSelectionViewModel: Showing confirmation dialog...");
            
            var ownerWin = windowObj as Window;
            var res = System.Windows.MessageBox.Show(
                ownerWin,
                "Save the Selection?", 
                "FilterPlus", 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Question);
                
            FilterPlus.Services.LoggerService.LogInfo($"SaveSelectionViewModel: Confirmation result: {res}");
            if (res == MessageBoxResult.Yes)
            {
                FilterPlus.Services.LoggerService.LogInfo($"SaveSelectionViewModel: Invoking _onOverwrite callback for '{SelectedExistingSelection?.Name}'...");
                _onOverwrite?.Invoke(SelectedExistingSelection);
                CloseWindow(windowObj);
            }
        }

        [RelayCommand]
        private void Cancel(object windowObj)
        {
            FilterPlus.Services.LoggerService.LogInfo("SaveSelectionViewModel: Cancel clicked.");
            _onCancel?.Invoke();
            CloseWindow(windowObj);
        }

        private void CloseWindow(object windowObj)
        {
            FilterPlus.Services.LoggerService.LogInfo($"SaveSelectionViewModel: CloseWindow requested. Parameter type: {windowObj?.GetType().Name ?? "null"}");
            if (windowObj is Window win)
            {
                FilterPlus.Services.LoggerService.LogInfo("SaveSelectionViewModel: Closing window...");
                win.Close();
                FilterPlus.Services.LoggerService.LogInfo("SaveSelectionViewModel: Window closed.");
            }
            else
            {
                FilterPlus.Services.LoggerService.LogInfo("SaveSelectionViewModel: WARNING - Could not close window because parameter was not a valid Window instance. Attempting alternative closure...");
                if (System.Windows.Application.Current != null)
                {
                    foreach (Window w in System.Windows.Application.Current.Windows)
                    {
                        if (w is Views.SaveSelectionView)
                        {
                            FilterPlus.Services.LoggerService.LogInfo("SaveSelectionViewModel: Found SaveSelectionView in Application.Current.Windows. Closing it.");
                            w.Close();
                            return;
                        }
                    }
                }
            }
        }
    }
}
