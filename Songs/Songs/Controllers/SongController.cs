using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Songs.Models;

namespace Songs.Controllers
{
    public class SongController : Controller
    {
        public ActionResult SongInfo(int SongId, string sort)
        {
            return View(new SongPageModel(SongId, sort));
        }
    }
}