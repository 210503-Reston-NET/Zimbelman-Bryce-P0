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
        public Order(Location location, Customer customer, int orderID, double total) {
            this.Location = location;
            this.Customer = customer;
            this.OrderID = orderID;
            this.Total = total;

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
        /// This stores a unique value for each order
        /// </summary>
        /// <value></value>
        public int OrderID { get; set; }

        /// <summary>
        /// This stores the total dollar amount of each order
        /// </summary>
        /// <value></value>
        public double Total { get; set; }

        public override string ToString()
        {
            return $"Customer Name: {Customer.FirstName} {Customer.LastName} \nLocation Name: {Location.StoreName}";
        }
    }
}