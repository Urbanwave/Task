using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsLogicLayer.DTO;
using SongsDBLayer.EF;

namespace SongsLogicLayer.Services
{
    class SingerService
    { 
        public ICollection<SingerModelDTO> SelectOnePage(int pageNumber)
        {
            using (DBContext context = new DBContext())
            {

            }



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
