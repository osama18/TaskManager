
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Services.Models;
using TaskManager.Services.Models.Process;

namespace TaskManager.Services.Services
{
    public interface ITaskManagerServices
    {
        Task<bool> AddAsync(Priority priority, string groupName);
        Task<ICollection<IProcess>> ListAsync(SortOption sortOption);
        Task KillIProcessAsync(long processId);
        Task KillIProcessGroupAsync(string groupName);
        Task KillAllAsync();
    }
}