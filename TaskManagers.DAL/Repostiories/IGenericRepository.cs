
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagers.DAL.Entities;

namespace TaskManagers.DAL.Repostiories
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task<T> RetrieveById(long id);
        
        Task<ICollection<T>> RetrievePage(int take, int skip = 0);
        
        Task<long?> InsertAsync(T entity);

        Task InsertRangeAsync(IEnumerable<T> entities);

        Task Remove(long id);

        Task RemoveRange(ICollection<T> processes);

        Task RemoveAll();

        Task SaveAsync();

        void Update(Entity entity);

        Task<long> Count();
    }
}