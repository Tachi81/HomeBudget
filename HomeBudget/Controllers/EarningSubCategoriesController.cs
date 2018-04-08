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
            var earningSubCategories = _earningSubCategoriesRepository
                .GetWhereWithIncludes(x => x.Id > 0, x => x.EarningCategory).ToList();
            return View(earningSubCategories);
        }

        // GET: EarningSubCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EarningSubCategory earningSubCategory =
                _earningSubCategoriesRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            if (earningSubCategory == null)
            {
                return HttpNotFound();
            }
            return View(earningSubCategory);
        }

        // GET: EarningSubCategories/Create
        public ActionResult Create()
        {
            var earningCategories = _earningCategoriesRepository.GetWhere(x => x.Id > 0).ToList();
            ViewBag.EarningCategoryId = new SelectList(earningCategories, "Id", "CategoryName");
            return View();
        }

        // POST: EarningSubCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EarningSubCategory earningSubCategory)
        {
            if (ModelState.IsValid)
            {
               _earningSubCategoriesRepository.Create(earningSubCategory);
                return RedirectToAction("Index");
            }

            var earningCategories = _earningCategoriesRepository.GetWhere(x => x.Id > 0).ToList();
            ViewBag.EarningCategoryId = new SelectList(earningCategories, "Id", "CategoryName", earningSubCategory.EarningCategoryId);

            return View(earningSubCategory);
        }

        // GET: EarningSubCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EarningSubCategory earningSubCategory =
                _earningSubCategoriesRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            if (earningSubCategory == null)
            {
                return HttpNotFound();
            }

            var earningCategories = _earningCategoriesRepository.GetWhere(x => x.Id > 0).ToList();
            ViewBag.EarningCategoryId = new SelectList(earningCategories, "Id", "CategoryName", earningSubCategory.EarningCategoryId);

            return View(earningSubCategory);
        }

        // POST: EarningSubCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EarningSubCategory earningSubCategory)
        {
            if (ModelState.IsValid)
            {
                _earningSubCategoriesRepository.Update(earningSubCategory);
                return RedirectToAction("Index");
            }
            var earningCategories = _earningCategoriesRepository.GetWhere(x => x.Id > 0).ToList();
            ViewBag.EarningCategoryId = new SelectList(earningCategories, "Id", "CategoryName", earningSubCategory.EarningCategoryId);
            return View(earningSubCategory);
        }

        // GET: EarningSubCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EarningSubCategory earningSubCategory =
                _earningSubCategoriesRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            if (earningSubCategory == null)
            {
                return HttpNotFound();
            }
            return View(earningSubCategory);
        }

        // POST: EarningSubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EarningSubCategory earningSubCategory = _earningSubCategoriesRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            _earningSubCategoriesRepository.Delete(earningSubCategory);
            return RedirectToAction("Index");
        }

    }
}
