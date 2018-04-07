using HomeBudget.Models;

namespace HomeBudget.DAL.Interfaces
{
    public interface IEarningsRepository : IAbstractRepository<Earning>, IGetListWithIncludes<Earning>
    {
    }
}