using Manicure.BusinessLogic.Authentication;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.BusinessLogic.Services.Concrete;
using Ninject.Modules;

namespace Manicure.Dependencies.NinjectModules
{
    public class BusinessLogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();

            Bind<IAuthProvider>().To<AuthProvider>();
        }
    }
}
