using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeBudget.DAL.Interfaces;
using HomeBudget.Models;
using HomeBudget.ViewModels;

namespace HomeBudget.Controllers
{
    public class FinancialOperationsController : Controller
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IEarningsRepository _earningsRepository;
        private readonly IExpensesRepository _expensesRepository;
        private readonly ITransferRepository _transferRepository;

        public FinancialOperationsController(IBankAccountRepository bankAccountRepository,
            IEarningsRepository earningsRepository, IExpensesRepository expensesRepository, ITransferRepository transferRepository )
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
            var listOfExpenses = _expensesRepository
                .GetWhereWithIncludes(t => t.BankAccountId == model.FinancialOperation.BankAccountId, e => e.Category, e => e.SubCategory, e => e.BankAccount);
            var listOfEarnings =
                _earningsRepository.GetWhereWithIncludes(t =>
                    t.BankAccountId == model.FinancialOperation.BankAccountId, e=>e.Category, e => e.SubCategory, e => e.BankAccount);

            var listOfTransferIncomes =
                _transferRepository.GetWhereWithIncludes(t => t.SourceBankAccountId == model.FinancialOperation.BankAccountId, e => e.SourceBankAccount, e => e.TargetBankAccount);
            var listOfTransferOutcomes =
                _transferRepository.GetWhereWithIncludes(t => t.TargetBankAccountId == model.FinancialOperation.BankAccountId, e => e.SourceBankAccount, e => e.TargetBankAccount);

            model.ListofFinancialOperation = new List<FinancialOperation>();

            model.ListofFinancialOperation.AddRange(listOfEarnings);
            model.ListofFinancialOperation.AddRange(listOfExpenses);
            model.ListofFinancialOperation.AddRange(listOfTransferOutcomes);
            model.ListofFinancialOperation.AddRange(listOfTransferIncomes);
            return View(model);
        }

       
        

    }
}
