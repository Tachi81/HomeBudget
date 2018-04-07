using System.Linq;
using System.Net;
using System.Web.Mvc;
using HomeBudget.DAL.Interfaces;
using HomeBudget.Models;

namespace HomeBudget.Controllers
{
    [Authorize]
    public class BankAccountsController : Controller
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public BankAccountsController(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        // GET: BankAccounts
        public ActionResult Index()
        {
            return View("Index", _bankAccountRepository.GetWhere(x => x.Id > 0));
        }

        // GET: BankAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var bankAccount = _bankAccountRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
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
        public ActionResult Create(BankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
               _bankAccountRepository.Create(bankAccount);
                return RedirectToAction("Index");
            }

            return View(bankAccount);
        }

        // GET: BankAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bankAccount = _bankAccountRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // POST: BankAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
               _bankAccountRepository.Update(bankAccount);
                return RedirectToAction("Index");
            }
            return View(bankAccount);
        }

        // GET: BankAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bankAccount = _bankAccountRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // POST: BankAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var bankAccount = _bankAccountRepository.GetWhere(x => x.Id == id).FirstOrDefault();
           _bankAccountRepository.Delete(bankAccount);
            return RedirectToAction("Index");
        }
       
    }
}
