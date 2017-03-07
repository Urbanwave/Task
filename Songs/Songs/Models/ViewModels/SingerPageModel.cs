using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Songs.Models.DBModels;

namespace Songs.Models.ViewModels
{
    public class SingerPageModel
    {
        public string Name { get; set; }
        public string Biography { get; set; }
        public ICollection<SongModel> Songs { get; set; }

        public SingerPageModel(int SingerId)
        {

            DBContext context = new DBContext();

            SingerModel singer = new SingerModel();

            singer = context.Singers.Where(x => x.Id == SingerId).FirstOrDefault();

            Name = singer.Name;
            Biography = singer.Biography;
        }
    }
}