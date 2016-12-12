namespace DAL.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogBrowseIPs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BrowseIP = c.String(),
                        BrowseTime = c.DateTime(nullable: false),
                        BlogID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Blogs", t => t.BlogID, cascadeDelete: true)
                .Index(t => t.BlogID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogBrowseIPs", "BlogID", "dbo.Blogs");
            DropIndex("dbo.BlogBrowseIPs", new[] { "BlogID" });
            DropTable("dbo.BlogBrowseIPs");
        }
    }
}
