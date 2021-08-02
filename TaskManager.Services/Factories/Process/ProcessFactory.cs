﻿using System;
using TaskManager.Services.Models;
using TaskManager.Services.Models.Process;
using TaskManager.Services.Models.Process.DecoratedProcesses;

namespace TaskManager.Services.Factories.Process
{
    public class ProcessFactory : IProcessFactory
    {
        public IComparableProcess Construct(IProcess process, SortOption sortOption)
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

        public IProcess Construct(long pID, Priority priority, string groupName)
        {
            return new ConcreteProcess(pID, priority, groupName);
        }
    }
}