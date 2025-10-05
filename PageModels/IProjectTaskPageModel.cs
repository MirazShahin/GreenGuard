using CommunityToolkit.Mvvm.Input;
using GreenGuard.Models;

namespace GreenGuard.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}