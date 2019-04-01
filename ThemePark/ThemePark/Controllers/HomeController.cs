using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThemePark.AuthData;
using ThemePark.DAL;

namespace ThemePark.Controllers
{
    public class HomeController : Controller
    {
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
                return View();
            else
                return Redirect(ApplicationSession.RedirectToHomeURL);
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