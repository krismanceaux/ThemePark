using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThemePark;
using ThemePark.AuthData;

namespace ThemePark.Controllers
{
    [AuthAttribute]
    public class MaintenanceController : Controller
    {
        private TPContext db = new TPContext();

        // GET: Maintenance
        public ActionResult Index()
        {
            var maintenances = db.Maintenances.Include(m => m.MaintCode1).Include(m => m.Ride);
            return View(maintenances.ToList());
        }

        // GET: Maintenance/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintenance maintenance = db.Maintenances.Find(id);
            if (maintenance == null)
            {
                return HttpNotFound();
            }
            return View(maintenance);
        }

        // GET: Maintenance/Create
        public ActionResult Create()
        {
            ViewBag.MaintCode = new SelectList(db.MaintCodes, "MaintCode1", "MaintType");
            ViewBag.RideID = new SelectList(db.Rides, "RideID", "RideName");
            return View();
        }

        // POST: Maintenance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaintenanceID,MaintDescription,CorrectiveAction,DateAdded,DateFixed,MaintCode,SupervisorID,RideID")] Maintenance maintenance)
        {
            if (ModelState.IsValid)
            {
                db.Maintenances.Add(maintenance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaintCode = new SelectList(db.MaintCodes, "MaintCode1", "MaintType", maintenance.MaintCode);
            ViewBag.RideID = new SelectList(db.Rides, "RideID", "RideName", maintenance.RideID);
            return View(maintenance);
        }

        // GET: Maintenance/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintenance maintenance = db.Maintenances.Find(id);
            if (maintenance == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaintCode = new SelectList(db.MaintCodes, "MaintCode1", "MaintType", maintenance.MaintCode);
            ViewBag.RideID = new SelectList(db.Rides, "RideID", "RideName", maintenance.RideID);
            return View(maintenance);
        }

        // POST: Maintenance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaintenanceID,MaintDescription,CorrectiveAction,DateAdded,DateFixed,MaintCode,SupervisorID,RideID")] Maintenance maintenance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maintenance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaintCode = new SelectList(db.MaintCodes, "MaintCode1", "MaintType", maintenance.MaintCode);
            ViewBag.RideID = new SelectList(db.Rides, "RideID", "RideName", maintenance.RideID);
            return View(maintenance);
        }

        // GET: Maintenance/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintenance maintenance = db.Maintenances.Find(id);
            if (maintenance == null)
            {
                return HttpNotFound();
            }
            return View(maintenance);
        }

        // POST: Maintenance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Maintenance maintenance = db.Maintenances.Find(id);
            db.Maintenances.Remove(maintenance);
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
