namespace Songs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSongsViewAmount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SongModels", "ViewsAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SongModels", "ViewsAmount");
        }
    }
}
