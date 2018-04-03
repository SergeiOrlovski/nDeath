using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nDeath.DAL.EF;
using nDeath.DAL.Entities;
using nDeath.DAL.Interfaces;

namespace nDeath.DAL.Repositories
{
    public class ParamRepository : IRepository<Param>
    {
        private DeathContext _dbcontext;

        public ParamRepository(DeathContext context)
        {
            _dbcontext = context;
        }

        public void Add(Param param)
        {
            _dbcontext.Params.Add(param);
        }

        public  IEnumerable<Param> Find(Func<Param, Boolean> predicate)
        {
            return _dbcontext.Params.Where(predicate).ToList();
        }
    }
}
