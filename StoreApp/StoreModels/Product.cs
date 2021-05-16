namespace StoreModels
{

    /// <summary>
    /// This data structure models a product. The quantity was separated from the product as it could vary from orders and locations.  
    /// </summary>
    public class Product
    {
            public Product(string itemName, double price, string description) {
                this.ItemName = itemName;
                this.Price = price;
                this.Description = description;
        }

        public Product(int id, string itemName, double price, string description) : this(itemName, price, description) {
            this.Id = id;
        }

        public int Id { get; set; }
        /// <summary>
        /// This stores the name of the item
        /// </summary>
        /// <value></value>
        public string ItemName { get; set; }

        /// <summary>
        /// This stores the price of the item
        /// </summary>
        /// <value></value>
        public double Price { get; set; }

        /// <summary>
        /// This stores a description of the item
        /// </summary>
        /// <value></value>
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Item: {ItemName} \nPrice: ${Price} \nDescription: {Description}\n";
        }

        public bool Equals(Product product) {
            return this.ItemName.Equals(product.ItemName);
        }
    }
}