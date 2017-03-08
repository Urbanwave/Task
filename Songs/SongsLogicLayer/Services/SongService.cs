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
using SongsLogicLayer.Interfaces;

namespace SongsLogicLayer.Services
{
    public class SongService : ISongService
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

        public List<SongModel> GetAllSongs()
        {
            return songRep.GetAllSongs();
        }

        public void AddSong(SongModelDTO Song)
        {
            SongModel song = new SongModel();

            song.Name = Song.Name;
            song.SingerId = Song.Singer.Id; 
            song.SongURL = Song.SongURL;
            song.ViewsAmount = Song.ViewsAmount;

            songRep.AddSong(song);
        }

        public List<string> GetSongsUrl()
        {
            return songRep.GetSongsUrl();
        }

        public void AddSongTextByURL(string text, string URL)
        {
            songRep.AddSongTextByURL(text, URL);
        }

        public void AddAccord(AccordModelDTO Accord, string URL)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AccordModelDTO, AccordModel>());

            AccordModel accord = Mapper.Map<AccordModelDTO, AccordModel>(Accord);
            songRep.AddAccord(accord, URL);
        }
    }
}
