using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Camp.Mvc.Swatter.Helper
{
    public class RedirectToIndexOnMissingArgumentAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var argumentException = filterContext.Exception as ArgumentException;
            if (argumentException == null || argumentException.ParamName != "parameters") return;

            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    {"controller", filterContext.RouteData.Values["controller"]},
                    {"action", "Index"}
                }
            );

            filterContext.ExceptionHandled = true;
        }
    }
}