using System.Collections.Generic;
using StoreModels;
namespace StoreDL
{
    public interface IRepository
    {
//      List<Order> GetAllOrders();
        List<Customer> GetAllCustomers();
    }
}