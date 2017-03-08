namespace SongsDBLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccordModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccordName = c.String(),
                        AccordURL = c.String(),
                        SongModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SongModels", t => t.SongModel_Id)
                .Index(t => t.SongModel_Id);
            
            CreateTable(
                "dbo.SingerModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Biography = c.String(),
                        SongsAmount = c.Int(nullable: false),
                        ViewsAmount = c.Int(nullable: false),
                        SingerURL = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SongModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Text = c.String(),
                        ViewsAmount = c.Int(nullable: false),
                        Singer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SingerModels", t => t.Singer_Id)
                .Index(t => t.Singer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SongModels", "Singer_Id", "dbo.SingerModels");
            DropForeignKey("dbo.AccordModels", "SongModel_Id", "dbo.SongModels");
            DropIndex("dbo.SongModels", new[] { "Singer_Id" });
            DropIndex("dbo.AccordModels", new[] { "SongModel_Id" });
            DropTable("dbo.SongModels");
            DropTable("dbo.SingerModels");
            DropTable("dbo.AccordModels");
        }
    }
}
