using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThemePark.DAL
{
    public enum AccessType
    {
        SPH,
        EMP,
        MGR,
        GNRL
    }
    public class ApplicationSession
    {
        public static AccessType AccessLevel {
            set
            {
                HttpContext.Current.Session["Access Level"] = value;
            }
            get
            {
                if (HttpContext.Current.Session["Access Level"] != null)
                {
                    return (AccessType)HttpContext.Current.Session["Access Level"];
                }
                else
                {
                    return AccessType.GNRL;
                }
            }
        }

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