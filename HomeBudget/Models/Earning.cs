using System;
using System.ComponentModel.DataAnnotations.Schema;
using HomeBudget.DAL.Interfaces;

namespace HomeBudget.Models
{
    public class Earning : IMoveMoney
    {
        public int Id { get; set; }
        public double Income { get; set; }
        public int BankAccountId { get; set; }
        public int EarningCategoryId { get; set; }
        public int EarningSubCategoryId { get; set; }

        public DateTime DateTime { get; set; }
        public string Note { get; set; }

        public virtual BankAccount BankAccount { get; set; }
        public virtual EarningCategory EarningCategory { get; set; }
        public virtual EarningSubCategory EarningSubCategory { get; set; }
    }
}