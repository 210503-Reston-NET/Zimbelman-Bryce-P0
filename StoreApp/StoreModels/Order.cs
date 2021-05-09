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
        public Order(Location location, double total) {
            this.Location = location;
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
        /// This stores the total amount of an order
        /// </summary>
        /// <value></value>
        public double Total { get; set; }
    }
}