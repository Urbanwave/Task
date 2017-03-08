namespace SongsDBLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SongModels", new[] { "Singer_Id1" });
            DropColumn("dbo.SongModels", "Singer_Id");
            RenameColumn(table: "dbo.SongModels", name: "Singer_Id1", newName: "Singer_Id");
            AlterColumn("dbo.SongModels", "Singer_Id", c => c.Int());
            CreateIndex("dbo.SongModels", "Singer_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SongModels", new[] { "Singer_Id" });
            AlterColumn("dbo.SongModels", "Singer_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.SongModels", name: "Singer_Id", newName: "Singer_Id1");
            AddColumn("dbo.SongModels", "Singer_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.SongModels", "Singer_Id1");
        }
    }
}
