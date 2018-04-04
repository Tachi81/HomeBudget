using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeBudget.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public double Balance { get; set; }
        public string AccountName { get; set; }
        public int PersonId { get; set; }
        public virtual List<Person> AccountOwners { get; set; }
        public virtual List<Expense> Expenses { get; set; }
        public virtual List<Earning> Earnings { get; set; }

    }
}