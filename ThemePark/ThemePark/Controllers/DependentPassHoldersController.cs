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
    public class DependentPassHoldersController : Controller
    {
        private TPContext db = new TPContext();

        // GET: DependentPassHolders
        public ActionResult Index()
        {
            var dependentPassHolders = db.DependentPassHolders.Include(d => d.SeasonPassHolder).Include(d => d.Ticket);
            return View(dependentPassHolders.ToList());
        }

        // GET: DependentPassHolders/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DependentPassHolder dependentPassHolder = db.DependentPassHolders.Find(id);
            if (dependentPassHolder == null)
            {
                return HttpNotFound();
            }
            return View(dependentPassHolder);
        }

        // GET: DependentPassHolders/Create
        public ActionResult Create()
        {
            ViewBag.SPH_ID = new SelectList(db.SeasonPassHolders, "SPH_ID", "StreetAddress");
            ViewBag.TicketNumber = new SelectList(db.Tickets, "TicketNumber", "TicketNumber");
            return View();
        }

        // POST: DependentPassHolders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepID,FirstName,LastName,MiddleName,TicketNumber,SPH_ID")] DependentPassHolder dependentPassHolder)
        {
            if (ModelState.IsValid)
            {
                db.DependentPassHolders.Add(dependentPassHolder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SPH_ID = new SelectList(db.SeasonPassHolders, "SPH_ID", "StreetAddress", dependentPassHolder.SPH_ID);
            ViewBag.TicketNumber = new SelectList(db.Tickets, "TicketNumber", "TicketNumber", dependentPassHolder.TicketNumber);
            return View(dependentPassHolder);
        }

        // GET: DependentPassHolders/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DependentPassHolder dependentPassHolder = db.DependentPassHolders.Find(id);
            if (dependentPassHolder == null)
            {
                return HttpNotFound();
            }
            ViewBag.SPH_ID = new SelectList(db.SeasonPassHolders, "SPH_ID", "StreetAddress", dependentPassHolder.SPH_ID);
            ViewBag.TicketNumber = new SelectList(db.Tickets, "TicketNumber", "TicketNumber", dependentPassHolder.TicketNumber);
            return View(dependentPassHolder);
        }

        // POST: DependentPassHolders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepID,FirstName,LastName,MiddleName,TicketNumber,SPH_ID")] DependentPassHolder dependentPassHolder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dependentPassHolder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SPH_ID = new SelectList(db.SeasonPassHolders, "SPH_ID", "StreetAddress", dependentPassHolder.SPH_ID);
            ViewBag.TicketNumber = new SelectList(db.Tickets, "TicketNumber", "TicketNumber", dependentPassHolder.TicketNumber);
            return View(dependentPassHolder);
        }

        // GET: DependentPassHolders/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DependentPassHolder dependentPassHolder = db.DependentPassHolders.Find(id);
            if (dependentPassHolder == null)
            {
                return HttpNotFound();
            }
            return View(dependentPassHolder);
        }

        // POST: DependentPassHolders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            DependentPassHolder dependentPassHolder = db.DependentPassHolders.Find(id);
            db.DependentPassHolders.Remove(dependentPassHolder);
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
