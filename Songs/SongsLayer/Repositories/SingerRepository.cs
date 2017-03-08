using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsDBLayer.Entities;
using SongsDBLayer.EF;
using SongsDBLayer.Interfaces;


namespace SongsDBLayer.Repositories
{
    public class SingerRepository : ISingerRepository
    {
        private DBContext db;

        public SingerRepository(DBContext context)
        {
            db = context;
        }

        public List<SingerModel> SelectOnePage(int pageNumber)
        {
            return db.Singers
                    .OrderByDescending(s => s.ViewsAmount)
                    .Skip((pageNumber - 1) * 30)
                    .Take(30).ToList();
        }

        public SingerModel SelectSingerPage(int SingerId)
        {
            return db.Singers.Where(x => x.Id == SingerId).FirstOrDefault();
        }

        public void AddSinger(SingerModel Singer)
        {
            db.Singers.Add(Singer);
            db.SaveChanges();
            db.Entry(Singer).State = System.Data.Entity.EntityState.Unchanged;
            db.SaveChanges();
        }


        public List<string> GetSingersUrl()
        {
            List<string> URLS = new List<string>();

            foreach (var item in db.Singers.ToList())
            {
                URLS.Add(item.SingerURL);
            }
            return URLS;
        }

        public SingerModel GetSingersByUrl(string URL)
        {
            return db.Singers.Where(x => x.SingerURL == URL).FirstOrDefault();
        }

        public List<SingerModel> GettAllSingers()
        {
            return db.Singers.ToList();
        }
    }
}
