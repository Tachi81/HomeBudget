using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeBudget.Models;

namespace HomeBudget.ViewModels
{
    public class TransferViewModel
    {
        public Transfer Transfer { get; set; }
        public List<Transfer> ListOfTransfers { get; set; }

        public IEnumerable<SelectListItem> SelectListOfBankAccounts { get; set; }
    }
}