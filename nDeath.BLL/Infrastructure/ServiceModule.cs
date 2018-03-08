using nDeath.DAL.Interfaces;
using nDeath.DAL.Repositories;
using Ninject.Modules;


namespace nDeath.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        private static ServiceModule instance;
        private ServiceModule(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public static ServiceModule GetInstance(string connectionString)
        {
            if (instance == null)
            {
                lock (typeof(ServiceModule))
                {
                    if (instance == null)
                        instance = new ServiceModule(connectionString);
                }
            }

            return instance;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
