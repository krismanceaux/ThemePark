using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ThemePark.ViewModels
{
    public class RideReportVM
    {

        [Display(Name = "Total Permitted today")]
        public int DailyTotal { get; set; }

        [Display(Name = "Total Permitted this Week")]
        public int WeeklyTotal { get; set; }

        [Display(Name = "Total Permitted this Month")]
        public int MonthlyTotal { get; set; }

        [Display(Name = "Average every Week")]
        public int WeeklyAvg { get; set; }

        [Display(Name = "Average every Month")]
        public int MonthlyAvg { get; set; }

        [Display(Name = "Total Permitted this Year")]
        public int YearlyTotal { get; set; }

        [Display(Name = "Average this Year")]
        public int YearlyAvg { get; set; }


        [Display(Name = "Total")]
        public int TC_Permit { get; set; }

        [Display(Name = "Weekly")]
        public int TC_WeeklyAvg { get; set; }

        [Display(Name = "Monthly")]
        public int TC_MonthlyAvg { get; set; }

        [Display(Name = "Yearly")]
        public int TC_YearlyAvg { get; set; }


        [Display(Name = "Total")]
        public int CT_Permit { get; set; }

        [Display(Name = "Weekly")]
        public int CT_WeeklyAvg { get; set; }

        [Display(Name = "Monthly")]
        public int CT_MonthlyAvg { get; set; }

        [Display(Name = "Yearly")]
        public int CT_YearlyAvg { get; set; }


        [Display(Name = "Total")]
        public int UD_Permit { get; set; }

        [Display(Name = "Weekly")]
        public int UD_WeeklyAvg { get; set; }

        [Display(Name = "Monthly")]
        public int UD_MonthlyAvg { get; set; }

        [Display(Name = "Yearly")]
        public int UD_YearlyAvg { get; set; }


        [Display(Name = "Total")]
        public int UT_Permit { get; set; }

        [Display(Name = "Weekly")]
        public int UT_WeeklyAvg { get; set; }

        [Display(Name = "Monthly")]
        public int UT_MonthlyAvg { get; set; }

        [Display(Name = "Yearly")]
        public int UT_YearlyAvg { get; set; }


        [Display(Name = "Total")]
        public int Teacups_Permit { get; set; }

        [Display(Name = "Weekly")]
        public int Teacups_WeeklyAvg { get; set; }

        [Display(Name = "Monthly")]
        public int Teacups_MonthlyAvg { get; set; }

        [Display(Name = "Yearly")]
        public int Teacups_YearlyAvg { get; set; }


        [Display(Name = "Total")]
        public int TT_Permit { get; set; }

        [Display(Name = "Weekly")]
        public int TT_WeeklyAvg { get; set; }

        [Display(Name = "Monthly")]
        public int TT_MonthlyAvg { get; set; }

        [Display(Name = "Yearly")]
        public int TT_YearlyAvg { get; set; }


        [Display(Name = "Total")]
        public int LC_Permit { get; set; }

        [Display(Name = "Weekly")]
        public int LC_WeeklyAvg { get; set; }

        [Display(Name = "Monthly")]
        public int LC_MonthlyAvg { get; set; }

        [Display(Name = "Yearly")]
        public int LC_YearlyAvg { get; set; }


        [Display(Name = "Total")]
        public int FW_Permit { get; set; }

        [Display(Name = "Weekly")]
        public int FW_WeeklyAvg { get; set; }

        [Display(Name = "Monthly")]
        public int FW_MonthlyAvg { get; set; }

        [Display(Name = "Yearly")]
        public int FW_YearlyAvg { get; set; }


        [Display(Name = "Total")]
        public int UHCS_Permit { get; set; }

        [Display(Name = "Weekly")]
        public int UHCS_WeeklyAvg { get; set; }

        [Display(Name = "Monthly")]
        public int UHCS_MonthlyAvg { get; set; }

        [Display(Name = "Yearly")]
        public int UHCS_YearlyAvg { get; set; }


        [Display(Name = "Total")]
        public int AB_Permit { get; set; }

        [Display(Name = "Weekly")]
        public int AB_WeeklyAvg { get; set; }

        [Display(Name = "Monthly")]
        public int AB_MonthlyAvg { get; set; }

        [Display(Name = "Yearly")]
        public int AB_YearlyAvg { get; set; }
    }
}