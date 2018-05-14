using System.Data.Entity;
using Manicure.Common.Domain;

namespace Manicure.DataAccess.Context
{
    public class ManicureInitializer : CreateDatabaseIfNotExists<ManicureContext>
    {
        protected override void Seed(ManicureContext context)
        {
            context.Users.Add(new User
            {
                Password = "123",
                Login = "log",
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}