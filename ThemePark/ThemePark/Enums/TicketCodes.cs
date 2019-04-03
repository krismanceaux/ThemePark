using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ThemePark.Enums
{
    public class TicketCodes
    {

        public enum TicketCode
        {
           Child = 1,
           Regular = 2,
           Senior = 3,
           [Display(Name = "Season Pass")]
           Season = 4
        }

    }
   
}