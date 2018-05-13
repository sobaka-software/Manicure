using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Manicure.DataAccess.Abstract;

namespace Manicure.DataAccess.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        public bool Any(System.Linq.Expressions.Expression<System.Func<T, bool>> filter)
        {
            return _dbSet.Any(filter);
        }

        public IEnumerable<T> Get(System.Linq.Expressions.Expression<System.Func<T, bool>> filter)
        {
            return _dbSet.Where(filter);
        }

        public T GetFirst(System.Linq.Expressions.Expression<System.Func<T, bool>> filter)
        {
            return _dbSet.FirstOrDefault(filter);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }
    }
}