using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThemePark.AuthData;
using ThemePark.DAL;
using System.Data.Entity;
using ThemePark.ViewModels;
using System.Globalization;
using System.Data.SqlClient;

namespace ThemePark.Controllers
{
    //[AuthAttribute]
    public class DataController : Controller
    {
        private TPContext db = new TPContext();
        private object reader;


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
            var currentMaintenance = db.Maintenances.Include(m => m.MaintCode1).Include(m => m.Ride).Where(m => m.CorrectiveAction == null).ToList();
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

            //retrieve info from DB and store in ViewModel to be displayed
            return View(maintVM);
        }

        [HttpGet]
        public ActionResult RideReport()
        {
            if (ApplicationSession.AccessLevel == "Manager")
            {
                var rideVM = new RideReportVM();

                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;
                int day = DateTime.Now.Day;

                //CultureInfo myCI = new CultureInfo("en-US");
                //Calendar myC = myCI.Calendar;
                //CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
                //DayOfWeek myFDOW = myCI.DateTimeFormat.FirstDayOfWeek;

                //Daily Permitted
                rideVM.DailyTotal = db.PERMITS.Count(m => m.PTimeStamp.Value.Day == day && m.PTimeStamp.Value.Month == month && m.PTimeStamp.Value.Year == year);

                //Monthly Permitted
                rideVM.ThisMonthlyTotal = db.PERMITS.Count(m => m.PTimeStamp.Value.Month == month && m.PTimeStamp.Value.Year == year);
                rideVM.MonthlyTotal = db.PERMITS.Count(m => m.PTimeStamp.Value.Month <= 3 && m.PTimeStamp.Value.Year == year);
                rideVM.MonthlyAvg = rideVM.MonthlyTotal / day;

                //Yearly Admitted
                rideVM.YearlyTotal = db.PERMITS.Count(m => m.PTimeStamp.Value.Year == year);
                rideVM.YearlyAvg = db.PERMITS.Count(m => m.PTimeStamp.Value.Year == year) / DateTime.Today.DayOfYear;

                //Weekly Permitted
                int weekno = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                rideVM.WeeklyTotal = db.PERMITS.ToList().Count
                    (m => CultureInfo.InvariantCulture.Calendar.GetWeekOfYear
                    (m.PTimeStamp.Value, CalendarWeekRule.FirstDay, DayOfWeek.Monday) == weekno);
                int weekday = (((int)DateTime.Today.DayOfWeek + 6) % 7) + 1;
                rideVM.WeeklyAvg = rideVM.YearlyTotal / weekno;

                var TC_Permit = db.PERMITS.Where(x => x.RideID == 100000);
                var CT_Permit = db.PERMITS.Where(x => x.RideID == 100001);
                var UD_Permit = db.PERMITS.Where(x => x.RideID == 100002);
                var UT_Permit = db.PERMITS.Where(x => x.RideID == 100003);
                var Teacups_Permit = db.PERMITS.Where(x => x.RideID == 100004);
                var TT_Permit = db.PERMITS.Where(x => x.RideID == 100005);
                var LC_Permit = db.PERMITS.Where(x => x.RideID == 100006);
                var FW_Permit = db.PERMITS.Where(x => x.RideID == 100007);
                var UHCS_Permit = db.PERMITS.Where(x => x.RideID == 100008);
                var AB_Permit = db.PERMITS.Where(x => x.RideID == 100009);

                rideVM.AB_Permit = AB_Permit.Count();
                rideVM.AB_WeeklyAvg = AB_Permit.ToList().Count(m => m.PTimeStamp.Value.Year == year) / weekno;
                rideVM.AB_MonthlyAvg = AB_Permit.Count(m => m.PTimeStamp.Value.Month <= 3 && m.PTimeStamp.Value.Year == year) / 3;
                rideVM.AB_YearlyAvg = AB_Permit.Count(m => m.PTimeStamp.Value.Year == year) / DateTime.Today.DayOfYear;

                rideVM.CT_Permit = CT_Permit.Count();
                rideVM.CT_WeeklyAvg = CT_Permit.ToList().Count(m => m.PTimeStamp.Value.Year == year) / weekno;
                rideVM.CT_MonthlyAvg = CT_Permit.Count(m => m.PTimeStamp.Value.Month <= 3 && m.PTimeStamp.Value.Year == year) / 3;
                rideVM.CT_YearlyAvg = CT_Permit.Count(m => m.PTimeStamp.Value.Year == year) / DateTime.Today.DayOfYear;

                rideVM.FW_Permit = FW_Permit.Count();
                rideVM.FW_WeeklyAvg = FW_Permit.ToList().Count(m => m.PTimeStamp.Value.Year == year) / weekno;
                rideVM.FW_MonthlyAvg = FW_Permit.Count(m => m.PTimeStamp.Value.Month <= 3 && m.PTimeStamp.Value.Year == year) / 3;
                rideVM.FW_YearlyAvg = FW_Permit.Count(m => m.PTimeStamp.Value.Year == year) / DateTime.Today.DayOfYear;

                rideVM.LC_Permit = LC_Permit.Count();
                rideVM.LC_WeeklyAvg = LC_Permit.ToList().Count(m => m.PTimeStamp.Value.Year == year) / weekno;
                rideVM.LC_MonthlyAvg = LC_Permit.Count(m => m.PTimeStamp.Value.Month <= 3 && m.PTimeStamp.Value.Year == year) / 3;
                rideVM.LC_YearlyAvg = LC_Permit.Count(m => m.PTimeStamp.Value.Year == year) / DateTime.Today.DayOfYear;

                rideVM.TC_Permit = TC_Permit.Count();
                rideVM.TC_WeeklyAvg = TC_Permit.ToList().Count(m => m.PTimeStamp.Value.Year == year) / weekno;
                rideVM.TC_MonthlyAvg = TC_Permit.Count(m => m.PTimeStamp.Value.Month <= 3 && m.PTimeStamp.Value.Year == year) / 3;
                rideVM.TC_YearlyAvg = TC_Permit.Count(m => m.PTimeStamp.Value.Year == year) / DateTime.Today.DayOfYear;

                rideVM.Teacups_Permit = Teacups_Permit.Count();
                rideVM.Teacups_WeeklyAvg = Teacups_Permit.ToList().Count(m => m.PTimeStamp.Value.Year == year) / weekno;
                rideVM.Teacups_MonthlyAvg = Teacups_Permit.Count(m => m.PTimeStamp.Value.Month <= 3 && m.PTimeStamp.Value.Year == year) / 3;
                rideVM.Teacups_YearlyAvg = Teacups_Permit.Count(m => m.PTimeStamp.Value.Year == year) / DateTime.Today.DayOfYear;

                rideVM.TT_Permit = TT_Permit.Count();
                rideVM.TT_WeeklyAvg = TT_Permit.ToList().Count(m => m.PTimeStamp.Value.Year == year) / weekno;
                rideVM.TT_MonthlyAvg = TT_Permit.Count(m => m.PTimeStamp.Value.Month <= 3 && m.PTimeStamp.Value.Year == year) / 3;
                rideVM.TT_YearlyAvg = TT_Permit.Count(m => m.PTimeStamp.Value.Year == year) / DateTime.Today.DayOfYear;

                rideVM.UD_Permit = UD_Permit.Count();
                rideVM.UD_WeeklyAvg = UD_Permit.ToList().Count(m => m.PTimeStamp.Value.Year == year) / weekno;
                rideVM.UD_MonthlyAvg = UD_Permit.Count(m => m.PTimeStamp.Value.Month <= 3 && m.PTimeStamp.Value.Year == year) / 3;
                rideVM.UD_YearlyAvg = UD_Permit.Count(m => m.PTimeStamp.Value.Year == year) / DateTime.Today.DayOfYear;

                rideVM.UHCS_Permit = UHCS_Permit.Count();
                rideVM.UHCS_WeeklyAvg = UHCS_Permit.ToList().Count(m => m.PTimeStamp.Value.Year == year) / weekno;
                rideVM.UHCS_MonthlyAvg = UHCS_Permit.Count(m => m.PTimeStamp.Value.Month <= 3 && m.PTimeStamp.Value.Year == year) / 3;
                rideVM.UHCS_YearlyAvg = UHCS_Permit.Count(m => m.PTimeStamp.Value.Year == year) / DateTime.Today.DayOfYear;

                rideVM.UT_Permit = UT_Permit.Count();
                rideVM.UT_WeeklyAvg = UT_Permit.ToList().Count(m => m.PTimeStamp.Value.Year == year) / weekno;
                rideVM.UT_MonthlyAvg = UT_Permit.Count(m => m.PTimeStamp.Value.Month <= 3 && m.PTimeStamp.Value.Year == year) / 3;
                rideVM.UT_YearlyAvg = UT_Permit.Count(m => m.PTimeStamp.Value.Year == year) / DateTime.Today.DayOfYear;

                return View(rideVM);
            }
            else
            {
                return Redirect(ApplicationSession.RedirectToHomeURL);
            }
        }
    }
}