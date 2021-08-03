using System.Diagnostics.CodeAnalysis;

namespace TaskManager.Services.Models.Process.DecoratedProcesses
{
    public class CreationDateComparableProcess : ConcreteProcess, IComparableProcess
    {
        public CreationDateComparableProcess(IProcess process) : base(process)
        {
        }

        public int CompareTo([AllowNull] IProcess other)
        {
            if (other == null)
                return 1;

            if (CreatedAt < other.CreatedAt)
                return -1;
            if (CreatedAt == other.CreatedAt)
                return 0;
            return 1;
        }
    }
}
