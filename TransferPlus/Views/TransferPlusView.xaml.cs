using System.Windows;
using TransferPlus.ViewModels;

namespace TransferPlus.Views;

public partial class TransferPlusView : Window
{
    public TransferPlusView(TransferPlusViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    private void CloseRegexPopup(object sender, RoutedEventArgs e)
    {
        BtnRegexHelper.IsChecked = false;
    }

    private void CloseDatePopup(object sender, RoutedEventArgs e)
    {
        BtnDateHelper.IsChecked = false;
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