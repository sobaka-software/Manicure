using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Manicure.Common.Domain;

namespace Manicure.DataAccess.Context
{
    public class ManicureContext : DbContext
    {
        public ManicureContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new ManicureInitializer());
            Database.Initialize(true);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseEntry> CourseEntries { get; set; }
        public DbSet<Diploma> Diplomas { get; set; }
        public DbSet<ExampleWork> ExampleWorks { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderContent> OrderContents { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<ProcedureEntry> ProcedureEntries { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<ReviewClient> ReviewClients { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<User> Users { get; set; }
    }
}