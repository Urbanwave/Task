using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsLogicLayer.DTO;
using SongsLogicLayer.Services;

namespace Songs.Models
{
    public class SingerPageModel
    {
        public string Name { get; set; }
        public string Biography { get; set; }
        public int singerId { get; set; }

        public ICollection<SongModelDTO> Songs { get; set; }

        public string SortDownByNames = "SortDownByNames";
        public string SortUpByNames = "SortUpByNames";
        public string SortDownByViewsAmount = "SortDownByViewsAmount";
        public string SortUpByViewsAmount = "SortUpByViewsAmount";


        public SingerPageModel(int SingerId, string sort)
        {
            singerId = SingerId;

            SingerModelDTO singer = new SingerModelDTO();

            SingerService singerServ = new SingerService();

            singer = singerServ.SelectSingerPage(SingerId);

            Name = singer.Name;
            Biography = singer.Biography;
            Songs = new SongService().GetSongsByUserId(SingerId, sort);
        }
    }
}
