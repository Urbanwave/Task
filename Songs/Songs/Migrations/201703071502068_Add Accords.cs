namespace Songs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccords : DbMigration
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
            
            AddColumn("dbo.SingerModels", "SingerURL", c => c.String());
            DropColumn("dbo.SongModels", "AccordsImages");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SongModels", "AccordsImages", c => c.String());
            DropForeignKey("dbo.AccordModels", "SongModel_Id", "dbo.SongModels");
            DropIndex("dbo.AccordModels", new[] { "SongModel_Id" });
            DropColumn("dbo.SingerModels", "SingerURL");
            DropTable("dbo.AccordModels");
        }
    }
}
