using System;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
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

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                if (authTicket != null && !authTicket.Expired)
                {
                    var roles = authTicket.UserData.Split(',');
                    Context.User = new System.Security.Principal.GenericPrincipal(new FormsIdentity(authTicket), roles);
                }
            }
        }


        protected override IKernel CreateKernel()
        {
            var dbConnectionString = ConfigurationManager.ConnectionStrings["ManicureDBConnectionString"].ConnectionString;

            var modules = new NinjectModule[] {new BusinessLogicModule(), new DalModule(dbConnectionString) };

            return new StandardKernel(modules);
        }
    }
}
