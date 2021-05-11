using System.Collections.Generic;

namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a customer order. 
    /// </summary>
    public class Order
    {
        /// <summary>
        /// This stores the location and total for a store order
        /// </summary>
        /// <param name="location"></param>
        /// <param name="total"></param>
        public Order(Location location, double total, List<Product> product, int numOfProduct, List<int> Quantity) {
            this.Location = location;
            this.Total = total;
            this.Product = product;

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
        /// <summary>
        /// This stores the product in an order
        /// </summary>
        /// <value></value>
        public List<Product> Product { get; set; }

        /// <summary>
        /// This stores the total amount of an order
        /// </summary>
        /// <value></value>
        
        public int NumOfProduct { get; set; }
        public List<int> Quantity { get; set; }
        public double Total { get; set; }
    }
}