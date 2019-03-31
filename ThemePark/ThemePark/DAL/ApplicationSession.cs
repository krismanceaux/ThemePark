using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThemePark.DAL
{
    public class ApplicationSession
    {
        public static string RedirectToHomeURL = "~/Home/Index";
        public static string AccessLevel = "";
        public static string Username
        {
            set
            {
                HttpContext.Current.Session["Username"] = value;
            }
            get
            {
                if (HttpContext.Current.Session["Username"] != null)
                {
                    return HttpContext.Current.Session["Username"].ToString();
                }
                else
                {
                    return null;
                }

            }
        }
    }
}