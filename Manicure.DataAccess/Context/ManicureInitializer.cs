using System.Data.Entity;
using Manicure.Common.Domain;

namespace Manicure.DataAccess.Context
{
    public class ManicureInitializer : CreateDatabaseIfNotExists<ManicureContext>
    {
        protected override void Seed(ManicureContext context)
        {
            context.Clients.Add(new Client());
            context.SaveChanges();
            base.Seed(context);
        }
    }
}