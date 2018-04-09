using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeBudget.DAL.Interfaces;

namespace HomeBudget.Models
{
    public class Transfer : IMoveMoney
    {
        public int Id { get; set; }
        public double AmountTransferred { get; set; }
        public int SourceBankAccountsId { get; set; }
        public int TargetBankAccountsId { get; set; }

        public DateTime DateTime { get; set; }
        public string Note { get; set; }

        public  virtual ICollection<BankAccount>  SourceBankAccounts { get; set; }
        public virtual ICollection<BankAccount> TargetBankAccounts { get; set; }

    }
}