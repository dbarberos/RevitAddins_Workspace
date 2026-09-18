using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TransferPlus.Models;
using TransferPlus.ViewModels;

namespace TransferPlus.Views
{
    public partial class LevelMappingView : Window
    {
        public LevelMappingView(IEnumerable<LevelConflict> conflicts)
        {
            InitializeComponent();
            DataContext = new LevelMappingViewModel(conflicts);

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
    }
}
