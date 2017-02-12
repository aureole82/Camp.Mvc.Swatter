using System;
using System.Web.Mvc;
using Camp.Mvc.Swatter.Models;

namespace Camp.Mvc.Swatter.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(new HomeModel
            {
                MachineName = Environment.MachineName,
                UserName = Environment.UserName,
                UserNameDirty = $"<b>{Environment.UserName}</b>",
                UserAge = 23,
                DateTime = DateTime.Now
            });
        }
    }
}