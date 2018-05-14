using System.ComponentModel.DataAnnotations;

namespace Manicure.Common.Domain
{
    public class ReviewClient
    {
        [Key]
        public int ReviewId { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public string Review { get; set; }
    }
}