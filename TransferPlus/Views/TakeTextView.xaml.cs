using System.Windows;

namespace TransferPlus.Views;

public partial class TakeTextView : Window
{
    public string TextoOut { get; private set; } = string.Empty;
    public bool Cancelado { get; private set; } = true;

    public TakeTextView()
    {
        InitializeComponent();
    }

    private void Ok_Click(object sender, RoutedEventArgs e)
    {
        TextoOut = InputTextBox.Text;
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
