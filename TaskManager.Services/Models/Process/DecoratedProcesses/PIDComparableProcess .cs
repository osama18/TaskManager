using System.Diagnostics.CodeAnalysis;

namespace TaskManager.Services.Models.Process.DecoratedProcesses
{
    public class PIDComparableProcess : ConcreteProcess, IComparableProcess
    {
        private readonly IProcess process;
        public PIDComparableProcess(IProcess process) : base(process.PID,process.Priority, process.GroupName)
        {
            this.process = process;
        }

        public int CompareTo([AllowNull] IProcess other)
        {
            if (other == null)
                return 1;

            if (PID < other.PID)
                return -1;
            if (PID == other.PID)
                return 0;
            return 1;
        }
    }
}
