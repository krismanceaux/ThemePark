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
    public class SOLD_BYController : Controller
    {
        private TPContext db = new TPContext();

        // GET: SOLD_BY
        public ActionResult Index()
        {
            var sOLD_BY = db.SOLD_BY.Include(s => s.Concession).Include(s => s.ParkEmployee);
            return View(sOLD_BY.ToList());
        }

        // GET: SOLD_BY/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOLD_BY sOLD_BY = db.SOLD_BY.Find(id);
            if (sOLD_BY == null)
            {
                return HttpNotFound();
            }
            return View(sOLD_BY);
        }

        // GET: SOLD_BY/Create
        public ActionResult Create()
        {
            ViewBag.ItemName = new SelectList(db.Concessions, "ItemName", "ItemDescription");
            ViewBag.EmployeeID = new SelectList(db.ParkEmployees, "EmployeeID", "FirstName");
            return View();
        }

        // POST: SOLD_BY/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemName,EmployeeID,DateSold")] SOLD_BY sOLD_BY)
        {
            if (ModelState.IsValid)
            {

                TimeSpan d = DateTime.Now.TimeOfDay;
                sOLD_BY.DateSold += d;

                db.SOLD_BY.Add(sOLD_BY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemName = new SelectList(db.Concessions, "ItemName", "ItemDescription", sOLD_BY.ItemName);
            ViewBag.EmployeeID = new SelectList(db.ParkEmployees, "EmployeeID", "FirstName", sOLD_BY.EmployeeID);
            return View(sOLD_BY);
        }

        // GET: SOLD_BY/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOLD_BY sOLD_BY = db.SOLD_BY.Find(id);
            if (sOLD_BY == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemName = new SelectList(db.Concessions, "ItemName", "ItemDescription", sOLD_BY.ItemName);
            ViewBag.EmployeeID = new SelectList(db.ParkEmployees, "EmployeeID", "FirstName", sOLD_BY.EmployeeID);
            return View(sOLD_BY);
        }

        // POST: SOLD_BY/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemName,EmployeeID,DateSold")] SOLD_BY sOLD_BY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sOLD_BY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemName = new SelectList(db.Concessions, "ItemName", "ItemDescription", sOLD_BY.ItemName);
            ViewBag.EmployeeID = new SelectList(db.ParkEmployees, "EmployeeID", "FirstName", sOLD_BY.EmployeeID);
            return View(sOLD_BY);
        }

        // GET: SOLD_BY/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOLD_BY sOLD_BY = db.SOLD_BY.Find(id);
            if (sOLD_BY == null)
            {
                return HttpNotFound();
            }
            return View(sOLD_BY);
        }

        // POST: SOLD_BY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SOLD_BY sOLD_BY = db.SOLD_BY.Find(id);
            db.SOLD_BY.Remove(sOLD_BY);
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
