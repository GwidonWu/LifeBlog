namespace DAL.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FileLibraries", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FileLibraries", "Description");
        }
    }
}
