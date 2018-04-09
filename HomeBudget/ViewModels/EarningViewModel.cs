using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeBudget.Models;

namespace HomeBudget.ViewModels
{
    public class EarningViewModel
    {
        public Earning Earning { get; set; }
        public List<Earning> ListOfEarnings{ get; set; }

        public IEnumerable<SelectListItem> SelectListOfBankAccounts { get; set; }
        public IEnumerable<SelectListItem> SelectListOfExpenseCategories { get; set; }
        public IEnumerable<SelectListItem> SelectListOfExpenseSubCategories { get; set; }
    }
}