using HomeBudget.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HomeBudget.ViewModels
{
    public class FinancialOperationsHistoryViewModel
    {
        public FinancialOperation FinancialOperation { get; set; }
        public List<FinancialOperation> ListofFinancialOperation { get; set; }


        public IEnumerable<SelectListItem> SelectListOfBankAccounts { get; set; }

    }
}