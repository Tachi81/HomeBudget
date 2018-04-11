using HomeBudget.Models;

namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeBudget.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HomeBudget.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.BankAccounts.AddOrUpdate(
                bankAccount => bankAccount.Id,
                new BankAccount { InitialBalance = 1300.0, AccountName = "Tomek Bank Account" },
                new BankAccount { InitialBalance = 1300.0, AccountName = "Phiona Account" }
                );

            context.EarningCategories.AddOrUpdate(
                cat=>cat.Id,
                new EarningCategory { CategoryName = "Official Salary" }
                );

        }
    }
}
