using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeBudget.Models
{
    public class ExpenseCategory 
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<ExpenseSubCategory> Subcategories { get; set; }
    }
}