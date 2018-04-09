using System.Collections.Generic;

namespace HomeBudget.Models
{
    public class BankAccount 
    {
        public int Id { get; set; }
        public double InitialBalance { get; set; }
        public double Balance { get; set; }
        public string AccountName { get; set; }
       
        
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Earning> Earnings { get; set; }
        public virtual ICollection<Transfer> Transfers { get; set; }

    }
}