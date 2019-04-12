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
    public class ADMITTED_BYController : Controller
    {
        private TPContext db = new TPContext();

        // GET: ADMITTED_BY
        public ActionResult Index()
        {
            var aDMITTED_BY = db.ADMITTED_BY.Include(a => a.ParkEmployee).Include(a => a.Ticket);
            return View(aDMITTED_BY.ToList());
        }

        // GET: ADMITTED_BY/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMITTED_BY aDMITTED_BY = db.ADMITTED_BY.Find(id);
            if (aDMITTED_BY == null)
            {
                return HttpNotFound();
            }
            return View(aDMITTED_BY);
        }

        // GET: ADMITTED_BY/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.ParkEmployees, "EmployeeID", "FirstName");
            ViewBag.TicketID = new SelectList(db.Tickets, "TicketNumber", "TicketNumber");
            return View();
        }

        // POST: ADMITTED_BY/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketID,EmployeeID,AdmissionsDate")] ADMITTED_BY aDMITTED_BY)
        {
            if (ModelState.IsValid)
            {
                db.ADMITTED_BY.Add(aDMITTED_BY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.ParkEmployees, "EmployeeID", "FirstName", aDMITTED_BY.EmployeeID);
            ViewBag.TicketID = new SelectList(db.Tickets, "TicketNumber", "TicketNumber", aDMITTED_BY.TicketID);
            return View(aDMITTED_BY);
        }

        // GET: ADMITTED_BY/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMITTED_BY aDMITTED_BY = db.ADMITTED_BY.Find(id);
            if (aDMITTED_BY == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.ParkEmployees, "EmployeeID", "FirstName", aDMITTED_BY.EmployeeID);
            ViewBag.TicketID = new SelectList(db.Tickets, "TicketNumber", "TicketNumber", aDMITTED_BY.TicketID);
            return View(aDMITTED_BY);
        }

        // POST: ADMITTED_BY/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketID,EmployeeID,AdmissionsDate")] ADMITTED_BY aDMITTED_BY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aDMITTED_BY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.ParkEmployees, "EmployeeID", "FirstName", aDMITTED_BY.EmployeeID);
            ViewBag.TicketID = new SelectList(db.Tickets, "TicketNumber", "TicketNumber", aDMITTED_BY.TicketID);
            return View(aDMITTED_BY);
        }

        // GET: ADMITTED_BY/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMITTED_BY aDMITTED_BY = db.ADMITTED_BY.Find(id);
            if (aDMITTED_BY == null)
            {
                return HttpNotFound();
            }
            return View(aDMITTED_BY);
        }

        // POST: ADMITTED_BY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ADMITTED_BY aDMITTED_BY = db.ADMITTED_BY.Find(id);
            db.ADMITTED_BY.Remove(aDMITTED_BY);
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
