using System.Net;
using Ninject.Modules;

namespace Manicure.Dependencies.NinjectModules
{
    public class BusinessLogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAuthProvider>().To<AuthProvider>();
        }
    }
}
