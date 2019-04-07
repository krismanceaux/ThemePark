using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThemePark.ViewModels
{
    public class MaintenanceVM
    {
        public int AvgNumRidesInop { get; set; }
        public int CurrentNumPeriodic { get; set; }
        public int CurrentNumEmergency { get; set; }
        public int CurrentNumScheduled { get; set; }
        public int CurrentNumUnscheduled { get; set; }
        // add all data we need from project description under
    }
}