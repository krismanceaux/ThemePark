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

        [HttpGet]
        public ActionResult CurrentMaintenance()
        {
            var currentMaintenance = db.Maintenances.Include(m => m.MaintCode1).Include(m => m.Ride).Where(m => m.CorrectiveAction == null);
            return View(currentMaintenance);
        }

        [HttpGet]
        public ActionResult MaintenanceReport()
        {
            var maintVM = new MaintenanceVM();
            maintVM.AvgNumRidesInop = 0;
            maintVM.CurrentNumEmergency = db.Maintenances.Count(m => m.MaintCode == 4);
            maintVM.CurrentNumScheduled = db.Maintenances.Count(m => m.MaintCode == 2);
            maintVM.CurrentNumUnscheduled = db.Maintenances.Count(m => m.MaintCode == 3);
            maintVM.CurrentNumPeriodic = db.Maintenances.Count(m => m.MaintCode == 1);
            return View(maintVM);
        }

    }
}