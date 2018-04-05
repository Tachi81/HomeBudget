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
            ViewBag.BankAccountId = new SelectList(db.BankAccounts, "Id", "AccountName");
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
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

            ViewBag.BankAccountId = new SelectList(db.BankAccounts, "Id", "AccountName", expense.BankAccountId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", expense.CategoryId);
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
            ViewBag.BankAccountId = new SelectList(db.BankAccounts, "Id", "AccountName", expense.BankAccountId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", expense.CategoryId);
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
            ViewBag.BankAccountId = new SelectList(db.BankAccounts, "Id", "AccountName", expense.BankAccountId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", expense.CategoryId);
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
