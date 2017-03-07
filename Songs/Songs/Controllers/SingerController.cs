using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SongsLogicLayer.BusinessModels;

namespace Songs.Controllers
{
    public class SingerController : Controller
    {
        public ActionResult SingerInfo(int SingerId)
        {
            return View(new SingerPageModel(SingerId));
        }
    }
}