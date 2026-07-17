using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using TransferPlus.ViewModels;

namespace TransferPlus.Views;

public partial class NumberingSettingsView : Window
{
    public NumberingSettingsView(TransferPlusViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
        try
        {
            if (System.Windows.Application.Current != null)
            {
                var activeWindow = System.Windows.Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
                if (activeWindow != null)
                {
                    Owner = activeWindow;
                }
                else
                {
                    Owner = System.Windows.Application.Current.MainWindow;
                }
            }
        }
        catch
        {
            // Fail-safe: do not crash if Owner cannot be bound in Revit
        }
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

    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }

    private void LetterValidationTextBox(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^a-zA-Z]+");
        e.Handled = regex.IsMatch(e.Text);
    }
}
