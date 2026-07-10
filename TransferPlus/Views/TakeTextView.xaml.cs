using System.Windows;

namespace TransferPlus.Views;

public partial class TakeTextView : Window
{
    public static string texto_out = "";
    public static bool cancelado = false;

    public TakeTextView()
    {
        InitializeComponent();
        texto_out = "";
        cancelado = true;
    }

    private void Ok_Click(object sender, RoutedEventArgs e)
    {
        texto_out = InputTextBox.Text;
        cancelado = false;
        DialogResult = true;
        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        cancelado = true;
        DialogResult = false;
        Close();
    }
}
