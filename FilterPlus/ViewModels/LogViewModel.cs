using CommunityToolkit.Mvvm.ComponentModel;
using FilterPlus.Services;
using System.Collections.ObjectModel;

namespace FilterPlus.ViewModels;

public partial class LogViewModel : ObservableObject
{
    public ObservableCollection<string> Logs => LoggerService.Logs;

    public LogViewModel()
    {
    }
}
