using System.Linq;
using System.Net;
using System.Web.Mvc;
using HomeBudget.Business_Logic;
using HomeBudget.DAL.Interfaces;
using HomeBudget.Models;
using HomeBudget.ViewModels;

namespace HomeBudget.Controllers
{
    [Authorize]
    public class BankAccountsController : Controller
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IBankAccountLogic _bankAccountLogic;

        public BankAccountsController(IBankAccountRepository bankAccountRepository, IBankAccountLogic bankAccountLogic)
        {
            _bankAccountRepository = bankAccountRepository;
            _bankAccountLogic = bankAccountLogic;
        }

        // GET: BankAccounts
        public ActionResult Index()
        {
            BankAccountViewModel bankAccountVm = new BankAccountViewModel
                { BankAccountsList = _bankAccountRepository.GetWhere(x => x.Id > 0)};
            return View("Index", bankAccountVm);
        }

        // GET: BankAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var bankAccountVm = new BankAccountViewModel
            {
                BankAccount = _bankAccountRepository.GetWhere(x => x.Id == id).FirstOrDefault()
            };
            return View(bankAccountVm);
        }

        // GET: BankAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BankAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BankAccountViewModel bankAccountVM)
        {
            if (ModelState.IsValid)
            {
                _bankAccountRepository.Create(bankAccountVM.BankAccount);
                _bankAccountLogic.CalculateBalanceOfAllAccounts();
                return RedirectToAction("Index");
            }

            return View(bankAccountVM);
        }

        // GET: BankAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var bankAccountVm = new BankAccountViewModel
            {
                BankAccount = _bankAccountRepository.GetWhere(x => x.Id == id).FirstOrDefault()
            };
            return View(bankAccountVm);
        }

        // POST: BankAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BankAccountViewModel bankAccountVm)
        {
            if (ModelState.IsValid)
            {
                _bankAccountRepository.Update(bankAccountVm.BankAccount);
                _bankAccountLogic.CalculateBalanceOfAllAccounts();
                return RedirectToAction("Index");
            }
            return View(bankAccountVm);
        }

        // GET: BankAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bankAccountVm = new BankAccountViewModel
            {
                BankAccount = _bankAccountRepository.GetWhere(x => x.Id == id).FirstOrDefault()
            };
            return View(bankAccountVm);
        }

        // POST: BankAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var bankAccountVm = new BankAccountViewModel
            {
                BankAccount = _bankAccountRepository.GetWhere(x => x.Id == id).FirstOrDefault()
            };
            _bankAccountRepository.Delete(bankAccountVm.BankAccount);
            return RedirectToAction("Index");
        }

    }
}
