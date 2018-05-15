using System;

namespace Manicure.Web.Models
{
    public class ProcedureEntryViewModel
    {
        public int ProcedureId { get; set; }

        public string MasterId { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}