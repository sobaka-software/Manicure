using System.Web.Mvc;

namespace Manicure.Web.Models
{
    public class ControlDataViewModel
    {
        public SelectList ProceduresList { get; set; }

        public SelectList MastersList { get; set; }
    }
}