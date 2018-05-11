using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace Manicure.DataAccess.Abstract
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);

        void Update(T entity);

        void Delete(int id);

        IEnumerable<T> Get(Expression<Func<T, bool>> filter);

        T GetFirst(Expression<Func<T, bool>> filter);

        bool Exists(Expression<Func<T, bool>> filter);
    }
}