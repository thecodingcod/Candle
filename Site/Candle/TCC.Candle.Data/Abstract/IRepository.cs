using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TCC.Candle.Data.Entities;

namespace TCC.Candle.Data.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        bool Create(T item);
        T GetById(Guid Id);
        T GetSingle(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetList(Expression<Func<T, bool>> predicate);
        bool Delete(Guid Id);
        bool Update(Guid Id, T Item);
    }
}
