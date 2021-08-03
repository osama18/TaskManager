using System;
using TaskManager.Models.Process;

namespace TaskManager.Services.Models.Process.DecoratedProcesses
{
    public interface IComparableProcess :  IComparable<IComparableProcess> 
    {
         ProcessDto Process { get; set; }
    }
}
