using System;
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
        public Order(int locationId, int customerId, int orderID, double total, string orderDate) {
            this.LocationID = locationId;
            this.CustomerID = customerId;
            this.OrderID = orderID;
            this.Total = total;
            this.OrderDate = orderDate;
        }

        public Order(int id, int locationId, int customerId, int orderID, double total, string orderDate) : this(locationId, customerId, orderID, total, orderDate) {
            this.Id = id;
        }

        public int Id { get; set; }
        /// <summary>
        /// This stores the customer information for an order
        /// </summary>
        /// <value></value>
        public int CustomerID { get; set; }

        /// <summary>
        /// This stores the location information for an order
        /// </summary>
        /// <value></value>
        public int LocationID { get; set; }
        
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
        public string OrderDate { get; set; }
    }
}