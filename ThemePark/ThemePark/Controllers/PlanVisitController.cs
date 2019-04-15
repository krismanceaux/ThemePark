using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThemePark.Controllers
{
    public class PlanVisitController : Controller
    {
        // GET: PlanVisit
        public ActionResult Park_Map()
        {
            return View();
        }

        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult Park_MapS()
        {
            return View();
        }

        public ActionResult CalendarS()
        {
            return View();
        }
    }
}