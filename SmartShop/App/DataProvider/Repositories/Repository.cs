using Microsoft.EntityFrameworkCore;
using SmartShop.App.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SmartShop.App.DataProvider.Repositories
{
    public class Repository<T, K> : IRepository<T, K>, IDisposable where T : QHN_PrimaryKey<K>
    {
        private readonly AppDbContext _appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(T entity)
        {
            _appDbContext.Set<T>().Add(entity);
        }

        public void Dispose()
        {
            if (_appDbContext != null)
            {
                _appDbContext.Dispose();
            }
        }

        public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _appDbContext.Set<T>();

            if (includeProperties != null)
            {
                foreach (var include in includeProperties)
                {
                    items = items.Include(include);
                }
            }

            return items;
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _appDbContext.Set<T>();

            if (includeProperties != null)
            {
                foreach (var include in includeProperties)
                {
                    items = items.Include(include);
                }
            }

            return items.Where(predicate);
        }

        public T FindById(K id, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(x => x.Id.Equals(id));
        }

        public T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(predicate);
        }

        public void Remove(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
        }

        public void Remove(K id)
        {
            var entity = FindById(id);
            Remove(entity);
        }

        public void RemoveMulty(List<T> entities)
        {
            _appDbContext.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _appDbContext.Set<T>().Update(entity);
        }
    }
}