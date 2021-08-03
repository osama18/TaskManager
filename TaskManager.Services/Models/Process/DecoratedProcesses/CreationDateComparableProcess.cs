using System.Diagnostics.CodeAnalysis;
using TaskManager.Models.Process;

namespace TaskManager.Services.Models.Process.DecoratedProcesses
{
    public class CreationDateComparableProcess : ProcessDto, IComparableProcess
    {
        public CreationDateComparableProcess(ProcessDto process) : base(process)
        {
            this.Process = process;
        }

        public int CompareTo([AllowNull] IComparableProcess other)
        {
            if (other == null)
                return 1;

            if (CreatedAt < other.Process.CreatedAt)
                return -1;
            if (CreatedAt == other.Process.CreatedAt)
                return 0;
            return 1;
        }

        public ProcessDto Process { get; set; }

    }
}
