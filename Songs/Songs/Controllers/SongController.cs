using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Songs.Models;
using SongsLogicLayer.Services;

namespace Songs.Controllers
{
    public class SongController : Controller
    {
        public ActionResult SongInfo(int SongId)
        {
            return View(new SongPageModel(SongId));
        }

        [HttpPost]
        public ActionResult SaveTags(string inputData)
        {
            return View("SongInfo", new SongPageModel(new SongService().UpdateSongAccords(inputData)));
        }

        public ActionResult AjaxSongPage(int SongId)
        {
            return PartialView("_AjaxSongPage",new SongPageModel(SongId));
        }
    }
}