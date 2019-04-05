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
    public class EmployeeLoginsController : Controller
    {
        private TPContext db = new TPContext();

        // GET: EmployeeLogins
        public ActionResult Index()
        {
            var employeeLogins = db.EmployeeLogins.Include(e => e.ParkEmployee);
            return View(employeeLogins.ToList());
        }

        // GET: EmployeeLogins/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeLogin employeeLogin = db.EmployeeLogins.Find(id);
            if (employeeLogin == null)
            {
                return HttpNotFound();
            }
            return View(employeeLogin);
        }

        // GET: EmployeeLogins/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.ParkEmployees, "EmployeeID", "FirstName");
            return View();
        }

        // POST: EmployeeLogins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoginEmail,Pswd,EmployeeID")] EmployeeLogin employeeLogin)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeLogins.Add(employeeLogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.ParkEmployees, "EmployeeID", "FirstName", employeeLogin.EmployeeID);
            return View(employeeLogin);
        }

        // GET: EmployeeLogins/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeLogin employeeLogin = db.EmployeeLogins.Find(id);
            if (employeeLogin == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.ParkEmployees, "EmployeeID", "FirstName", employeeLogin.EmployeeID);
            return View(employeeLogin);
        }

        // POST: EmployeeLogins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoginEmail,Pswd,EmployeeID")] EmployeeLogin employeeLogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeLogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.ParkEmployees, "EmployeeID", "FirstName", employeeLogin.EmployeeID);
            return View(employeeLogin);
        }

        // GET: EmployeeLogins/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeLogin employeeLogin = db.EmployeeLogins.Find(id);
            if (employeeLogin == null)
            {
                return HttpNotFound();
            }
            return View(employeeLogin);
        }

        // POST: EmployeeLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EmployeeLogin employeeLogin = db.EmployeeLogins.Find(id);
            db.EmployeeLogins.Remove(employeeLogin);
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
