using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HomeBudget.DAL.Interfaces
{
    public interface IGetListWithIncludes<T>
    {
        List<T> GetWhereWithIncludes(Expression<Func<T, bool>> expressionWhere,
            params Expression<Func<T, object>>[] includes);

    }
}