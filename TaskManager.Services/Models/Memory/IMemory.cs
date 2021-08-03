using System.Collections.Generic;
using TaskManager.Services.Models.Process;

namespace TaskManager.Services.Models
{
    public interface IMemory
    {
        bool Add(IProcess process);
        ICollection<IProcess> List();
        void KillIProcess(IProcess process);
        void KillIProcessGroup(string groupName);
        void KillAll();
        IProcess Get(long processId);
    }
}
