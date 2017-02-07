namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMig : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Question", "section_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Question", "section_id", c => c.Int(nullable: false));
        }
    }
}
