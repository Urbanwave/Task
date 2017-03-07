using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsLogicLayer.DTO;

namespace Songs.Models
{
    public class SingerPageModel
    {
        public string Name { get; set; }
        public string Biography { get; set; }
        public ICollection<SongModelDTO> Songs { get; set; }

        public SingerPageModel(int SingerId)
        { 
            SingerModelDTO singer = new SingerModelDTO();

            singer = SelectSingerPage(SingerId);

            Name = singer.Name;
            Biography = singer.Biography;
        }
    }
}
