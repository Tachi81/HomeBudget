using HomeBudget.Models;

namespace HomeBudget.DAL.Interfaces
{
    public interface ISubCategoriesRepository : IAbstractRepository<SubCategory>, IGetListWithIncludes<SubCategory>
    {
    }
}