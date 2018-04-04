namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Balance = c.Double(nullable: false),
                        AccountName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Earnings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Income = c.Double(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Note = c.String(),
                        Account_Id = c.Int(),
                        CategoryName_Id = c.Int(),
                        SubCategory_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .ForeignKey("dbo.Categories", t => t.CategoryName_Id)
                .ForeignKey("dbo.SubCategories", t => t.SubCategory_Id)
                .Index(t => t.Account_Id)
                .Index(t => t.CategoryName_Id)
                .Index(t => t.SubCategory_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        SubCategoryName = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cost = c.Double(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Note = c.String(),
                        Account_Id = c.Int(),
                        CategoryName_Id = c.Int(),
                        SubCategory_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .ForeignKey("dbo.Categories", t => t.CategoryName_Id)
                .ForeignKey("dbo.SubCategories", t => t.SubCategory_Id)
                .Index(t => t.Account_Id)
                .Index(t => t.CategoryName_Id)
                .Index(t => t.SubCategory_Id);
            
            CreateTable(
                "dbo.PersonAccounts",
                c => new
                    {
                        Person_Id = c.Int(nullable: false),
                        Account_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.Account_Id })
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.Account_Id, cascadeDelete: true)
                .Index(t => t.Person_Id)
                .Index(t => t.Account_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "SubCategory_Id", "dbo.SubCategories");
            DropForeignKey("dbo.Expenses", "CategoryName_Id", "dbo.Categories");
            DropForeignKey("dbo.Expenses", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Earnings", "SubCategory_Id", "dbo.SubCategories");
            DropForeignKey("dbo.Earnings", "CategoryName_Id", "dbo.Categories");
            DropForeignKey("dbo.SubCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Earnings", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.PersonAccounts", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.PersonAccounts", "Person_Id", "dbo.People");
            DropIndex("dbo.PersonAccounts", new[] { "Account_Id" });
            DropIndex("dbo.PersonAccounts", new[] { "Person_Id" });
            DropIndex("dbo.Expenses", new[] { "SubCategory_Id" });
            DropIndex("dbo.Expenses", new[] { "CategoryName_Id" });
            DropIndex("dbo.Expenses", new[] { "Account_Id" });
            DropIndex("dbo.SubCategories", new[] { "Category_Id" });
            DropIndex("dbo.Earnings", new[] { "SubCategory_Id" });
            DropIndex("dbo.Earnings", new[] { "CategoryName_Id" });
            DropIndex("dbo.Earnings", new[] { "Account_Id" });
            DropTable("dbo.PersonAccounts");
            DropTable("dbo.Expenses");
            DropTable("dbo.SubCategories");
            DropTable("dbo.Categories");
            DropTable("dbo.Earnings");
            DropTable("dbo.People");
            DropTable("dbo.Accounts");
        }
    }
}
