using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TasteRestaurateApplication.DataAccess.Repository.IRepository;

namespace TasteRestaurateApplication.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;
        internal DbSet<T> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string navigationProperties = null)
        {
            IQueryable<T> myQuery = _dbSet;

            if(filter != null)
            {
                myQuery = myQuery.Where(filter);
            }

            if(navigationProperties != null)
            {
                foreach (var propertyToAdd in navigationProperties.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    myQuery.Include(propertyToAdd);
                }
            }

            if(orderBy != null)
            {
                return orderBy(myQuery).ToList();
            }

            return myQuery.ToList();
        }

        public T GetFirstOrDefaultValue(Expression<Func<T, bool>> filter = null, string navigationProperties = null)
        {
            IQueryable<T> myQuery = _dbSet;

            if (filter != null)
            {
                myQuery = myQuery.Where(filter);
            }

            if (navigationProperties != null)
            {
                foreach (var propertyToAdd in navigationProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    myQuery.Include(propertyToAdd);
                }
            }

            return myQuery.FirstOrDefault();
        }

        public void Remove(int id)
        {
            var findObj = _dbSet.Find(id);
            Remove(findObj);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
