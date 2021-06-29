using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TasteRestaurateApplication.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string navigationProperties = null);

        T GetFirstOrDefaultValue(Expression<Func<T, bool>> filter = null,
             string navigationProperties = null);

        void Add(T entity);
        void Remove(int id);
        void Remove(T entity);
    }
}
