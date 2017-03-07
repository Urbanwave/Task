using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsDBLayer.Entities;

namespace SongsLogicLayer.DTO
{
    public class SongModelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int ViewsAmount { get; set; }
        public SingerModel Singer { get; set; }

        public ICollection<AccordModel> Accords { get; set; }


        public SongModelDTO()
        {
            Accords = new List<AccordModel>();
        }
    }
}
