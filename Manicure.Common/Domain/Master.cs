using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manicure.Common.Domain
{
    public class Master
    {
        [ForeignKey("User")]
        public int MasterId { get; set; }

        public string Description { get; set; }

        public byte[] Photo { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Diploma> Diplomas { get; set; }

        public virtual ICollection<ExampleWork> ExampleWorks { get; set; }

        public virtual User User { get; set; }
    }
}