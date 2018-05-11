using Manicure.DataAccess.Abstract;

namespace Manicure.DataAccess.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public void Create(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(System.Linq.Expressions.Expression<System.Func<T, bool>> filter)
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<T> Get(System.Linq.Expressions.Expression<System.Func<T, bool>> filter)
        {
            throw new System.NotImplementedException();
        }

        public T GetFirst(System.Linq.Expressions.Expression<System.Func<T, bool>> filter)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}