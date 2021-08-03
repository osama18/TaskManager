using System;
using TaskManager.Models.Process;
using TaskManager.Services.Models;
using TaskManager.Services.Models.Process;
using TaskManager.Services.Models.Process.DecoratedProcesses;

namespace TaskManager.Services.Factories.Process
{
    internal interface IProcessFactory
    {
        IComparableProcess Construct(ProcessDto process, SortOption sortOption);
        IProcess Construct(Priority priority, string groupName);

    }
}
