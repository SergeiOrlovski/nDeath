using nDeath.BLL.Interfaces;
using nDeath.BLL.Services;
using Ninject.Modules;

namespace nDeath.WEB.Utility
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataService>().To<DeathDataService>();
        }
    }
}