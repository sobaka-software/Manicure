using System.ComponentModel.DataAnnotations;

namespace Manicure.Common.Domain
{
    public class ExampleWork
    {
        [Key]
        public int WorkId { get; set; }

        public int MasterId { get; set; }

        public Master Master { get; set; }

        public byte[] Photo { get; set; }

        public string Description { get; set; }
    }
}