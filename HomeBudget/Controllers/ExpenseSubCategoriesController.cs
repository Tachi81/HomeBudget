using System.Linq;
using System.Net;
using System.Web.Mvc;
using HomeBudget.DAL.Interfaces;
using HomeBudget.Models;

namespace HomeBudget.Controllers
{
    public class ExpenseSubCategoriesController : Controller
    {
        private readonly IExpenseCategoriesRepository _categoriesRepository;
        private readonly IExpenseSubCategoriesRepository _subCategoriesRepository;

        public ExpenseSubCategoriesController(IExpenseSubCategoriesRepository subCategoriesRepository, IExpenseCategoriesRepository categoriesRepository)
        {
            _subCategoriesRepository = subCategoriesRepository;
            _categoriesRepository = categoriesRepository;
        }

        // GET: SubCategories
        public ActionResult Index()
        {
            var subCategories = _subCategoriesRepository.GetWhereWithIncludes(x => x.Id > 0, x => x.Category).ToList();
            return View(subCategories);
        }

        // GET: SubCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseSubcategory subCategory = _subCategoriesRepository.GetWhereWithIncludes(subCat => subCat.Id == id, x => x.Category).FirstOrDefault();
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // GET: SubCategories/Create
        public ActionResult Create()
        {
            var categories = _categoriesRepository.GetWhere(x => x.Id > 0).ToList();
            ViewBag.CategoryId = new SelectList(categories, "Id", "CategoryName");
            return View();
        }

        // POST: SubCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpenseSubcategory subCategory)
        {
            if (ModelState.IsValid)
            {
                _subCategoriesRepository.Create(subCategory);
                return RedirectToAction("Index");
            }

            var categories = _categoriesRepository.GetWhere(x => x.Id > 0).ToList();
            ViewBag.CategoryId = new SelectList(categories, "Id", "CategoryName", subCategory.CategoryId);
            return View(subCategory);
        }

        // GET: SubCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseSubcategory subCategory = _subCategoriesRepository.GetWhereWithIncludes(subCat => subCat.Id == id, x => x.Category).FirstOrDefault();
            if (subCategory == null)
            {
                return HttpNotFound();
            }

            var categories = _categoriesRepository.GetWhere(x => x.Id > 0).ToList();
            ViewBag.CategoryId = new SelectList(categories, "Id", "CategoryName", subCategory.CategoryId);
            return View(subCategory);
        }

        // POST: SubCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExpenseSubcategory subCategory)
        {
            if (ModelState.IsValid)
            {
                _subCategoriesRepository.Update(subCategory);
                return RedirectToAction("Index");
            }

            var categories = _categoriesRepository.GetWhere(x => x.Id > 0).ToList();
            ViewBag.CategoryId = new SelectList(categories, "Id", "CategoryName", subCategory.CategoryId);
            return View(subCategory);
        }

        // GET: SubCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseSubcategory subCategory = _subCategoriesRepository.GetWhereWithIncludes(subCat => subCat.Id == id, x => x.Category).FirstOrDefault();
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
            ExpenseSubcategory subCategory = _subCategoriesRepository.GetWhereWithIncludes(subCat => subCat.Id == id, x => x.Category).FirstOrDefault();
            _subCategoriesRepository.Delete(subCategory);
            return RedirectToAction("Index");
        }


    }
}
