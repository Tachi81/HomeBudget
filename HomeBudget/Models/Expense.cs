using System;
using HomeBudget.DAL.Interfaces;

namespace HomeBudget.Models
{
    public class Expense : FinancialOperation
    {
        public new virtual ExpenseCategory Category{ get; set; }
        public new virtual ExpenseSubCategory SubCategory { get; set; }

        public new int? SourceBankAccountId { get; set; }
        public new int? TargetBankAccountId { get; set; }

    }
}