using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThemePark.AuthData;
using ThemePark.DAL;
using System.Data.Entity;
using ThemePark.ViewModels;


namespace ThemePark.Controllers
{
    //[AuthAttribute]
    public class DataController : Controller
    {
        private TPContext db = new TPContext();


        // GET: Data
        public ActionResult Index()
        {
            if (ApplicationSession.AccessLevel == "Manager")
                return View();
            else
                return Redirect(ApplicationSession.RedirectToHomeURL);
            
        }

        public ActionResult MaintenanceGraphic()
        {

            var AB_Maint = db.Maintenances.Where(x => x.RideID == 100010);
            ViewBag.AB_Emergency = AB_Maint.Count(x => x.MaintCode.Value == 4);
            ViewBag.AB_Periodic = AB_Maint.Count(x => x.MaintCode.Value == 1);
            ViewBag.AB_Scheduled = AB_Maint.Count(x => x.MaintCode.Value == 2);
            ViewBag.AB_Unscheduled = AB_Maint.Count(x => x.MaintCode.Value == 3);

            var CT_Maint = db.Maintenances.Where(x => x.RideID == 100001);
            ViewBag.CT_Emergency = CT_Maint.Count(x => x.MaintCode.Value == 4);
            ViewBag.CT_Periodic = CT_Maint.Count(x => x.MaintCode.Value == 1);
            ViewBag.CT_Scheduled = CT_Maint.Count(x => x.MaintCode.Value == 2);
            ViewBag.CT_Unscheduled = CT_Maint.Count(x => x.MaintCode.Value == 3);

            var FW_Maint = db.Maintenances.Where(x => x.RideID == 100008);
            ViewBag.FW_Emergency = FW_Maint.Count(x => x.MaintCode.Value == 4);
            ViewBag.FW_Periodic = FW_Maint.Count(x => x.MaintCode.Value == 1);
            ViewBag.FW_Scheduled = FW_Maint.Count(x => x.MaintCode.Value == 2);
            ViewBag.FW_Unscheduled = FW_Maint.Count(x => x.MaintCode.Value == 3);

            var LC_Maint = db.Maintenances.Where(x => x.RideID == 100006);
            ViewBag.LC_Emergency = LC_Maint.Count(x => x.MaintCode.Value == 4);
            ViewBag.LC_Periodic = LC_Maint.Count(x => x.MaintCode.Value == 1);
            ViewBag.LC_Scheduled = LC_Maint.Count(x => x.MaintCode.Value == 2);
            ViewBag.LC_Unscheduled = LC_Maint.Count(x => x.MaintCode.Value == 3);

            var TC_Maint = db.Maintenances.Where(x => x.RideID == 100000);
            ViewBag.TC_Emergency = TC_Maint.Count(x => x.MaintCode.Value == 4);
            ViewBag.TC_Periodic = TC_Maint.Count(x => x.MaintCode.Value == 1);
            ViewBag.TC_Scheduled = TC_Maint.Count(x => x.MaintCode.Value == 2);
            ViewBag.TC_Unscheduled = TC_Maint.Count(x => x.MaintCode.Value == 3);

            

            return View();
        }

        public ActionResult MaintenanceGraphic2()
        {
            var Teacups_Maint = db.Maintenances.Where(x => x.RideID == 100004);
            ViewBag.Teacups_Emergency = Teacups_Maint.Count(x => x.MaintCode.Value == 4);
            ViewBag.Teacups_Periodic = Teacups_Maint.Count(x => x.MaintCode.Value == 1);
            ViewBag.Teacups_Scheduled = Teacups_Maint.Count(x => x.MaintCode.Value == 2);
            ViewBag.Teacups_Unscheduled = Teacups_Maint.Count(x => x.MaintCode.Value == 3);

            var TT_Maint = db.Maintenances.Where(x => x.RideID == 100005);
            ViewBag.TT_Emergency = TT_Maint.Count(x => x.MaintCode.Value == 4);
            ViewBag.TT_Periodic = TT_Maint.Count(x => x.MaintCode.Value == 1);
            ViewBag.TT_Scheduled = TT_Maint.Count(x => x.MaintCode.Value == 2);
            ViewBag.TT_Unscheduled = TT_Maint.Count(x => x.MaintCode.Value == 3);

            var UD_Maint = db.Maintenances.Where(x => x.RideID == 100002);
            ViewBag.UD_Emergency = UD_Maint.Count(x => x.MaintCode.Value == 4);
            ViewBag.UD_Periodic = UD_Maint.Count(x => x.MaintCode.Value == 1);
            ViewBag.UD_Scheduled = UD_Maint.Count(x => x.MaintCode.Value == 2);
            ViewBag.UD_Unscheduled = UD_Maint.Count(x => x.MaintCode.Value == 3);

            var UHCS_Maint = db.Maintenances.Where(x => x.RideID == 100009);
            ViewBag.UHCS_Emergency = UHCS_Maint.Count(x => x.MaintCode.Value == 4);
            ViewBag.UHCS_Periodic = UHCS_Maint.Count(x => x.MaintCode.Value == 1);
            ViewBag.UHCS_Scheduled = UHCS_Maint.Count(x => x.MaintCode.Value == 2);
            ViewBag.UHCS_Unscheduled = UHCS_Maint.Count(x => x.MaintCode.Value == 3);

            var UT_Maint = db.Maintenances.Where(x => x.RideID == 100003);
            ViewBag.UT_Emergency = UT_Maint.Count(x => x.MaintCode.Value == 4);
            ViewBag.UT_Periodic = UT_Maint.Count(x => x.MaintCode.Value == 1);
            ViewBag.UT_Scheduled = UT_Maint.Count(x => x.MaintCode.Value == 2);
            ViewBag.UT_Unscheduled = UT_Maint.Count(x => x.MaintCode.Value == 3);
            return View();
        }

        [HttpGet]
        public ActionResult CurrentMaintenance()
        {
            var currentMaintenance = db.Maintenances.Include(m => m.MaintCode1).Include(m => m.Ride).Where(m => m.CorrectiveAction == null).ToList();
            return View(currentMaintenance);
        }

        [HttpGet]
        public ActionResult MaintenanceReport()
        {
            var maintVM = new MaintenanceVM();
           
            var eMaint = db.Maintenances.Where(x => x.MaintCode == 4);

            maintVM.AvgMonthlyInop = eMaint.Count() / 4;
            maintVM.AvgWeeklyInop = eMaint.Count() / 15;

            var TC_Maint = db.Maintenances.Where(x => x.RideID == 100000);
            var CT_Maint = db.Maintenances.Where(x => x.RideID == 100001);
            var UD_Maint = db.Maintenances.Where(x => x.RideID == 100002);
            var UT_Maint = db.Maintenances.Where(x => x.RideID == 100003);
            var Teacups_Maint = db.Maintenances.Where(x => x.RideID == 100004);
            var TT_Maint = db.Maintenances.Where(x => x.RideID == 100005);
            var LC_Maint = db.Maintenances.Where(x => x.RideID == 100006);
            var FW_Maint = db.Maintenances.Where(x => x.RideID == 100008);
            var UHCS_Maint = db.Maintenances.Where(x => x.RideID == 100009);
            var AB_Maint = db.Maintenances.Where(x => x.RideID == 100010);

            maintVM.AB_maint = AB_Maint.Count();
            maintVM.AB_Emergency = AB_Maint.Count(x => x.MaintCode.Value == 4);
            maintVM.AB_Periodic = AB_Maint.Count(x => x.MaintCode.Value == 1);
            maintVM.AB_Scheduled = AB_Maint.Count(x => x.MaintCode.Value == 2);
            maintVM.AB_Unscheduled = AB_Maint.Count(x => x.MaintCode.Value == 3);


            maintVM.CT_maint = CT_Maint.Count();
            maintVM.CT_Emergency = CT_Maint.Count(x => x.MaintCode.Value == 4);
            maintVM.CT_Periodic = CT_Maint.Count(x => x.MaintCode.Value == 1);
            maintVM.CT_Scheduled = CT_Maint.Count(x => x.MaintCode.Value == 2);
            maintVM.CT_Unscheduled = CT_Maint.Count(x => x.MaintCode.Value == 3);

            maintVM.FW_maint = FW_Maint.Count();
            maintVM.FW_Emergency = FW_Maint.Count(x => x.MaintCode.Value == 4);
            maintVM.FW_Periodic = FW_Maint.Count(x => x.MaintCode.Value == 1);
            maintVM.FW_Scheduled = FW_Maint.Count(x => x.MaintCode.Value == 2);
            maintVM.FW_Unscheduled = FW_Maint.Count(x => x.MaintCode.Value == 3);


            maintVM.LC_maint = LC_Maint.Count();
            maintVM.LC_Emergency = LC_Maint.Count(x => x.MaintCode.Value == 4);
            maintVM.LC_Periodic = LC_Maint.Count(x => x.MaintCode.Value == 1);
            maintVM.LC_Scheduled = LC_Maint.Count(x => x.MaintCode.Value == 2);
            maintVM.LC_Unscheduled = LC_Maint.Count(x => x.MaintCode.Value == 3);

            maintVM.TC_maint = TC_Maint.Count();
            maintVM.TC_Emergency = TC_Maint.Count(x => x.MaintCode.Value == 4);
            maintVM.TC_Periodic = TC_Maint.Count(x => x.MaintCode.Value == 1);
            maintVM.TC_Scheduled = TC_Maint.Count(x => x.MaintCode.Value == 2);
            maintVM.TC_Unscheduled = TC_Maint.Count(x => x.MaintCode.Value == 3);


            maintVM.Teacups_maint = Teacups_Maint.Count();
            maintVM.Teacups_Emergency = Teacups_Maint.Count(x => x.MaintCode.Value == 4);
            maintVM.Teacups_Periodic = Teacups_Maint.Count(x => x.MaintCode.Value == 1);
            maintVM.Teacups_Scheduled = Teacups_Maint.Count(x => x.MaintCode.Value == 2);
            maintVM.Teacups_Unscheduled = Teacups_Maint.Count(x => x.MaintCode.Value == 3);

            maintVM.TT_maint = TT_Maint.Count();
            maintVM.TT_Emergency = TT_Maint.Count(x => x.MaintCode.Value == 4);
            maintVM.TT_Periodic = TT_Maint.Count(x => x.MaintCode.Value == 1);
            maintVM.TT_Scheduled = TT_Maint.Count(x => x.MaintCode.Value == 2);
            maintVM.TT_Unscheduled = TT_Maint.Count(x => x.MaintCode.Value == 3);


            maintVM.UD_maint = UD_Maint.Count();
            maintVM.UD_Emergency = UD_Maint.Count(x => x.MaintCode.Value == 4);
            maintVM.UD_Periodic = UD_Maint.Count(x => x.MaintCode.Value == 1);
            maintVM.UD_Scheduled = UD_Maint.Count(x => x.MaintCode.Value == 2);
            maintVM.UD_Unscheduled = UD_Maint.Count(x => x.MaintCode.Value == 3);

            maintVM.UHCS_maint = UHCS_Maint.Count();
            maintVM.UHCS_Emergency = UHCS_Maint.Count(x => x.MaintCode.Value == 4);
            maintVM.UHCS_Periodic = UHCS_Maint.Count(x => x.MaintCode.Value == 1);
            maintVM.UHCS_Scheduled = UHCS_Maint.Count(x => x.MaintCode.Value == 2);
            maintVM.UHCS_Unscheduled = UHCS_Maint.Count(x => x.MaintCode.Value == 3);


            maintVM.UT_maint = UT_Maint.Count();
            maintVM.UT_Emergency = UT_Maint.Count(x => x.MaintCode.Value == 4);
            maintVM.UT_Periodic = UT_Maint.Count(x => x.MaintCode.Value == 1);
            maintVM.UT_Scheduled = UT_Maint.Count(x => x.MaintCode.Value == 2);
            maintVM.UT_Unscheduled = UT_Maint.Count(x => x.MaintCode.Value == 3);



            maintVM.CurrentNumEmergency = db.Maintenances.Count(m => m.MaintCode == 4);
            maintVM.CurrentNumScheduled = db.Maintenances.Count(m => m.MaintCode == 2);
            maintVM.CurrentNumUnscheduled = db.Maintenances.Count(m => m.MaintCode == 3);
            maintVM.CurrentNumPeriodic = db.Maintenances.Count(m => m.MaintCode == 1);

            //retrieve info from DB and store in ViewModel to be displayed
            return View(maintVM);
        }

    }
}