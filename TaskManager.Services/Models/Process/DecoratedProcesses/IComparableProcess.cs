using System;

namespace TaskManager.Services.Models.Process.DecoratedProcesses
{
    public interface IComparableProcess :  IComparable<IProcess> , IProcess
    {
    }
}
