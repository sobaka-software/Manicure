using System;
using Manicure.Common.Domain;

namespace Manicure.Web.Models
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public virtual Master Master { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool HasDiploma { get; set; }

        public int MaxNumberOfPeople { get; set; }
    }
}