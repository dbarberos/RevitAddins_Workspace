# Dependency Injection (DI) with MVVM Toolkit

Integrating `CommunityToolkit.Mvvm` ViewModels with `Microsoft.Extensions.DependencyInjection` creates a clean, decoupled architecture.

## 1. The Generic Host Setup
Use `Microsoft.Extensions.Hosting` to configure the DI container inside the entry point (e.g., `App.xaml.cs`).

```csharp
public partial class App : Application
{
    public static IServiceProvider Services { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                // Register Services (Singletons)
                services.AddSingleton<IDataService, DataService>();
                
                // Register ViewModels (Transient for multiple instances, Singleton for shared state)
                services.AddTransient<MainViewModel>();
                services.AddTransient<SettingsViewModel>();
            })
            .Build();

        Services = host.Services;
        
        // Resolve entry point
        var mainView = new MainWindow { DataContext = Services.GetRequiredService<MainViewModel>() };
        mainView.Show();
    }
}
```

## 2. Constructor Injection
ViewModels automatically receive dependencies registered in the DI container.

```csharp
public partial class MainViewModel : ObservableObject
{
    private readonly IDataService _dataService;

    // Dependency is injected automatically
    public MainViewModel(IDataService dataService)
    {
        _dataService = dataService;
    }

    [RelayCommand]
    private async Task LoadAsync()
    {
        var data = await _dataService.GetDataAsync();
    }
}
```

## 3. Resolving ViewModels in Views (XAML Behind)
If the view needs to resolve its ViewModel (e.g., Pages in a Navigation app), do it via the static `Services` provider.

```csharp
public partial class SettingsPage : Page
{
    public SettingsPage()
    {
        InitializeComponent();
        DataContext = App.Services.GetRequiredService<SettingsViewModel>();
    }
}
```
