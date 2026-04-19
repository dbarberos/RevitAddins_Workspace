using System.Windows;
using PrimeraPrueba.ViewModels;

namespace PrimeraPrueba.Views;

public partial class SelectionFilterView : Window
{
    public SelectionFilterView(SelectionFilterViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
