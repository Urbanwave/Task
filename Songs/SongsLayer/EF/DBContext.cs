﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsDBLayer.Entities;
using System.Data.Entity;

namespace SongsDBLayer.EF
{
    public class DBContext : DbContext
    {
        public DbSet<SingerModel> Singers { get; set; }
        public DbSet<SongModel> Songs { get; set; }

        public DBContext() : base("TopSingers")
        { }
    }
}