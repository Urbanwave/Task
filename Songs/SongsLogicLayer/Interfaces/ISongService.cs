using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsLogicLayer.DTO;
using SongsDBLayer.Entities;

namespace SongsLogicLayer.Interfaces
{
    interface ISongService
    {
        List<string> GetSongsUrl();
        SongModelDTO SelectSingerSong(int SingerId);
        void AddSong(SongModelDTO Song);
        void AddSongTextByURL(string text, string URL);
        void AddAccord(AccordModelDTO Accord, string URL);
        List<SongModel> GetAllSongs();
        List<SongModelDTO> GetSongsByUserId(int SingerId, string sort);
        SongModelDTO GetSongById(int SongId);
        List<AccordModelDTO> GetAccordsBySongId(int SongId);
        List<AccordModelDTO> GetAllAccords();
        int GetNextSongId(int songId);
        int GetPreviousSongId(int songId);
        int UpdateSongAccords(string inputData);
    }
}
