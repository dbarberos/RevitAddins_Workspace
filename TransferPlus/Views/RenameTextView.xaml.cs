using System.Windows;

namespace TransferPlus.Views;

public partial class RenameTextView : Window
{
    public static string textofind_out = "";
    public static string textoreplace_out = "";
    public static bool usaregex = false;
    public static bool cancelado = false;

    public RenameTextView()
    {
        InitializeComponent();
        textofind_out = "";
        textoreplace_out = "";
        usaregex = false;
        cancelado = true;
    }

    private void Ok_Click(object sender, RoutedEventArgs e)
    {
        textofind_out = FindTextBox.Text;
        textoreplace_out = ReplaceTextBox.Text;
        usaregex = RegexCheckBox.IsChecked == true;
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
