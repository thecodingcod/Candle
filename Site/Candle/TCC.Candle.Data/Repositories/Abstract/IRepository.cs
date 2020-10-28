using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TCC.Candle.Data.Repositories.Abstract
{
    public interface IRepository<T>
    {
        T GetById(Guid Id);
        T GetSingle(Expression<Func<T, bool>> predicate);
        bool Add(T item);
        bool Remove(Guid Id);
        bool RemovePhysical(Guid Id);
        bool Update(Guid Id, T Item);
        IEnumerable<T> GetAll();
        IEnumerable<T> Where(Expression<Func<T, bool>> predicate);

    }
}
