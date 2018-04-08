using System;
using HomeBudget.DAL.Interfaces;

namespace HomeBudget.Models
{
    public class Expense : IMoveMoney
    {
        
        public int Id { get; set; }
        public double Cost { get; set; }
        public int BankAccountId { get; set; }
        public int ExpenseCategoryId { get; set; }
        public int ExpenseSubcategoryId { get; set; }

        public DateTime DateTime { get; set; }
        public string Note { get; set; }

        public virtual BankAccount BankAccount { get; set; }
        public virtual ExpenseCategory ExpenseCategory{ get; set; }
        public virtual ExpenseSubCategory ExpenseSubCategory { get; set; }

    }
}