using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeBudget.DAL.Interfaces;
using HomeBudget.Models;

namespace HomeBudget.DAL.Repositories
{
    public class BankAccountRepository : AbstractRepository<BankAccount>, IBankAccountRepository
    {
        public override void Create(BankAccount bankAccount)
        {
            using (var context = new ApplicationDbContext())
            {
                bankAccount.Balance = bankAccount.InitialBalance;
                context.Set<BankAccount>().Add(bankAccount);
                context.SaveChanges();
            }
        }
    }
}