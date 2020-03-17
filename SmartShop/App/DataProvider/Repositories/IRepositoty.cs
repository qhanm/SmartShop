using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SmartShop.App.DataProvider.Repositories
{
    public interface IRepository<T, K> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);

        void Remove(K id);

        void RemoveMulty(List<T> entities);

        T FindById(K id, params Expression<Func<T, object>>[] includeProperties);

        T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
    }
}