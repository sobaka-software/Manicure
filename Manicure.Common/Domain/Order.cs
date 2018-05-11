using System;

namespace Manicure.Common.Domain
{
    public class Order
    {
        public int OrderId { get; set; }

        public int ClientId { get; set; }

        public DateTime SaleDate { get; set; }
    }
}