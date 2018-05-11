namespace Manicure.Common.Domain
{
    public class Diploma
    {
        public int DiplomaId { get; set; }

        public int MasterId { get; set; }

        public Master Master { get; set; }

        public byte[] ScanDiploma { get; set; }
    }
}