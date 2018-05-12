using System.Web.Mvc;
using System.Web.Routing;
using Manicure.Dependencies.NinjectModules;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common.WebHost;

namespace Manicure.Web
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected override IKernel CreateKernel()
        {
            var modules = new NinjectModule[] {new BusinessLogicModule(), new DalModule()};

            return new StandardKernel(modules);
        }
    }
}
