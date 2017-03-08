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
    }
}
