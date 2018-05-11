using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manicure.Common.Domain
{
    public class OrderContent
    {
        [Key, Column(Order = 1)]
        public int OrderId { get; set; }

        public Order Order { get; set; }

        [Key, Column(Order = 2)]
        public int ProductiontId { get; set; }

        public Production Production { get; set; }

        public int Quantity { get; set; }
    }
}