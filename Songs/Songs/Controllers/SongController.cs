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

        [HttpPost, ValidateInput(false)]
        public RedirectToRouteResult SaveTags(string inputData)
        {
            return RedirectToAction("SongInfo", "Song", new { SongId = new SongService().UpdateSongAccords(inputData) });
        }
    }
}