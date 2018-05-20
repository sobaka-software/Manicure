using System.Collections.Generic;
using Manicure.Common.Domain;

namespace Manicure.Web.Models
{
    public class MasterToViewViewModel
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        public byte[] Photo { get; set; }

        public virtual ICollection<ExampleWork> ExampleWorks { get; set; }
    }
}