namespace StoreModels
{

    /// <summary>
    /// This data structure models a product and its quantity. The quantity was separated from the product as it could vary from orders and locations.  
    /// </summary>
    public class Frost
    {
            public Frost(string name, int quantity, int price, string desription) {
                this.ItemName = name;
                this.Quantity = quantity;
                this.Price = price;
                this.Description = desription;
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

        /// <summary>
        /// This stores the price of the item
        /// </summary>
        /// <value></value>
        public int Price { get; set; }

        /// <summary>
        /// This stores a description of the item
        /// </summary>
        /// <value></value>
        public string Description { get; set; }
    }
}