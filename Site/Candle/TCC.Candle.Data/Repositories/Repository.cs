using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TCC.Candle.Data.Entities;

namespace TCC.Candle.Data.Repositories
{


    internal class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private CandleContext context;
        public Repository(IDesignTimeDbContextFactory<CandleContext> contextfactory)
        {
            context = contextfactory.CreateDbContext(null);
        }

        public bool Create(T item)
        {
            var entry = context.Set<T>().Add(item);
            int occurences = context.SaveChanges();
            if (occurences > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(Guid Id)
        {
            var Entry = context.Find<T>(Id);
            if (Entry != null)
            {
                context.Remove<T>(Entry);
                int occurences = context.SaveChanges();
                if (occurences > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<T> GetAll()
        {
            // Decided not to convert it to a list for Defered Execution
            return context.Set<T>();
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> predicate)
        {
            var items = context.Set<T>().Where(predicate);
            if (items.Count() > 0) return items;
            return null;
        }

        public T GetById(Guid Id)
        {
            var item = context.Find<T>(Id);
            if (item != null) return item;
            return null;

        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            var item = context.Set<T>().SingleOrDefault(predicate);
            if (item != null) return item;
            return null;
        }

        public bool Update(Guid Id, T Item)
        {
            var item = context.Find<T>(Id);
            if (item != null)
            {
                var entry = context.Update<T>(item);
                int occurences = context.SaveChanges();
                if (occurences > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
