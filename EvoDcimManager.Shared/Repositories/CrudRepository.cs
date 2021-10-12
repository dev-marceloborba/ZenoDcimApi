using System;
using System.Collections.Generic;

namespace EvoDcimManager.Shared.Repositories
{
    public interface CrudRepository<T> where T : class
    {
        void Save(T item);
        IReadOnlyCollection<T> List();
        void Update(T item);
        void Delete(T item);
        T Find(Guid id);
    }
}