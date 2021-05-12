using System.Collections.Generic;
using StoreModels;
using StoreDL;
using System;
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
        public Order AddOrder(Order order)
        {
            return _repo.AddOrder(order);
        }

        public List<Order> GetCustomerOrders()
        {
            return _repo.GetCustomerOrders();
        }

        public Order ViewOrder(Order order)
        {
            return _repo.ViewOrder(order);
        }
    }
}