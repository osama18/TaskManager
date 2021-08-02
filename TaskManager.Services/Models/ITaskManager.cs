
using TaskManager.Services.Models.Process;

namespace TaskManager.Services.Models
{
    public interface ITaskManager 
    {
        bool Add(IProcess process);
        IProcess[] List(SortOption sortOption);
        void KillIProcess(IProcess process);
        void KillIProcessGroup(string groupName);
        void KillAll();
    }
}