using System.Web;

namespace Manicure.Web.Models
{
    public class DiplomaViewModel
    {
        public int DiplomaId { get; set; }

        public HttpPostedFileBase[] Photos { get; set; }
    }
}