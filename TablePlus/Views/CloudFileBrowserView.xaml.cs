using System;
using System.Windows;
using TablePlus.ViewModels;

namespace TablePlus.Views;

public partial class CloudFileBrowserView : Window
{
    private readonly CloudFileBrowserViewModel _viewModel;

    public CloudFileBrowserView(CloudFileBrowserViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        DataContext = _viewModel;

        _viewModel.RequestClose = () =>
        {
            DialogResult = _viewModel.DownloadedFilePaths.Count > 0;
            Close();
        };
    }
}
