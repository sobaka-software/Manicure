using System.Collections.Generic;
using Manicure.Common.Domain;

namespace Manicure.Web.Models
{
    public class CompositeHomeViewModel
    {
        public ControlDataViewModel Controls { get; set; }

        public IEnumerable<Schedule> MasterSchedule { get; set; }
    }
}