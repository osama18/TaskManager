using System.Diagnostics.CodeAnalysis;

namespace TaskManager.Services.Models.Process.DecoratedProcesses
{
    public class PriorityComparableProcess : ConcreteProcess, IComparableProcess
    {
        private readonly IProcess process;
        public PriorityComparableProcess(IProcess process) : base(process.Priority, process.GroupName)
        {
            this.process = process;
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
