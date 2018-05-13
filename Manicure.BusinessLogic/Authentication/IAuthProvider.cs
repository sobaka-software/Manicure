using Manicure.Common.Auth;
using Manicure.Common.Domain;

namespace Manicure.BusinessLogic.Authentication
{
    public interface IAuthProvider
    {
        User Authenticate(Login login);

        void Deauthenticate();
    }
}