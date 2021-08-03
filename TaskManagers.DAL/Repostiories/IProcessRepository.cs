using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagers.DAL.Entities;

namespace TaskManagers.DAL.Repostiories
{
    public interface IProcessRepository : IGenericRepository<ProcessEntity>
    {
        Task<ICollection<ProcessEntity>> RetrieveByGroup(string groupName);
        Task RemoveOldest();
        Task RemoveOldestLowestPriority();
        Task Remove(string groupName);
    }
}