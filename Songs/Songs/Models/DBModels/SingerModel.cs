using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Songs.Models.DBModels
{
    public class SingerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set;  }
        public int SongsAmount { get; set; }
        public int ViewsAmount { get; set; }

        public ICollection<SongModel> Songs { get; set; }

        public SingerModel()
        {
            Songs = new List<SongModel>();
        }

    }
}