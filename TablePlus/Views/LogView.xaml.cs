using System.Windows;

namespace TablePlus.Views;

public partial class LogView : Window
{
    public bool AllowClose { get; set; }

    public LogView()
    {
        InitializeComponent();
        Closing += OnClosing;
    }

    private void OnClosing(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        if (!AllowClose)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
