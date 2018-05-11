using System.ComponentModel.DataAnnotations;

namespace Manicure.Common.Domain
{
    public class ReviewClient
    {
        [Key]
        public int ReviewId { get; set; }

        public int ClientId { get; set; }

        public string Review { get; set; }
    }
}