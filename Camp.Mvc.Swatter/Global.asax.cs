using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Camp.Mvc.Swatter
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Allows calling Index.htm if the url doesn't address a controller.
            RouteTable.Routes.Ignore(
                url: ""
            );

            RouteTable.Routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
            );
        }
    }
}