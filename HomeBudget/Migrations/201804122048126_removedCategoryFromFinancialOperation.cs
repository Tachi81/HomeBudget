namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedCategoryFromFinancialOperation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Earnings", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Expenses", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Transfers", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Earnings", new[] { "CategoryId" });
            DropIndex("dbo.Expenses", new[] { "CategoryId" });
            DropIndex("dbo.Transfers", new[] { "CategoryId" });
            DropColumn("dbo.Earnings", "CategoryId");
            DropColumn("dbo.Expenses", "CategoryId");
            DropColumn("dbo.Transfers", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transfers", "CategoryId", c => c.Int());
            AddColumn("dbo.Expenses", "CategoryId", c => c.Int());
            AddColumn("dbo.Earnings", "CategoryId", c => c.Int());
            CreateIndex("dbo.Transfers", "CategoryId");
            CreateIndex("dbo.Expenses", "CategoryId");
            CreateIndex("dbo.Earnings", "CategoryId");
            AddForeignKey("dbo.Transfers", "CategoryId", "dbo.Categories", "Id");
            AddForeignKey("dbo.Expenses", "CategoryId", "dbo.Categories", "Id");
            AddForeignKey("dbo.Earnings", "CategoryId", "dbo.Categories", "Id");
        }
    }
}
