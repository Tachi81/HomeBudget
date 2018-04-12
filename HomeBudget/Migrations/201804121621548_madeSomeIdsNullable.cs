namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madeSomeIdsNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Earnings", "BankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.Earnings", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Earnings", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.Expenses", "BankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.Expenses", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Expenses", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.Transfers", "SourceBankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.Transfers", "TargetBankAccountId", "dbo.BankAccounts");
            DropIndex("dbo.Earnings", new[] { "BankAccountId" });
            DropIndex("dbo.Earnings", new[] { "CategoryId" });
            DropIndex("dbo.Earnings", new[] { "SubCategoryId" });
            DropIndex("dbo.Expenses", new[] { "BankAccountId" });
            DropIndex("dbo.Expenses", new[] { "CategoryId" });
            DropIndex("dbo.Expenses", new[] { "SubCategoryId" });
            DropIndex("dbo.Transfers", new[] { "SourceBankAccountId" });
            DropIndex("dbo.Transfers", new[] { "TargetBankAccountId" });
            AlterColumn("dbo.Earnings", "BankAccountId", c => c.Int());
            AlterColumn("dbo.Earnings", "CategoryId", c => c.Int());
            AlterColumn("dbo.Earnings", "SubCategoryId", c => c.Int());
            AlterColumn("dbo.Expenses", "BankAccountId", c => c.Int());
            AlterColumn("dbo.Expenses", "CategoryId", c => c.Int());
            AlterColumn("dbo.Expenses", "SubCategoryId", c => c.Int());
            AlterColumn("dbo.Transfers", "SourceBankAccountId", c => c.Int());
            AlterColumn("dbo.Transfers", "TargetBankAccountId", c => c.Int());
            CreateIndex("dbo.Earnings", "BankAccountId");
            CreateIndex("dbo.Earnings", "CategoryId");
            CreateIndex("dbo.Earnings", "SubCategoryId");
            CreateIndex("dbo.Expenses", "BankAccountId");
            CreateIndex("dbo.Expenses", "CategoryId");
            CreateIndex("dbo.Expenses", "SubCategoryId");
            CreateIndex("dbo.Transfers", "SourceBankAccountId");
            CreateIndex("dbo.Transfers", "TargetBankAccountId");
            AddForeignKey("dbo.Earnings", "BankAccountId", "dbo.BankAccounts", "Id");
            AddForeignKey("dbo.Earnings", "CategoryId", "dbo.Categories", "Id");
            AddForeignKey("dbo.Earnings", "SubCategoryId", "dbo.SubCategories", "Id");
            AddForeignKey("dbo.Expenses", "BankAccountId", "dbo.BankAccounts", "Id");
            AddForeignKey("dbo.Expenses", "CategoryId", "dbo.Categories", "Id");
            AddForeignKey("dbo.Expenses", "SubCategoryId", "dbo.SubCategories", "Id");
            AddForeignKey("dbo.Transfers", "SourceBankAccountId", "dbo.BankAccounts", "Id");
            AddForeignKey("dbo.Transfers", "TargetBankAccountId", "dbo.BankAccounts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transfers", "TargetBankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.Transfers", "SourceBankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.Expenses", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.Expenses", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Expenses", "BankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.Earnings", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.Earnings", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Earnings", "BankAccountId", "dbo.BankAccounts");
            DropIndex("dbo.Transfers", new[] { "TargetBankAccountId" });
            DropIndex("dbo.Transfers", new[] { "SourceBankAccountId" });
            DropIndex("dbo.Expenses", new[] { "SubCategoryId" });
            DropIndex("dbo.Expenses", new[] { "CategoryId" });
            DropIndex("dbo.Expenses", new[] { "BankAccountId" });
            DropIndex("dbo.Earnings", new[] { "SubCategoryId" });
            DropIndex("dbo.Earnings", new[] { "CategoryId" });
            DropIndex("dbo.Earnings", new[] { "BankAccountId" });
            AlterColumn("dbo.Transfers", "TargetBankAccountId", c => c.Int(nullable: false));
            AlterColumn("dbo.Transfers", "SourceBankAccountId", c => c.Int(nullable: false));
            AlterColumn("dbo.Expenses", "SubCategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Expenses", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Expenses", "BankAccountId", c => c.Int(nullable: false));
            AlterColumn("dbo.Earnings", "SubCategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Earnings", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Earnings", "BankAccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transfers", "TargetBankAccountId");
            CreateIndex("dbo.Transfers", "SourceBankAccountId");
            CreateIndex("dbo.Expenses", "SubCategoryId");
            CreateIndex("dbo.Expenses", "CategoryId");
            CreateIndex("dbo.Expenses", "BankAccountId");
            CreateIndex("dbo.Earnings", "SubCategoryId");
            CreateIndex("dbo.Earnings", "CategoryId");
            CreateIndex("dbo.Earnings", "BankAccountId");
            AddForeignKey("dbo.Transfers", "TargetBankAccountId", "dbo.BankAccounts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transfers", "SourceBankAccountId", "dbo.BankAccounts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Expenses", "SubCategoryId", "dbo.SubCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Expenses", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Expenses", "BankAccountId", "dbo.BankAccounts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Earnings", "SubCategoryId", "dbo.SubCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Earnings", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Earnings", "BankAccountId", "dbo.BankAccounts", "Id", cascadeDelete: true);
        }
    }
}
