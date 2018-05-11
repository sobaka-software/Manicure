using System.Data.Entity;

namespace Manicure.DataAccess.Context
{
    public class ManicureInitializer : CreateDatabaseIfNotExists<ManicureContext>
    {
        protected override void Seed(ManicureContext context)
        {
            base.Seed(context);
        }
    }
}