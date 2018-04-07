﻿using System.Linq;
using System.Net;
using System.Web.Mvc;
using HomeBudget.Business_Logic;
using HomeBudget.DAL.Interfaces;
using HomeBudget.DAL.Repositories;
using HomeBudget.Models;

namespace HomeBudget.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesRepository _expenseRepository;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly ISubCategoriesRepository _subCategoriesRepository;
        private readonly IBankAccountLogic _bankAccountLogic;

        public ExpensesController(IExpensesRepository expenseRepository, IBankAccountRepository bankAccountRepository,
            ICategoriesRepository categoriesRepository, IBankAccountLogic bankAccountLogic,
            ISubCategoriesRepository subCategoriesRepository)
        {
            _expenseRepository = expenseRepository;
            _bankAccountRepository = bankAccountRepository;
            _categoriesRepository = categoriesRepository;
            _subCategoriesRepository = subCategoriesRepository;
            _bankAccountLogic = bankAccountLogic;
        }

        // GET: Expenses
        public ActionResult Index()
        {
            var expenses = _expenseRepository.GetWhereWithIncludes(e => e.Id > 0, x=>x.BankAccount, x=>x.SubCategory, x=>x.Category).ToList();
            return View(expenses);
        }

        // GET: Expenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Expense expense = _expenseRepository.GetWhereWithIncludes(e => e.Id == id, x => x.BankAccount, x => x.SubCategory, x => x.Category).FirstOrDefault();
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // GET: Expenses/Create
        public ActionResult Create()
        {
            var bankAccounts = _bankAccountRepository.GetWhere(x => x.Id > 0).ToList();
            var categories = _categoriesRepository.GetWhere(x => x.Id > 0).ToList();
            var subCategories = _subCategoriesRepository.GetWhere(x => x.Id > 0).ToList();

            ViewBag.BankAccountId = new SelectList(bankAccounts, "Id", "AccountName");
            ViewBag.CategoryId = new SelectList(categories, "Id", "CategoryName");
            ViewBag.SubCategoryId = new SelectList(subCategories, "Id", "SubCategoryName");
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _expenseRepository.Create(expense);
           
                _bankAccountLogic.CalculateAccountBalance(expense.BankAccountId);
                return RedirectToAction("Index");
            }

            var bankAccounts = _bankAccountRepository.GetWhere(x => x.Id > 0).ToList();
            var categories = _categoriesRepository.GetWhere(x => x.Id > 0).ToList();
            var subCategories = _subCategoriesRepository.GetWhere(x => x.Id > 0).ToList();

            ViewBag.BankAccountId = new SelectList(bankAccounts, "Id", "AccountName");
            ViewBag.CategoryId = new SelectList(categories, "Id", "CategoryName");
            ViewBag.SubCategoryId = new SelectList(subCategories, "Id", "SubCategoryName");

            return View(expense);
        }

        // GET: Expenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = _expenseRepository.GetWhereWithIncludes(e => e.Id == id, x => x.BankAccount, x => x.SubCategory, x => x.Category).FirstOrDefault();
            if (expense == null)
            {
                return HttpNotFound();
            }

            var bankAccounts = _bankAccountRepository.GetWhere(x => x.Id > 0).ToList();
            var categories = _categoriesRepository.GetWhere(x => x.Id > 0).ToList();
            var subCategories = _subCategoriesRepository.GetWhere(x => x.Id > 0).ToList();

            ViewBag.BankAccountId = new SelectList(bankAccounts, "Id", "AccountName");
            ViewBag.CategoryId = new SelectList(categories, "Id", "CategoryName");
            ViewBag.SubCategoryId = new SelectList(subCategories, "Id", "SubCategoryName");

            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _expenseRepository.Update(expense);
                _bankAccountLogic.CalculateAccountBalance(expense.BankAccountId);
                return RedirectToAction("Index");
            }

            var bankAccounts = _bankAccountRepository.GetWhere(x => x.Id > 0).ToList();
            var categories = _categoriesRepository.GetWhere(x => x.Id > 0).ToList();
            var subCategories = _subCategoriesRepository.GetWhere(x => x.Id > 0).ToList();

            ViewBag.BankAccountId = new SelectList(bankAccounts, "Id", "AccountName");
            ViewBag.CategoryId = new SelectList(categories, "Id", "CategoryName");
            ViewBag.SubCategoryId = new SelectList(subCategories, "Id", "SubCategoryName");
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = _expenseRepository.GetWhereWithIncludes(e => e.Id == id, x => x.BankAccount, x => x.SubCategory, x => x.Category).FirstOrDefault();
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expense expense = _expenseRepository.GetWhereWithIncludes(e => e.Id == id, x => x.BankAccount, x => x.SubCategory, x => x.Category).FirstOrDefault();
            _expenseRepository.Delete(expense);
            _bankAccountLogic.CalculateAccountBalance(expense.BankAccountId);


            return RedirectToAction("Index");
        }


    }
}
