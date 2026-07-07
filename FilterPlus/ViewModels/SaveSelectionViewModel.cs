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
            ExistingSelections = new ObservableCollection<SavedSelection>(existingSelections);
            _onSaveNew = onSaveNew;
            _onOverwrite = onOverwrite;
            _onCancel = onCancel;
        }

        [RelayCommand]
        private void SaveNew(object windowObj)
        {
            if (!IsNewNameValid) return;

            TaskDialogResult res = TaskDialog.Show("FilterPlus", "Save the Selection?", TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No);
            if (res == TaskDialogResult.Yes)
            {
                _onSaveNew?.Invoke(NewSelectionName.Trim());
                CloseWindow(windowObj);
            }
        }

        [RelayCommand]
        private void Overwrite(object windowObj)
        {
            if (!IsExistingSelectionSelected) return;

            TaskDialogResult res = TaskDialog.Show("FilterPlus", "Save the Selection?", TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No);
            if (res == TaskDialogResult.Yes)
            {
                _onOverwrite?.Invoke(SelectedExistingSelection);
                CloseWindow(windowObj);
            }
        }

        [RelayCommand]
        private void Cancel(object windowObj)
        {
            _onCancel?.Invoke();
            CloseWindow(windowObj);
        }

        private void CloseWindow(object windowObj)
        {
            if (windowObj is Window win)
            {
                win.Close();
            }
        }
    }
}
