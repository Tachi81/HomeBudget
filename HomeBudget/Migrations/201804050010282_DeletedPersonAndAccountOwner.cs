namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedPersonAndAccountOwner : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonBankAccounts", "Person_Id", "dbo.People");
            DropForeignKey("dbo.PersonBankAccounts", "BankAccount_Id", "dbo.BankAccounts");
            DropIndex("dbo.PersonBankAccounts", new[] { "Person_Id" });
            DropIndex("dbo.PersonBankAccounts", new[] { "BankAccount_Id" });
            DropColumn("dbo.BankAccounts", "PersonId");
           DropTable("dbo.People");
            DropTable("dbo.PersonBankAccounts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PersonBankAccounts",
                c => new
                    {
                        Person_Id = c.Int(nullable: false),
                        BankAccount_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.BankAccount_Id });
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonName = c.String(),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.BankAccounts", "PersonId", c => c.Int(nullable: false));
            CreateIndex("dbo.PersonBankAccounts", "BankAccount_Id");
            CreateIndex("dbo.PersonBankAccounts", "Person_Id");
            AddForeignKey("dbo.PersonBankAccounts", "BankAccount_Id", "dbo.BankAccounts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PersonBankAccounts", "Person_Id", "dbo.People", "Id", cascadeDelete: true);
        }
    }
}
