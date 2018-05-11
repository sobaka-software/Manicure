using System.Data.Entity;

namespace Manicure.DataAccess.Context
{
    public class ManicureContext : DbContext
    {
        static ManicureContext()
        {
            Database.SetInitializer(new ManicureInitializer());
        }

        public ManicureContext() : base("ManicureDBConnectionString")
        { }
    }
}