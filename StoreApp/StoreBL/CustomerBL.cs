using System.Collections.Generic;
using StoreModels;
using StoreDL;
using System;
namespace StoreBL
{
    /// <summary>
    /// Business Lgoic class for the customer model
    /// </summary>
    public class CustomerBL : ICustomerBL
    {
        private IRepository _repo;
        public CustomerBL(IRepository repo) {
            _repo = repo;
        }

        public Customer AddCustomer(Customer customer) {
            if (_repo.GetCustomer(customer) != null) {
                throw new Exception ("Customer already exists");
            }
            return _repo.AddCustomer(customer);
        }

        public List<Customer> GetAllCustomers() {
            return _repo.GetAllCustomers();
        }
    }
}