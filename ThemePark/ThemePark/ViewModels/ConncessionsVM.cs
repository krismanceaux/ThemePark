using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThemePark.ViewModels
{
    public class ConcessionsVM
    {
        [Display(Name = "Items Sold Count")]
        public int solditems { get; set; }

        [Display(Name = "Revenue")]
        public Decimal Revenue { get; set; }
        // add all data we need from project description under
        [Display(Name = "Items Sold Count")]
        public int BWsolditems { get; set; }

        [Display(Name = "Revenue")]
        public Decimal BWRevenue { get; set; }

        [Display(Name = "Items Sold Count")]
        public int CAsolditems { get; set; }

        [Display(Name = "Revenue")]
        public Decimal CARevenue { get; set; }

        [Display(Name = "Items Sold Count")]
        public int CCsolditems { get; set; }

        [Display(Name = "Revenue")]
        public Decimal CCRevenue { get; set; }

        [Display(Name = "Items Sold Count")]
        public int FCsolditems { get; set; }

        [Display(Name = "Revenue")]
        public Decimal FCRevenue { get; set; }

        [Display(Name = "Items Sold Count")]
        public int Nsolditems { get; set; }

        [Display(Name = "Revenue")]
        public Decimal NRevenue { get; set; }

        [Display(Name = "Items Sold Count")]
        public int Psolditems { get; set; }

        [Display(Name = "Revenue")]
        public Decimal PRevenue { get; set; }

        [Display(Name = "Items Sold Count")]
        public int Popsolditems { get; set; }

        [Display(Name = "Revenue")]
        public Decimal PopRevenue { get; set; }

        [Display(Name = "Items Sold Count")]
        public int SKsolditems { get; set; }

        [Display(Name = "Revenue")]
        public Decimal SKRevenue { get; set; }

        [Display(Name = "Items Sold Count")]
        public int SDsolditems { get; set; }

        [Display(Name = "Revenue")]
        public Decimal SDRevenue { get; set; }
    }
}
