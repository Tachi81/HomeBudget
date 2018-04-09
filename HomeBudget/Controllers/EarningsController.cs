using System.Linq;
using System.Net;
using System.Web.Mvc;
using HomeBudget.Business_Logic;
using HomeBudget.DAL.Interfaces;
using HomeBudget.DAL.Repositories;
using HomeBudget.Models;
using HomeBudget.ViewModels;

namespace HomeBudget.Controllers
{
    public class EarningsController : Controller
    {

        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IEarningCategoriesRepository _categoriesRepository;
        private readonly IEarningSubCategoriesRepository _subCategoriesRepository;
        private readonly IBankAccountLogic _bankAccountLogic;
        private readonly IEarningsRepository _earningsRepository;

        public EarningsController(IBankAccountRepository bankAccountRepository,
            IEarningCategoriesRepository categoriesRepository, IBankAccountLogic bankAccountLogic, IEarningsRepository earningsRepository,
            IEarningSubCategoriesRepository subCategoriesRepository)
        {
            _bankAccountRepository = bankAccountRepository;
            _categoriesRepository = categoriesRepository;
            _subCategoriesRepository = subCategoriesRepository;
            _bankAccountLogic = bankAccountLogic;
            _earningsRepository = earningsRepository;
        }

        // GET: Earnings
        public ActionResult Index()
        {
            var earningVm = new EarningViewModel();
            earningVm.ListOfEarnings = _earningsRepository.GetWhereWithIncludes(x => x.Id > 0, x => x.BankAccount, x => x.EarningSubCategory, x => x.EarningCategory).ToList();
            return View(earningVm);
        }

        // GET: Earnings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var earningVm = new EarningViewModel();
            earningVm.Earning = _earningsRepository.GetWhereWithIncludes(e => e.Id == id, x => x.BankAccount, x => x.EarningSubCategory, x => x.EarningCategory).FirstOrDefault();
            if (earningVm.Earning == null)
            {
                return HttpNotFound();
            }
            return View(earningVm);
        }

        // GET: Earnings/Create
        public ActionResult Create()
        {
            EarningViewModel earningVm = CreateVmWithLists();
            return View(earningVm);
        }

        // POST: Earnings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EarningViewModel earningVm)
        {
            if (ModelState.IsValid)
            {
                _earningsRepository.Create(earningVm.Earning);

                _bankAccountLogic.CalculateBalanceOfAllAccounts();
                return RedirectToAction("Index");
            }

            earningVm = CreateVmWithLists();

            return View(earningVm);
        }

        // GET: Earnings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var earningVm = CreateVmWithLists();
            earningVm.Earning = _earningsRepository.GetWhereWithIncludes(e => e.Id == id, x => x.BankAccount, x => x.EarningSubCategory, x => x.EarningCategory).FirstOrDefault();
            if (earningVm.Earning == null)
            {
                return HttpNotFound();
            }
            return View(earningVm);
        }

        // POST: Earnings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EarningViewModel earningVm)
        {
            if (ModelState.IsValid)
            {
                _earningsRepository.Update(earningVm.Earning);
                _bankAccountLogic.CalculateBalanceOfAllAccounts();

                return RedirectToAction("Index");
            }
            earningVm = CreateVmWithLists();
            return View(earningVm);
        }

        // GET: Earnings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var earningVm = new EarningViewModel();
            earningVm.Earning = _earningsRepository.GetWhereWithIncludes(e => e.Id == id, x => x.BankAccount, x => x.EarningSubCategory, x => x.EarningCategory).FirstOrDefault();
            if (earningVm.Earning == null)
            {
                return HttpNotFound();
            }
            return View(earningVm);
        }

        // POST: Earnings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var earningVm = new EarningViewModel();
            earningVm.Earning = _earningsRepository.GetWhereWithIncludes(e => e.Id == id, x => x.BankAccount, x => x.EarningSubCategory, x => x.EarningCategory).FirstOrDefault();
            if (earningVm.Earning == null)
            {
                return HttpNotFound();
            }
            _earningsRepository.Delete(earningVm.Earning);
            _bankAccountLogic.CalculateBalanceOfAllAccounts();

            return RedirectToAction("Index");
        }



        private EarningViewModel CreateVmWithLists()
        {
            var earningVm = new EarningViewModel();

            var bankAccounts = _bankAccountRepository.GetWhere(x => x.Id > 0).ToList();
            var categories = _categoriesRepository.GetWhere(x => x.Id > 0).ToList();
            var subCategories = _subCategoriesRepository.GetWhere(x => x.Id > 0).ToList();

            earningVm.SelectListOfBankAccounts = new SelectList(bankAccounts, "Id", "AccountName");
            earningVm.SelectListOfEarningCategories = new SelectList(categories, "Id", "CategoryName");
            earningVm.SelectListOfEarningSubCategories = new SelectList(subCategories, "Id", "SubCategoryName");
            return earningVm;
        }
    }
}
