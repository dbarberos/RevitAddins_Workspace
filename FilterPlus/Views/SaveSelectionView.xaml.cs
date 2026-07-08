using System.Windows;
using FilterPlus.ViewModels;

namespace FilterPlus.Views
{
    public partial class SaveSelectionView : Window
    {
        public SaveSelectionView(SaveSelectionViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
