using System.Collections.Generic;
namespace StoreModels
{
    /// <summary>
    /// This stores individual line items of an order
    /// </summary>
    public class LineItem
    {
        public LineItem(Product product, int quantity, int orderID) {
            this.Product = product;
            this.Quantity = quantity;
            this.OrderID = orderID;
        }

        public LineItem(int id, Product product, int quantity, int orderID) : this(product, quantity, orderID) {
            this.Id = id;
        }

        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }

        public override string ToString()
        {
            return $"{Quantity} {Product.ItemName}";
        }
    }
}