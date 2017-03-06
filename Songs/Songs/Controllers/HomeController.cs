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
            DBContext context = new DBContext();
            context.Singers.Add(new SingerModel());
            context.SaveChanges();

            //ParseSingers parseSingers = new ParseSingers();

            //parseSingers.ParseAllSingers();

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