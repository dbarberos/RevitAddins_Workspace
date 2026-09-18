using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TransferPlus.Models;

namespace TransferPlus.ViewModels
{
    public partial class LevelMappingViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<LevelConflict> _conflicts = new();

        public LevelMappingViewModel(System.Collections.Generic.IEnumerable<LevelConflict> conflicts)
        {
            Conflicts = new ObservableCollection<LevelConflict>(conflicts);
        }

        [RelayCommand]
        private void Apply(object parameter)
        {
            if (parameter is Window window)
            {
                window.DialogResult = true;
                window.Close();
            }
        }

        [RelayCommand]
        private void Cancel(object parameter)
        {
            if (parameter is Window window)
            {
                window.DialogResult = false;
                window.Close();
            }
        }
    }
}
