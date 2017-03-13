using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Songs.Models;

namespace Songs.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(string sort = "SortDownByViewsAmount", int page = 1)
        {
            ViewBag.Page = page;
            return View(new MainPageModel(page, sort));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}