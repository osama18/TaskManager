using System.Diagnostics.CodeAnalysis;
using TaskManager.Models.Process;

namespace TaskManager.Services.Models.Process.DecoratedProcesses
{
    public class PriorityComparableProcess : ProcessDto, IComparableProcess
    {
        public PriorityComparableProcess(ProcessDto process) : base(process)
        {
            this.Process = process;
        }

        public int CompareTo([AllowNull] IComparableProcess other)
        {
            if (other == null)
                return 1;

            if ((int)Priority < (int)other.Process.Priority)
                return -1;
            if ((int)Priority == (int)other.Process.Priority)
                return 0;
            return 1;
        }

        public ProcessDto Process { get; set; }
    }
}
