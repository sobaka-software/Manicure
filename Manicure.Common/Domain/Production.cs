using System.Collections.Generic;

namespace Manicure.Common.Domain
{
    public class Production
    {
        public int ProductionId { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string ProductionName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string NumberOfMeasure { get; set; }

        public virtual ICollection<OrderContent> OrderContents { get; set; }
    }
}