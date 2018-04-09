namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InitialBalance = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                        AccountName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Earnings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Income = c.Double(nullable: false),
                        BankAccountId = c.Int(nullable: false),
                        EarningCategoryId = c.Int(nullable: false),
                        EarningSubCategoryId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankAccounts", t => t.BankAccountId, cascadeDelete: true)
                .ForeignKey("dbo.EarningCategories", t => t.EarningCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.EarningSubCategories", t => t.EarningSubCategoryId, cascadeDelete: true)
                .Index(t => t.BankAccountId)
                .Index(t => t.EarningCategoryId)
                .Index(t => t.EarningSubCategoryId);
            
            CreateTable(
                "dbo.EarningCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EarningSubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubCategoryName = c.String(nullable: false),
                        EarningCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EarningCategories", t => t.EarningCategoryId, cascadeDelete: false)
                .Index(t => t.EarningCategoryId);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cost = c.Double(nullable: false),
                        BankAccountId = c.Int(nullable: false),
                        ExpenseCategoryId = c.Int(nullable: false),
                        ExpenseSubcategoryId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankAccounts", t => t.BankAccountId, cascadeDelete: true)
                .ForeignKey("dbo.ExpenseCategories", t => t.ExpenseCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.ExpenseSubCategories", t => t.ExpenseSubcategoryId, cascadeDelete: true)
                .Index(t => t.BankAccountId)
                .Index(t => t.ExpenseCategoryId)
                .Index(t => t.ExpenseSubcategoryId);
            
            CreateTable(
                "dbo.ExpenseCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExpenseSubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubCategoryName = c.String(nullable: false),
                        ExpenseCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseCategories", t => t.ExpenseCategoryId, cascadeDelete: false)
                .Index(t => t.ExpenseCategoryId);
            
            CreateTable(
                "dbo.Transfers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AmountTransferred = c.Double(nullable: false),
                        SourceBankAccountsId = c.Int(nullable: false),
                        TargetBankAccountsId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Note = c.String(),
                        BankAccount_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankAccounts", t => t.SourceBankAccountsId, cascadeDelete: true)
                .ForeignKey("dbo.BankAccounts", t => t.TargetBankAccountsId, cascadeDelete: false)
                .ForeignKey("dbo.BankAccounts", t => t.BankAccount_Id)
                .Index(t => t.SourceBankAccountsId)
                .Index(t => t.TargetBankAccountsId)
                .Index(t => t.BankAccount_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Transfers", "BankAccount_Id", "dbo.BankAccounts");
            DropForeignKey("dbo.Transfers", "TargetBankAccountsId", "dbo.BankAccounts");
            DropForeignKey("dbo.Transfers", "SourceBankAccountsId", "dbo.BankAccounts");
            DropForeignKey("dbo.Expenses", "ExpenseSubcategoryId", "dbo.ExpenseSubCategories");
            DropForeignKey("dbo.Expenses", "ExpenseCategoryId", "dbo.ExpenseCategories");
            DropForeignKey("dbo.ExpenseSubCategories", "ExpenseCategoryId", "dbo.ExpenseCategories");
            DropForeignKey("dbo.Expenses", "BankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.Earnings", "EarningSubCategoryId", "dbo.EarningSubCategories");
            DropForeignKey("dbo.Earnings", "EarningCategoryId", "dbo.EarningCategories");
            DropForeignKey("dbo.EarningSubCategories", "EarningCategoryId", "dbo.EarningCategories");
            DropForeignKey("dbo.Earnings", "BankAccountId", "dbo.BankAccounts");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Transfers", new[] { "BankAccount_Id" });
            DropIndex("dbo.Transfers", new[] { "TargetBankAccountsId" });
            DropIndex("dbo.Transfers", new[] { "SourceBankAccountsId" });
            DropIndex("dbo.ExpenseSubCategories", new[] { "ExpenseCategoryId" });
            DropIndex("dbo.Expenses", new[] { "ExpenseSubcategoryId" });
            DropIndex("dbo.Expenses", new[] { "ExpenseCategoryId" });
            DropIndex("dbo.Expenses", new[] { "BankAccountId" });
            DropIndex("dbo.EarningSubCategories", new[] { "EarningCategoryId" });
            DropIndex("dbo.Earnings", new[] { "EarningSubCategoryId" });
            DropIndex("dbo.Earnings", new[] { "EarningCategoryId" });
            DropIndex("dbo.Earnings", new[] { "BankAccountId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Transfers");
            DropTable("dbo.ExpenseSubCategories");
            DropTable("dbo.ExpenseCategories");
            DropTable("dbo.Expenses");
            DropTable("dbo.EarningSubCategories");
            DropTable("dbo.EarningCategories");
            DropTable("dbo.Earnings");
            DropTable("dbo.BankAccounts");
        }
    }
}
