using System.Web;
using System.Web.Mvc;
using ThemePark.AuthData;

namespace ThemePark
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new AuthAttribute());
        }
    }
}
