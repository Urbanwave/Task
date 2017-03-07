using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Songs.Models.DBModels;

namespace Songs.Models.ViewModels
{
    public class SongPageModel
    {
        public SongModel Song;

        public SongPageModel(int SingerId)
        {
            using (DBContext context = new DBContext())
            {
                Song = context.Songs.Where(x => x.Id == SingerId).FirstOrDefault();
            }
        }
    }
}