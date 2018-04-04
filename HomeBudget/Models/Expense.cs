using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeBudget.Models
{
    public class Expense
    {
        private Account _account = new Account();
        public Expense()
        {
            
        }
        public int Expense_Id { get; set; }
        public Category CategoryName { get; set; }
        public double Cost { get; set; }
        public DateTime DateTime { get; set; }
        public string ExpenseNote { get; set; }

    }
}