namespace StoreModels
{
    public class Inventory
    {
        /// <summary>
        /// This class contains inventory information for each store mapped to a product.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public Inventory(Location location, Product product, int quantity) {
            this.Location = location;
            this.Product = product;
            this.Quantity = quantity;
        }
        
        public Location Location { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{Product.ItemName} {Quantity}";
        }
    }
}