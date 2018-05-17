using System.Collections.Generic;
using Manicure.Common.Domain;

namespace Manicure.Web.Models
{
    public class UserProfileViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }

        public string Description { get; set; }

        public byte[] Photo { get; set; }

        public virtual ICollection<ProcedureEntry> ProcedureEntries { get; set; }

        public virtual ICollection<CourseEntry> CourseEntries { get; set; }

        public virtual ICollection<Diploma> Diplomas { get; set; }

        public virtual ICollection<ExampleWork> ExampleWorks { get; set; }
    }
}