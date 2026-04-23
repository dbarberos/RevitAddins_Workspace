using System.Windows;
using FilterPlus.ViewModels;

namespace FilterPlus.Views;

public partial class SelectionFilterView : Window
{
    public SelectionFilterView(SelectionFilterViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
