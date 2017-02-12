using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Camp.Mvc.Swatter.Models;

namespace Camp.Mvc.Swatter.Controllers
{
    public class FliesController : Controller
    {
        private static List<Fly> _flies = new List<Fly>
        {
            new Fly
            {
                Id = 1,
                Head = "Cannot fly",
                Body = @"This morning I awoke
realized that I cannot fly. :-(",
                Creator = "fly@hornets.net",
                Weight = Weight.Heavy
            },
            new Fly
            {
                Id = 2,
                Head = "I'm tired",
                Body = @"Every evening I'm getting tired. Need help!",
                Creator = "zzz@honey.cup",
            },
            new Fly
            {
                Id = 3,
                Head = "The landlord slaps",
                Body = @"Everytime I sip at landlord's coffee he takes the swatter and tries to kill me!!!
Could it be he doesn't like me?",
                Creator = "shy@coffee.cup",
                Weight = Weight.Heavy
            }
        };

        // GET: Flies
        public ActionResult Index()
        {
            return View();
        }

        // GET: Flies/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Flies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flies/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Flies/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Flies/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Flies/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Flies/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
