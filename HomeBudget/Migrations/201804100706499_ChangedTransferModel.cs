namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTransferModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Transfers", name: "SourceBankAccountsId", newName: "SourceBankAccountId");
            RenameColumn(table: "dbo.Transfers", name: "TargetBankAccountsId", newName: "TargetBankAccountId");
            RenameIndex(table: "dbo.Transfers", name: "IX_SourceBankAccountsId", newName: "IX_SourceBankAccountId");
            RenameIndex(table: "dbo.Transfers", name: "IX_TargetBankAccountsId", newName: "IX_TargetBankAccountId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Transfers", name: "IX_TargetBankAccountId", newName: "IX_TargetBankAccountsId");
            RenameIndex(table: "dbo.Transfers", name: "IX_SourceBankAccountId", newName: "IX_SourceBankAccountsId");
            RenameColumn(table: "dbo.Transfers", name: "TargetBankAccountId", newName: "TargetBankAccountsId");
            RenameColumn(table: "dbo.Transfers", name: "SourceBankAccountId", newName: "SourceBankAccountsId");
        }
    }
}
