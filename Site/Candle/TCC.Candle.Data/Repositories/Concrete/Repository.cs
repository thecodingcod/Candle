using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TCC.Candle.Data.Entities;
using TCC.Candle.Data.Repositories.Abstract;

namespace TCC.Candle.Data.Repositories
{


    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected CandleContext context;
        public Repository(IDesignTimeDbContextFactory<CandleContext> contextfactory)
        {
            context = contextfactory.CreateDbContext(null);
        }



        public bool Add(T item)
        {
            var entry = context.Set<T>().Add(item);
            int occurences = context.SaveChanges();
            if (occurences > 0)
            {
                return true;
            }
            return false;
        }

        public bool Remove(Guid Id)
        {
            var Entry = context.Find<T>(Id);
            if (Entry != null)
            {
                Entry.IsDeleted = true;
                int occurences = context.SaveChanges();
                if (occurences > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool RemovePhysical(Guid Id)
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


        public bool Update(Guid id, T item)
        {
            var current = context.Set<T>().AsNoTracking().SingleOrDefault(i => i.Id == id);
            if (current == null) return false;
            context.Set<T>().Update(item);
            var occurrences = context.SaveChanges();
            return occurrences > 0;
        }

        public T GetById(Guid Id)
        {
            var item = context.Set<T>().SingleOrDefault(i => i.Id == Id);
            if (item != null) return item;
            return null;
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            var item = context.Set<T>().SingleOrDefault(predicate);
            if (item != null) return item;
            return null;
        }

        IEnumerable<T> IRepository<T>.GetAll()
        {
            return context.Set<T>().ToList();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
        {
            var items = context.Set<T>().Where(predicate);
            if (items.Count() > 0) return items;
            return null;
        }



        /// <summary>
        /// Return String representation of a property name
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="propexpr"></param>
        /// <returns></returns>
        protected string GetPropName<TProperty>(Expression<Func<T, TProperty>> propexpr)
        {
            var member = (MemberExpression)propexpr.Body;
            return member.Member.Name;
        }

    }
}
