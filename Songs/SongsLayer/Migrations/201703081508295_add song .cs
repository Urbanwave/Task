namespace SongsDBLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsong : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SongModels", "Singer_Id", "dbo.SingerModels");
            DropIndex("dbo.SongModels", new[] { "Singer_Id" });
            AddColumn("dbo.SongModels", "Singer_Id1", c => c.Int());
            AlterColumn("dbo.SongModels", "Singer_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.SongModels", "Singer_Id1");
            AddForeignKey("dbo.SongModels", "Singer_Id1", "dbo.SingerModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SongModels", "Singer_Id1", "dbo.SingerModels");
            DropIndex("dbo.SongModels", new[] { "Singer_Id1" });
            AlterColumn("dbo.SongModels", "Singer_Id", c => c.Int());
            DropColumn("dbo.SongModels", "Singer_Id1");
            CreateIndex("dbo.SongModels", "Singer_Id");
            AddForeignKey("dbo.SongModels", "Singer_Id", "dbo.SingerModels", "Id");
        }
    }
}
