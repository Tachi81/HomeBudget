using System.Collections.Generic;

namespace HomeBudget.Models
{
    public class Person
    {
        public int Person_Id { get; set; }
        public string PersonName { get; set; }
        public virtual List<Account> Accounts { get; set;}
    }
}