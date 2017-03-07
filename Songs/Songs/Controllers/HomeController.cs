using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Songs.Models.DBModels;
using Songs.Services.ParsingService;
using Songs.Models.ViewModels;
using HtmlAgilityPack;

namespace Songs.Controllers
{
    public class HomeController : Controller
    {

        DBContext Context = new DBContext();

        public ActionResult Index(int page = 1)
        {

            //ParseSingers singers = new ParseSingers();

            ViewBag.Page = page;

            return View(new MainPageModel(Context.Singers
                .OrderByDescending(s => s.ViewsAmount)
                .Skip((page - 1) * 30)
                .Take(30).ToList()));
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

        public ActionResult SingerInfo(int SingerId)
        {         
            return View(new SingerPageModel(SingerId));
        }
    }
}