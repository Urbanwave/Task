namespace Songs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSongsCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SingerModels", "SongsAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SingerModels", "SongsAmount");
        }
    }
}
