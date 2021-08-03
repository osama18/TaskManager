using System;
using TaskManager.Models.Process;
using TaskManager.Services.Models;
using TaskManager.Services.Models.Process;
using TaskManager.Services.Models.Process.DecoratedProcesses;

namespace TaskManager.Services.Factories.Process
{
    internal class ProcessFactory : IProcessFactory
    {
        public IComparableProcess Construct(ProcessDto process, SortOption sortOption)
        {
            switch (sortOption)
            {
                case SortOption.ByCreationTime:
                    return new CreationDateComparableProcess(process);
                case SortOption.ById:
                    return new PIDComparableProcess(process);
                case SortOption.ByPriority:
                    return new PriorityComparableProcess(process);
            }
            throw new NotImplementedException();
        }

        public IProcess Construct(Priority priority, string groupName)
        {
            return new ConcreteProcess(0,priority, groupName, DateTime.UtcNow);
        }
    }
}
