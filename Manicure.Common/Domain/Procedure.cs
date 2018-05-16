using System.Collections.Generic;

namespace Manicure.Common.Domain
{
    public class Procedure
    {
        public int ProcedureId { get; set; }

        public string ProcedureName { get; set; }

        public decimal Price { get; set; }

        public int Duration { get; set; }

        public virtual ICollection<ProcedureEntry> ProcedureEntries { get; set; }
    }
}