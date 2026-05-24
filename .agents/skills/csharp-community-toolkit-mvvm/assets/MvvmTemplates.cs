using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MvvmToolkitTemplates
{
    // ==========================================
    // 1. DI HOST SETUP (App.xaml.cs equivalent)
    // ==========================================
    public static class Bootstrapper
    {
        public static IServiceProvider Services { get; private set; }

        public static void Initialize()
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    // Register ViewModels
                    services.AddTransient<BaseViewModelTemplate>();
                    services.AddTransient<MessengerViewModelTemplate>();
                })
                .Build();

            Services = host.Services;
        }
    }

    // ==========================================
    // 2. CORE VIEWMODEL TEMPLATE
    // ==========================================
    public partial class BaseViewModelTemplate : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FullName))]
        [NotifyCanExecuteChangedFor(nameof(SaveDataCommand))]
        private string _firstName = string.Empty;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FullName))]
        [NotifyCanExecuteChangedFor(nameof(SaveDataCommand))]
        private string _lastName = string.Empty;

        public string FullName => $"{FirstName} {LastName}";

        private bool CanSave() => !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName);

        [RelayCommand(CanExecute = nameof(CanSave))]
        private async Task SaveDataAsync()
        {
            await Task.Delay(500); // Simulate work
            // Broadcast success
            WeakReferenceMessenger.Default.Send(new NotificationMessage("Data saved successfully!"));
        }
    }

    // ==========================================
    // 3. MESSENGER & RECIPIENT TEMPLATE
    // ==========================================
    
    // Message definition
    public record NotificationMessage(string Text);

    // Recipient ViewModel
    public partial class MessengerViewModelTemplate : ObservableRecipient, IRecipient<NotificationMessage>
    {
        [ObservableProperty]
        private string _lastNotification = string.Empty;

        public MessengerViewModelTemplate()
        {
            // Activate the recipient to listen to registered messages
            IsActive = true;
        }

        public void Receive(NotificationMessage message)
        {
            LastNotification = message.Text;
        }

        // Cleanup when view is destroyed (optional but good practice)
        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
