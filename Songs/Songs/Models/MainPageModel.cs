using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsLogicLayer.DTO;
using SongsLogicLayer.Services;

namespace Songs.Models
{
    public class MainPageModel
    {
        public ICollection<SingerModelDTO> Singers;

        public MainPageModel(int pageId)
        {
            Singers = new SingerService().SelectOnePage(pageId);
        }
    }
}
