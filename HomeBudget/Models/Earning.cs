using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeBudget.Models
{
    public class Earning : MoveMoney
    {
        public int Id { get; set; }
        public double Income { get; set; }
        public int BankAccountId { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }

        public virtual BankAccount BankAccount { get; set; }
        public virtual Category CategoryName { get; set; }
        public virtual SubCategory SubCategory { get; set; }


    }
}