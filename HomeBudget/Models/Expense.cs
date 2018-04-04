using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeBudget.Models
{
    public class Expense
    {
        public Expense()
        {
            
        }
        public int Id { get; set; }
        public Account Account { get; set; }
        public Category CategoryName { get; set; }
        public double Cost { get; set; }
        public DateTime DateTime { get; set; }
        public string ExpenseNote { get; set; }

    }
}