﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsLogicLayer.DTO;
using SongsDBLayer.EF;
using SongsDBLayer.Entities;
using SongsDBLayer.Repositories;
using AutoMapper;
using SongsLogicLayer.Interfaces;

namespace SongsLogicLayer.Services
{
    public class SingerService : ISingerService
    {
        DBContext context;
        SingerRepository singerRep;

        public SingerService()
        {
            context = new DBContext();
            singerRep = new SingerRepository(context);
        }

        public List<SingerModelDTO> SelectOnePage(int pageNumber, string sort)
        {        
            Mapper.Initialize(cfg => cfg.CreateMap<SingerModel, SingerModelDTO>());

            return Mapper.Map<List<SingerModel>, List<SingerModelDTO>>(singerRep.SelectOnePage(pageNumber, sort));
        }

        public SingerModelDTO SelectSingerPage(int SingerId)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<SingerModel, SingerModelDTO>());

            return Mapper.Map<SingerModel, SingerModelDTO>(singerRep.SelectSingerPage(SingerId));
        }

        public void AddSinger(SingerModelDTO Singer)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<SingerModelDTO, SingerModel>());

            SingerModel singer = Mapper.Map<SingerModelDTO, SingerModel>(Singer);
            singerRep.AddSinger(singer);
        }


        public List<string> GetSingersUrl()
        {
            return singerRep.GetSingersUrl();
        }

        public SingerModelDTO GetSingersByUrl(string URL)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<SingerModel, SingerModelDTO>());

            return Mapper.Map<SingerModel, SingerModelDTO>(singerRep.GetSingersByUrl(URL));
        }

        public List<SingerModelDTO> GettAllSingers()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<SingerModel, SingerModelDTO>());

            return Mapper.Map<List<SingerModel>, List<SingerModelDTO>>(singerRep.GettAllSingers());
        }

        public string  GetSingerNameById(int SingerId)
        {
            return singerRep.GetSingerNameById(SingerId);
        }
    }
}
