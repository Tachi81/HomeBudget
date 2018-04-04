namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAccountToBankAccount : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Accounts", newName: "BankAccounts");
            RenameTable(name: "dbo.PersonAccounts", newName: "PersonBankAccounts");
            RenameColumn(table: "dbo.PersonBankAccounts", name: "Account_Id", newName: "BankAccount_Id");
            RenameColumn(table: "dbo.Earnings", name: "AccountId", newName: "BankAccountId");
            RenameColumn(table: "dbo.Expenses", name: "AccountId", newName: "BankAccountId");
            RenameIndex(table: "dbo.Earnings", name: "IX_AccountId", newName: "IX_BankAccountId");
            RenameIndex(table: "dbo.Expenses", name: "IX_AccountId", newName: "IX_BankAccountId");
            RenameIndex(table: "dbo.PersonBankAccounts", name: "IX_Account_Id", newName: "IX_BankAccount_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PersonBankAccounts", name: "IX_BankAccount_Id", newName: "IX_Account_Id");
            RenameIndex(table: "dbo.Expenses", name: "IX_BankAccountId", newName: "IX_AccountId");
            RenameIndex(table: "dbo.Earnings", name: "IX_BankAccountId", newName: "IX_AccountId");
            RenameColumn(table: "dbo.Expenses", name: "BankAccountId", newName: "AccountId");
            RenameColumn(table: "dbo.Earnings", name: "BankAccountId", newName: "AccountId");
            RenameColumn(table: "dbo.PersonBankAccounts", name: "BankAccount_Id", newName: "Account_Id");
            RenameTable(name: "dbo.PersonBankAccounts", newName: "PersonAccounts");
            RenameTable(name: "dbo.BankAccounts", newName: "Accounts");
        }
    }
}
