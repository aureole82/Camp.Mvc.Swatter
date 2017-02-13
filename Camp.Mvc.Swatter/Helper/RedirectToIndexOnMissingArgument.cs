using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Camp.Mvc.Swatter.Helper
{
    public class RedirectToIndexOnMissingArgumentAttribute : FilterAttribute, IExceptionFilter
    {
        private const string RedirectViewName = "Index";

        public void OnException(ExceptionContext filterContext)
        {
            var argumentException = filterContext.Exception as ArgumentException;
            if (argumentException == null
                || argumentException.ParamName != "parameters"
                || (filterContext.RouteData.Values["action"] as string) == RedirectViewName) return;

            var indexAction = filterContext.Controller.GetType().GetMethods()
                .SingleOrDefault(info => info.Name == RedirectViewName);

            var actionResult = indexAction?.Invoke(filterContext.Controller, new object[0]) as ActionResult;
            var viewResult = actionResult as ViewResult;
            if (viewResult != null)
            {
                viewResult.ViewName = RedirectViewName;
                viewResult.ViewData["Error"] =
                    "Your request was wrong. Forget to enter something? The id? Please fix it or select the correct item below...";
            }
            else
            {
                actionResult = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"controller", filterContext.RouteData.Values["controller"]},
                        {"action", RedirectViewName}
                    }
                );
            }
            filterContext.Result = actionResult;

            filterContext.ExceptionHandled = true;
        }
    }
}