using System.Linq;
using HomeBudget.DAL.Interfaces;
using HomeBudget.DAL.Repositories;

namespace HomeBudget.Business_Logic
{
    public class BankAccountLogic : IBankAccountLogic
    {

        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly ITransferRepository _transferRepository;

        public BankAccountLogic(IBankAccountRepository bankAccountRepository, ITransferRepository transferRepository)
        
        {
            _bankAccountRepository = bankAccountRepository;
            _transferRepository = transferRepository;
        }

        public void CalculateBalanceOfAllAccounts()
        {
            var bankAccountList = _bankAccountRepository.GetWhereWithIncludes(x => x.Id > 0, x => x.Expenses, x => x.Earnings, x => x.Transfers).ToList();
            foreach (var bankAccount in bankAccountList)
            {
                var sumOfExpenses = bankAccount.Expenses.Sum(e => e.Cost);
                var sumOfEarnings = bankAccount.Earnings.Sum(x => x.Income);
                var sumOfTransferIncomes = _transferRepository.GetWhere(t => t.SourceBankAccountId == bankAccount.Id)
                    .Sum(x => x.AmountTransferred);
                var sumOfTransferOutcomes = _transferRepository.GetWhere(t => t.TargetBankAccountId == bankAccount.Id)
                    .Sum(t => t.AmountTransferred);
                bankAccount.Balance = bankAccount.InitialBalance - sumOfExpenses + sumOfEarnings + sumOfTransferIncomes- sumOfTransferOutcomes;
                _bankAccountRepository.Update(bankAccount);
            }

        }

    }
}