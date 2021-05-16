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

        public Customer SearchCustomer(string firstName, string lastName)
        {
            List<Customer> customers = GetAllCustomers();
                if (customers.Count == 0) {
                    throw new Exception ("No customers found");
                } else {
                    foreach (Customer customer in customers) {
                    if (firstName.Equals(customer.FirstName) && lastName.Equals(customer.LastName)) {
                        return customer;
                    }
                }
                throw new Exception ("No matching customer found");
            }
        }

        public Customer SearchCustomer(int customerId) {
            List<Customer> customers = GetAllCustomers();
            if (customers.Count == 0) {
                throw new Exception ("No customers found");
            } else {
                foreach (Customer customer in customers)
                {
                    if (customerId.Equals(customer.Id)) {
                        return customer;
                    }
                }
                throw new Exception ("No matching customer found");
            }
        }
    }
}