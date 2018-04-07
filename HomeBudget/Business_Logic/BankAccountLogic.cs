using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeBudget.DAL.Repositories;
using HomeBudget.Models;

namespace HomeBudget.Business_Logic
{
    public class BankAccountLogic : IBankAccountLogic
    {
        
        private BankAccountRepository bankAccountRepository =new BankAccountRepository();
        /// <summary>
        /// calculates Account balance
        /// </summary>
        /// <param name="bankAccountId"></param>
        public void CalculateAccountBalance(int bankAccountId)
        {
            var bankAccount = bankAccountRepository.GetWhereWithIncludes(x => x.Id == bankAccountId,x=>x.Expenses).FirstOrDefault();
            if (bankAccount != null)
            {
                var sumOfExpenses = bankAccount.Expenses.Sum(e => e.Cost);
                bankAccount.Balance = bankAccount.InitialBalance - sumOfExpenses;
            }

            bankAccountRepository.Update(bankAccount);
        }
        
    }
}