using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Services.Models.Process;

namespace TaskManager.Services.Models
{
    public interface IMemory
    {
        Task<long?> AddAsync(IProcess process);
        Task<IEnumerable<IProcess>> ListAsync(int take = 1000, int skip = 0);
        Task KillIProcessAsync(long processId);
        Task KillIProcessGroupAsync(string groupName);
        Task KillAllAsync();
        Task<IProcess> RetrieveAsync(long processId);
    }
}
