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
    public class PERMITsController : Controller
    {
        private TPContext db = new TPContext();

        // GET: PERMITs
        public ActionResult Index()
        {
            var pERMITS = db.PERMITS.Include(p => p.Ride).Include(p => p.Ticket);
            return View(pERMITS.ToList());
        }

        // GET: PERMITs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERMIT pERMIT = db.PERMITS.Find(id);
            if (pERMIT == null)
            {
                return HttpNotFound();
            }
            return View(pERMIT);
        }

        // GET: PERMITs/Create
        public ActionResult Create()
        {
            ViewBag.RideID = new SelectList(db.Rides, "RideID", "RideName");
            ViewBag.TicketNumber = new SelectList(db.Tickets, "TicketNumber", "TicketNumber");
            return View();
        }

        // POST: PERMITs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RideID,TicketNumber,PTimeStamp")] PERMIT pERMIT)
        {
            if (ModelState.IsValid)
            {
                TimeSpan d = DateTime.Now.TimeOfDay;
                pERMIT.PTimeStamp += d;

                db.PERMITS.Add(pERMIT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RideID = new SelectList(db.Rides, "RideID", "RideName", pERMIT.RideID);
            ViewBag.TicketNumber = new SelectList(db.Tickets, "TicketNumber", "TicketNumber", pERMIT.TicketNumber);
            return View(pERMIT);
        }

        // GET: PERMITs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERMIT pERMIT = db.PERMITS.Find(id);
            if (pERMIT == null)
            {
                return HttpNotFound();
            }
            ViewBag.RideID = new SelectList(db.Rides, "RideID", "RideName", pERMIT.RideID);
            ViewBag.TicketNumber = new SelectList(db.Tickets, "TicketNumber", "TicketNumber", pERMIT.TicketNumber);
            return View(pERMIT);
        }

        // POST: PERMITs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RideID,TicketNumber,PTimeStamp")] PERMIT pERMIT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pERMIT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RideID = new SelectList(db.Rides, "RideID", "RideName", pERMIT.RideID);
            ViewBag.TicketNumber = new SelectList(db.Tickets, "TicketNumber", "TicketNumber", pERMIT.TicketNumber);
            return View(pERMIT);
        }

        // GET: PERMITs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERMIT pERMIT = db.PERMITS.Find(id);
            if (pERMIT == null)
            {
                return HttpNotFound();
            }
            return View(pERMIT);
        }

        // POST: PERMITs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            PERMIT pERMIT = db.PERMITS.Find(id);
            db.PERMITS.Remove(pERMIT);
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
