using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Camp.Mvc.Swatter.Models;

namespace Camp.Mvc.Swatter.Controllers
{
    public class FliesController : Controller
    {
        private static readonly List<Fly> _flies = new List<Fly>
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
                Creator = "zzz@honey.cup"
            },
            new Fly
            {
                Id = 3,
                Head = "The landlord slaps",
                Body = @"Everytime I sip at landlord's coffee he takes the swatter and tries to kill me!!!
Could it be he doesn't like me?",
                Creator = "shy@coffee.cup",
                Weight = Weight.Heavy
            },
            new Fly
            {
                Id = 4,
                Head = "I hear myself buzzing",
                Body = @"Zzzzzzzzzzzzzzzzzzhhhh. Everywhere I fly. Cannot escape...
Drives me nuts",
                Weight = Weight.Trivial
            }
        };

        // GET: Flies
        public ActionResult Index()
        {
            return View(_flies.OrderBy(fly => fly.Weight));
        }

        // GET: Flies/Details/5
        public ActionResult Details(int id)
        {
            var foundFly = GetFly(id);
            if (foundFly == null)
            {
                return HttpNotFound("No fly to slap!");
            }
            return View(foundFly);
        }

        private static Fly GetFly(int id)
        {
            return _flies
                .SingleOrDefault(fly => fly.Id == id);
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
            var newFly = new Fly
            {
                Id = _flies.Select(fly => fly.Id).DefaultIfEmpty(0).Max() + 1,
                Updated = DateTime.Now
            };


            if (TryUpdateModel(newFly))
            {
                _flies.Add(newFly);
                return RedirectToAction("Details", new {newFly.Id});
            }

            return View();
        }

        // GET: Flies/Edit/5
        public ActionResult Edit(int id)
        {
            var foundFly = GetFly(id);
            if (foundFly == null)
            {
                return HttpNotFound("No fly to slap!");
            }

            return View(foundFly);
        }

        // POST: Flies/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var foundFly = GetFly(id);
            if (foundFly == null)
            {
                return HttpNotFound("No fly to slap!");
            }

            if (TryUpdateModel(foundFly))
                return RedirectToAction("Details", new {foundFly.Id});

            foundFly.Updated = DateTime.Now;
            return View();
        }

        // GET: Flies/Delete/5
        public ActionResult Delete(int id)
        {
            var foundFly = GetFly(id);
            if (foundFly == null)
            {
                return HttpNotFound("No fly to slap!");
            }

            return View(foundFly);
        }

        // POST: Flies/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var foundFly = GetFly(id);
            if (foundFly == null)
            {
                return HttpNotFound("No fly to slap!");
            }

            _flies.Remove(foundFly);
            return RedirectToAction("Index");
        }
    }
}