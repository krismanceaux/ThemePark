using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThemePark;

namespace ThemePark.Controllers
{
    public class ConcessionsController : Controller
    {
        private TPContext db = new TPContext();

        // GET: Concessions
        public ActionResult Index()
        {
            return View(db.Concessions.ToList());
        }

        // GET: Concessions/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concession concession = db.Concessions.Find(id);
            if (concession == null)
            {
                return HttpNotFound();
            }
            return View(concession);
        }

        // GET: Concessions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Concessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemName,ItemPrice,ItemDescription")] Concession concession)
        {
            if (ModelState.IsValid)
            {
                db.Concessions.Add(concession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(concession);
        }

        // GET: Concessions/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concession concession = db.Concessions.Find(id);
            if (concession == null)
            {
                return HttpNotFound();
            }
            return View(concession);
        }

        // POST: Concessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemName,ItemPrice,ItemDescription")] Concession concession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(concession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(concession);
        }

        // GET: Concessions/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concession concession = db.Concessions.Find(id);
            if (concession == null)
            {
                return HttpNotFound();
            }
            return View(concession);
        }

        // POST: Concessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Concession concession = db.Concessions.Find(id);
            db.Concessions.Remove(concession);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
