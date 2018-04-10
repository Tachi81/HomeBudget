using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeBudget.DAL.Interfaces;

namespace HomeBudget.Models
{
    public class Transfer : FinancialOperation
    {
        public new int? BankAccountId { get; set; }
        public new int? CategoryId { get; set; }
        public new int? SubCategoryId { get; set; }
    }
}