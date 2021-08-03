using TaskManager.Services.Models;
using TaskManager.Services.Models.Process;
using TaskManager.Services.Models.Process.DecoratedProcesses;

namespace TaskManager.Services.Factories.Process
{
    internal interface IProcessFactory
    {
        IComparableProcess Construct(IProcess process, SortOption sortOption);
        IProcess Construct(Priority priority, string groupName);

    }
}
