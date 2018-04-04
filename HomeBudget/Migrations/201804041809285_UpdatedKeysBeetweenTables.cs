namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedKeysBeetweenTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Earnings", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Expenses", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Earnings", "CategoryName_Id", "dbo.Categories");
            DropForeignKey("dbo.Expenses", "CategoryName_Id", "dbo.Categories");
            DropIndex("dbo.Earnings", new[] { "Account_Id" });
            DropIndex("dbo.Earnings", new[] { "CategoryName_Id" });
            DropIndex("dbo.Expenses", new[] { "Account_Id" });
            DropIndex("dbo.Expenses", new[] { "CategoryName_Id" });
            RenameColumn(table: "dbo.Earnings", name: "Account_Id", newName: "AccountId");
            RenameColumn(table: "dbo.Expenses", name: "Account_Id", newName: "AccountId");
            RenameColumn(table: "dbo.Earnings", name: "CategoryName_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.Expenses", name: "CategoryName_Id", newName: "CategoryId");
            AddColumn("dbo.Accounts", "PersonId", c => c.Int(nullable: false));
            AddColumn("dbo.Earnings", "SubcategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "Name", c => c.String());
            AddColumn("dbo.Expenses", "SubcategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Earnings", "AccountId", c => c.Int(nullable: false));
            AlterColumn("dbo.Earnings", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Expenses", "AccountId", c => c.Int(nullable: false));
            AlterColumn("dbo.Expenses", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Earnings", "AccountId");
            CreateIndex("dbo.Earnings", "CategoryId");
            CreateIndex("dbo.Expenses", "AccountId");
            CreateIndex("dbo.Expenses", "CategoryId");
            AddForeignKey("dbo.Earnings", "AccountId", "dbo.Accounts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Expenses", "AccountId", "dbo.Accounts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Earnings", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Expenses", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Earnings", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Expenses", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Earnings", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Expenses", new[] { "CategoryId" });
            DropIndex("dbo.Expenses", new[] { "AccountId" });
            DropIndex("dbo.Earnings", new[] { "CategoryId" });
            DropIndex("dbo.Earnings", new[] { "AccountId" });
            AlterColumn("dbo.Expenses", "CategoryId", c => c.Int());
            AlterColumn("dbo.Expenses", "AccountId", c => c.Int());
            AlterColumn("dbo.Earnings", "CategoryId", c => c.Int());
            AlterColumn("dbo.Earnings", "AccountId", c => c.Int());
            DropColumn("dbo.Expenses", "SubcategoryId");
            DropColumn("dbo.Categories", "Name");
            DropColumn("dbo.Earnings", "SubcategoryId");
            DropColumn("dbo.Accounts", "PersonId");
            RenameColumn(table: "dbo.Expenses", name: "CategoryId", newName: "CategoryName_Id");
            RenameColumn(table: "dbo.Earnings", name: "CategoryId", newName: "CategoryName_Id");
            RenameColumn(table: "dbo.Expenses", name: "AccountId", newName: "Account_Id");
            RenameColumn(table: "dbo.Earnings", name: "AccountId", newName: "Account_Id");
            CreateIndex("dbo.Expenses", "CategoryName_Id");
            CreateIndex("dbo.Expenses", "Account_Id");
            CreateIndex("dbo.Earnings", "CategoryName_Id");
            CreateIndex("dbo.Earnings", "Account_Id");
            AddForeignKey("dbo.Expenses", "CategoryName_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.Earnings", "CategoryName_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.Expenses", "Account_Id", "dbo.Accounts", "Id");
            AddForeignKey("dbo.Earnings", "Account_Id", "dbo.Accounts", "Id");
        }
    }
}
