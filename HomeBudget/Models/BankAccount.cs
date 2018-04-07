using System.Collections.Generic;

namespace HomeBudget.Models
{
    public class BankAccount 
    {
        public int Id { get; set; }
        public double InitialBalance { get; set; }
        public double Balance { get; set; }
        public string AccountName { get; set; }
       
        
        public virtual List<Expense> Expenses { get; set; }
        public virtual List<Earning> Earnings { get; set; }

    }
}