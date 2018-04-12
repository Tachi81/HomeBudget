namespace HomeBudget.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class createDB : DbMigration
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
                    AccountName = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Earnings",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    AmountOfMoney = c.Double(nullable: false),
                    BankAccountId = c.Int(),
                    SubCategoryId = c.Int(),
                    DescriptionOfOperation = c.String(),
                    SourceBankAccountId = c.Int(),
                    TargetBankAccountId = c.Int(),
                    DateTime = c.DateTime(nullable: false),
                    Note = c.String(),
                    BankAccount_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankAccounts", t => t.BankAccountId)
                .ForeignKey("dbo.BankAccounts", t => t.SourceBankAccountId)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryId)
                .ForeignKey("dbo.BankAccounts", t => t.TargetBankAccountId)
                .ForeignKey("dbo.BankAccounts", t => t.BankAccount_Id)
                .Index(t => t.BankAccountId)
                .Index(t => t.SubCategoryId)
                .Index(t => t.SourceBankAccountId)
                .Index(t => t.TargetBankAccountId)
                .Index(t => t.BankAccount_Id);

            CreateTable(
                "dbo.SubCategories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    SubCategoryName = c.String(nullable: false),
                    CategoryId = c.Int(nullable: false),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);

            CreateTable(
                "dbo.Categories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CategoryName = c.String(nullable: false, maxLength: 50),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Expenses",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    AmountOfMoney = c.Double(nullable: false),
                    BankAccountId = c.Int(),
                    SubCategoryId = c.Int(),
                    DescriptionOfOperation = c.String(),
                    SourceBankAccountId = c.Int(),
                    TargetBankAccountId = c.Int(),
                    DateTime = c.DateTime(nullable: false),
                    Note = c.String(),
                    BankAccount_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankAccounts", t => t.BankAccountId)
                .ForeignKey("dbo.BankAccounts", t => t.SourceBankAccountId, cascadeDelete: true)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryId)
                .ForeignKey("dbo.BankAccounts", t => t.TargetBankAccountId, cascadeDelete: false)
                .ForeignKey("dbo.BankAccounts", t => t.BankAccount_Id)
                .Index(t => t.BankAccountId)
                .Index(t => t.SubCategoryId)
                .Index(t => t.SourceBankAccountId)
                .Index(t => t.TargetBankAccountId)
                .Index(t => t.BankAccount_Id);

            CreateTable(
                "dbo.Transfers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    AmountOfMoney = c.Double(nullable: false),
                    BankAccountId = c.Int(),
                    SubCategoryId = c.Int(),
                    DescriptionOfOperation = c.String(),
                    SourceBankAccountId = c.Int(),
                    TargetBankAccountId = c.Int(),
                    DateTime = c.DateTime(nullable: false),
                    Note = c.String(),
                    BankAccount_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankAccounts", t => t.BankAccountId)
                .ForeignKey("dbo.BankAccounts", t => t.SourceBankAccountId)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryId)
                .ForeignKey("dbo.BankAccounts", t => t.TargetBankAccountId)
                .ForeignKey("dbo.BankAccounts", t => t.BankAccount_Id)
                .Index(t => t.BankAccountId)
                .Index(t => t.SubCategoryId)
                .Index(t => t.SourceBankAccountId)
                .Index(t => t.TargetBankAccountId)
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
            DropForeignKey("dbo.Transfers", "TargetBankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.Transfers", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.Transfers", "SourceBankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.Transfers", "BankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.Expenses", "BankAccount_Id", "dbo.BankAccounts");
            DropForeignKey("dbo.Expenses", "TargetBankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.Expenses", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.Expenses", "SourceBankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.Expenses", "BankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.Earnings", "BankAccount_Id", "dbo.BankAccounts");
            DropForeignKey("dbo.Earnings", "TargetBankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.Earnings", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Earnings", "SourceBankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.Earnings", "BankAccountId", "dbo.BankAccounts");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Transfers", new[] { "BankAccount_Id" });
            DropIndex("dbo.Transfers", new[] { "TargetBankAccountId" });
            DropIndex("dbo.Transfers", new[] { "SourceBankAccountId" });
            DropIndex("dbo.Transfers", new[] { "SubCategoryId" });
            DropIndex("dbo.Transfers", new[] { "BankAccountId" });
            DropIndex("dbo.Expenses", new[] { "BankAccount_Id" });
            DropIndex("dbo.Expenses", new[] { "TargetBankAccountId" });
            DropIndex("dbo.Expenses", new[] { "SourceBankAccountId" });
            DropIndex("dbo.Expenses", new[] { "SubCategoryId" });
            DropIndex("dbo.Expenses", new[] { "BankAccountId" });
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            DropIndex("dbo.Earnings", new[] { "BankAccount_Id" });
            DropIndex("dbo.Earnings", new[] { "TargetBankAccountId" });
            DropIndex("dbo.Earnings", new[] { "SourceBankAccountId" });
            DropIndex("dbo.Earnings", new[] { "SubCategoryId" });
            DropIndex("dbo.Earnings", new[] { "BankAccountId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Transfers");
            DropTable("dbo.Expenses");
            DropTable("dbo.Categories");
            DropTable("dbo.SubCategories");
            DropTable("dbo.Earnings");
            DropTable("dbo.BankAccounts");
        }
    }
}
