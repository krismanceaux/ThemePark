using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ThemePark.ViewModels
{
    public class MaintenanceVM
    {
        [Display(Name ="Monthly Average of Rides Inop.")]
        public int AvgMonthlyInop { get; set; }

        [Display(Name = "Weekly Average of Rides Inop.")]
        public int AvgWeeklyInop { get; set; }

        [Display(Name = "Periodic")]
        public int CurrentNumPeriodic { get; set; }
        [Display(Name = "Emergency")]
        public int CurrentNumEmergency { get; set; }
        [Display(Name = "Scheduled")]
        public int CurrentNumScheduled { get; set; }
        [Display(Name = "Unscheduled")]
        public int CurrentNumUnscheduled { get; set; }
        // add all data we need from project description under

        [Display(Name = "Total")]
        public int TC_maint { get; set; }
        [Display(Name = "Unscheduled")]
        public int TC_Unscheduled { get; set; }
        [Display(Name = "Scheduled")]
        public int TC_Scheduled { get; set; }
        [Display(Name = "Periodic")]
        public int TC_Periodic { get; set; }
        [Display(Name = "Emergency")]
        public int TC_Emergency { get; set; }

        [Display(Name = "Total")]
        public int CT_maint { get; set; }
        [Display(Name = "Unscheduled")]
        public int CT_Unscheduled { get; set; }
        [Display(Name = "Scheduled")]
        public int CT_Scheduled { get; set; }
        [Display(Name = "Periodic")]
        public int CT_Periodic { get; set; }
        [Display(Name = "Emergency")]
        public int CT_Emergency { get; set; }

        [Display(Name = "Total")]
        public int UD_maint { get; set; }
        [Display(Name = "Unscheduled")]
        public int UD_Unscheduled { get; set; }
        [Display(Name = "Scheduled")]
        public int UD_Scheduled { get; set; }
        [Display(Name = "Periodic")]
        public int UD_Periodic { get; set; }
        [Display(Name = "Emergency")]
        public int UD_Emergency { get; set; }

        [Display(Name = "Total")]
        public int UT_maint { get; set; }
        [Display(Name = "Unscheduled")]
        public int UT_Unscheduled { get; set; }
        [Display(Name = "Scheduled")]
        public int UT_Scheduled { get; set; }
        [Display(Name = "Periodic")]
        public int UT_Periodic { get; set; }
        [Display(Name = "Emergency")]
        public int UT_Emergency { get; set; }

        [Display(Name = "Total")]
        public int Teacups_maint { get; set; }
        [Display(Name = "Unscheduled")]
        public int Teacups_Unscheduled { get; set; }
        [Display(Name = "Scheduled")]
        public int Teacups_Scheduled { get; set; }
        [Display(Name = "Periodic")]
        public int Teacups_Periodic { get; set; }
        [Display(Name = "Emergency")]
        public int Teacups_Emergency { get; set; }

        [Display(Name = "Total")]
        public int TT_maint { get; set; }
        [Display(Name = "Unscheduled")]
        public int TT_Unscheduled { get; set; }
        [Display(Name = "Scheduled")]
        public int TT_Scheduled { get; set; }
        [Display(Name = "Periodic")]
        public int TT_Periodic { get; set; }
        [Display(Name = "Emergency")]
        public int TT_Emergency { get; set; }

        [Display(Name = "Total")]
        public int LC_maint { get; set; }
        [Display(Name = "Unscheduled")]
        public int LC_Unscheduled { get; set; }
        [Display(Name = "Scheduled")]
        public int LC_Scheduled { get; set; }
        [Display(Name = "Periodic")]
        public int LC_Periodic { get; set; }
        [Display(Name = "Emergency")]
        public int LC_Emergency { get; set; }

        [Display(Name = "Total")]
        public int FW_maint { get; set; }
        [Display(Name = "Unscheduled")]
        public int FW_Unscheduled { get; set; }
        [Display(Name = "Scheduled")]
        public int FW_Scheduled { get; set; }
        [Display(Name = "Periodic")]
        public int FW_Periodic { get; set; }
        [Display(Name = "Emergency")]
        public int FW_Emergency { get; set; }

        [Display(Name = "Total")]
        public int UHCS_maint { get; set; }
        [Display(Name = "Unscheduled")]
        public int UHCS_Unscheduled { get; set; }
        [Display(Name = "Scheduled")]
        public int UHCS_Scheduled { get; set; }
        [Display(Name = "Periodic")]
        public int UHCS_Periodic { get; set; }
        [Display(Name = "Emergency")]
        public int UHCS_Emergency { get; set; }

        [Display(Name = "Total")]
        public int AB_maint { get; set; }
        [Display(Name = "Unscheduled")]
        public int AB_Unscheduled { get; set; }
        [Display(Name = "Scheduled")]
        public int AB_Scheduled { get; set; }
        [Display(Name = "Periodic")]
        public int AB_Periodic { get; set; }
        [Display(Name = "Emergency")]
        public int AB_Emergency { get; set; }
    }
}