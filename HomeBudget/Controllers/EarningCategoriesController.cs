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
    public class EarningCategoriesController : Controller
    {

        private readonly IEarningCategoriesRepository _earningCategoriesRepository;

        public EarningCategoriesController(IEarningCategoriesRepository earningCategoriesRepository)
        {
            _earningCategoriesRepository = earningCategoriesRepository;
        }

        // GET: EarningCategories
        public ActionResult Index()
        {
            return View(_earningCategoriesRepository.GetWhere(cat => cat.Id > 0).ToList());
        }

        // GET: EarningCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EarningCategory earningCategory = _earningCategoriesRepository.GetWhere(c => c.Id == id).FirstOrDefault();
            if (earningCategory == null)
            {
                return HttpNotFound();
            }
            return View(earningCategory);
        }

        // GET: EarningCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EarningCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EarningCategory earningCategory)
        {
            if (ModelState.IsValid)
            {
                _earningCategoriesRepository.Create(earningCategory);
                
                return RedirectToAction("Index");
            }

            return View(earningCategory);
        }

        // GET: EarningCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EarningCategory earningCategory = _earningCategoriesRepository.GetWhere(c => c.Id == id).FirstOrDefault();
            if (earningCategory == null)
            {
                return HttpNotFound();
            }
            return View(earningCategory);
        }

        // POST: EarningCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( EarningCategory earningCategory)
        {
            if (ModelState.IsValid)
            {
               _earningCategoriesRepository.Update(earningCategory);
                return RedirectToAction("Index");
            }
            return View(earningCategory);
        }

        // GET: EarningCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EarningCategory earningCategory = _earningCategoriesRepository.GetWhere(c => c.Id == id).FirstOrDefault();
            if (earningCategory == null)
            {
                return HttpNotFound();
            }
            return View(earningCategory);
        }

        // POST: EarningCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EarningCategory earningCategory = _earningCategoriesRepository.GetWhere(c => c.Id == id).FirstOrDefault();
            _earningCategoriesRepository.Delete(earningCategory);
            return RedirectToAction("Index");
        }
        
    }
}
