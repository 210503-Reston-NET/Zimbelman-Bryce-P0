using System.Collections.Generic;
using StoreModels;
using StoreDL;
namespace StoreBL
{
    public class CustomerBL : ICustomerBL
    {
        private IRepository _repo;
        public CustomerBL(IRepository repo) {
            _repo = repo;
        }

    public List<Customer> GetAllCustomers() {
        return _repo.GetAllCustomers();
    }
    //    public List<Order> GetAllOrders() {
    //        return _repo.GetAllOrders();
    //    }
    }
}