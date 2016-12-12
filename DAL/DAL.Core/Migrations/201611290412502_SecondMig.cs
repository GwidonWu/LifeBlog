namespace DAL.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FileLibraries", "AlbumID", c => c.Int(nullable: false));
            CreateIndex("dbo.FileLibraries", "AlbumID");
            AddForeignKey("dbo.FileLibraries", "AlbumID", "dbo.Albums", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileLibraries", "AlbumID", "dbo.Albums");
            DropIndex("dbo.FileLibraries", new[] { "AlbumID" });
            DropColumn("dbo.FileLibraries", "AlbumID");
        }
    }
}
