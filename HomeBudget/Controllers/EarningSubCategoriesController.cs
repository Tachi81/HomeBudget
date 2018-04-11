using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeBudget.DAL.Interfaces;
using HomeBudget.Models;
using HomeBudget.ViewModels;

namespace HomeBudget.Controllers
{
    public class EarningSubCategoriesController : Controller
    {
        private readonly IEarningCategoriesRepository _earningCategoriesRepository;
        private readonly IEarningSubCategoriesRepository _earningSubCategoriesRepository;

        public EarningSubCategoriesController(IEarningCategoriesRepository earningCategoriesRepository, IEarningSubCategoriesRepository earningSubCategoriesRepository)
        {
            _earningCategoriesRepository = earningCategoriesRepository;
            _earningSubCategoriesRepository = earningSubCategoriesRepository;
        }

        // GET: EarningSubCategories
        public ActionResult Index()
        {
            var earningSubCategoryVm = new EarningSubcategoryViewModel();
            earningSubCategoryVm.ListOfEarningSubCategories = _earningSubCategoriesRepository
                .GetWhereWithIncludes(x => x.Id > 0, x => x.Category).ToList();
            return View(earningSubCategoryVm);
        }

        // GET: EarningSubCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var earningSubCategoryVm = new EarningSubcategoryViewModel();
            earningSubCategoryVm.SubCategory =
                _earningSubCategoriesRepository.GetWhereWithIncludes(x => x.Id == id,subc=>subc.Category).FirstOrDefault();
            if (earningSubCategoryVm.SubCategory == null)
            {
                return HttpNotFound();
            }
            return View(earningSubCategoryVm);
        }

        // GET: EarningSubCategories/Create
        public ActionResult Create()
        {
            var earningSubCategoryVm = CreateEarningSubcategoryWithSelectList();
            return View(earningSubCategoryVm);
        }

        private EarningSubcategoryViewModel CreateEarningSubcategoryWithSelectList()
        {
            var earningSubCategoryVm = new EarningSubcategoryViewModel();
            var earningCategories = _earningCategoriesRepository.GetWhere(x => x.Id > 0).ToList();
            earningSubCategoryVm.SelectListOfEarningCategories = new SelectList(earningCategories, "Id", "CategoryName");
            return earningSubCategoryVm;
        }

        // POST: EarningSubCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EarningSubcategoryViewModel earningSubCategoryVm)
        {
            if (ModelState.IsValid)
            {
                _earningSubCategoriesRepository.Create(earningSubCategoryVm.SubCategory);
                return RedirectToAction("Index");
            }

            earningSubCategoryVm = CreateEarningSubcategoryWithSelectList();
            return View(earningSubCategoryVm);
        }

        // GET: EarningSubCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var earningSubCategoryVm = CreateEarningSubcategoryWithSelectList();
            earningSubCategoryVm.SubCategory =
                _earningSubCategoriesRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            if (earningSubCategoryVm.SubCategory == null)
            {
                return HttpNotFound();
            }
            return View(earningSubCategoryVm);

        }

        // POST: EarningSubCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EarningSubcategoryViewModel earningSubCategoryVm)
        {
            if (ModelState.IsValid)
            {
                _earningSubCategoriesRepository.Update(earningSubCategoryVm.SubCategory);
                return RedirectToAction("Index");
            }
            earningSubCategoryVm = CreateEarningSubcategoryWithSelectList();
            return View(earningSubCategoryVm);
        }

        // GET: EarningSubCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var earningSubCategoryVm = new EarningSubcategoryViewModel();
            earningSubCategoryVm.SubCategory =
                _earningSubCategoriesRepository.GetWhere(subCategory => subCategory.Id == id).FirstOrDefault();
            if (earningSubCategoryVm.SubCategory == null)
            {
                return HttpNotFound();
            }
            return View(earningSubCategoryVm);
        }

        // POST: EarningSubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var earningSubCategoryVm = new EarningSubcategoryViewModel();
            earningSubCategoryVm.SubCategory =
                _earningSubCategoriesRepository.GetWhere(earningSubCategory => earningSubCategory.Id == id).FirstOrDefault();
            _earningSubCategoriesRepository.Delete(earningSubCategoryVm.SubCategory);
            return RedirectToAction("Index");
        }

    }
}
