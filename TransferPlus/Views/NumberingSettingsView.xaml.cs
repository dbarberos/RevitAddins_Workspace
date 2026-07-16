using System.Windows;
using TransferPlus.ViewModels;

namespace TransferPlus.Views;

public partial class NumberingSettingsView : Window
{
    public NumberingSettingsView(TransferPlusViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
        Owner = System.Windows.Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive) ?? System.Windows.Application.Current.MainWindow;
    }

    private void Accept_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}
