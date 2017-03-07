using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsLogicLayer.DTO;
using SongsLogicLayer.Services;

namespace Songs.Models
{
    public class SongPageModel
    {
        public SongModelDTO Song;

        public SongPageModel(int SingerId)
        {
            Song = new SongService().SelectSingerSong(SingerId);
        }
    }
}
