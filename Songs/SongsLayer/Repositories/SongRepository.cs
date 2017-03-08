using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsDBLayer.EF;
using SongsDBLayer.Entities;
using SongsDBLayer.Interfaces;

namespace SongsDBLayer.Repositories
{
    public class SongRepository : ISongRepository
    {
        private DBContext db;

        public SongRepository(DBContext context)
        {
            db = context;
        }

        public SongModel SelectSingerSong(int SingerId)
        {
            return db.Songs.Where(x => x.Id == SingerId).FirstOrDefault();
        }

        public void AddSong(SongModel Song)
        {     
            db.Songs.Add(Song);
            db.SaveChanges();         
        }

        public List<SongModel> GetAllSongs()
        {
            return db.Songs.ToList();
        }

        public List<string> GetSongsUrl()
        {
            List<string> URLS = new List<string>();

            foreach (var item in db.Songs.ToList())
            {
                URLS.Add(item.SongURL);
            }
            return URLS;
        }

        public void AddSongTextByURL(string text, string URL)
        {
            db.Songs.Where(x => x.SongURL == URL).FirstOrDefault().Text = text;
            db.SaveChanges();
        }

        public void AddAccord(AccordModel Accord, string URL)
        {        
            Accord.SongId = db.Songs.Where(x => x.SongURL == URL).FirstOrDefault().Id;
            db.Accords.Add(Accord);
            db.SaveChanges();
        }
    }
}
