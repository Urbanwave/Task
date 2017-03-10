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
using System.Runtime.Caching;

namespace SongsLogicLayer.Services
{
    public class SongService : ISongService
    {
        DBContext context;
        SongRepository songRep;
        public MemoryCache memorycache;

        public SongService()
        {
            memorycache = MemoryCache.Default;
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

        public List<SongModelDTO> GetSongsByUserId(int SingerId, string sort)
        {
            List<SongModel> songs = songRep.GetSongsByUserId(SingerId, sort);
            List<SongModelDTO> songsDTO = new List<SongModelDTO>();

            foreach (var item in songs)
            {
                SongModelDTO songDTO = new SongModelDTO();

                songDTO.Id = item.Id;
                songDTO.Name = item.Name;
                songDTO.ViewsAmount = item.ViewsAmount;
                songsDTO.Add(songDTO);
            }
            return songsDTO;
        }

        public SongModelDTO GetSongById(int SongId)
        {
            SongModelDTO songDTO = new SongModelDTO();
            SongModel song = songRep.GetSongById(SongId);

            songDTO.Id = song.Id;
            songDTO.Name = song.Name;
            songDTO.Text = song.Text;
            songDTO.Accords = GetAccordsBySongId(song.Id);
            songDTO.SongURL = song.SongURL;

            return songDTO;
        }

        public List<AccordModelDTO> GetAccordsBySongId(int SongId)
        {
            List<AccordModel> accords = songRep.GetAccordsBySongId(SongId);
            List<AccordModelDTO> accodrsDTO = new List<AccordModelDTO>();

            foreach (var item in accords)
            {
                AccordModelDTO accordDTO = new AccordModelDTO();

                accordDTO.Id = item.Id;
                accordDTO.AccordName = item.AccordName;
                accordDTO.AccordURL = item.AccordURL;
                accodrsDTO.Add(accordDTO);
            }
            return accodrsDTO;
        }

        public List<AccordModelDTO> GetAllAccords()
        {
            List<AccordModel> accords = songRep.GetAllAccords();
            List<AccordModelDTO> accodrsDTO = new List<AccordModelDTO>();

            foreach (var item in accords)
            {
                AccordModelDTO accordDTO = new AccordModelDTO();

                accordDTO.Id = item.Id;
                accordDTO.AccordName = item.AccordName;
                accordDTO.AccordURL = item.AccordURL;
                accodrsDTO.Add(accordDTO);
            }
            return accodrsDTO;
        }

        public int GetNextSongId(int songId)
        {
            int[] songsId = songRep.GetSongsId(songId);

            int songPosition = Array.IndexOf(songsId, songId) + 1;

            if (songPosition == (songsId.Count()))
            {
                return 0;
            } else
            {
                return songsId[songPosition];
            }
        }


        public int GetPreviousSongId(int songId)
        {
            int[] songsId = songRep.GetSongsId(songId);

            int songPosition = Array.IndexOf(songsId, songId) + 1;

            if (songPosition == 10)
            {
                return songsId[songPosition - 2];
            }
            else
            if (songPosition == 1)
            {
                return 0;
            } else
            {
                return songsId[songPosition - 2];
            }
        }

        public int UpdateSongAccords(string inputData)
        {
            string[] parametrs = inputData.Split(',');

            int SongId = Convert.ToInt32(parametrs[0]);

            List<AccordModelDTO> Accords = GetAccords();

            songRep.DeleteAccordsBySongId(SongId);

            for (int i = 1; i < parametrs.Count(); i++)
            {
                if (Accords.Where(x => x.AccordName == parametrs[i]) != null)
                {
                    AccordModelDTO Accord = Accords.Where(x => x.AccordName == parametrs[i]).FirstOrDefault();

                    if (Accord != null)
                    {
                        AccordModel NewAccord = new AccordModel
                        {
                            AccordName = Accord.AccordName,
                            AccordURL = Accord.AccordURL,
                            SongId = SongId
                        };

                        songRep.AddNewAccord(NewAccord);
                    }
                }
            }
            return SongId;
        }

        public void AddAccodrs()
        {
            List<AccordModelDTO> Accords = new SongService().GetAllAccords();
            memorycache.Add("Аккорды", Accords, DateTimeOffset.MaxValue);
        }

        public List<AccordModelDTO> GetAccords()
        {
            return memorycache.Get("Аккорды") as List<AccordModelDTO>;
        }

    }
}
