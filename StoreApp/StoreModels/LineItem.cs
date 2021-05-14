using System.Collections.Generic;
namespace StoreModels
{
    /// <summary>
    /// This stores individual line items of an order
    /// </summary>
    public class LineItem
    {
        public LineItem(string productName, int quantity, int orderID) {
            this.ProductName = productName;
            this.Quantity = quantity;
            this.OrderID = orderID;
        }

        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }

        public override string ToString()
        {
            return $"{Quantity} {ProductName}";
        }
    }
}