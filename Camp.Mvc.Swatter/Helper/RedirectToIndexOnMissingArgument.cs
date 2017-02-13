using System;
using System.Linq;
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

            var indexAction =filterContext.Controller.GetType().GetMethods()
                .SingleOrDefault(info => info.Name == "Index");

            var actionResult = indexAction?.Invoke(filterContext.Controller, new object[0]) as ActionResult;
            var viewResult = actionResult as ViewResult;
            if (viewResult != null)
            {
                viewResult.ViewName = "Index";
                viewResult.ViewData["Error"] =
                    "Your request was wrong. Forget to enter something? The id? Please select the correct item...";
            }
            else
            {
                actionResult = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"controller", filterContext.RouteData.Values["controller"]},
                        {"action", "Index"}
                    }
                );
            }
            filterContext.Result = actionResult;

            filterContext.ExceptionHandled = true;
        }
    }
}