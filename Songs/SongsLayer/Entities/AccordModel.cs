using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsDBLayer.Entities
{
    public class AccordModel
    {
        public int Id { get; set; }
        public string AccordName { get; set; }
        public string AccordURL { get; set; }
        public int? SongId { get; set; }
        public SongModel Song { get; set; }

    }
}
