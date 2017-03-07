using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsLogicLayer.DTO;

namespace Songs.Models
{
    public class MainPageModel
    {
        public ICollection<SingerModelDTO> Singers;

        public MainPageModel(ICollection<SingerModelDTO> singers)
        {
            Singers = singers;
        }
    }
}
