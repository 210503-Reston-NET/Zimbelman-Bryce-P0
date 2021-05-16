using System.Collections.Generic;
using StoreModels;
namespace StoreBL
{
    public interface IOrderBL
    {
         List<Order> GetCustomerOrders(string firstName, string lastName);
         Order AddOrder(Order order, Location location, Customer customer);

         Order ViewOrder(Order order);
         List<Order> GetAllOrders();
    }
}