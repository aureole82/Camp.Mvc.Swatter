using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Camp.Mvc.Swatter.Models;

namespace Camp.Mvc.Swatter.Controllers
{
    public class PotsController : Controller
    {
        private readonly SwatterContext _db = new SwatterContext();

        // GET: Pots
        public ActionResult Index()
        {
            return View(_db.Pots.ToList());
        }

        // GET: Pots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pot pot = _db.Pots.Find(id);
            if (pot == null)
            {
                return HttpNotFound();
            }
            return View(pot);
        }

        // GET: Pots/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Abbreviation,Name,Description,Chief")] Pot pot)
        {
            if (ModelState.IsValid)
            {
                _db.Pots.Add(pot);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pot);
        }

        // GET: Pots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pot pot = _db.Pots.Find(id);
            if (pot == null)
            {
                return HttpNotFound();
            }
            return View(pot);
        }

        // POST: Pots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Abbreviation,Name,Description,Chief")] Pot pot)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(pot).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pot);
        }

        // GET: Pots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pot pot = _db.Pots.Find(id);
            if (pot == null)
            {
                return HttpNotFound();
            }
            return View(pot);
        }

        // POST: Pots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pot pot = _db.Pots.Find(id);
            _db.Pots.Remove(pot);
            _db.SaveChanges();
            return RedirectToAction("Index");
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
