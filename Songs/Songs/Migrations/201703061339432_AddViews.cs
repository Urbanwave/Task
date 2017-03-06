namespace Songs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddViews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SingerModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Biography = c.String(),
                        ViewsAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SongModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Text = c.String(),
                        AccordsImages = c.String(),
                        Singer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SingerModels", t => t.Singer_Id)
                .Index(t => t.Singer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SongModels", "Singer_Id", "dbo.SingerModels");
            DropIndex("dbo.SongModels", new[] { "Singer_Id" });
            DropTable("dbo.SongModels");
            DropTable("dbo.SingerModels");
        }
    }
}
