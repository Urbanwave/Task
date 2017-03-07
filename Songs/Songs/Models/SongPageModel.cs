using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsLogicLayer.DTO;

namespace Songs.Models
{
    public class SongPageModel
    {
        public SongModelDTO Song;

        public SongPageModel(int SingerId)
        {
            Song = SelectSingerSong(SingerId);
        }
    }
}
