using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThemePark.DAL;
using ThemePark.ViewModels;

namespace ThemePark.Controllers
{
    public class EmployeeAccountController : Controller
    {
        // GET: EmployeeAccount
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(EmployeeLoginVM userAuthInfo)
        {
            if (ModelState.IsValid)
            {

                //need to get the Employee ID from the login table
                //Use that ID to identify if that employee is a manager
                var context = new TPContext();
                if (context.EmployeeLogins.Any(x => x.LoginEmail == userAuthInfo.Username && x.Pswd == userAuthInfo.Password) == true)
                {
                    var EmployeeLogin = context.EmployeeLogins.Single(x => x.LoginEmail == userAuthInfo.Username && x.Pswd == userAuthInfo.Password);
                    if (EmployeeLogin != null && context.MANAGED_BY.Any(x => x.EmployeeID == EmployeeLogin.EmployeeID))
                    {
                        ApplicationSession.AccessLevel = "Manager";
                        ApplicationSession.Username = userAuthInfo.Username;
                        return Redirect("/Home/ManagerHub");
                    }
                    else if (EmployeeLogin != null)
                    {
                        ApplicationSession.AccessLevel = "Employee";
                        ApplicationSession.Username = userAuthInfo.Username;
                        return Redirect("/Home/EmployeeHub");
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
    }
}