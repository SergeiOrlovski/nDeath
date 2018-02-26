using System.Collections.Generic;

namespace nDeath.DAL.Entities
{
    public class Param
    {
        public int ParamId { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double Step { get; set; }
        public double RangeFrom { get; set; }
        public double RangeTo { get; set; }

        public virtual ICollection<CacheData> CacheDatas { get; set; }
    }
}
