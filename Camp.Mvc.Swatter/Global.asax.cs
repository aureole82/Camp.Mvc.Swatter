using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Camp.Mvc.Swatter.Models;

namespace Camp.Mvc.Swatter
{
    public class MvcApplication : HttpApplication
    {
        internal static SwatterContextFactory DbFactory = new SwatterContextFactory();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}