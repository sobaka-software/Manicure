using System;
using System.ComponentModel.DataAnnotations;

namespace Manicure.Common.Domain
{
    public class ProcedureEntry
    {
        [Key]
        public int EntryId { get; set; }

        public int ClientId { get; set; }

        public int ScheduleId { get; set; }

        public int ProcedureId { get; set; }

        public DateTime StartTime { get; set; }
    }
}