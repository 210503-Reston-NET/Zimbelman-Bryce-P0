using System.Collections.Generic;
using StoreModels;
using StoreDL;
using System;
using System.Linq;

namespace StoreBL
{
    /// <summary>
    /// Business logic class for LineItem model
    /// </summary>
    public class LineItemBL : ILineItemBL
    {

        private IRepository _repo;
        public LineItemBL(IRepository repo) {
            _repo = repo;
        }
        public LineItem AddLineItem(LineItem lineItem)
        {
            return _repo.AddLineItem(lineItem);
        }

        public List<LineItem> GetAllLineItems()
        {
            return _repo.GetAllLineItems();
        }

        public List<LineItem> GetLineItems(int orderID)
        {
            List<LineItem> lineItems = GetAllLineItems();
            List<LineItem> requestedLineItems = new List<LineItem>();
            if (lineItems.Count == 0) {
                throw new Exception("No orders placed");
            } else {
                foreach (LineItem lineItem in lineItems)
                {
                    if (orderID.Equals(lineItem.OrderID)) {
                        requestedLineItems.Add(lineItem);
                    }
                }
                if (!requestedLineItems.Any()) {
                    throw new Exception("No matching order found");
                } else {
                    return requestedLineItems;
                }
                
            }
        }
    }
}