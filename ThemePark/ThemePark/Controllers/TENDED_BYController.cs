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
    public class TENDED_BYController : Controller
    {
        private TPContext db = new TPContext();

        // GET: TENDED_BY
        public ActionResult Index()
        {
            var tENDED_BY = db.TENDED_BY.Include(t => t.ParkEmployee).Include(t => t.Ride);
            return View(tENDED_BY.ToList());
        }

        // GET: TENDED_BY/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TENDED_BY tENDED_BY = db.TENDED_BY.Find(id);
            if (tENDED_BY == null)
            {
                return HttpNotFound();
            }
            return View(tENDED_BY);
        }

        // GET: TENDED_BY/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.ParkEmployees, "EmployeeID", "FirstName");
            ViewBag.RideID = new SelectList(db.Rides, "RideID", "RideName");
            return View();
        }

        // POST: TENDED_BY/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RideID,EmployeeID,DateTended")] TENDED_BY tENDED_BY)
        {
            if (ModelState.IsValid)
            {
                db.TENDED_BY.Add(tENDED_BY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.ParkEmployees, "EmployeeID", "FirstName", tENDED_BY.EmployeeID);
            ViewBag.RideID = new SelectList(db.Rides, "RideID", "RideName", tENDED_BY.RideID);
            return View(tENDED_BY);
        }

        // GET: TENDED_BY/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TENDED_BY tENDED_BY = db.TENDED_BY.Find(id);
            if (tENDED_BY == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.ParkEmployees, "EmployeeID", "FirstName", tENDED_BY.EmployeeID);
            ViewBag.RideID = new SelectList(db.Rides, "RideID", "RideName", tENDED_BY.RideID);
            return View(tENDED_BY);
        }

        // POST: TENDED_BY/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RideID,EmployeeID,DateTended")] TENDED_BY tENDED_BY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tENDED_BY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.ParkEmployees, "EmployeeID", "FirstName", tENDED_BY.EmployeeID);
            ViewBag.RideID = new SelectList(db.Rides, "RideID", "RideName", tENDED_BY.RideID);
            return View(tENDED_BY);
        }

        // GET: TENDED_BY/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TENDED_BY tENDED_BY = db.TENDED_BY.Find(id);
            if (tENDED_BY == null)
            {
                return HttpNotFound();
            }
            return View(tENDED_BY);
        }

        // POST: TENDED_BY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TENDED_BY tENDED_BY = db.TENDED_BY.Find(id);
            db.TENDED_BY.Remove(tENDED_BY);
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
