﻿using HomeBudget.DAL.Interfaces;
using HomeBudget.Models;

namespace HomeBudget.DAL.Repositories
{
    public class ExpensesRepository : AbstractRepository<Expense>, IExpensesRepository
    {
    }
}