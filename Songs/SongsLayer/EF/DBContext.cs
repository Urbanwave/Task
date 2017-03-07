using System;
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
        public DbSet<AccordModel> Accords { get; set; }

        static DBContext()
        {
            Database.SetInitializer<DBContext>(new StoreDbInitializer());
        }

        public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<DBContext>
        {
            //protected override void Seed(DBContext db)
            //{
            //    db.Accords.Add(new AccordModel { AccordName = "Nokia Lumia 630", AccordURL = "Nokia"});
            //    db.SaveChanges();
            //}
        }

        public DBContext() :base("TopSingers")
        { }
    }
}
