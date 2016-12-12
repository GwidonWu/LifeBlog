namespace DAL.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FifthMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "Count", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Albums", "Count");
        }
    }
}
