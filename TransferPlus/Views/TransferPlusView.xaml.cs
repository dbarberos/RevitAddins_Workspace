using System.Windows;
using TransferPlus.ViewModels;

namespace TransferPlus.Views;

public partial class TransferPlusView : Window
{
    public TransferPlusView(TransferPlusViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}