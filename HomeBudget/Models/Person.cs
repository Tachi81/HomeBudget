using System.Collections.Generic;

namespace HomeBudget.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string PersonName { get; set; }
        public int AccountId { get; set; }
        public virtual List<BankAccount> Accounts { get; set;}
    }
}