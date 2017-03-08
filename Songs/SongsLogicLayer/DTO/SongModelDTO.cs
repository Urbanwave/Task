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
        public string SongURL { get; set; }

        public SingerModelDTO Singer { get; set; }

        public ICollection<AccordModelDTO> Accords { get; set; }

        public SongModelDTO()
        {
            Accords = new List<AccordModelDTO>();
        }
    }
}
