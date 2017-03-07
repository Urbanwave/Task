using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Songs.Controllers
{
    public class SongController : Controller
    {
        public ActionResult SongInfo(int SingerId)
        {
            return View();
        }
    }
}