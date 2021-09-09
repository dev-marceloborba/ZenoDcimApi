using System;
using System.Collections.Generic;

namespace EvoDcimManager.Shared.Repositories
{
    public interface CrudRepository<T> where T : class
    {
        T Save(T item);
        IReadOnlyCollection<T> List();
        T Update(T item);
        T Delete(T item);
        T Find(Guid id);
    }
}