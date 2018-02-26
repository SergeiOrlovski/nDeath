using System.Collections.Generic;
using nDeath.BLL.DTO;

namespace nDeath.BLL.Interfaces
{
    public interface IDataService 
    {
        int FindParamsId(ParamDTO param);
        void AddParamsAndCacheData(ParamDTO param, List<CacheDataDTO> cacheData);
        List<CacheDataDTO> GetCacheData(int id);
        void Dispose();
    }
}
