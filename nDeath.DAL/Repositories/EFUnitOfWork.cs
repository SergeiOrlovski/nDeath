using System;
using nDeath.DAL.EF;
using nDeath.DAL.Entities;
using nDeath.DAL.Interfaces;

namespace nDeath.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DeathContext _dbcontext;
        private ParamRepository paramRepository;
        private CacheDataRepository cacheDataRepository;

        public EFUnitOfWork(string connectionString)
        {
            _dbcontext = new DeathContext(connectionString);
        }

        public IRepository<Param> Parameters
        {
            get
            {
                if (paramRepository == null)
                    paramRepository = new ParamRepository(_dbcontext);
                return paramRepository;
            }
        }

        public IRepository<CacheData> CacheData
        {
            get
            {
                if (cacheDataRepository == null)
                    cacheDataRepository = new CacheDataRepository(_dbcontext);
                return cacheDataRepository;
            }
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbcontext.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

