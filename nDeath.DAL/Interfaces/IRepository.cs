using System;
using System.Collections.Generic;

namespace nDeath.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Add(T item);
    }
}
