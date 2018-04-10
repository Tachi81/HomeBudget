using System;
using HomeBudget.DAL.Interfaces;

namespace HomeBudget.Models
{
    public class Expense : FinancialOperation
    {
        public int ExpenseCategoryId { get; set; }
        public int ExpenseSubcategoryId { get; set; }
       
        public virtual ExpenseCategory ExpenseCategory{ get; set; }
        public virtual ExpenseSubCategory ExpenseSubCategory { get; set; }

    }
}