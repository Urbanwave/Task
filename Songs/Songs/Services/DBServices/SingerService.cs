using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Songs.Models.DBModels;

namespace Songs.Services.DBServices
{
    public class SingerService
    {
        DBContext context = new DBContext();

        public List<SingerModel> SelectOnePage(int pageNumber)
        {       
            return context.Singers
                    .OrderByDescending(s => s.ViewsAmount)
                    .Skip((pageNumber - 1) * 30)
                    .Take(30).ToList();
         }
    }
}