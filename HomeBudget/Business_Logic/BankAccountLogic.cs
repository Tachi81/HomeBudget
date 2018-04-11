using System.Linq;
using HomeBudget.DAL.Interfaces;
using HomeBudget.DAL.Repositories;

namespace HomeBudget.Business_Logic
{
    public class BankAccountLogic : IBankAccountLogic
    {

        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly ITransferRepository _transferRepository;
        private readonly IExpensesRepository _expensesRepository;
        private readonly IEarningsRepository _earningsRepository;

        public BankAccountLogic(IBankAccountRepository bankAccountRepository,
            ITransferRepository transferRepository, IExpensesRepository expensesRepository, IEarningsRepository earningsRepository)

        {
            _bankAccountRepository = bankAccountRepository;
            _transferRepository = transferRepository;
            _expensesRepository = expensesRepository;
            _earningsRepository = earningsRepository;
        }

        public void CalculateBalanceOfAllAccounts()
        {
            var bankAccountList = _bankAccountRepository.GetWhereWithIncludes(x => x.Id > 0, x => x.Expenses, x => x.Earnings, x => x.Transfers).ToList();
            foreach (var bankAccount in bankAccountList)
            {
                var sumOfExpenses = _expensesRepository.GetWhere(t => t.BankAccountId == bankAccount.Id).Sum(e => e.AmountOfMoney);
                var sumOfEarnings = _earningsRepository.GetWhere(t => t.BankAccountId == bankAccount.Id).Sum(e => e.AmountOfMoney);
                var sumOfTransferIncomes = _transferRepository.GetWhere(t => t.TargetBankAccountId == bankAccount.Id)
                    .Sum(x => x.AmountOfMoney);
                var sumOfTransferOutcomes = _transferRepository.GetWhere(t => t.SourceBankAccountId == bankAccount.Id)
                    .Sum(t => t.AmountOfMoney);
                bankAccount.Balance = bankAccount.InitialBalance - sumOfExpenses + sumOfEarnings + sumOfTransferIncomes - sumOfTransferOutcomes;
                _bankAccountRepository.Update(bankAccount);
            }

        }

    }
}