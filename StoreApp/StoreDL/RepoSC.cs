using System.Collections.Generic;
using StoreModels;
using System.Linq;
namespace StoreDL
{
    /// <summary>
    /// Implementation of the IRepository that stores data in a static collection
    /// </summary>
    public class RepoSC : IRepository
    {

        public Customer AddCustomer(Customer customer) {
            StoreSCStorage.Customers.Add(customer);
            return customer;
        }
        public List<Customer> GetAllCustomers() {
            return StoreSCStorage.Customers;
        }

        public Customer GetCustomer(Customer customer) {
            return StoreSCStorage.Customers.FirstOrDefault(custo => custo.Equals(customer));
        }
    }
}