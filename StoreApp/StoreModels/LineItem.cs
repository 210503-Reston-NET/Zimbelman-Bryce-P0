using System.Collections.Generic;
namespace StoreModels
{
    /// <summary>
    /// This stores individual line items of an order
    /// </summary>
    public class LineItem
    {
        public LineItem(int productId, int quantity, int orderID) {
            this.ProductID = productId;
            this.Quantity = quantity;
            this.OrderID = orderID;
        }

        public LineItem(int id, int productId, int quantity, int orderID) : this(productId, quantity, orderID) {
            this.Id = id;
        }

        public int Id { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }

        public override string ToString()
        {
            return $"{Quantity}";
        }
    }
}