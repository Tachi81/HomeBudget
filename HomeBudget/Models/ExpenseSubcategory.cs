using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HomeBudget.Models
{
    public class ExpenseSubCategory 
    {
        public int Id { get; set; }
        public string SubCategoryName { get; set; }
       [ForeignKey("ExpenseCategory")]
        public int ExpenseCategoryId { get; set; }

        public virtual ExpenseCategory ExpenseCategory { get; set; }
    }
}