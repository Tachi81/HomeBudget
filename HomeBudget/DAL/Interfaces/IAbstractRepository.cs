﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HomeBudget.DAL.Interfaces
{
    public interface IAbstractRepository<T> : IGetListWithIncludes<T> where T : class 
    {
        void Create(T entity);
        void Delete(T entity);
        List<T> GetWhere(Expression<Func<T, bool>> expression);
        void Update(T entity);
    }
}
