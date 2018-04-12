using HomeBudget.DAL.Interfaces;
using HomeBudget.Models;
using HomeBudget.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HomeBudget.Controllers
{
    public class FinancialOperationsController : Controller
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IEarningsRepository _earningsRepository;
        private readonly IExpensesRepository _expensesRepository;
        private readonly ITransferRepository _transferRepository;

        public FinancialOperationsController(IBankAccountRepository bankAccountRepository,
            IEarningsRepository earningsRepository, IExpensesRepository expensesRepository, ITransferRepository transferRepository)
        {
            _bankAccountRepository = bankAccountRepository;
            _earningsRepository = earningsRepository;
            _expensesRepository = expensesRepository;
            _transferRepository = transferRepository;
        }
        // GET: FinancialOperations
        public ActionResult Index()
        {
            var financialOperationsVm = new FinancialOperationsHistoryViewModel();
            var listOfBankAccounts = _bankAccountRepository.GetWhere(ba => ba.Id > 0).ToList();
            financialOperationsVm.SelectListOfBankAccounts = new SelectList(listOfBankAccounts, "Id", "AccountName");

            return View(financialOperationsVm);
        }


        public ActionResult Details(FinancialOperationsHistoryViewModel model)
        {
            model.ListofFinancialOperation = new List<FinancialOperation>();


            var listOfExpenses = _expensesRepository
                .GetWhereWithIncludes(t => t.BankAccountId == model.FinancialOperation.BankAccountId,
                    e => e.SubCategory.Category, e => e.SubCategory, e => e.BankAccount);

            listOfExpenses.ForEach(exp => exp.AmountOfMoney *= (-1));
            listOfExpenses.ForEach(exp => exp.DescriptionOfOperation = @"Category: " + exp.SubCategory.Category.CategoryName + "<br/>" + " SubCategory: " + exp.SubCategory.SubCategoryName);


            var listOfEarnings = _earningsRepository.GetWhereWithIncludes(t =>
                     t.BankAccountId == model.FinancialOperation.BankAccountId, e => e.SubCategory.Category, e => e.SubCategory, e => e.BankAccount);
            listOfEarnings.ForEach(earn => earn.DescriptionOfOperation = @"Category: " + earn.SubCategory.Category.CategoryName + "<br/>" + " SubCategory: " + earn.SubCategory.SubCategoryName);

            var listOfTransferIncomes =
                _transferRepository.GetWhereWithIncludes(t => t.TargetBankAccountId == model.FinancialOperation.BankAccountId, e => e.SourceBankAccount, e => e.TargetBankAccount);
            listOfTransferIncomes.ForEach(transfer =>
            {
                transfer.DescriptionOfOperation = transfer.SourceBankAccount.AccountName;
                transfer.BankAccount = transfer.TargetBankAccount;
            });



            var listOfTransferOutcomes =
                _transferRepository.GetWhereWithIncludes(t => t.SourceBankAccountId == model.FinancialOperation.BankAccountId, e => e.SourceBankAccount, e => e.TargetBankAccount);
            listOfTransferOutcomes.ForEach(transf =>
            {
                transf.AmountOfMoney *= (-1);
                transf.DescriptionOfOperation = transf.TargetBankAccount.AccountName;
                transf.BankAccount = transf.SourceBankAccount;
            });


            model.ListofFinancialOperation.AddRange(listOfEarnings);
            model.ListofFinancialOperation.AddRange(listOfExpenses);
            model.ListofFinancialOperation.AddRange(listOfTransferOutcomes);
            model.ListofFinancialOperation.AddRange(listOfTransferIncomes);


            return View(model);
        }




    }
}
