using System.Collections.Generic;

namespace Manicure.Common.Domain
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public virtual ICollection<Production> Productions { get; set; }
    }
}