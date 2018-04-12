using HomeBudget.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HomeBudget.ViewModels
{
    public class TransferViewModel
    {
        public Transfer Transfer { get; set; }
        public List<Transfer> ListOfTransfers { get; set; }

        public IEnumerable<SelectListItem> SelectListOfBankAccounts { get; set; }
    }
}