using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manicure.Common.Domain
{
    public class Client
    {
        [ForeignKey("User")]
        public int ClientId { get; set; }

        public string Email { get; set; }

        public virtual ICollection<ProcedureEntry> ProcedureEntries { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<ReviewClient> ReviewClients { get; set; }

        public virtual ICollection<CourseEntry> CourseEntries { get; set; }

        public virtual User User { get; set; }
    }
}