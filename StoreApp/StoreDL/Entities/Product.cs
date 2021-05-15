using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
            LineItems = new HashSet<LineItem>();
        }

        public int ProductId { get; set; }
        public string ItemName { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
