namespace nDeath.DAL.Entities
{
    public class CacheData
    {
        public int CacheDataId { get; set; }
        public double PointX { get; set; }
        public double PointY { get; set; }

        public int ParamId { get; set; }
        public virtual Param Param { get; set; }
    }
}
