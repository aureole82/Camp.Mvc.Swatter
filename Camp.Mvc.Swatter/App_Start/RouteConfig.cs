using System.Web.Mvc;
using System.Web.Routing;

namespace Camp.Mvc.Swatter
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "FliesCodeRoute",
                "Flies/{code}",
                new { controller = "Flies", action = "DetailsByCode" },
                new { code = @"\w+-\d+" }
            );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
            );
        }
    }
}