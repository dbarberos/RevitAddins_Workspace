// ==========================================
// GenericHost App.xaml.cs DI Registration
// ==========================================
public partial class App : Application
{
    private static readonly IHost _host = Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            // Wpf.Ui Services
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<ISnackbarService, SnackbarService>();
            services.AddSingleton<IContentDialogService, ContentDialogService>();
            services.AddSingleton<IThemeService, ThemeService>();

            // Windows
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainWindowViewModel>();

            // Pages (Transient for navigation)
            services.AddTransient<HomePage>();
            services.AddTransient<HomeViewModel>();
            services.AddTransient<SettingsPage>();
            services.AddTransient<SettingsViewModel>();
        })
        .Build();

    protected override async void OnStartup(StartupEventArgs e)
    {
        await _host.StartAsync();

        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await _host.StopAsync();
        _host.Dispose();
        base.OnExit(e);
    }
}

// ==========================================
// MainWindow.xaml.cs Service Initialization
// ==========================================
public partial class MainWindow : FluentWindow
{
    public MainWindow(
        MainWindowViewModel viewModel,
        INavigationService navigationService,
        ISnackbarService snackbarService,
        IContentDialogService contentDialogService)
    {
        DataContext = viewModel;
        InitializeComponent();

        // Wire Wpf.Ui controls to their services
        navigationService.SetNavigationControl(RootNavigation);
        snackbarService.SetSnackbarPresenter(RootSnackbar);
        contentDialogService.SetDialogHost(RootContentDialog);
    }
}

// ==========================================
// Page Implementation
// ==========================================
// Page implements ui:INavigableView<TViewModel>
public partial class HomePage : Page, INavigableView<HomeViewModel>
{
    public HomeViewModel ViewModel { get; }

    public HomePage(HomeViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = viewModel;
        InitializeComponent();
    }
}
