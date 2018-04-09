namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTransfer : DbMigration
    {
        public override void Up()
        {
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
                .ForeignKey("dbo.BankAccounts", t => t.BankAccount_Id)
                .Index(t => t.BankAccount_Id);
            
            AddColumn("dbo.BankAccounts", "Transfer_Id", c => c.Int());
            AddColumn("dbo.BankAccounts", "Transfer_Id1", c => c.Int());
            CreateIndex("dbo.BankAccounts", "Transfer_Id");
            CreateIndex("dbo.BankAccounts", "Transfer_Id1");
            AddForeignKey("dbo.BankAccounts", "Transfer_Id", "dbo.Transfers", "Id");
            AddForeignKey("dbo.BankAccounts", "Transfer_Id1", "dbo.Transfers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transfers", "BankAccount_Id", "dbo.BankAccounts");
            DropForeignKey("dbo.BankAccounts", "Transfer_Id1", "dbo.Transfers");
            DropForeignKey("dbo.BankAccounts", "Transfer_Id", "dbo.Transfers");
            DropIndex("dbo.Transfers", new[] { "BankAccount_Id" });
            DropIndex("dbo.BankAccounts", new[] { "Transfer_Id1" });
            DropIndex("dbo.BankAccounts", new[] { "Transfer_Id" });
            DropColumn("dbo.BankAccounts", "Transfer_Id1");
            DropColumn("dbo.BankAccounts", "Transfer_Id");
            DropTable("dbo.Transfers");
        }
    }
}
