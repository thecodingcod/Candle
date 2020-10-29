using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TCC.Candle.Data.Repositories.Abstract
{
    public interface IRepository<T>
    {
        T GetById(Guid id);
        T GetSingle(Expression<Func<T, bool>> predicate);

        bool Add(T item);
        bool Remove(Guid id);
        bool RemovePhysical(Guid id);
        bool Update(Guid id, T item);
        IEnumerable<T> GetAll();
        IEnumerable<T> Where(Expression<Func<T, bool>> predicate);

    }
}
