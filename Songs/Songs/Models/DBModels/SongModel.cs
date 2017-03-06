using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Songs.Models.DBModels
{
    public class SongModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string AccordsImages { get; set; }

        public SingerModel Singer { get; set; }

    }
}