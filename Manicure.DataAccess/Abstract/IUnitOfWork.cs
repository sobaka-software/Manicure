namespace Manicure.DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}