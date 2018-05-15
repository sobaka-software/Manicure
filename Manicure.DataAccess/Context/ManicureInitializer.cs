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
                Login = "admin",
                Password = "123".GetHashCode().ToString(),
                FirstName = "Manicure",
                LastName = "Administrator",
                Role = "Administrator"
            });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}