using System.Windows;
using TransferPlus.ViewModels;

namespace TransferPlus.Views;

public partial class TransferPlusView : Window
{
    private LogView? _logView;
    private bool _isClosing = false;

    public TransferPlusView(TransferPlusViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;

        // Set dispatcher for secure logger updates
        TransferPlus.Services.LoggerService.SetDispatcher(this.Dispatcher);

        // Register action delegate for ConfigurationViewModel toggle debug window button
        ConfigurationViewModel.ToggleDebugWindowAction = () =>
        {
            this.Dispatcher.Invoke(() =>
            {
                ToggleDebugLogWindow();
            });
        };

        this.Loaded += TransferPlusView_Loaded;
        this.Closed += TransferPlusView_Closed;
    }

    private void TransferPlusView_Loaded(object sender, RoutedEventArgs e)
    {
        this.Loaded -= TransferPlusView_Loaded;
        try
        {
            CreateAndPrepareLogView();

#if DEBUG
            _logView?.Show();
#endif
        }
        catch (System.Exception ex)
        {
            TransferPlus.Services.LoggerService.LogError("LogView Open", ex);
        }
    }

    private void CreateAndPrepareLogView()
    {
        if (_logView != null) return;

        _logView = new LogView();
        _logView.Owner = this;
        _logView.Closing += (s, e) =>
        {
            if (!_isClosing)
            {
                e.Cancel = true;
                _logView.Hide();
            }
        };
    }

    private void TransferPlusView_Closed(object? sender, System.EventArgs e)
    {
        _isClosing = true;
        if (_logView != null)
        {
            try
            {
                _logView.Close();
            }
            catch { }
        }
    }

    public void ToggleDebugLogWindow()
    {
        try
        {
            if (_logView == null)
            {
                CreateAndPrepareLogView();
            }

            if (_logView != null)
            {
                if (_logView.IsVisible)
                {
                    _logView.Hide();
                }
                else
                {
                    _logView.Show();
                    _logView.Activate();
                }
            }
        }
        catch
        {
            // Recreate if window object state was destroyed
            _logView = null;
            CreateAndPrepareLogView();
            _logView?.Show();
            _logView?.Activate();
        }
    }

    private void CloseRegexPopup(object sender, RoutedEventArgs e)
    {
        BtnRegexHelper.IsChecked = false;
    }

    private void CloseFilterRegexPopup(object sender, RoutedEventArgs e)
    {
        BtnFilterRegexHelper.IsChecked = false;
    }

    private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        if (DataContext is TransferPlusViewModel vm && e.NewValue is TreeItemViewModel selectedNode)
        {
            if (selectedNode.Item is Models.FamilyItemModel famItem)
            {
                vm.SelectedFamily = famItem;
                vm.SelectedSymbol = null;
            }
            else if (selectedNode.Item is Models.FamilySymbolItemModel symItem && selectedNode.Parent?.Item is Models.FamilyItemModel parentFam)
            {
                vm.SelectedFamily = parentFam;
                vm.SelectedSymbol = symItem;
            }
            else
            {
                vm.SelectedFamily = null;
                vm.SelectedSymbol = null;
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