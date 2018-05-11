using System.Collections.Generic;

namespace Manicure.Common.Domain
{
    public class Client
    {
        public int ClientId { get; set; }

        public string Email { get; set; }

        public ICollection<Client> Clients { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<ReviewClient> ReviewClients { get; set; }

        public ICollection<CourseEntry> CourseEntries { get; set; }
    }
}