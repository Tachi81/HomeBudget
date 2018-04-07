using System.Linq;
using HomeBudget.DAL.Repositories;

namespace HomeBudget.Business_Logic
{
    public class BankAccountLogic : IBankAccountLogic
    {

        private readonly BankAccountRepository _bankAccountRepository = new BankAccountRepository();
        /// <summary>
        /// calculates Account balance
        /// </summary>
        /// <param name="bankAccountId"></param>
        public void CalculateAccountBalance(int bankAccountId)
        {
            var bankAccount = _bankAccountRepository.GetWhereWithIncludes(x => x.Id == bankAccountId, x => x.Expenses, x => x.Earnings).FirstOrDefault();
            if (bankAccount != null)
            {
                var sumOfExpenses = bankAccount.Expenses.Sum(e => e.Cost);
                var sumOfEarnings = bankAccount.Earnings.Sum(x => x.Income);
                bankAccount.Balance = bankAccount.InitialBalance - sumOfExpenses + sumOfEarnings;
            }

            _bankAccountRepository.Update(bankAccount);
        }

    }
}