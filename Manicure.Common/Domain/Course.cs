using System;

namespace Manicure.Common.Domain
{
    public class Course
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public int MasterId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool HasDiploma { get; set; }

        public int MaxNumberOfPeople { get; set; }
    }
}