using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZenoDcimManager.Shared.Repositories
{
    public interface CrudRepository<T> where T : class
    {
        Task Save(T item);
        Task<IEnumerable<T>> List();
        void Update(T item);
        void Delete(T item);
        Task<T> Find(Guid id);
    }
}