using System.Windows;
using FilterPlus.ViewModels;

namespace FilterPlus.Views;

public partial class SelectionFilterView : Window
{
    private LogView _logView;

    public SelectionFilterView(SelectionFilterViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;

        // Register dispatcher for logging
        FilterPlus.Services.LoggerService.SetDispatcher(this.Dispatcher);

        _logView = new LogView();
        _logView.Show();
        
        this.Closed += (s, e) => _logView.Close();
    }
}
