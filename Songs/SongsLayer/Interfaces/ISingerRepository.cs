using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsDBLayer.Entities;

namespace SongsDBLayer.Interfaces
{
    interface ISingerRepository
    {
        List<SingerModel> SelectOnePage(int pageNumber);
        SingerModel SelectSingerPage(int SingerId);
    }
}
