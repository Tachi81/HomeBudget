
using HomeBudget.Models;

namespace HomeBudget.DAL.Interfaces
{
    public interface IExpenseSubCategoriesRepository : IAbstractRepository<ExpenseSubcategory>, IGetListWithIncludes<ExpenseSubcategory>
    {
    }
}