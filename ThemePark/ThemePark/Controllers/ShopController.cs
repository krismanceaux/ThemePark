using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThemePark.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Food()
        {
            return View();
        }

        public ActionResult Drink()
        {
            return View();
        }

        public ActionResult DrinkS()
        {
            return View();
        }

        public ActionResult FoodS()
        {
            return View();
        }
    }
}