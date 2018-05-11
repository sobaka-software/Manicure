using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manicure.Common.Domain
{
    public class CourseEntry
    {
        [Key, Column(Order = 1)]
        public int CourseId { get; set; }

        [Key, Column(Order = 2)]
        public int ClientId { get; set; }

        public bool IsPaid { get; set; }
    }
}