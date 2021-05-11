using System.Collections.Generic;

namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a customer order. 
    /// </summary>
    public class Order
    {
        public Order(Location location, Customer customer, double total, int mochaQuantity, int frostQuantity, int espressoQuantity) {
            this.Location = location;
            this.Customer = customer;
            this.Total = total;
            this.MochaQuantity = mochaQuantity;
            this.FrostQuantity = frostQuantity;
            this.EspressoQuantity = espressoQuantity;
        }

        /// <summary>
        /// This stores the customer information for an order
        /// </summary>
        /// <value></value>
        public Customer Customer { get; set; }

        /// <summary>
        /// This stores the location information for an order
        /// </summary>
        /// <value></value>
        public Location Location { get; set; }
        public int MochaQuantity { get; set; }
        public int FrostQuantity { get; set; }
        public int EspressoQuantity { get; set; }

        /// <summary>
        /// This stores the total amount of an order
        /// </summary>
        /// <value></value>
        public double Total { get; set; }
    }
}