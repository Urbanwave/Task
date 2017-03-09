using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Songs.Models;

namespace Songs.Controllers
{
    public class SingerController : Controller
    {
        public ActionResult SingerInfo(int SingerId, string sort)
        {
            //TempData.S = SingerId;
            return View(new SingerPageModel(SingerId, sort));
        }
    }
}

http://stackoverflow.com/questions/22990443/viewbag-value-becomes-null-in-the-post-method