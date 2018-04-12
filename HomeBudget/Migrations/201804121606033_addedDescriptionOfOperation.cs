namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDescriptionOfOperation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Earnings", "DescriptionOfOperation", c => c.String());
            AddColumn("dbo.Expenses", "DescriptionOfOperation", c => c.String());
            AddColumn("dbo.Transfers", "DescriptionOfOperation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transfers", "DescriptionOfOperation");
            DropColumn("dbo.Expenses", "DescriptionOfOperation");
            DropColumn("dbo.Earnings", "DescriptionOfOperation");
        }
    }
}
