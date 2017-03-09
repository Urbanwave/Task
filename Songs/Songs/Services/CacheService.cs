using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;
using SongsLogicLayer.DTO;
using SongsLogicLayer.Services;

namespace Songs.Services
{
    public class CacheService
    {
        public MemoryCache memorycache;

        public CacheService()
        {
            memorycache = MemoryCache.Default;
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