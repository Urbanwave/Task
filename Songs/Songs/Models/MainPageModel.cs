using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsLogicLayer.DTO;
using SongsLogicLayer.Services;

namespace Songs.Models
{
    public class MainPageModel
    {
        public ICollection<SingerModelDTO> Singers;
        public int PageId;
        public string SortDownByNames = "SortDownByNames";
        public string SortUpByNames = "SortUpByNames";
        public string SortDownBySongsAmount = "SortDownBySongsAmount";
        public string SortUpBySongsAmount = "SortUpBySongsAmount";
        public string SortDownByViewsAmount = "SortDownByViewsAmount";
        public string SortUpByViewsAmount = "SortUpByViewsAmount";
        public string CurrentSort;


        public MainPageModel(int pageId, string sort)
        {
            CurrentSort = sort;
            PageId = pageId;
            Singers = new SingerService().SelectOnePage(pageId, sort);
        }
    }
}
