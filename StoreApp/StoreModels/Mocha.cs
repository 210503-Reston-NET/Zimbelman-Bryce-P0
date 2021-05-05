namespace StoreModels
{

    /// <summary>
    /// This data structure models a product and its quantity. The quantity was separated from the product as it could vary from orders and locations.  
    /// </summary>
    public class Mocha
    {
        public Mocha(string name, int quantity) {
            this.ItemName = name;
            this.Quantity = quantity;
        }
        /// <summary>
        /// This stores the name of the item
        /// </summary>
        /// <value></value>
        public string ItemName { get; set; }

/// <summary>
/// This stores the quantity of the item
/// </summary>
/// <value></value>
        public int Quantity { get; set; }
    }
}