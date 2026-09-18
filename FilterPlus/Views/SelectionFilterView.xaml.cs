using System.Windows;
using FilterPlus.ViewModels;

namespace FilterPlus.Views;

public partial class SelectionFilterView : Window
{
#if DEBUG
    private LogView _logView;
#endif

    public SelectionFilterView(SelectionFilterViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;

        // Register dispatcher for logging
        FilterPlus.Services.LoggerService.SetDispatcher(this.Dispatcher);

        viewModel.HideWindowRequested = this.Hide;
        viewModel.ShowWindowRequested = this.Show;

#if DEBUG
        _logView = new LogView();
        _logView.Show();
        this.Closed += (s, e) => _logView?.Close();
#endif
    }
}
