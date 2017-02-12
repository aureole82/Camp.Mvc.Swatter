using System.Collections.Generic;
using System.Dynamic;
using System.Web.Mvc;

namespace Camp.Mvc.Swatter.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            IDictionary<string, object> expando = new ExpandoObject();
            expando.Add("UserName","Max");
            return View((ExpandoObject)expando);
        }
    }
}