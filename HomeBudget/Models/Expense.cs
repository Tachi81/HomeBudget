using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeBudget.DAL.Interfaces;

namespace HomeBudget.Models
{
    public class Expense : IMoveMoney
    {
        
        public int Id { get; set; }
        public double Cost { get; set; }
        public int BankAccountId { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }

        public DateTime DateTime { get; set; }
        public string Note { get; set; }

        public virtual BankAccount BankAccount { get; set; }
        public virtual Category CategoryName { get; set; }
        public virtual SubCategory SubCategory { get; set; }

    }
}