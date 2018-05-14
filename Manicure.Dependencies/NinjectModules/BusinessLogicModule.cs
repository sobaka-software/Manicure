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
            Bind<IContactService>().To<ContactService>();
            Bind<IArticleService>().To<ArticleService>();
            Bind<IReviewService>().To<ReviewService>();
            Bind<IMasterService>().To<MasterService>();
            Bind<IClientService>().To<ClientService>();

            Bind<IAuthProvider>().To<AuthProvider>();
        }
    }
}
