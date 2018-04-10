using HomeBudget.DAL.Interfaces;
using HomeBudget.Models;

namespace HomeBudget.DAL.Repositories
{
    internal interface ITransferRepository : IAbstractRepository<Transfer>, IGetListWithIncludes<Transfer>
    {
    }
}