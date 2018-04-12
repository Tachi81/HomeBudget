using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using HomeBudget.Business_Logic;
using HomeBudget.DAL.Interfaces;
using HomeBudget.DAL.Repositories;
using HomeBudget.Models;
using HomeBudget.ViewModels;

namespace HomeBudget.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesRepository _expenseRepository;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IExpenseCategoriesRepository _expenseCategoriesRepository;
        private readonly IExpenseSubCategoriesRepository _subCategoriesRepository;
        private readonly IBankAccountLogic _bankAccountLogic;

        public ExpensesController(IExpensesRepository expenseRepository, IBankAccountRepository bankAccountRepository,
            IExpenseCategoriesRepository categoriesRepository, IBankAccountLogic bankAccountLogic,
            IExpenseSubCategoriesRepository subCategoriesRepository)
        {
            _expenseRepository = expenseRepository;
            _bankAccountRepository = bankAccountRepository;
            _expenseCategoriesRepository = categoriesRepository;
            _subCategoriesRepository = subCategoriesRepository;
            _bankAccountLogic = bankAccountLogic;
        }

        // GET: Expenses
        public ActionResult Index()
        {
            var expenseVm = new ExpenseViewModel();
             expenseVm.ListOfExpenses = _expenseRepository.GetWhereWithIncludes(e => e.Id > 0, 
                 x=>x.BankAccount, x=>x.SubCategory, x=>x.SubCategory.Category).ToList();
            return View(expenseVm);
        }

        // GET: Expenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var expenseVm = new ExpenseViewModel();
            expenseVm.Expense = _expenseRepository.GetWhereWithIncludes(e => e.Id == id, x => x.BankAccount, 
                x => x.SubCategory, x => x.SubCategory.Category).FirstOrDefault();
            
            return View(expenseVm);
        }

        // GET: Expenses/Create
        public ActionResult Create()
        {
            ExpenseViewModel expenseVm = CreateExpenseViewModelWithSelectLists();

            return View(expenseVm);
        }

       

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpenseViewModel expenseVm)
        {
            if (ModelState.IsValid)
            {
                _expenseRepository.Create(expenseVm.Expense);
           
                _bankAccountLogic.CalculateBalanceOfAllAccounts();
                return RedirectToAction("Index");
            }

             expenseVm = CreateExpenseViewModelWithSelectLists();
            return View(expenseVm);
           
        }

        // GET: Expenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var expenseVm = CreateExpenseViewModelWithSelectLists();
            expenseVm.Expense = _expenseRepository.GetWhereWithIncludes(e => e.Id == id, 
                x => x.BankAccount, x => x.SubCategory, x => x.SubCategory.Category).FirstOrDefault();
            
            return View(expenseVm);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExpenseViewModel expenseVm)
        {
            if (ModelState.IsValid)
            {
                _expenseRepository.Update(expenseVm.Expense);
                _bankAccountLogic.CalculateBalanceOfAllAccounts();
                return RedirectToAction("Index");
            }

           
            return View(expenseVm);
        }

        // GET: Expenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var expenseVm = new ExpenseViewModel();
            expenseVm.Expense = _expenseRepository.GetWhereWithIncludes(e => e.Id == id,
                x => x.BankAccount, x => x.SubCategory, x => x.SubCategory.Category).FirstOrDefault();

            return View(expenseVm);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var expenseVm = new ExpenseViewModel();
            expenseVm.Expense = _expenseRepository.GetWhereWithIncludes(e => e.Id == id,
                x => x.BankAccount, x => x.SubCategory, x => x.SubCategory.Category).FirstOrDefault();
            _expenseRepository.Delete(expenseVm.Expense);
            _bankAccountLogic.CalculateBalanceOfAllAccounts();


            return RedirectToAction("Index");
        }

        private ExpenseViewModel CreateExpenseViewModelWithSelectLists()
        {
            var expenseVm = new ExpenseViewModel();
            var listOfBankAccounts = _bankAccountRepository.GetWhere(x => x.Id > 0).ToList();
            var listOfExpenseCategories = _expenseCategoriesRepository.GetWhere(x => x.Id > 0).ToList();
            var listOfExpenseSubCategories = _subCategoriesRepository.GetWhere(x => x.Id > 0).ToList();

            expenseVm.SelectListOfBankAccounts = new SelectList(listOfBankAccounts, "Id", "AccountName");
            expenseVm.SelectListOfExpenseCategories = new SelectList(listOfExpenseCategories, "Id", "CategoryName");
            expenseVm.SelectListOfExpenseSubCategories = new SelectList(listOfExpenseSubCategories, "Id", "SubCategoryName");
            return expenseVm;
        }
    }
}
