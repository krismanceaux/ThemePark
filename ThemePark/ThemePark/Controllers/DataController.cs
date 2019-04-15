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
        private object reader;

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
                //int day = DateTime.Now.Day;
                int day = 13;

                //Daily
                
                AdmitVM.DailyTotal = db.ADMITTED_BY.Count(m => m.AdmissionsDate.Value.Day == day && 
                m.AdmissionsDate.Value.Month == month && 
                m.AdmissionsDate.Value.Year == year);

                //Weekly
                int weekno = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                AdmitVM.WeeklyTotal = db.ADMITTED_BY.ToList().Count
                    (m => CultureInfo.InvariantCulture.Calendar.GetWeekOfYear
                    (m.AdmissionsDate.Value, CalendarWeekRule.FirstDay, DayOfWeek.Monday) == weekno);
                int WeekDay = (((int)DateTime.Today.DayOfWeek + 6) % 7) + 1;
                AdmitVM.WeeklyAvg = AdmitVM.WeeklyTotal / WeekDay;

                //Monthly
                AdmitVM.MonthlyTotal = db.ADMITTED_BY.Count(m => m.AdmissionsDate.Value.Month == month && m.AdmissionsDate.Value.Year == year);
                AdmitVM.MonthlyAvg = AdmitVM.MonthlyTotal / day;

                //Yearly
                AdmitVM.YearlyTotal = db.ADMITTED_BY.Count(m => m.AdmissionsDate.Value.Year == year);
                AdmitVM.YearlyAvg = db.ADMITTED_BY.Count(m => m.AdmissionsDate.Value.Year == year) / DateTime.Today.DayOfYear;
                AdmitVM.YearlyAvgPerMonth = db.ADMITTED_BY.Count(m => m.AdmissionsDate.Value.Year == year) / DateTime.Today.Month;

                //If (spiked month)
                //AdmitVM.SpikedMonths.append(Month.tostring())
                for (int i = 1; i <= month; i++)
                {
                    int MonthCount = db.ADMITTED_BY.Count(m => m.AdmissionsDate.Value.Year == year && m.AdmissionsDate.Value.Month == i);
                    if (MonthCount > AdmitVM.YearlyAvgPerMonth)
                    {
                        AdmitVM.SpikedMonths.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i));
                    }
                }

                //Rainouts
                int count = 0;
                //Count Current Month
                for (int i = 1; i <= day; i++)
                {
                    int DayCheck = db.ADMITTED_BY.Count(m => m.AdmissionsDate.Value.Month == month &&
                    m.AdmissionsDate.Value.Day == i &&
                    m.AdmissionsDate.Value.Year == year);
                    if (DayCheck == 0)
                    {
                        count++;
                    }
                }
                AdmitVM.MonthlyRainouts = count;

                //Count Previous Months
                for (int i = 1; i < month; i++)
                {
                    for (int j = 1; j <= DateTime.DaysInMonth(year, i); j++)
                    {
                        int DayCheck = db.ADMITTED_BY.Count(m => m.AdmissionsDate.Value.Month == i &&
                        m.AdmissionsDate.Value.Day == j &&
                        m.AdmissionsDate.Value.Year == year);
                        if (DayCheck == 0)
                        {
                            count++;
                        }
                    }
                }
                AdmitVM.Rainouts = count;
                return View(AdmitVM);
            }
            else
            {
                return Redirect(ApplicationSession.RedirectToHomeURL);
            }
        }

        //Update, chose selected month
        [HttpPost]
        public ActionResult AdmissionsReport(AdmissionsVM AdmitVM)
        {
            var NewAdmit = new AdmissionsVM();
            int year = DateTime.Now.Year;
            int month = AdmitVM.SelectedMonth;
            //int day = DateTime.Now.Day;
            int day = 13;

            //Daily
            NewAdmit.DailyTotal = db.ADMITTED_BY.Count(m => m.AdmissionsDate.Value.Day == day && 
            m.AdmissionsDate.Value.Month == DateTime.Now.Month && 
            m.AdmissionsDate.Value.Year == year);

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
            NewAdmit.YearlyAvgPerMonth = db.ADMITTED_BY.Count(m => m.AdmissionsDate.Value.Year == year) / DateTime.Today.Month;

            for (int i = 1; i <= DateTime.Now.Month; i++)
            {
                int MonthCount = db.ADMITTED_BY.Count(m => m.AdmissionsDate.Value.Year == year && m.AdmissionsDate.Value.Month == i);
                if (MonthCount > NewAdmit.YearlyAvgPerMonth)
                {
                    NewAdmit.SpikedMonths.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i));
                }
            }

            //Rainouts
            int count = 0;
            //Count Current Month
            int DayCount;
            //IF current month, go up to current day
            if(month == DateTime.Now.Month)
            {
                DayCount = day;
            }
            else
            {
                DayCount = DateTime.DaysInMonth(year, month);
            }

            for (int i = 1; i <= DayCount; i++)
            {
                int DayCheck = db.ADMITTED_BY.Count(m => m.AdmissionsDate.Value.Month == month &&
                m.AdmissionsDate.Value.Day == i &&
                m.AdmissionsDate.Value.Year == year);
                if (DayCheck == 0)
                {
                    count++;
                }
            }

            NewAdmit.MonthlyRainouts = count;

            //Need to reset count, so as not to double count a month accidentally
            //Count Previous Months
            month = DateTime.Now.Month;
            count = 0;
            for (int i = 1; i < month; i++)
            {
                for (int j = 1; j <= DateTime.DaysInMonth(year, i); j++)
                {
                    int DayCheck = db.ADMITTED_BY.Count(m => m.AdmissionsDate.Value.Month == i &&
                    m.AdmissionsDate.Value.Day == j &&
                    m.AdmissionsDate.Value.Year == year);
                    if (DayCheck == 0)
                    {
                        count++;
                    }
                }
            }
            for (int i = 1; i <= day; i++)
            {
                int DayCheck = db.ADMITTED_BY.Count(m => m.AdmissionsDate.Value.Month == month &&
                m.AdmissionsDate.Value.Day == i &&
                m.AdmissionsDate.Value.Year == year);
                if (DayCheck == 0)
                {
                    count++;
                }
            }
            NewAdmit.Rainouts = count;

            return View(NewAdmit);
        }



        //Maintenance Report Page
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

        public ActionResult RideGraphic()
        {
            var rGraphicVM = new RideGraphicsVM();

            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            //Monthly Permitted
            rGraphicVM.ThisMonthlyTotal = db.PERMITS.Count(m => m.PTimeStamp.Value.Month == month && m.PTimeStamp.Value.Year == year);
            rGraphicVM.MonthlyTotal = db.PERMITS.Count(m => m.PTimeStamp.Value.Month <= 3 && m.PTimeStamp.Value.Year == year);
            rGraphicVM.MonthlyAvg = rGraphicVM.MonthlyTotal / 3;

            //Yearly Admitted
            rGraphicVM.YearlyTotal = db.PERMITS.Count(m => m.PTimeStamp.Value.Year == year);
            rGraphicVM.YearlyAvg = db.PERMITS.Count(m => m.PTimeStamp.Value.Year == year) / DateTime.Today.DayOfYear;

            //Weekly Permitted
            int weekno = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            rGraphicVM.WeeklyTotal = db.PERMITS.ToList().Count
                (m => CultureInfo.InvariantCulture.Calendar.GetWeekOfYear
                (m.PTimeStamp.Value, CalendarWeekRule.FirstDay, DayOfWeek.Monday) == weekno);
            int weekday = (((int)DateTime.Today.DayOfWeek + 6) % 7) + 1;
            rGraphicVM.WeeklyAvg = rGraphicVM.YearlyTotal / weekno;


            var AB_PERMIT = db.PERMITS.Where(x => x.RideID == 100010);
            ViewBag.AB_WeeklyAvg = AB_PERMIT.ToList().Count(m => m.PTimeStamp.Value.Year == year) / weekno;
            ViewBag.AB_MonthlyAvg = AB_PERMIT.Count(m => m.PTimeStamp.Value.Month <= 3 && m.PTimeStamp.Value.Year == year) / 3;
            ViewBag.AB_YearlyAvg = AB_PERMIT.Count(m => m.PTimeStamp.Value.Year == year) / DateTime.Today.DayOfYear;

            var CT_PERMIT = db.PERMITS.Where(x => x.RideID == 100001);
            ViewBag.CT_WeeklyAvg = CT_PERMIT.ToList().Count(m => m.PTimeStamp.Value.Year == year) / weekno;
            ViewBag.CT_MonthlyAvg = CT_PERMIT.Count(m => m.PTimeStamp.Value.Month <= 3 && m.PTimeStamp.Value.Year == year) / 3;
            ViewBag.CT_YearlyAvg = CT_PERMIT.Count(m => m.PTimeStamp.Value.Year == year) / DateTime.Today.DayOfYear;

            var FW_PERMIT = db.PERMITS.Where(x => x.RideID == 100008);
            ViewBag.FW_WeeklyAvg = FW_PERMIT.ToList().Count(m => m.PTimeStamp.Value.Year == year) / weekno;
            ViewBag.FW_MonthlyAvg = FW_PERMIT.Count(m => m.PTimeStamp.Value.Month <= 3 && m.PTimeStamp.Value.Year == year) / 3;
            ViewBag.FW_YearlyAvg = FW_PERMIT.Count(m => m.PTimeStamp.Value.Year == year) / DateTime.Today.DayOfYear;

            var LC_PERMIT = db.PERMITS.Where(x => x.RideID == 100006);
            ViewBag.LC_WeeklyAvg = LC_PERMIT.ToList().Count(m => m.PTimeStamp.Value.Year == year) / weekno;
            ViewBag.LC_MonthlyAvg = LC_PERMIT.Count(m => m.PTimeStamp.Value.Month <= 3 && m.PTimeStamp.Value.Year == year) / 3;
            ViewBag.LC_YearlyAvg = LC_PERMIT.Count(m => m.PTimeStamp.Value.Year == year) / DateTime.Today.DayOfYear;

            var TC_PERMIT = db.PERMITS.Where(x => x.RideID == 100000);
            ViewBag.TC_WeeklyAvg = TC_PERMIT.ToList().Count(m => m.PTimeStamp.Value.Year == year) / weekno;
            ViewBag.TC_MonthlyAvg = TC_PERMIT.Count(m => m.PTimeStamp.Value.Month <= 3 && m.PTimeStamp.Value.Year == year) / 3;
            ViewBag.TC_YearlyAvg = TC_PERMIT.Count(m => m.PTimeStamp.Value.Year == year) / DateTime.Today.DayOfYear;

            return View();
        }

        public ActionResult RideGraphic2()
        {
            var rGraphicVM = new RideGraphicsVM();

            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            //Monthly Permitted
            rGraphicVM.ThisMonthlyTotal = db.PERMITS.Count(m => m.PTimeStamp.Value.Month == month && m.PTimeStamp.Value.Year == year);
            rGraphicVM.MonthlyTotal = db.PERMITS.Count(m => m.PTimeStamp.Value.Month <= 3 && m.PTimeStamp.Value.Year == year);
            rGraphicVM.MonthlyAvg = rGraphicVM.MonthlyTotal / 3;

            //Yearly Admitted
            rGraphicVM.YearlyTotal = db.PERMITS.Count(m => m.PTimeStamp.Value.Year == year);
            rGraphicVM.YearlyAvg = db.PERMITS.Count(m => m.PTimeStamp.Value.Year == year) / DateTime.Today.DayOfYear;

            //Weekly Permitted
            int weekno = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            rGraphicVM.WeeklyTotal = db.PERMITS.ToList().Count
                (m => CultureInfo.InvariantCulture.Calendar.GetWeekOfYear
                (m.PTimeStamp.Value, CalendarWeekRule.FirstDay, DayOfWeek.Monday) == weekno);
            int weekday = (((int)DateTime.Today.DayOfWeek + 6) % 7) + 1;
            rGraphicVM.WeeklyAvg = rGraphicVM.YearlyTotal / weekno;

            var Teacups_PERMIT = db.PERMITS.Where(x => x.RideID == 100004);
            ViewBag.Teacups_WeeklyAvg = Teacups_PERMIT.ToList().Count(m => m.PTimeStamp.Value.Year == year) / weekno;
            ViewBag.Teacups_MonthlyAvg = Teacups_PERMIT.Count(m => m.PTimeStamp.Value.Month <= 3 && m.PTimeStamp.Value.Year == year) / 3;
            ViewBag.Teacups_YearlyAvg = Teacups_PERMIT.Count(m => m.PTimeStamp.Value.Year == year) / DateTime.Today.DayOfYear;

            var TT_PERMIT = db.PERMITS.Where(x => x.RideID == 100005);
            ViewBag.TT_WeeklyAvg = TT_PERMIT.ToList().Count(m => m.PTimeStamp.Value.Year == year) / weekno;
            ViewBag.TT_MonthlyAvg = TT_PERMIT.Count(m => m.PTimeStamp.Value.Month <= 3 && m.PTimeStamp.Value.Year == year) / 3;
            ViewBag.TT_YearlyAvg = TT_PERMIT.Count(m => m.PTimeStamp.Value.Year == year) / DateTime.Today.DayOfYear;

            var UD_PERMIT = db.PERMITS.Where(x => x.RideID == 100002);
            ViewBag.UD_WeeklyAvg = UD_PERMIT.ToList().Count(m => m.PTimeStamp.Value.Year == year) / weekno;
            ViewBag.UD_MonthlyAvg = UD_PERMIT.Count(m => m.PTimeStamp.Value.Month <= 3 && m.PTimeStamp.Value.Year == year) / 3;
            ViewBag.UD_YearlyAvg = UD_PERMIT.Count(m => m.PTimeStamp.Value.Year == year) / DateTime.Today.DayOfYear;

            var UHCS_PERMIT = db.PERMITS.Where(x => x.RideID == 100009);
            ViewBag.UHCS_WeeklyAvg = UHCS_PERMIT.ToList().Count(m => m.PTimeStamp.Value.Year == year) / weekno;
            ViewBag.UHCS_MonthlyAvg = UHCS_PERMIT.Count(m => m.PTimeStamp.Value.Month <= 3 && m.PTimeStamp.Value.Year == year) / 3;
            ViewBag.UHCS_YearlyAvg = UHCS_PERMIT.Count(m => m.PTimeStamp.Value.Year == year) / DateTime.Today.DayOfYear;

            var UT_PERMIT = db.PERMITS.Where(x => x.RideID == 100003);
            ViewBag.UT_WeeklyAvg = UT_PERMIT.ToList().Count(m => m.PTimeStamp.Value.Year == year) / weekno;
            ViewBag.UT_MonthlyAvg = UT_PERMIT.Count(m => m.PTimeStamp.Value.Month <= 3 && m.PTimeStamp.Value.Year == year) / 3;
            ViewBag.UT_YearlyAvg = UT_PERMIT.Count(m => m.PTimeStamp.Value.Year == year) / DateTime.Today.DayOfYear;
            return View();
        }
        //Update with info for selected month
        [HttpPost]
        public ActionResult MaintenanceReport(MaintenanceVM maintVM)
        {
            var newMaint = new MaintenanceVM();

            var eMaint = db.Maintenances.Where(x => x.MaintCode == 4);

            newMaint.AvgMonthlyInop = eMaint.Count() / 4;
            newMaint.AvgWeeklyInop = eMaint.Count() / 15;

            int month = maintVM.SelectedMonth;

            var TC_Maint = db.Maintenances.Where(x => x.RideID == 100000 && x.DateAdded.Value.Month == month);
            var CT_Maint = db.Maintenances.Where(x => x.RideID == 100001 && x.DateAdded.Value.Month == month);
            var UD_Maint = db.Maintenances.Where(x => x.RideID == 100002 && x.DateAdded.Value.Month == month);
            var UT_Maint = db.Maintenances.Where(x => x.RideID == 100003 && x.DateAdded.Value.Month == month);
            var Teacups_Maint = db.Maintenances.Where(x => x.RideID == 100004 && x.DateAdded.Value.Month == month);
            var TT_Maint = db.Maintenances.Where(x => x.RideID == 100005 && x.DateAdded.Value.Month == month);
            var LC_Maint = db.Maintenances.Where(x => x.RideID == 100006 && x.DateAdded.Value.Month == month);
            var FW_Maint = db.Maintenances.Where(x => x.RideID == 100008 && x.DateAdded.Value.Month == month);
            var UHCS_Maint = db.Maintenances.Where(x => x.RideID == 100009 && x.DateAdded.Value.Month == month);
            var AB_Maint = db.Maintenances.Where(x => x.RideID == 100010 && x.DateAdded.Value.Month == month);

            newMaint.AB_maint = AB_Maint.Count();
            newMaint.AB_Emergency = AB_Maint.Count(x => x.MaintCode.Value == 4);
            newMaint.AB_Periodic = AB_Maint.Count(x => x.MaintCode.Value == 1);
            newMaint.AB_Scheduled = AB_Maint.Count(x => x.MaintCode.Value == 2);
            newMaint.AB_Unscheduled = AB_Maint.Count(x => x.MaintCode.Value == 3);


            newMaint.CT_maint = CT_Maint.Count();
            newMaint.CT_Emergency = CT_Maint.Count(x => x.MaintCode.Value == 4);
            newMaint.CT_Periodic = CT_Maint.Count(x => x.MaintCode.Value == 1);
            newMaint.CT_Scheduled = CT_Maint.Count(x => x.MaintCode.Value == 2);
            newMaint.CT_Unscheduled = CT_Maint.Count(x => x.MaintCode.Value == 3);

            newMaint.FW_maint = FW_Maint.Count();
            newMaint.FW_Emergency = FW_Maint.Count(x => x.MaintCode.Value == 4);
            newMaint.FW_Periodic = FW_Maint.Count(x => x.MaintCode.Value == 1);
            newMaint.FW_Scheduled = FW_Maint.Count(x => x.MaintCode.Value == 2);
            newMaint.FW_Unscheduled = FW_Maint.Count(x => x.MaintCode.Value == 3);


            newMaint.LC_maint = LC_Maint.Count();
            newMaint.LC_Emergency = LC_Maint.Count(x => x.MaintCode.Value == 4);
            newMaint.LC_Periodic = LC_Maint.Count(x => x.MaintCode.Value == 1);
            newMaint.LC_Scheduled = LC_Maint.Count(x => x.MaintCode.Value == 2);
            newMaint.LC_Unscheduled = LC_Maint.Count(x => x.MaintCode.Value == 3);

            newMaint.TC_maint = TC_Maint.Count();
            newMaint.TC_Emergency = TC_Maint.Count(x => x.MaintCode.Value == 4);
            newMaint.TC_Periodic = TC_Maint.Count(x => x.MaintCode.Value == 1);
            newMaint.TC_Scheduled = TC_Maint.Count(x => x.MaintCode.Value == 2);
            newMaint.TC_Unscheduled = TC_Maint.Count(x => x.MaintCode.Value == 3);


            newMaint.Teacups_maint = Teacups_Maint.Count();
            newMaint.Teacups_Emergency = Teacups_Maint.Count(x => x.MaintCode.Value == 4);
            newMaint.Teacups_Periodic = Teacups_Maint.Count(x => x.MaintCode.Value == 1);
            newMaint.Teacups_Scheduled = Teacups_Maint.Count(x => x.MaintCode.Value == 2);
            newMaint.Teacups_Unscheduled = Teacups_Maint.Count(x => x.MaintCode.Value == 3);

            newMaint.TT_maint = TT_Maint.Count();
            newMaint.TT_Emergency = TT_Maint.Count(x => x.MaintCode.Value == 4);
            newMaint.TT_Periodic = TT_Maint.Count(x => x.MaintCode.Value == 1);
            newMaint.TT_Scheduled = TT_Maint.Count(x => x.MaintCode.Value == 2);
            newMaint.TT_Unscheduled = TT_Maint.Count(x => x.MaintCode.Value == 3);


            newMaint.UD_maint = UD_Maint.Count();
            newMaint.UD_Emergency = UD_Maint.Count(x => x.MaintCode.Value == 4);
            newMaint.UD_Periodic = UD_Maint.Count(x => x.MaintCode.Value == 1);
            newMaint.UD_Scheduled = UD_Maint.Count(x => x.MaintCode.Value == 2);
            newMaint.UD_Unscheduled = UD_Maint.Count(x => x.MaintCode.Value == 3);

            newMaint.UHCS_maint = UHCS_Maint.Count();
            newMaint.UHCS_Emergency = UHCS_Maint.Count(x => x.MaintCode.Value == 4);
            newMaint.UHCS_Periodic = UHCS_Maint.Count(x => x.MaintCode.Value == 1);
            newMaint.UHCS_Scheduled = UHCS_Maint.Count(x => x.MaintCode.Value == 2);
            newMaint.UHCS_Unscheduled = UHCS_Maint.Count(x => x.MaintCode.Value == 3);


            newMaint.UT_maint = UT_Maint.Count();
            newMaint.UT_Emergency = UT_Maint.Count(x => x.MaintCode.Value == 4);
            newMaint.UT_Periodic = UT_Maint.Count(x => x.MaintCode.Value == 1);
            newMaint.UT_Scheduled = UT_Maint.Count(x => x.MaintCode.Value == 2);
            newMaint.UT_Unscheduled = UT_Maint.Count(x => x.MaintCode.Value == 3);



            newMaint.CurrentNumEmergency = db.Maintenances.Count(m => m.MaintCode == 4);
            newMaint.CurrentNumScheduled = db.Maintenances.Count(m => m.MaintCode == 2);
            newMaint.CurrentNumUnscheduled = db.Maintenances.Count(m => m.MaintCode == 3);
            newMaint.CurrentNumPeriodic = db.Maintenances.Count(m => m.MaintCode == 1);

            return View(newMaint);
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
                rideVM.MonthlyAvg = rideVM.MonthlyTotal / 3;

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