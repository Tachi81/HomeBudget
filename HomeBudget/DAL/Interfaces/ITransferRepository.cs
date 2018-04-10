using HomeBudget.DAL.Interfaces;
using HomeBudget.Models;

namespace HomeBudget.DAL.Interfaces
{
    public interface ITransferRepository : IAbstractRepository<Transfer>, IGetListWithIncludes<Transfer>
    {
    }
}