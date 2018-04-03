using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nDeath.BLL.DTO;
using nDeath.BLL.Interfaces;
using nDeath.DAL.Entities;
using nDeath.DAL.Interfaces;

namespace nDeath.BLL.Services
{
    public class DeathDataService : IDataService
    {
        private IUnitOfWork Database { get; set; }

        public DeathDataService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public  Task<int> FindParamsIdAsync(ParamDTO param)
        {
            var task = Task.Run(() =>
            {
                var _param = Database.Parameters.Find(p =>
                p.A == param.A &&
                p.B == param.B &&
                p.C == param.C &&
                p.Step == param.Step &&
                p.RangeFrom == param.RangeFrom &&
                p.RangeTo == param.RangeTo).FirstOrDefault();

                if (_param != null)
                {
                    return _param.ParamId;

                }
                return -1;
            });
            return task;
            
        }

        public  Task<List<CacheDataDTO>> GetCacheDataAsync(int id)
        {
            var task =  Task.Run(() =>
            {
                var cacheDataList = Database.CacheData.Find(c => c.ParamId == id).ToList();
                return ReplaseCacheData(cacheDataList);
            });
            return task;
            
        }

        public  async Task AddParamsAndCacheDataAsync(ParamDTO param, List<CacheDataDTO> cacheData)
        {
            await Task.Run(() =>
            {
                Param _param = new Param
                {
                    A = param.A,
                    B = param.B,
                    C = param.C,
                    Step = param.Step,
                    RangeFrom = param.RangeFrom,
                    RangeTo = param.RangeTo,
                    CacheDatas = ReplaseCacheData(cacheData)
                };
                Database.Parameters.Add(_param);
                Database.Save();
            });
        }

        private List<CacheDataDTO> ReplaseCacheData(List<CacheData> cacheData)
        {
            List<CacheDataDTO> cacheDataDTO = new List<CacheDataDTO>();
            foreach (var cache in cacheData)
            {
                CacheDataDTO data = new CacheDataDTO
                {
                    PointX = cache.PointX,
                    PointY = cache.PointY,
                    ParamId = cache.ParamId
                };
                cacheDataDTO.Add(data);
            }
            return cacheDataDTO;
        }

        private List<CacheData> ReplaseCacheData(List<CacheDataDTO> cacheDataDTO)
        {
            List<CacheData> cacheData = new List<CacheData>();
            foreach (var cache in cacheDataDTO)
            {
                CacheData data = new CacheData
                {
                    PointX = cache.PointX,
                    PointY = cache.PointY,
                    ParamId = cache.ParamId
                };
                cacheData.Add(data);
            }
            return cacheData;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
