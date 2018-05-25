using System.ComponentModel.DataAnnotations;

namespace Manicure.Common.Domain
{
    public class ProcedureEntry
    {
        [Key]
        public int EntryId { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

        public int ScheduleId { get; set; }

        public virtual Schedule Schedule { get; set; }

        public int ProcedureId { get; set; }

        public virtual Procedure Procedure { get; set; }
    }
}