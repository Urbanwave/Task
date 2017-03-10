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
        public PartialViewResult SongInfo(int SongId)
        {
            return PartialView("_AjaxSongPage", new SongPageModel(SongId));
        }

        [HttpPost]
        public ViewResult SaveTags(string inputData)
        {
            return View("SongInfo", new SongPageModel(new SongService().UpdateSongAccords(inputData)));
        }
    }
}