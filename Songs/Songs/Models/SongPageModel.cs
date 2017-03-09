using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsLogicLayer.DTO;
using SongsLogicLayer.Services;

namespace Songs.Models
{
    public class SongPageModel
    {
        public SongModelDTO Song;
        public List<AccordModelDTO> Accords;
        public string Tags;
        public string initialTags;

        public SongPageModel(int SongId, string sort)
        {
            Song = new SongService().GetSongById(SongId);
            Accords = new SongService().GetAllAccords();

            foreach (var item in Song.Accords)
            {
                initialTags += item.AccordName + ";";
            }

            for (int i = 0; i < Accords.Count(); i++)
            {
                Tags += Accords[i].AccordName + ";";
            }  
        }
    }
}
