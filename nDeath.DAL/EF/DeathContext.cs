using System.Data.Entity;
using nDeath.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace nDeath.DAL.EF
{
    public class DeathContext : DbContext
    {
        public DbSet<Param> Params { get; set; }
        public DbSet<CacheData> CacheDatas { get; set; }

        public DeathContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Param>().Property(p => p.ParamId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Param>().Property(p => p.A).IsRequired();
            modelBuilder.Entity<Param>().Property(p => p.B).IsRequired();
            modelBuilder.Entity<Param>().Property(p => p.C).IsRequired();
            modelBuilder.Entity<Param>().Property(p => p.Step).IsRequired();
            modelBuilder.Entity<Param>().Property(p => p.RangeFrom).IsRequired();
            modelBuilder.Entity<Param>().Property(p => p.RangeTo).IsRequired();

            modelBuilder.Entity<CacheData>().Property(c => c.CacheDataId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<CacheData>().Property(c => c.PointX).IsRequired();
            modelBuilder.Entity<CacheData>().Property(c => c.PointY).IsRequired();
            modelBuilder.Entity<CacheData>().Property(c => c.ParamId).IsRequired();
        }
    }
}
