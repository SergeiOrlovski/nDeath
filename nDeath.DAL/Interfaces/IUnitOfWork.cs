using System;
using nDeath.DAL.Entities;

namespace nDeath.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Param> Parameters { get; }
        IRepository<CacheData> CacheData { get; }
        void Save();
    }
}
