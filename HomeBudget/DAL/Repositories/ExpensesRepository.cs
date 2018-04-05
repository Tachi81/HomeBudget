using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeBudget.Models;

namespace HomeBudget.DAL.Repositories
{
    public class ExpensesRepository : AbstractRepository<Expense>, IExpensesRepository
    {
    }
}