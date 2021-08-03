using System.Diagnostics.CodeAnalysis;

namespace TaskManager.Services.Models.Process.DecoratedProcesses
{
    public class PIDComparableProcess : ConcreteProcess, IComparableProcess
    {
        public PIDComparableProcess(IProcess process) : base(process)
        {
            
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
