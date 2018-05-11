using Manicure.Common.Domain;

namespace Manicure.BusinessLogic.Services.Abstract
{
    public interface IUserService
    {
        void Create();

        void Update();

        User GetBy(string login, string password);
    }
}