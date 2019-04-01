using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThemePark.DAL;
using ThemePark.ViewModels;

namespace ThemePark.Controllers
{
    public class SPHAccountController : Controller
    {
        // GET: EmployeeAccount
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(SPHLoginVM userAuthInfo)
        {
            if (ModelState.IsValid)
            {
                var context = new TPContext();
                var SPHLogin = context.SPHLogins.First();
                if (context.SPHLogins.Any(x => x.LoginEmail == userAuthInfo.Username && x.Pswd == userAuthInfo.Password))
                {
                    ApplicationSession.AccessLevel = "SPH";
                    ApplicationSession.Username = userAuthInfo.Username;
                    return Redirect("/Home/SPH_Profile");
                }
                else
                {
                    // Display error
                    ModelState.AddModelError(string.Empty, "Invalid Username or Password");
                    return View(userAuthInfo);

                }
            }
            else
            {
                return View();
            }

        }

        public ActionResult Register()
        {
            return View();
        }
    }
}