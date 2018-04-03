using System.Collections.Generic;
using System.Threading.Tasks;
using nDeath.BLL.DTO;

namespace nDeath.BLL.Interfaces
{
    public interface IDataService 
    {
        Task<int> FindParamsIdAsync(ParamDTO param);
        Task AddParamsAndCacheDataAsync(ParamDTO param, List<CacheDataDTO> cacheData);
        Task<List<CacheDataDTO>> GetCacheDataAsync(int id);
        void Dispose();
    }
}
