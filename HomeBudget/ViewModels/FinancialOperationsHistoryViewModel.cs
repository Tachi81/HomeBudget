using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeBudget.Models;

namespace HomeBudget.ViewModels
{
    public class FinancialOperationsHistoryViewModel
    {
        public FinancialOperation FinancialOperation { get; set; }
        public List<FinancialOperation> ListofFinancialOperation { get; set; }

        public IEnumerable<SelectListItem> SelectListOfBankAccounts { get; set; }

    }
}