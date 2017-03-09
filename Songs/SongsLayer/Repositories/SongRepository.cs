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

        public List<SongModel> GetSongsByUserId(int SingerId,string sort)
        {
            switch (sort)
            {
                case "SortDownByNames":
                    return db.Songs.Where(x => x.SingerId == SingerId).OrderByDescending(x => x.Name).ToList();

                case "SortUpByNames":
                    return db.Songs.Where(x => x.SingerId == SingerId).OrderBy(x => x.Name).ToList();

                case "SortDownByViewsAmount":
                    return db.Songs.Where(x => x.SingerId == SingerId).OrderByDescending(x => x.ViewsAmount).ToList();

                case "SortUpByViewsAmount":
                    return db.Songs.Where(x => x.SingerId == SingerId).OrderBy(x => x.ViewsAmount).ToList(); 

                default:
                    return db.Songs.Where(x => x.SingerId == SingerId).ToList();
            }

        }

        public SongModel GetSongById(int SongId)
        {
            return db.Songs.Where(x => x.Id == SongId).FirstOrDefault();
        }

        public List<AccordModel> GetAccordsBySongId(int SongId)
        {
            return db.Accords.Where(x => x.SongId == SongId).ToList();
        }

        public List<AccordModel> GetAllAccords()
        {
            return db.Accords.GroupBy(x => x.AccordName).Select(x => x.FirstOrDefault()).ToList();
        }

        public int[] GetSongsId(int songId)
        {
            SongModel song = db.Songs.Where(x => x.Id == songId).FirstOrDefault();
    
            List<SongModel> Songs = db.Songs.Where(x => x.SingerId == song.SingerId).ToList();

            int[] item = new int[Songs.Count()];

            for (int i = 0; i < Songs.Count(); i++)
            {
                item[i] = Songs[i].Id;
            }

            return item;
        }

        public void DeleteAccordsBySongId(int SongId)
        {
            foreach(var item in db.Accords.Where(x => x.SongId == SongId).ToList())
            {
                db.Accords.Remove(item);
                db.SaveChanges();
            }
        }

        public void AddNewAccord(AccordModel NewAccord)
        {
            db.Accords.Add(NewAccord);
            db.SaveChanges();
        }
    }
}
