using System.Data.Entity;
using Manicure.DataAccess.Abstract;
using Manicure.DataAccess.Concrete;
using Manicure.DataAccess.Context;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Manicure.Dependencies.NinjectModules
{
    public class DalModule : NinjectModule
    {
        private readonly string _connectionString;

        public DalModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<DbContext>().To<ManicureContext>()
                .InRequestScope()
                .WithConstructorArgument(_connectionString);


            Bind(typeof(IRepository<>)).To(typeof(Repository<>));

            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
