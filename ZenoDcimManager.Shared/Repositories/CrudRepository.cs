using System;
using System.Collections.Generic;

namespace ZenoDcimManager.Shared.Repositories
{
    public interface CrudRepository<T> where T : class
    {
        void Save(T item);
        IEnumerable<T> List();
        void Update(T item);
        void Delete(T item);
        T Find(Guid id);
    }
}