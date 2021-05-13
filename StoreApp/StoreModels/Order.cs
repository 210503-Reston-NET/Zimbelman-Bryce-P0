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
        public Order(Location location, Customer customer, List<string> lineItem, double total, List<int> quantity) {
            this.Location = location;
            this.Customer = customer;
            this.LineItem = lineItem;
            this.Total = total;
            this.Quantity = quantity;

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
        /// This stores the total amount of an order
        /// </summary>
        /// <value></value>
        public List<int> Quantity { get; set; }
        /// <summary>
        /// This stores the names of products ordered
        /// </summary>
        /// <value></value>
        public List<string> LineItem { get; set; }
        public double Total { get; set; }

        public override string ToString()
        {
            return $"Customer Name: {Customer.FirstName} {Customer.LastName} \nTotal {Total}";
        }
    }
}