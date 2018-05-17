using System.Web;

namespace Manicure.Web.Models
{
    public class ExampleWorkViewModel
    {
        public int WorkId { get; set; }

        public string WorkDescription { get; set; }

        public HttpPostedFileBase Photo { get; set; }
    }
}