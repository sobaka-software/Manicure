using Manicure.Common.Domain;

namespace Manicure.Web.Models
{
    public class ReviewViewModel
    {
        public int ReviewId { get; set; }

        public User User { get; set; }

        public string Review { get; set; }
    }
}