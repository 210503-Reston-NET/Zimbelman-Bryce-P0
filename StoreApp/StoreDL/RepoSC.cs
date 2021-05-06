using System.Collections.Generic;
using StoreModels;
namespace StoreDL
{
    public class RepoSC : IRepository
    {
 //       public List<Order> GetAllOrders() {
     //       return StoreSCStorage.Orders;
 //       }
        public List<Customer> GetAllCustomers() {
            return StoreSCStorage.Customers;
        }
    }
}