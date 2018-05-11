using System;

namespace Manicure.Common.Domain
{
    public class Schedule
    {
        public int ScheduleId { get; set; }

        public string MasterId { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}