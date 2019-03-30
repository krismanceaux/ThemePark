using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThemePark.Controllers
{
    public class EmployeeAccountController : Controller
    {
        // GET: EmployeeAccount
        public ActionResult Login()
        {
            return View();
        }
    }
}