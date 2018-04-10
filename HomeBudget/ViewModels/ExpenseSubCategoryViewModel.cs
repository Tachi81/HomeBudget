using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeBudget.Models;

namespace HomeBudget.ViewModels
{
    public class ExpenseSubCategoryViewModel
    {
        public ExpenseSubCategory SubCategory { get; set; }
        public List<ExpenseSubCategory> ListOfExpenseSubCategories { get; set; }

        public IEnumerable<SelectListItem> SelectListOfExpenseCategories { get; set; }
    }
}