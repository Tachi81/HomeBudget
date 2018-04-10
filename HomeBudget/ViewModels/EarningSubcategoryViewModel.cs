using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeBudget.Models;

namespace HomeBudget.ViewModels
{
    public class EarningSubcategoryViewModel
    {
        public EarningSubCategory SubCategory { get; set; }
        public List<EarningSubCategory> ListOfEarningSubCategories { get; set; }

        public IEnumerable<SelectListItem> SelectListOfEarningCategories { get; set; }
    }
}