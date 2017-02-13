using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Camp.Mvc.Swatter.Aggregates;
using Camp.Mvc.Swatter.Helper;
using Camp.Mvc.Swatter.Models;

namespace Camp.Mvc.Swatter.Controllers
{
    [RedirectToIndexOnMissingArgument]
    public class FliesController : Controller
    {
        private readonly SwatterContext _db = MvcApplication.DbFactory.Create();

        // GET: Flies
        public ActionResult Index()
        {
            return View(_db.Flies.ToList());
        }

        // GET: Flies/Details/5
        public ActionResult Details(int id)
        {
            var aggregate = GetDetailsAggregate(id);

            if (aggregate == null)
            {
                return HttpNotFound();
            }

            return View(aggregate);
        }

        // GET: Flies/Create
        public ActionResult Create()
        {
            ViewBag.Pots = _db.Pots;
            return View(new Fly());
        }

        // POST: Flies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PotId,Head,Body,Creator,Weight")] Fly fly)
        {
            if (ModelState.IsValid)
            {
                _db.Flies.Add(fly);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fly);
        }

        // GET: Flies/Edit/5
        public ActionResult Edit(int id)
        {
            var fly = _db.Flies.Find(id);
            if (fly == null)
            {
                return HttpNotFound();
            }
            return View(fly);
        }

        // POST: Flies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Head,Body,Creator,Weight")] Fly fly)
        {
            if (ModelState.IsValid)
            {
                fly.Updated = DateTime.Now;
                _db.Entry(fly).State = EntityState.Modified;
                _db.Entry(fly).Property(f => f.PotId).IsModified = false;
                _db.Entry(fly).Property(f => f.Born).IsModified = false;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fly);
        }

        // GET: Flies/Delete/5
        public ActionResult Delete(int id)
        {
            var aggregate = GetDetailsAggregate(id);
            if (aggregate == null)
            {
                return HttpNotFound();
            }
            return View(aggregate);
        }

        // POST: Flies/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var fly = _db.Flies.Find(id);
            _db.Flies.Remove(fly);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        private FlyDetailsAggregate GetDetailsAggregate(int flyId)
        {
            var aggregate = (
                    from fly in _db.Flies
                    join pot in _db.Pots on fly.PotId equals pot.Id
                    where fly.Id == flyId
                    select new FlyDetailsAggregate
                    {
                        Fly = fly,
                        PotCode = pot.Abbreviation,
                        PotName = pot.Name
                    }
                )
                .SingleOrDefault();
            return aggregate;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}