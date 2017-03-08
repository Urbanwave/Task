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

        DBContext context = new DBContext();

        public List<SingerModel> SelectOnePage(int pageNumber)
        {
            return context.Singers
                    .OrderByDescending(s => s.ViewsAmount)
                    .Skip((pageNumber - 1) * 30)
                    .Take(30).ToList();
        }

        public SingerModel SelectSingerPage(int SingerId)
        {
            return context.Singers.Where(x => x.Id == SingerId).FirstOrDefault();
        }

        public void AddSinger(SingerModel Singer)
        {
            context.Singers.Add(Singer);
            context.SaveChanges();
        }

        public List<string> GetSingersUrl()
        {
            List<string> URLS = new List<string>();

            foreach (var item in context.Singers.ToList())
            {
                URLS.Add(item.SingerURL);
            }
            return URLS;
        }

        public SingerModel GetSingersByUrl(string URL)
        {
            return context.Singers.Where(x => x.SingerURL == URL).FirstOrDefault();
        }
    }
}
