using System.Collections.Generic;
using StoreModels;
namespace StoreBL
{
    public interface IOrderBL
    {
         List<Order> GetCustomerOrders();
         Order AddOrder(Order order);

         Order ViewOrder(Order order);
    }
}