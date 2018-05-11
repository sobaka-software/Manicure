using System.Collections.Generic;

namespace Manicure.Common.Domain
{
    public class Master
    {
        public int MasterId { get; set; }

        public string Description { get; set; }

        public byte[] Photo { get; set; }

        public ICollection<Schedule> Schedules { get; set; }

        public ICollection<Course> Courses { get; set; }

        public ICollection<Diploma> Diplomas { get; set; }

        public ICollection<ExampleWork> ExampleWorks { get; set; }
    }
}