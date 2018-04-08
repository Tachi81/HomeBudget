using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeBudget.Models;

namespace HomeBudget.ViewModels
{
    public class BankAccountViewModel
    {
        public BankAccount BankAccount { get; set; }
        public List<BankAccount> BankAccountsList { get; set; }

    }
}