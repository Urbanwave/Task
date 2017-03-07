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
    }
}
