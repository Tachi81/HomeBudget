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
using HomeBudget.ViewModels;

namespace HomeBudget.Controllers
{
    public class TransfersController : Controller
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IBankAccountLogic _bankAccountLogic;

        public TransfersController(ITransferRepository transferRepository, IBankAccountRepository bankAccountRepository, IBankAccountLogic bankAccountLogic)
        {
            _transferRepository = transferRepository;
            _bankAccountRepository = bankAccountRepository;
            _bankAccountLogic = bankAccountLogic;
        }

        // GET: Transfers
        public ActionResult Index()
        {
            var transferVm = new TransferViewModel();
            transferVm.ListOfTransfers = _transferRepository.GetWhereWithIncludes(t => t.Id > 0, t => t.SourceBankAccount, t => t.TargetBankAccount).ToList();
            return View(transferVm);
        }

        // GET: Transfers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var transferVm = new TransferViewModel();
            transferVm.Transfer = _transferRepository.GetWhereWithIncludes(transfer => transfer.Id == id, t => t.SourceBankAccount, t => t.TargetBankAccount).FirstOrDefault();
            if (transferVm.Transfer == null)
            {
                return HttpNotFound();
            }
            return View(transferVm);
        }

        // GET: Transfers/Create
        public ActionResult Create()
        {
            var transferVm = CreateTransferViewModelWithAccountSelectList();
            return View(transferVm);
        }

        private TransferViewModel CreateTransferViewModelWithAccountSelectList()
        {
            var transferVm = new TransferViewModel();
            var bankAccountsList = _bankAccountRepository.GetWhere(b => b.Id > 0).ToList();
            transferVm.SelectListOfBankAccounts = new SelectList(bankAccountsList, "Id", "AccountName");
            return transferVm;
        }

        // POST: Transfers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransferViewModel transferVm)
        {
            if (ModelState.IsValid)
            {
                _transferRepository.Create(transferVm.Transfer);
                
                _bankAccountLogic.CalculateBalanceOfAllAccounts();
                return RedirectToAction("Index");
            }

            return View(transferVm);
        }

        // GET: Transfers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var transferVm = CreateTransferViewModelWithAccountSelectList();
            transferVm.Transfer = _transferRepository.GetWhereWithIncludes(transfer => transfer.Id == id, t => t.SourceBankAccount, t => t.TargetBankAccount).FirstOrDefault();
            if (transferVm.Transfer == null)
            {
                return HttpNotFound();
            }
            return View(transferVm);
        }

        // POST: Transfers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TransferViewModel transferVm)
        {
            if (ModelState.IsValid)
            {
                _transferRepository.Update(transferVm.Transfer);
                _bankAccountLogic.CalculateBalanceOfAllAccounts();
                return RedirectToAction("Index");
            }
            return View(transferVm);
        }

        // GET: Transfers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var transferVm = new TransferViewModel();
            transferVm.Transfer = _transferRepository.GetWhere(transfer => transfer.Id == id).FirstOrDefault();
            if (transferVm.Transfer == null)
            {
                return HttpNotFound();
            }
            return View(transferVm);
        }

        // POST: Transfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var transferVm = new TransferViewModel();
            transferVm.Transfer = _transferRepository.GetWhere(transfer => transfer.Id == id).FirstOrDefault();
            if (transferVm.Transfer == null)
            {
                return HttpNotFound();
            }
            _transferRepository.Delete(transferVm.Transfer);
            _bankAccountLogic.CalculateBalanceOfAllAccounts();
            return RedirectToAction("Index");
        }


    }
}
