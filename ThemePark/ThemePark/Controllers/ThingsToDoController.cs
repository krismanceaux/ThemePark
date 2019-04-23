using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThemePark.Controllers
{
    public class ThingsToDoController : Controller
    {
        private TPContext db = new TPContext();

        public ActionResult UH_Ride()
        {
            var ct = db.Rides.Single(x => x.RideID == 100001);
            var ud = db.Rides.Single(x => x.RideID == 100002);
            var lc = db.Rides.Single(x => x.RideID == 100006);

            ViewBag.ct_Status = ct.RideStatus;
            ViewBag.ud_Status = ud.RideStatus;
            ViewBag.lc_Status = lc.RideStatus;
            return View();
        }

        public ActionResult CS_Train()
        {
            var uhcs = db.Rides.Single(x => x.RideID == 100009);
            var tc = db.Rides.Single(x => x.RideID == 100000);
            
            ViewBag.uhcs_Status = uhcs.RideStatus;
            ViewBag.tc_Status = tc.RideStatus;
            
            return View();
        }

        public ActionResult TEXAS_Coaster()
        {
            var ut = db.Rides.Single(x => x.RideID == 100003);
            var tt = db.Rides.Single(x => x.RideID == 100005);
            var ab = db.Rides.Single(x => x.RideID == 100010);

            ViewBag.ut_Status = ut.RideStatus;
            ViewBag.tt_Status = tt.RideStatus;
            ViewBag.ab_Status = ab.RideStatus;
            return View();
        }

        public ActionResult DBMS_Drive()
        {
            var fw = db.Rides.Single(x => x.RideID == 100008);
            var teacups = db.Rides.Single(x => x.RideID == 100004);

            ViewBag.FW_Status = fw.RideStatus;
            ViewBag.teacups_Status = teacups.RideStatus;
            return View();
        }

    }
}