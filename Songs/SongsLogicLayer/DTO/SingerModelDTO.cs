using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsDBLayer.Entities;

namespace SongsLogicLayer.DTO
{
    public class SingerModelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public int SongsAmount { get; set; }
        public int ViewsAmount { get; set; }
        public string SingerURL { get; set; }

        public ICollection<SongModelDTO> Songs { get; set; }

        public SingerModelDTO()
        {
            Songs = new List<SongModelDTO>();
        }
    }
}
