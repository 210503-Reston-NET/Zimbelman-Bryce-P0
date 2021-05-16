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
        public Inventory(int locationId, int productId, int quantity) {
            this.LocationID = locationId;
            this.ProductID = productId;
            this.Quantity = quantity;
        }

        public Inventory(int id,int locationId, int productId, int quantity) : this(locationId, productId, quantity) {
            this.Id = id;
        }
        
        /// <summary>
        /// This represents a unique value for every inventory
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        public int LocationID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{Quantity}";
        }
    }
}