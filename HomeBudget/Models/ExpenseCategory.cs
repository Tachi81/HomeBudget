using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeBudget.Models
{
    public class ExpenseCategory : Category
    {
        public new string CategoryName { get; set; }
        public new virtual ICollection<ExpenseSubCategory> Subcategories { get; set; }
    }
}