using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsDBLayer.Entities
{
    public class SongModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int ViewsAmount { get; set; }
        public string SongURL { get; set; }
        public int? SingerId { get; set; }
        public SingerModel Singer { get; set; }

        public ICollection<AccordModel> Accords { get; set; }

        public SongModel()
        {
            Accords = new List<AccordModel>();
        }
    }
}
