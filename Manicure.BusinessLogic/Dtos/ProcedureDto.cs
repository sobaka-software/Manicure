using System;

namespace Manicure.BusinessLogic.Dtos
{
    public class ProcedureDto
    {
        public int ProcedureId { get; set; }

        public int MasterId { get; set; }

        public string ClientLogin { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }
    }
}