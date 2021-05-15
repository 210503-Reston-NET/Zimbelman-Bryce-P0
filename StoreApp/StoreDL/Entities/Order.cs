using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Order
    {
        public Order()
        {
            LineItems = new HashSet<LineItem>();
        }

        public int OrderId { get; set; }
        public double Total { get; set; }
        public int? LocationId { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
