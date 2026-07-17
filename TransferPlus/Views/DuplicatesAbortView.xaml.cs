using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace TransferPlus.Views
{
    public partial class DuplicatesAbortView : Window
    {
        private List<string> _duplicateNames;

        public DuplicatesAbortView(List<string> duplicateNames)
        {
            InitializeComponent();
            _duplicateNames = duplicateNames;
            DuplicatesDataGrid.ItemsSource = _duplicateNames;

            // Safe Owner Resolution
            try
            {
                if (System.Windows.Application.Current != null)
                {
                    var activeWindow = System.Windows.Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
                    Owner = activeWindow ?? System.Windows.Application.Current.MainWindow;
                }
            }
            catch
            {
                // Fallback startup location
            }
        }

        private void CopySelected_Click(object sender, RoutedEventArgs e)
        {
            var selected = DuplicatesDataGrid.SelectedItems.Cast<string>().ToList();
            if (selected.Any())
            {
                try
                {
                    Clipboard.SetText(string.Join(Environment.NewLine, selected));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to copy to clipboard: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CopyAll_Click(object sender, RoutedEventArgs e)
        {
            if (_duplicateNames.Any())
            {
                try
                {
                    Clipboard.SetText(string.Join(Environment.NewLine, _duplicateNames));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to copy to clipboard: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
