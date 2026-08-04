using System.Windows;
using TransferPlus.ViewModels;

namespace TransferPlus.Views;

public partial class TransferPlusView : Window
{
    private LogView _logView;

    public TransferPlusView(TransferPlusViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;

        // Set dispatcher for secure logger updates
        TransferPlus.Services.LoggerService.SetDispatcher(this.Dispatcher);

        this.Loaded += TransferPlusView_Loaded;
    }

    private void TransferPlusView_Loaded(object sender, RoutedEventArgs e)
    {
        this.Loaded -= TransferPlusView_Loaded;
        // UNCOMMENT FOR DEVELOPMENT/DEBUGGING
#if DEBUG
        try
        {
            _logView = new LogView();
            _logView.Owner = this; // Safe now because the parent window is shown
            _logView.Show();
            this.Closed += (s, e) => _logView.Close();
        }
        catch (System.Exception ex)
        {
            TransferPlus.Services.LoggerService.LogError("LogView Open", ex);
        }
#endif
    }

    private void CloseRegexPopup(object sender, RoutedEventArgs e)
    {
        BtnRegexHelper.IsChecked = false;
    }

    private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        if (DataContext is TransferPlusViewModel vm && e.NewValue is TreeItemViewModel selectedNode)
        {
            if (selectedNode.Level == 2 && selectedNode.Category == "Family" && selectedNode.Item is Models.FamilyItemModel famItem)
            {
                vm.SelectedFamily = famItem;
            }
            else
            {
                vm.SelectedFamily = null;
            }
        }
    }

    private void CloseDatePopup(object sender, RoutedEventArgs e)
    {
        BtnDateHelper.IsChecked = false;
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}

public class NegativeConverter : System.Windows.Data.IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value is double d) return -d;
        return 0;
    }
    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value is double d) return -d;
        return 0;
    }
}