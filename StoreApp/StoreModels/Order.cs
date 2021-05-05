namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a customer order. 
    /// </summary>
    public class Order
    {
        public Order(Location location, double total) {
            this.Location = location;
            this.Total = total;
        }
        public Customer Customer { get; set; }
        public Location Location { get; set; }
        public double Total { get; set; }

        //TODO: add a property for the order items
    }
}