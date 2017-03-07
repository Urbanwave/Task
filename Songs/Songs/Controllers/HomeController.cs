using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Songs.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(int page = 1)
        {
            ViewBag.Page = page;
            return View(new Singer().SelectOnePage(page));
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