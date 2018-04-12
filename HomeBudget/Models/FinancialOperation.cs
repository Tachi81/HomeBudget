using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeBudget.DAL.Interfaces;

namespace HomeBudget.Models
{
    public class FinancialOperation
    {
        public int Id { get; set; }
        public double AmountOfMoney { get; set; }
        public int? BankAccountId { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }

        public string DescriptionOfOperation { get; set; }

        public int? SourceBankAccountId { get; set; }
        public int? TargetBankAccountId { get; set; }

        public DateTime DateTime { get; set; }
        public string Note { get; set; }

        public virtual BankAccount SourceBankAccount { get; set; }
        public virtual BankAccount TargetBankAccount { get; set; }

        public virtual BankAccount BankAccount { get; set; }
        public virtual Category Category { get; set; }
        public virtual SubCategory SubCategory { get; set; }
    }
}