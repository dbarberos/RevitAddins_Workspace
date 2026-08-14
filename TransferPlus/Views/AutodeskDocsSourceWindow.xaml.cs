using System.Windows;
using System.Windows.Controls;
using TransferPlus.ViewModels;

namespace TransferPlus.Views;

public partial class AutodeskDocsSourceWindow : Window
{
    public AutodeskDocsSourceWindow()
    {
        InitializeComponent();
    }

    private async void TreeView_ItemExpanded(object sender, RoutedEventArgs e)
    {
        if (e.OriginalSource is TreeViewItem item && item.DataContext is AccTreeNodeModel node)
        {
            if (DataContext is AutodeskDocsSourceViewModel vm)
            {
                await vm.OnNodeExpandedAsync(node);
            }
        }
    }

    private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        if (e.NewValue is AccTreeNodeModel node)
        {
            if (DataContext is AutodeskDocsSourceViewModel vm)
            {
                vm.OnNodeSelected(node);
            }
        }
    }
}
