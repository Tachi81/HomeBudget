using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeBudget.DAL.Interfaces;
using HomeBudget.Models;

namespace HomeBudget.DAL.Repositories
{
    public class FinancialOperationsRepository : AbstractRepository<FinancialOperation>, IFinancialOperationsRepository
    {
    }
}