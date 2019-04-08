using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThemePark.AuthData;
using ThemePark.DAL;

namespace ThemePark.Controllers
{
    public class HomeController : Controller
    {
        private TPContext db = new TPContext();

        // Home page on start and that the home button routes to
        public ActionResult Index(int? id)
        {
            if (id == 1)
            {
                if (ApplicationSession.Username != "")
                {
                    ApplicationSession.Username = "";
                } 
            }
            return View();
        }

        

        [AuthAttribute]
        public ActionResult EmployeeHub()
        {
            if (ApplicationSession.AccessLevel == "Employee" || ApplicationSession.AccessLevel == "Manager")
                return View();
            else
                return Redirect(ApplicationSession.RedirectToHomeURL);
        }

        [AuthAttribute]
        public ActionResult SPH_Profile()
        {
            if(ApplicationSession.Username == "" || ApplicationSession.Username == null)
            {
                ApplicationSession.AccessLevel = "SPHProfileDenied";
            }

            if (ApplicationSession.AccessLevel == "SPH")
                return View();
            else
                return Redirect(ApplicationSession.RedirectToHomeURL);
        }

        [AuthAttribute]
        public ActionResult EmployeeProfile()
        {

            if (ApplicationSession.AccessLevel == "Employee" || ApplicationSession.AccessLevel == "Manager")
            {
                if (ApplicationSession.Username == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                EmployeeLogin login = db.EmployeeLogins.Single(x => x.LoginEmail == ApplicationSession.Username);
                ParkEmployee parkEmployee = db.ParkEmployees.Find(login.EmployeeID);

                if (parkEmployee == null)
                {
                    return HttpNotFound();
                }

                ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DName", parkEmployee.DepartmentID);
                return View(parkEmployee);
            }
            else
                return Redirect(ApplicationSession.RedirectToHomeURL);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthAttribute]
        public ActionResult EmployeeProfile([Bind(Include = "EmployeeID,FirstName,MiddleName,LastName,StreetAddress,State,City,ZipCode,PhoneNumber,DateOfBirth,Sex,JobTitle,DepartmentID")] ParkEmployee parkEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EmployeeProfile");
            }
            //ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DName", parkEmployee.DepartmentID);
            return View(parkEmployee);
        }

        [AuthAttribute]
        public ActionResult ManagerHub()
        {
            if (ApplicationSession.AccessLevel == "Manager")
                return View();
            else
                return Redirect(ApplicationSession.RedirectToHomeURL);
        }
    }
}