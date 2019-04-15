using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThemePark.Controllers
{
    public class ParkInformationController : Controller
    {
        // GET: ParkInformation
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult AboutUsS()
        {
            return View();
        }

        public ActionResult SocialMedia()
        {
            return View();
        }

        public ActionResult SocialMediaS()
        {
            return View();
        }
    }
}