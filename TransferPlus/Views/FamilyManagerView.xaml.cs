using System.Windows;
using TransferPlus.ViewModels;

namespace TransferPlus.Views
{
    /// <summary>
    /// Lógica de interacción para FamilyManagerView.xaml.
    /// Diseñado bajo MVVM estricto: la vista solo se vincula al ViewModel a través de DataContext.
    /// </summary>
    public partial class FamilyManagerView : Window
    {
        public FamilyManagerView()
        {
            InitializeComponent();
            DataContext = new FamilyManagerViewModel();
        }

        public FamilyManagerView(FamilyManagerViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
