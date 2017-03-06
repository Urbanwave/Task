using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Songs.Models.DBModels;

namespace Songs.Models.ViewModels
{
    public class MainPageModel
    {
        public ICollection<SingerModel> Singers;

        public MainPageModel(ICollection<SingerModel> singers)
        {
            Singers = singers;
        }
    }
}