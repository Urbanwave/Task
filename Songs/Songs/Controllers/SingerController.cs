using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Songs.Models;
using SongsLogicLayer.Services;

namespace Songs.Controllers
{
    public class SingerController : Controller
    {
        public ActionResult SingerInfo(int SingerId, string sort)
        {
            TempData["SingerId"] = SingerId;
            TempData["SingerName"] = new SingerService().GetSingerNameById(SingerId);
            return View(new SingerPageModel(SingerId, sort));
        }
    }
}
