namespace Manicure.Common.Domain
{
    public class Procedure
    {
        public int ProcedureId { get; set; }

        public string ProcedureName { get; set; }

        public decimal Price { get; set; }

        public string Duration { get; set; }
    }
}