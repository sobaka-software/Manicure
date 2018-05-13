using Manicure.Common.Domain;

namespace Manicure.Web.Models
{
    public class ReviewViewModel
    {
        public int ReviewId { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public string Review { get; set; }
    }
}