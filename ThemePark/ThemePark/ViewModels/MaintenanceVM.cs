using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThemePark.ViewModels
{
    public class MaintenanceVM
    {
        [Display(Name="Average Rides Inoperable")]
        public int AvgNumRidesInop { get; set; }

        
        public int CurrentNumPeriodic { get; set; }
        public int CurrentNumEmergency { get; set; }
        public int CurrentNumScheduled { get; set; }
        public int CurrentNumUnscheduled { get; set; }
        // add all data we need from project description under
        
    }
}