using System.Windows;

namespace TransferPlus.Views;

public partial class RenameTextView : Window
{
    public string TextoFindOut { get; private set; } = string.Empty;
    public string TextoReplaceOut { get; private set; } = string.Empty;
    public bool UsaRegex { get; private set; } = false;
    public bool Cancelado { get; private set; } = true;

    public RenameTextView()
    {
        InitializeComponent();
    }

    private void Ok_Click(object sender, RoutedEventArgs e)
    {
        TextoFindOut = FindTextBox.Text;
        TextoReplaceOut = ReplaceTextBox.Text;
        UsaRegex = RegexCheckBox.IsChecked == true;
        Cancelado = false;
        DialogResult = true;
        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        Cancelado = true;
        DialogResult = false;
        Close();
    }
}
