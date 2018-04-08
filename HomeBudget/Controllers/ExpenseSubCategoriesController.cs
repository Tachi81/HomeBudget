using System.Linq;
using System.Net;
using System.Web.Mvc;
using HomeBudget.DAL.Interfaces;
using HomeBudget.Models;

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
            var subCategories = _expensesubCategoriesRepository.GetWhereWithIncludes(x => x.Id > 0, x => x.ExpenseCategory).ToList();
            return View(subCategories);
        }

        // GET: SubCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseSubCategory subCategory = _expensesubCategoriesRepository.GetWhereWithIncludes(subCat => subCat.Id == id, x => x.ExpenseCategory).FirstOrDefault();
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // GET: SubCategories/Create
        public ActionResult Create()
        {
            var categories = _expenseCategoriesRepository.GetWhere(x => x.Id > 0).ToList();
            ViewBag.ExpenseCategoryId = new SelectList(categories, "Id", "CategoryName");
            return View();
        }

        // POST: SubCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpenseSubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                _expensesubCategoriesRepository.Create(subCategory);
                return RedirectToAction("Index");
            }

            var categories = _expenseCategoriesRepository.GetWhere(x => x.Id > 0).ToList();
            ViewBag.ExpenseCategoryId = new SelectList(categories, "Id", "CategoryName", subCategory.ExpenseCategoryId);
            return View(subCategory);
        }

        // GET: SubCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseSubCategory subCategory = _expensesubCategoriesRepository.GetWhereWithIncludes(subCat => subCat.Id == id, x => x.ExpenseCategory).FirstOrDefault();
            if (subCategory == null)
            {
                return HttpNotFound();
            }

            var categories = _expenseCategoriesRepository.GetWhere(x => x.Id > 0).ToList();
            ViewBag.ExpenseCategoryId = new SelectList(categories, "Id", "CategoryName", subCategory.ExpenseCategoryId);
            return View(subCategory);
        }

        // POST: SubCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExpenseSubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                _expensesubCategoriesRepository.Update(subCategory);
                return RedirectToAction("Index");
            }

            var categories = _expenseCategoriesRepository.GetWhere(x => x.Id > 0).ToList();
            ViewBag.ExpenseCategoryId = new SelectList(categories, "Id", "CategoryName", subCategory.ExpenseCategoryId);
            return View(subCategory);
        }

        // GET: SubCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseSubCategory subCategory = _expensesubCategoriesRepository.GetWhereWithIncludes(subCat => subCat.Id == id, x => x.ExpenseCategory).FirstOrDefault();
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // POST: SubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpenseSubCategory subCategory = _expensesubCategoriesRepository.GetWhereWithIncludes(subCat => subCat.Id == id, x => x.ExpenseCategory).FirstOrDefault();
            _expensesubCategoriesRepository.Delete(subCategory);
            return RedirectToAction("Index");
        }


    }
}
