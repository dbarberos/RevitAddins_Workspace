using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TransferPlus.Models;

namespace TransferPlus.Views
{
    /// <summary>
    /// Interaction logic for ConfirmCadDeleteWindow.xaml.
    /// Modal dialog displaying hierarchical deletion scope before removing elements from the active Revit model.
    /// </summary>
    public partial class ConfirmCadDeleteWindow : Window
    {
        public ConfirmCadDeleteWindow(List<CadDeleteSheetGroup> confirmationTree, int totalItemsCount)
        {
            InitializeComponent();
            DeletionTreeView.ItemsSource = confirmationTree ?? new List<CadDeleteSheetGroup>();
            SummaryTextBlock.Text = totalItemsCount == 1
                ? "Total: 1 element to delete. Parent Sheets and Views will be preserved."
                : $"Total: {totalItemsCount} elements to delete. Parent Sheets and Views will be preserved.";
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
            catch { }
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
}
