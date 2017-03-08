namespace SongsDBLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _123 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SongModels", name: "Singer_Id", newName: "SingerId");
            RenameIndex(table: "dbo.SongModels", name: "IX_Singer_Id", newName: "IX_SingerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SongModels", name: "IX_SingerId", newName: "IX_Singer_Id");
            RenameColumn(table: "dbo.SongModels", name: "SingerId", newName: "Singer_Id");
        }
    }
}
