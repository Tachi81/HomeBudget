using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeBudget.Business_Logic;
using HomeBudget.DAL.Interfaces;
using HomeBudget.DAL.Repositories;
using HomeBudget.Models;

namespace HomeBudget.Controllers
{
    public class EarningsController : Controller
    {
        private readonly IExpensesRepository _expenseRepository;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly ISubCategoriesRepository _subCategoriesRepository;
        private readonly IBankAccountLogic _bankAccountLogic;
        private readonly IEarningsRepository _earningsRepository;




        public EarningsController(IExpensesRepository expenseRepository, IBankAccountRepository bankAccountRepository,
            ICategoriesRepository categoriesRepository, IBankAccountLogic bankAccountLogic, IEarningsRepository earningsRepository,
        ISubCategoriesRepository subCategoriesRepository)
        {
            _expenseRepository = expenseRepository;
            _bankAccountRepository = bankAccountRepository;
            _categoriesRepository = categoriesRepository;
            _subCategoriesRepository = subCategoriesRepository;
            _bankAccountLogic = bankAccountLogic;
            _earningsRepository = earningsRepository;
        }
        
        // GET: Earnings
        public ActionResult Index()
        {
            var earnings = _earningsRepository.GetWhereWithIncludes(x => x.Id > 0, x => x.BankAccount, x => x.SubCategory, x => x.Category).ToList();
            return View(earnings);
        }

        // GET: Earnings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Earning earning = _earningsRepository.GetWhereWithIncludes(e => e.Id == id, x => x.BankAccount, x => x.SubCategory, x => x.Category).FirstOrDefault();
            if (earning == null)
            {
                return HttpNotFound();
            }
            return View(earning);
        }

        // GET: Earnings/Create
        public ActionResult Create()
        {
            var bankAccounts = _bankAccountRepository.GetWhere(x => x.Id > 0).ToList();
            var categories = _categoriesRepository.GetWhere(x => x.Id > 0).ToList();
            var subCategories = _subCategoriesRepository.GetWhere(x => x.Id > 0).ToList();

            ViewBag.BankAccountId = new SelectList(bankAccounts, "Id", "AccountName");
            ViewBag.CategoryId = new SelectList(categories, "Id", "CategoryName");
            ViewBag.SubcategoryId = new SelectList(subCategories, "Id", "SubCategoryName");
            return View();
        }

        // POST: Earnings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Earning earning)
        {
            if (ModelState.IsValid)
            {
                _earningsRepository.Create(earning);

                _bankAccountLogic.CalculateAccountBalance(earning.BankAccountId);
                return RedirectToAction("Index");
            }

            var bankAccounts = _bankAccountRepository.GetWhere(x => x.Id > 0).ToList();
            var categories = _categoriesRepository.GetWhere(x => x.Id > 0).ToList();
            var subCategories = _subCategoriesRepository.GetWhere(x => x.Id > 0).ToList();

            ViewBag.BankAccountId = new SelectList(bankAccounts, "Id", "AccountName");
            ViewBag.CategoryId = new SelectList(categories, "Id", "CategoryName");
            ViewBag.SubcategoryId = new SelectList(subCategories, "Id", "SubCategoryName");
            return View(earning);
        }

        // GET: Earnings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Earning earning = _earningsRepository.GetWhereWithIncludes(e => e.Id == id, x => x.BankAccount, x => x.SubCategory, x => x.Category).FirstOrDefault();
            if (earning == null)
            {
                return HttpNotFound();
            }

            var bankAccounts = _bankAccountRepository.GetWhere(x => x.Id > 0).ToList();
            var categories = _categoriesRepository.GetWhere(x => x.Id > 0).ToList();
            var subCategories = _subCategoriesRepository.GetWhere(x => x.Id > 0).ToList();

            ViewBag.BankAccountId = new SelectList(bankAccounts, "Id", "AccountName");
            ViewBag.CategoryId = new SelectList(categories, "Id", "CategoryName");
            ViewBag.SubcategoryId = new SelectList(subCategories, "Id", "SubCategoryName");
            return View(earning);
        }

        // POST: Earnings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Earning earning)
        {
            if (ModelState.IsValid)
            {
                _earningsRepository.Update(earning);
                _bankAccountLogic.CalculateAccountBalance(earning.BankAccountId);

                return RedirectToAction("Index");
            }
            var bankAccounts = _bankAccountRepository.GetWhere(x => x.Id > 0).ToList();
            var categories = _categoriesRepository.GetWhere(x => x.Id > 0).ToList();
            var subCategories = _subCategoriesRepository.GetWhere(x => x.Id > 0).ToList();

            ViewBag.BankAccountId = new SelectList(bankAccounts, "Id", "AccountName");
            ViewBag.CategoryId = new SelectList(categories, "Id", "CategoryName");
            ViewBag.SubcategoryId = new SelectList(subCategories, "Id", "SubCategoryName");
            return View(earning);
        }

        // GET: Earnings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Earning earning = _earningsRepository.GetWhereWithIncludes(e => e.Id == id, x => x.BankAccount, x => x.SubCategory, x => x.Category).FirstOrDefault();
            if (earning == null)
            {
                return HttpNotFound();
            }
            return View(earning);
        }

        // POST: Earnings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Earning earning = _earningsRepository.GetWhereWithIncludes(e => e.Id == id, x => x.BankAccount, x => x.SubCategory, x => x.Category).FirstOrDefault();
            _earningsRepository.Delete(earning);
            _bankAccountLogic.CalculateAccountBalance(earning.BankAccountId);

            return RedirectToAction("Index");
        }

       
    }
}
