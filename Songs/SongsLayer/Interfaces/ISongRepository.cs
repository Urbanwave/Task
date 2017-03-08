using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsDBLayer.Entities;

namespace SongsDBLayer.Interfaces
{
    interface ISongRepository
    {
        SongModel SelectSingerSong(int SingerId);
        void AddSong(SongModel Songs);
        List<string> GetSongsUrl();
        List<SongModel> GetAllSongs();
        void AddAccord(AccordModel Accord, string URL);
        void AddSongTextByURL(string text, string URL);
    }
}
