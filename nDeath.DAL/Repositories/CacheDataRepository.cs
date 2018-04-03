using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using nDeath.DAL.EF;
using nDeath.DAL.Entities;
using nDeath.DAL.Interfaces;

namespace nDeath.DAL.Repositories
{
    public class CacheDataRepository : IRepository<CacheData>
    {
        private readonly DeathContext _dbcontext;

        public CacheDataRepository(DeathContext context)
        {
            _dbcontext = context;
        }

        public void Add(CacheData cacheData)
        {
            _dbcontext.CacheDatas.Add(cacheData);
        }

        public IEnumerable<CacheData> Find(Func<CacheData, Boolean> predicate)
        {
            return _dbcontext.CacheDatas.Where(predicate).ToList();  
        }
    }
}
