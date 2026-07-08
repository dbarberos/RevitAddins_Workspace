using System.Windows;
using FilterPlus.ViewModels;

namespace FilterPlus.Views;

public partial class ModelSelectionView : Window
{
    public ModelSelectionView(ModelSelectionViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
