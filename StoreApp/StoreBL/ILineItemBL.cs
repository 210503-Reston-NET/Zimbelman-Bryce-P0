using System.Collections.Generic;
using StoreModels;
namespace StoreBL
{
    public interface ILineItemBL
    {
         LineItem AddLineItem(LineItem lineItem);
         List<LineItem> GetAllLineItems();
         List<LineItem> GetLineItems(int orderID);
    }
}