using nDeath.DAL.Interfaces;
using nDeath.DAL.Repositories;
using Ninject.Modules;


namespace nDeath.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;

        public ServiceModule(string connect)
        {
            connectionString = connect;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
