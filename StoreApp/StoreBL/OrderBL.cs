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

        public Order UpdateOrder(Order order, Location location, Customer customer) {
            return _repo.UpdateOrder(order, location, customer);
        }

        public List<Order> GetAllOrders()
        {
            return _repo.GetAllOrders();
        }

        public List<Order> GetCustomerOrders(int customerId)
        {
            List<Order> orders = _repo.GetAllOrders();
            List<Order> customerOrders = new List<Order>();
            foreach (Order order in orders)
            {
                if (customerId.Equals(order.CustomerID)) {
                    customerOrders.Add(order);
                }
            }
            if (customerOrders.Any()) {
                return customerOrders;
            } else {
                throw new Exception("No matching orders found");
            }
        }

        public Order ViewOrder(int orderId)
        {
            List<Order> orders = _repo.GetAllOrders();
            foreach (Order order in orders) {
                if (orderId.Equals(order.OrderID)) {
                    return order;
                }
            }
            throw new Exception("No matching orders found");
        }
    }
}