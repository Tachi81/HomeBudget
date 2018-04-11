using System.Linq;
using System.Net;
using System.Web.Mvc;
using HomeBudget.DAL.Interfaces;
using HomeBudget.Models;
using HomeBudget.ViewModels;

namespace HomeBudget.Controllers
{
    public class ExpenseSubCategoriesController : Controller
    {
        private readonly IExpenseCategoriesRepository _expenseCategoriesRepository;
        private readonly IExpenseSubCategoriesRepository _expensesubCategoriesRepository;

        public ExpenseSubCategoriesController(IExpenseSubCategoriesRepository expensesubCategoriesRepository, IExpenseCategoriesRepository expenseCategoriesRepository)
        {
            _expensesubCategoriesRepository = expensesubCategoriesRepository;
            _expenseCategoriesRepository = expenseCategoriesRepository;
        }

        // GET: SubCategories
        public ActionResult Index()
        {
            var expenseSubcategoryVm = new ExpenseSubCategoryViewModel();
            expenseSubcategoryVm.ListOfExpenseSubCategories = _expensesubCategoriesRepository.GetWhereWithIncludes(x => x.Id > 0, x => x.Category).ToList();
            return View(expenseSubcategoryVm);
        }

        // GET: SubCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var expenseSubcategoryVm = new ExpenseSubCategoryViewModel();
            expenseSubcategoryVm.SubCategory = _expensesubCategoriesRepository.GetWhereWithIncludes(subCat => subCat.Id == id, x => x.Category).FirstOrDefault();
            if (expenseSubcategoryVm.SubCategory == null)
            {
                return HttpNotFound();
            }
            return View(expenseSubcategoryVm);
        }

        // GET: SubCategories/Create
        public ActionResult Create()
        {
            var expenseSubcategoryVm = CreateExpenseSubCategoryViewModelWithSelectLists();
            return View(expenseSubcategoryVm);
        }



        // POST: SubCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpenseSubCategoryViewModel expenseSubcategoryVm)
        {
            if (ModelState.IsValid)
            {
                _expensesubCategoriesRepository.Create(expenseSubcategoryVm.SubCategory);
                return RedirectToAction("Index");
            }

            expenseSubcategoryVm = CreateExpenseSubCategoryViewModelWithSelectLists();
            return View(expenseSubcategoryVm);
        }

        // GET: SubCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var expenseSubcategoryVm = CreateExpenseSubCategoryViewModelWithSelectLists();
            expenseSubcategoryVm.SubCategory = _expensesubCategoriesRepository.GetWhereWithIncludes(subCat => subCat.Id == id, x => x.Category).FirstOrDefault();
            if (expenseSubcategoryVm.SubCategory == null)
            {
                return HttpNotFound();
            }
            return View(expenseSubcategoryVm);
        }

        // POST: SubCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExpenseSubCategoryViewModel expenseSubcategoryVm)
        {
            if (ModelState.IsValid)
            {
                _expensesubCategoriesRepository.Update(expenseSubcategoryVm.SubCategory);
                return RedirectToAction("Index");
            }

            expenseSubcategoryVm = CreateExpenseSubCategoryViewModelWithSelectLists();
            return View(expenseSubcategoryVm);
        }

        // GET: SubCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var expenseSubcategoryVm = new ExpenseSubCategoryViewModel();
            expenseSubcategoryVm.SubCategory = _expensesubCategoriesRepository.GetWhereWithIncludes(subCat => subCat.Id == id, x => x.Category).FirstOrDefault();
            if (expenseSubcategoryVm.SubCategory == null)
            {
                return HttpNotFound();
            }
            return View(expenseSubcategoryVm);
        }

        // POST: SubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var expenseSubcategoryVm = new ExpenseSubCategoryViewModel();
            expenseSubcategoryVm.SubCategory = _expensesubCategoriesRepository.GetWhereWithIncludes(subCat => subCat.Id == id, x => x.Category).FirstOrDefault();

            _expensesubCategoriesRepository.Delete(expenseSubcategoryVm.SubCategory);
            return RedirectToAction("Index");
        }





        private ExpenseSubCategoryViewModel CreateExpenseSubCategoryViewModelWithSelectLists()
        {
            var expenseSubcategoryVm = new ExpenseSubCategoryViewModel();
            var categories = _expenseCategoriesRepository.GetWhere(x => x.Id > 0).ToList();
            expenseSubcategoryVm.SelectListOfExpenseCategories = new SelectList(categories, "Id", "CategoryName");
            return expenseSubcategoryVm;
        }
    }
}
