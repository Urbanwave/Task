using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsLogicLayer.DTO;

namespace SongsLogicLayer.Interfaces
{
    interface ISingerService
    {
        List<string> GetSingersUrl();
        void AddSinger(SingerModelDTO Singer);
        SingerModelDTO SelectSingerPage(int SingerId);
        List<SingerModelDTO> SelectOnePage(int pageNumber);
        SingerModelDTO GetSingersByUrl(string URL);
    }
}
