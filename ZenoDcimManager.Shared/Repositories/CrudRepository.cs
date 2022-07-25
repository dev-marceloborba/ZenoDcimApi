using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZenoDcimManager.Shared.Repositories
{
    public interface CrudRepository<T> where T : class
    {
        Task CreateAsync(T model);
        Task<IEnumerable<T>> FindAllAsync();
        Task<T> FindByIdAsync(Guid id);
        void Update(T model);
        void Delete(T model);
    }
}