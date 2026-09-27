using System.Windows;
using TablePlus.Models;

namespace TablePlus.Views;

/// <summary>
/// Interaction logic for ConfirmTableDeleteWindow.xaml.
/// Modal dialog displaying table deletion scope before permanently removing views from the active Revit model.
/// Matches the TransferPlus deletion confirmation dialog standard.
/// </summary>
public partial class ConfirmTableDeleteWindow : Window
{
    public ConfirmTableDeleteWindow(List<TableItemModel> confirmationList)
    {
        InitializeComponent();
        TablesListView.ItemsSource = confirmationList ?? new List<TableItemModel>();
        int count = confirmationList?.Count ?? 0;
        SummaryTextBlock.Text = count == 1
            ? "Total: 1 table will be permanently deleted from Revit."
            : $"Total: {count} tables will be permanently deleted from Revit.";
        ResolveOwner();
    }

    private void ResolveOwner()
    {
        try
        {
            if (System.Windows.Application.Current != null)
            {
                var activeWindow = System.Windows.Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w != this && w.IsActive);
                Owner = activeWindow ?? System.Windows.Application.Current.MainWindow;
            }
        }
        catch
        {
            // Silently fallback if host window cannot be resolved
        }
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }

    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
        Close();
    }
}
