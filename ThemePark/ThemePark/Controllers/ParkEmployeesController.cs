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
using ThemePark.DAL;
using ThemePark.ViewModels;

namespace ThemePark.Controllers
{
    [AuthAttribute]
    public class ParkEmployeesController : Controller
    {
        private TPContext db = new TPContext();

        // GET: ParkEmployees
        public ActionResult Index()
        {
            if (ApplicationSession.AccessLevel == "Manager")
            {
                var parkEmployees = db.ParkEmployees.Include(p => p.Department);
                return View(parkEmployees.ToList());
            }
            else
            {
                return Redirect(ApplicationSession.RedirectToHomeURL);
            }
        }

        // GET: ParkEmployees/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkEmployee parkEmployee = db.ParkEmployees.Find(id);
            if (parkEmployee == null)
            {
                return HttpNotFound();
            }
            return View(parkEmployee);
        }

        // GET: ParkEmployees/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DName");
            return View();
        }

        // POST: ParkEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeVM employee)
        {
            if (ModelState.IsValid)
            {

                //check database for existing username
                if (db.EmployeeLogins.Any(x => x.LoginEmail == employee.LoginEmail))
                {
                    ModelState.AddModelError(string.Empty, "Email already exists");
                    return RedirectToAction("Index");
                }
                else
                {
                    var parkEmployee = new ParkEmployee();
                    parkEmployee.FirstName = employee.FirstName;
                    parkEmployee.LastName = employee.LastName;
                    parkEmployee.MiddleName = employee.MiddleName;
                    parkEmployee.StreetAddress = employee.StreetAddress;
                    parkEmployee.City = employee.City;
                    parkEmployee.State = employee.State;
                    parkEmployee.ZipCode = employee.ZipCode;
                    parkEmployee.PhoneNumber = employee.PhoneNumber;
                    parkEmployee.DateOfBirth = employee.DateOfBirth;
                    parkEmployee.Sex = employee.Sex;
                    parkEmployee.JobTitle = employee.JobTitle;
                    parkEmployee.DepartmentID = employee.DepartmentID;

                    var login = new EmployeeLogin();
                    login.ParkEmployee = parkEmployee;
                    login.LoginEmail = employee.LoginEmail;
                    login.Pswd = employee.Pswd;

                    db.ParkEmployees.Add(parkEmployee);
                    db.EmployeeLogins.Add(login);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DName", employee.DepartmentID);
            return View(employee);
        }

        // GET: ParkEmployees/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkEmployee parkEmployee = db.ParkEmployees.Find(id);
            if (parkEmployee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DName", parkEmployee.DepartmentID);
            return View(parkEmployee);
        }

        // POST: ParkEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,FirstName,MiddleName,LastName,StreetAddress,State,City,ZipCode,PhoneNumber,DateOfBirth,Sex,JobTitle,DepartmentID")] ParkEmployee parkEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DName", parkEmployee.DepartmentID);
            return View(parkEmployee);
        }

        // GET: ParkEmployees/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkEmployee parkEmployee = db.ParkEmployees.Find(id);
            if (parkEmployee == null)
            {
                return HttpNotFound();
            }
            return View(parkEmployee);
        }

        // POST: ParkEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ParkEmployee parkEmployee = db.ParkEmployees.Find(id);
            db.ParkEmployees.Remove(parkEmployee);
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
