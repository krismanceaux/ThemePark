using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThemePark.DAL;

namespace ThemePark.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(ApplicationSession.Username != "")
            {
                ApplicationSession.Username = "";
            }
            return View();
        }

        [Authorize]
        public ActionResult EmployeeHub()
        {
            return View();
        }

        public ActionResult SPH_Profile()
        {
            return View();
        }
        public ActionResult ManagerHub()
        {
            return View();
        }
    }
}