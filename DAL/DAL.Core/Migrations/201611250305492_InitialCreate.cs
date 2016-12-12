namespace DAL.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdminName = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 256),
                        LoginIP = c.String(),
                        LoginTime = c.DateTime(),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 1000),
                        Content = c.String(nullable: false),
                        Author = c.String(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        BrowseNum = c.Int(nullable: false),
                        Comment = c.Int(nullable: false),
                        Fabulous = c.Int(nullable: false),
                        Publish = c.Boolean(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        ParentID = c.Int(nullable: false),
                        ParentPath = c.String(),
                        Depth = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 1000),
                        Order = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CategoryGenerals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        View = c.String(nullable: false),
                        ContentTypeID = c.Int(nullable: false),
                        ContentView = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CategoryLinks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        Url = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CategoryPages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        View = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        CommentTime = c.DateTime(nullable: false),
                        CommentIP = c.String(),
                        BlogID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Blogs", t => t.BlogID, cascadeDelete: true)
                .Index(t => t.BlogID);
            
            CreateTable(
                "dbo.ContentTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Controller = c.String(nullable: false),
                        Description = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FileLibraries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OldFileName = c.String(),
                        NewFileName = c.String(),
                        Extension = c.String(),
                        Size = c.Int(nullable: false),
                        Url = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 500),
                        MessageTime = c.DateTime(nullable: false),
                        Name = c.String(nullable: false),
                        MessageIP = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MimeType = c.String(),
                        Content = c.Binary(),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Description = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SysLogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DATES = c.DateTime(),
                        LEVELS = c.String(),
                        LOGGER = c.String(),
                        CLIENTUSER = c.String(),
                        CLIENTIP = c.String(),
                        REQUESTURL = c.String(),
                        ACTION = c.String(),
                        MESSAGE = c.String(),
                        EXCEPTION = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TimnAxis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        Content = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(),
                        Username = c.String(maxLength: 50),
                        Name = c.String(maxLength: 20),
                        Sex = c.Int(nullable: false),
                        Password = c.String(maxLength: 256),
                        Email = c.String(maxLength: 50),
                        LastLoginTime = c.DateTime(),
                        LastLoginIP = c.String(),
                        RegTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.RoleID)
                .Index(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Comments", "BlogID", "dbo.Blogs");
            DropForeignKey("dbo.Blogs", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.Comments", new[] { "BlogID" });
            DropIndex("dbo.Blogs", new[] { "CategoryID" });
            DropTable("dbo.Users");
            DropTable("dbo.TimnAxis");
            DropTable("dbo.SysLogs");
            DropTable("dbo.Roles");
            DropTable("dbo.Photos");
            DropTable("dbo.Messages");
            DropTable("dbo.FileLibraries");
            DropTable("dbo.ContentTypes");
            DropTable("dbo.Comments");
            DropTable("dbo.CategoryPages");
            DropTable("dbo.CategoryLinks");
            DropTable("dbo.CategoryGenerals");
            DropTable("dbo.Categories");
            DropTable("dbo.Blogs");
            DropTable("dbo.Admins");
        }
    }
}
