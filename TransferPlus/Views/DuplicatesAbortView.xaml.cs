using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TransferPlus.Models;

namespace TransferPlus.Views
{
    public partial class DuplicatesAbortView : Window
    {
        private List<DuplicateElementInfo> _duplicateItems;

        public DuplicatesAbortView(List<DuplicateElementInfo> duplicateItems)
        {
            InitializeComponent();
            _duplicateItems = duplicateItems ?? new List<DuplicateElementInfo>();
            DuplicatesDataGrid.ItemsSource = _duplicateItems;
            ResolveOwner();
        }

        public DuplicatesAbortView(List<string> duplicateNames)
        {
            InitializeComponent();
            _duplicateItems = (duplicateNames ?? new List<string>())
                .Select(s => ParseStringToDuplicateInfo(s))
                .ToList();
            DuplicatesDataGrid.ItemsSource = _duplicateItems;
            ResolveOwner();
        }

        private static DuplicateElementInfo ParseStringToDuplicateInfo(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return new DuplicateElementInfo();

            if (str.Contains(":"))
            {
                var parts = str.Split(new[] { ':' }, 2);
                return new DuplicateElementInfo("General", "Standard", parts[0].Trim(), parts[1].Trim());
            }
            return new DuplicateElementInfo("General", "Standard", "Element", str.Trim());
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

        private void CopySelected_Click(object sender, RoutedEventArgs e)
        {
            var selected = DuplicatesDataGrid.SelectedItems.Cast<DuplicateElementInfo>().ToList();
            if (selected.Any())
            {
                try
                {
                    string text = string.Join(Environment.NewLine, selected.Select(i => $"{i.Categoria}\t{i.Familia}\t{i.Clase}\t{i.Nombre}"));
                    Clipboard.SetText(text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to copy to clipboard: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CopyAll_Click(object sender, RoutedEventArgs e)
        {
            if (_duplicateItems != null && _duplicateItems.Any())
            {
                try
                {
                    string text = string.Join(Environment.NewLine, _duplicateItems.Select(i => $"{i.Categoria}\t{i.Familia}\t{i.Clase}\t{i.Nombre}"));
                    Clipboard.SetText(text);
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
