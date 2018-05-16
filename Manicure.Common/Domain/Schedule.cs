using System;
using System.Collections.Generic;

namespace Manicure.Common.Domain
{
    public class Schedule
    {
        public int ScheduleId { get; set; }

        public int MasterId { get; set; }

        public virtual Master Master { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public virtual ICollection<ProcedureEntry> ProcedureEntries { get; set; }
    }
}