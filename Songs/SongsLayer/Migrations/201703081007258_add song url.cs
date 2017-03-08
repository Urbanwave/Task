namespace SongsDBLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsongurl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SongModels", "SongURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SongModels", "SongURL");
        }
    }
}
