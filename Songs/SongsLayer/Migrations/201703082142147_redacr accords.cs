namespace SongsDBLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class redacraccords : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AccordModels", name: "SongModel_Id", newName: "SongId");
            RenameIndex(table: "dbo.AccordModels", name: "IX_SongModel_Id", newName: "IX_SongId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AccordModels", name: "IX_SongId", newName: "IX_SongModel_Id");
            RenameColumn(table: "dbo.AccordModels", name: "SongId", newName: "SongModel_Id");
        }
    }
}
