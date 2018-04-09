using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeBudget.Models;

namespace HomeBudget.ViewModels
{
    public class ExpenseViewModel
    {
        public Expense Expense { get; set; }
        public List<Expense> ListOfExpenses { get; set; }
        
        public IEnumerable<SelectListItem> SelectListOfBankAccounts { get; set; }
        public IEnumerable<SelectListItem> SelectListOfExpenseCategories { get; set; }
        public IEnumerable<SelectListItem> SelectListOfExpenseSubCategories { get; set; }

    }
}