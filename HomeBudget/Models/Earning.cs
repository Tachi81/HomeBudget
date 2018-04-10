using System;
using System.ComponentModel.DataAnnotations.Schema;
using HomeBudget.DAL.Interfaces;

namespace HomeBudget.Models
{
    public class Earning : FinancialOperation
    {
        public new virtual EarningCategory Category { get; set; }
        public new virtual EarningSubCategory SubCategory { get; set; }

        public new int? SourceBankAccountId { get; set; }
        public new int? TargetBankAccountId { get; set; }

    }
}