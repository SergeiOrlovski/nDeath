using System.Web.Mvc;
using System.Web.Routing;

namespace nDeath.WEB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Death", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
