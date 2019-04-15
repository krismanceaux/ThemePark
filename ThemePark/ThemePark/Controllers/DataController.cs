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
            var currentMaintenance = db.Maintenances.Include(m => m.MaintCode1).Include(m => m.Ride).Where(m => m.CorrectiveAction == null).ToList();
            return View(currentMaintenance);
        }

        //Admissions Report Page
        [HttpGet]
        public ActionResult AdmissionsReport()
        {
            if (ApplicationSession.AccessLevel == "Manager")
            {
                var AdmitVM = new AdmissionsVM();

                //Create Dropdown list to chose what month it is?
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;
                //int month = AdmitVM.SelectedMonth;
                int day = DateTime.Now.Day;

                //Daily
                AdmitVM.DailyTotal = db.ADMITTED_BY.Count(m => m.AdmissionsDate.Value.Day == day);

                //Weekly
                int weekno = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                AdmitVM.WeeklyTotal = db.ADMITTED_BY.ToList().Count
                    (m => CultureInfo.InvariantCulture.Calendar.GetWeekOfYear
                    (m.AdmissionsDate.Value, CalendarWeekRule.FirstDay, DayOfWeek.Monday) == weekno);
                int WeekDay = (((int)DateTime.Today.DayOfWeek + 6) % 7) + 1;
                AdmitVM.WeeklyAvg = AdmitVM.WeeklyTotal / WeekDay;

                //Monthly
                ///int average = 0;
                /*
                for (int i = 1; i <= day; i++)
                {
                    int daily = db.ADMITTED_BY.Count(m => m.AdmissionsDate.Value.Month == month && m.AdmissionsDate.Value.Year == year && m.AdmissionsDate.Value.Day == i);
                    average = average + daily;
                }
                */
                AdmitVM.MonthlyTotal = db.ADMITTED_BY.Count(m => m.AdmissionsDate.Value.Month == month && m.AdmissionsDate.Value.Year == year);
                AdmitVM.MonthlyAvg = AdmitVM.MonthlyTotal / day;

                //Yearly
                AdmitVM.YearlyTotal = db.ADMITTED_BY.Count(m => m.AdmissionsDate.Value.Year == year);
                AdmitVM.YearlyAvg = db.ADMITTED_BY.Count(m => m.AdmissionsDate.Value.Year == year) / DateTime.Today.DayOfYear;

                return View(AdmitVM);
            }
            else
            {
                return Redirect(ApplicationSession.RedirectToHomeURL);
            }
        }

        [HttpPost]
        public ActionResult AdmissionsReport(AdmissionsVM AdmitVM)
        {
            var NewAdmit = new AdmissionsVM();
            int year = DateTime.Now.Year;
            int month = AdmitVM.SelectedMonth;
            int day = DateTime.Now.Day;
            //Daily
            NewAdmit.DailyTotal = db.ADMITTED_BY.Count(m => m.AdmissionsDate.Value.Day == day);

            //Weekly
            int weekno = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            NewAdmit.WeeklyTotal = db.ADMITTED_BY.ToList().Count
                (m => CultureInfo.InvariantCulture.Calendar.GetWeekOfYear
                (m.AdmissionsDate.Value, CalendarWeekRule.FirstDay, DayOfWeek.Monday) == weekno);
            int WeekDay = (((int)DateTime.Today.DayOfWeek + 6) % 7) + 1;
            NewAdmit.WeeklyAvg = NewAdmit.WeeklyTotal / WeekDay;

            //Monthly
            NewAdmit.MonthlyTotal = db.ADMITTED_BY.Count(m => m.AdmissionsDate.Value.Month == month && m.AdmissionsDate.Value.Year == year);
            NewAdmit.MonthlyAvg = NewAdmit.MonthlyTotal / day;

            //Yearly
            NewAdmit.YearlyTotal = db.ADMITTED_BY.Count(m => m.AdmissionsDate.Value.Year == year);
            NewAdmit.YearlyAvg = db.ADMITTED_BY.Count(m => m.AdmissionsDate.Value.Year == year) / DateTime.Today.DayOfYear;

            return View(NewAdmit);
        }

        //Maintenance Report Page
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

    }
}