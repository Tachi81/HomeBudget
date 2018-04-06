using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeBudget.DAL.Repositories;
using HomeBudget.Models;

namespace HomeBudget.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesRepository _expenseRepository;

        public ExpensesController(IExpensesRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        // GET: Expenses
        public ActionResult Index()
        {
            var expenses = _expenseRepository.GetWhere(e=>e.Id>0).ToList();
            return View(expenses);
        }

        // GET: Expenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Expense expense = _expenseRepository.GetWhere(e => e.Id == id).FirstOrDefault();
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // GET: Expenses/Create
        public ActionResult Create()
        {
            var bankAccountRepository = new BankAccountRepository();
            var bankAccounts = bankAccountRepository.GetWhere(x => x.Id > 0).ToList();

            var categoriesRepository = new CategoriesRepository();
            var categories = categoriesRepository.GetWhere(x => x.Id > 0).ToList();

            var subCategoriesRepository = new SubCategoriesRepository();
            var subCategories = subCategoriesRepository.GetWhere(x => x.Id > 0).ToList();

            ViewBag.BankAccountId = new SelectList(bankAccounts, "Id", "AccountName");
         ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            ViewBag.CategoryId = new SelectList(subCategories, "Id", "Name");
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Expense expense)
        {
            if (ModelState.IsValid)
            {
                
               _expenseRepository.Create(expense);
                return RedirectToAction("Index");
            }

            var bankAccountRepository = new BankAccountRepository();
            var bankAccounts = bankAccountRepository.GetWhere(x => x.Id > 0).ToList();

            var categoriesRepository = new CategoriesRepository();
            var categories = categoriesRepository.GetWhere(x => x.Id > 0).ToList();

            var subCategoriesRepository = new SubCategoriesRepository();
            var subCategories = subCategoriesRepository.GetWhere(x => x.Id > 0).ToList();

            ViewBag.BankAccountId = new SelectList(bankAccounts, "Id", "AccountName");
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            ViewBag.CategoryId = new SelectList(subCategories, "Id", "Name");

            return View(expense);
        }

        // GET: Expenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = _expenseRepository.GetWhere(e => e.Id == id).FirstOrDefault();
            if (expense == null)
            {
                return HttpNotFound();
            }
            var bankAccountRepository = new BankAccountRepository();
            var bankAccounts = bankAccountRepository.GetWhere(x => x.Id > 0).ToList();

            var categoriesRepository = new CategoriesRepository();
            var categories = categoriesRepository.GetWhere(x => x.Id > 0).ToList();

            var subCategoriesRepository = new SubCategoriesRepository();
            var subCategories = subCategoriesRepository.GetWhere(x => x.Id > 0).ToList();

            ViewBag.BankAccountId = new SelectList(bankAccounts, "Id", "AccountName");
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            ViewBag.CategoryId = new SelectList(subCategories, "Id", "Name");

            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Expense expense)
        {
            if (ModelState.IsValid)
            {
                _expenseRepository.Update(expense);
                return RedirectToAction("Index");
            }

            var bankAccountRepository = new BankAccountRepository();
            var bankAccounts = bankAccountRepository.GetWhere(x => x.Id > 0).ToList();

            var categoriesRepository = new CategoriesRepository();
            var categories = categoriesRepository.GetWhere(x => x.Id > 0).ToList();

            var subCategoriesRepository = new SubCategoriesRepository();
            var subCategories = subCategoriesRepository.GetWhere(x => x.Id > 0).ToList();

            ViewBag.BankAccountId = new SelectList(bankAccounts, "Id", "AccountName");
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            ViewBag.CategoryId = new SelectList(subCategories, "Id", "Name");
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = _expenseRepository.GetWhere(e => e.Id == id).FirstOrDefault();
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
            Expense expense = _expenseRepository.GetWhere(e => e.Id == id).FirstOrDefault();
            _expenseRepository.Delete(expense);
 
            return RedirectToAction("Index");
        }

       
    }
}
