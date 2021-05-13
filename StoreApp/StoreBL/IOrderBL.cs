using System.Collections.Generic;
using StoreModels;
namespace StoreBL
{
    public interface IOrderBL
    {
         List<Order> GetCustomerOrders(string firstName, string lastName);
         Order AddOrder(Order order);

         Order ViewOrder(Order order);
    }
}