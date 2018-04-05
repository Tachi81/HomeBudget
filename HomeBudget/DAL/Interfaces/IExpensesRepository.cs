using HomeBudget.DAL.Interfaces;
using HomeBudget.Models;

namespace HomeBudget.DAL.Repositories
{
    public interface IExpensesRepository : IAbstractRepository<Expense>, IGetListWithIncludes<Expense>
    {
    }
}