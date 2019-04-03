using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThemePark.Enums
{
    public class MaintCodes
    {
        public enum MaintCode
        {
            Periodic = 1,
            Scheduled = 2,
            Unscheduled = 3,
            Emergency = 4
        }
    }
}