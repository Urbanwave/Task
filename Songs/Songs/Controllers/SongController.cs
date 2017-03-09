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
        public ActionResult SongInfo(int SongId)
        {
            return View(new SongPageModel(SongId));
        }

        [HttpPost]
        public void SaveTags(string inputData)
        {
            //return View(new SongPageModel(SongId, sort));
        }

        public ActionResult AjaxSongPage(int SongId)
        {
            return PartialView("_AjaxSongPage",new SongPageModel(SongId));
        }
    }
}