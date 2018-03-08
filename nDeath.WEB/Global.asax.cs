using Ninject;
using Ninject.Modules;
using System.Web.Mvc;
using System.Web.Routing;
using nDeath.BLL.Infrastructure;
using nDeath.WEB.Utility;
using Ninject.Web.Mvc;

namespace nDeath.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            NinjectModule dataModule = new DataModule();
            NinjectModule serviceModule = ServiceModule.GetInstance("DefaultConnection");
            var kernel = new StandardKernel(dataModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
