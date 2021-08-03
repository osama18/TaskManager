
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Models.Process;
using TaskManager.Services.Models;
using TaskManager.Services.Models.Process;

namespace TaskManager.Services.Services
{
    public interface ITaskManagerServices
    {
        Task<long?> AddAsync(Priority priority, string groupName);
        Task<IEnumerable<ProcessDto>> ListAsync(SortOption sortOption);
        Task KillIProcessAsync(long processId);
        Task KillIProcessGroupAsync(string groupName);
        Task KillAllAsync();
    }
}