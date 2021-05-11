using System.Collections.Generic;
using StoreModels;
namespace StoreBL
{
    public interface ICustomerBL
    {
         List<Customer> GetAllCustomers();
         Customer AddCustomer(Customer customer);
         Customer SearchCustomer(string name);
    }
}