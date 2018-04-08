using System.Linq;
using HomeBudget.DAL.Repositories;

namespace HomeBudget.Business_Logic
{
    public class BankAccountLogic : IBankAccountLogic
    {

        private readonly BankAccountRepository _bankAccountRepository = new BankAccountRepository();
       
        public void CalculateBalanceOfAllAccounts()
        {
            var bankAccountList = _bankAccountRepository.GetWhereWithIncludes(x => x.Id > 0, x => x.Expenses, x => x.Earnings).ToList();
            foreach (var bankAccount in bankAccountList)
            {
                var sumOfExpenses = bankAccount.Expenses.Sum(e => e.Cost);
                var sumOfEarnings = bankAccount.Earnings.Sum(x => x.Income);
                bankAccount.Balance = bankAccount.InitialBalance - sumOfExpenses + sumOfEarnings;
                _bankAccountRepository.Update(bankAccount);
            }

        }

    }
}