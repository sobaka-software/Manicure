using System.Collections.Generic;
using Manicure.Common.Domain;

namespace Manicure.BusinessLogic.Services.Abstract
{
    public interface IUserService
    {
        void Create(User user);

        void Update(User user);

        User GetBy(string login, string password);

        IEnumerable<User> GetBy(string role);
    }
}