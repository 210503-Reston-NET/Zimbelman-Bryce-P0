using System.Collections.Generic;
using StoreModels;
using StoreDL;
using System;
using System.Linq;
namespace StoreBL
{
    public class OrderBL : IOrderBL
    {
        /// <summary>
        /// Business logic class for the order model
        /// </summary>
        
        private IRepository _repo;
        public OrderBL(IRepository repo) {
            _repo = repo;
        }
        public Order AddOrder(Order order, Location location, Customer customer)
        {
            return _repo.AddOrder(order, location, customer);
        }

        public List<Order> GetAllOrders()
        {
            return _repo.GetAllOrders();
        }

        public List<Order> GetCustomerOrders(string firstName, string lastName)
        {
            List<Order> orders = _repo.GetAllOrders();
            List<Order> customerOrders = new List<Order>();
            foreach (Order order in orders)
            {
                if (firstName.Equals(order.Customer.FirstName) && lastName.Equals(order.Customer.LastName)) {
                    customerOrders.Add(order);
                }
            }
            if (customerOrders.Any()) {
                return customerOrders;
            } else {
                throw new Exception("No matching orders found");
            }
        }

        public Order ViewOrder(Order order)
        {
            return _repo.GetOrder(order);
        }
    }
}