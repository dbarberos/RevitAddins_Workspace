using System.Windows;
using FilterPlus.ViewModels;

namespace FilterPlus.Views;

public partial class PreSelectionView : Window
{
    public PreSelectionView(PreSelectionViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
