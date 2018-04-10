using HomeBudget.Models;

namespace HomeBudget.DAL.Interfaces
{
    public interface IBankAccountRepository : IAbstractRepository<BankAccount>, IGetListWithIncludes<BankAccount>
    {
    }
}