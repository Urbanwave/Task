using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsLogicLayer.Services;
using SongsDBLayer.EF;
using SongsLogicLayer.DTO;
using SongsDBLayer.Entities;
using SongsDBLayer.Repositories;
using AutoMapper;

namespace SongsLogicLayer.Services
{
    public class SongService
    {
        DBContext context;
        SongRepository songRep;

        public SongService()
        {
            context = new DBContext();
            songRep = new SongRepository(context);
        }

        public SongModelDTO SelectSingerSong(int SingerId)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<SongModel, SongModelDTO>());

            return Mapper.Map<SongModel, SongModelDTO>(songRep.SelectSingerSong(SingerId));
        }
    }
}
