using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Songs.Models.DBModels
{
    public class DBContext : DbContext
    {
        public DbSet<SingerModel> Singers {get; set; }
        public DbSet<SongModel> Songs { get; set; }

        public DBContext() : base("TopSingers")
        { }
    }
}