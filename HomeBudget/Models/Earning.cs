using System;
using System.ComponentModel.DataAnnotations.Schema;
using HomeBudget.DAL.Interfaces;

namespace HomeBudget.Models
{
    public class Earning : FinancialOperation
    {
        
        public new int? SourceBankAccountId { get; set; }
        public new int? TargetBankAccountId { get; set; }

    }
}