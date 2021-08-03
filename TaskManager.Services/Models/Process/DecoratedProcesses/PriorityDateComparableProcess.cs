using System.Diagnostics.CodeAnalysis;

namespace TaskManager.Services.Models.Process.DecoratedProcesses
{
    public class PriorityDateComparableProcess : ConcreteProcess , IComparableProcess
    {
        private readonly IProcess process;
        public PriorityDateComparableProcess(IProcess process) : base(process.Priority, process.GroupName)
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
            { 
                if(CreatedAt < other.CreatedAt)
                    return -1;
                else if (CreatedAt == other.CreatedAt)
                    return 0;
                return 1;
            }
                
            return 1;
        }
    }
}
