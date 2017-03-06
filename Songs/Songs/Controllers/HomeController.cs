using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Songs.Models.DBModels;
using Songs.Services.ParsingService;

namespace Songs.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            ParseSingers parseSingers = new ParseSingers();

            return View();
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