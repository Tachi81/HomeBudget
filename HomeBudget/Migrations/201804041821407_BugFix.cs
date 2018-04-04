namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BugFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "AccountId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "AccountId");
        }
    }
}
