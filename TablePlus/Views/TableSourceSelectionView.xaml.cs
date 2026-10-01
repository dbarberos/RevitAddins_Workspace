using System;
using System.Windows;
using TablePlus.ViewModels;

namespace TablePlus.Views;

/// <summary>
/// Interaction logic for TableSourceSelectionView.xaml.
/// Compact intermediate modal dialog allowing the user to pick a table source (Local or Cloud)
/// and navigate files before opening the "Add Table" configuration wizard.
/// </summary>
public partial class TableSourceSelectionView : Window
{
    private readonly TableSourceSelectionViewModel _viewModel;

    public TableSourceSelectionView(TableSourceSelectionViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        DataContext = _viewModel;

        _viewModel.RequestClose = () =>
        {
            DialogResult = _viewModel.ResultFilePaths.Count > 0;
            Close();
        };
    }
}
