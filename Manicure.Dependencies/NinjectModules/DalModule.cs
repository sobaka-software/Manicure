using Manicure.DataAccess.Abstract;
using Manicure.DataAccess.Concrete;
using Ninject.Modules;

namespace Manicure.Dependencies.NinjectModules
{
    public class DalModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepository<>)).To(typeof(Repository<>));

            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
