using CommunityToolkit.Mvvm.ComponentModel;
using TransferPlus.Services;
using System.Collections.ObjectModel;

namespace TransferPlus.ViewModels;

public partial class LogViewModel : ObservableObject
{
    public ObservableCollection<string> Logs => LoggerService.Logs;

    public LogViewModel()
    {
    }
}
