using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Manicure.DataAccess.Abstract
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);

        void Update(T entity);

        void Delete(int id);

        void Delete(T entity);

        IEnumerable<T> Get(Expression<Func<T, bool>> filter);

        T GetFirst(Expression<Func<T, bool>> filter);

        bool Any(Expression<Func<T, bool>> filter);

        IEnumerable<T> GetAll();
    }
}