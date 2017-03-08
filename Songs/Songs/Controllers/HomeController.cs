using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Songs.Models;
using SongsLogicLayer.Services;

namespace Songs.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(int page = 1)
        {
            ParseService parse = new ParseService();
            //parse.ParseSingers();
            //parse.ParseSingersName(10);
            //parse.ParseSongs(3);
            parse.ParseSongsAccords();

            ViewBag.Page = page;
            return View(new MainPageModel(page));
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