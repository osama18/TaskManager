using System.Diagnostics.CodeAnalysis;

namespace TaskManager.Services.Models.Process.DecoratedProcesses
{
    public class PriorityComparableProcess : ConcreteProcess, IComparableProcess
    {
        public PriorityComparableProcess(IProcess process) : base(process)
        {
        }

        public int CompareTo([AllowNull] IProcess other)
        {
            if (other == null)
                return 1;

            if ((int)Priority < (int)other.Priority)
                return -1;
            if ((int)Priority == (int)other.Priority)
                return 0;
            return 1;
        }
    }
}
