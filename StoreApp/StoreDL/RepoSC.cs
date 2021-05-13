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

        public Location AddLocation(Location location)
        {
            StoreSCStorage.Locations.Add(location);
            return location;
        }

        public Order AddOrder(Order order)
        {
            StoreSCStorage.Orders.Add(order);
            return order;
        }

        public Product AddProduct(Product product)
        {
            StoreSCStorage.Products.Add(product);
            return product;
        }

        public List<Customer> GetAllCustomers() {
            return StoreSCStorage.Customers;
        }

        public List<Order> GetAllOrders()
        {
            return StoreSCStorage.Orders;
        }

        public List<Product> GetAllProducts()
        {
            return StoreSCStorage.Products;
        }

        public Customer GetCustomer(Customer customer) {
            return StoreSCStorage.Customers.FirstOrDefault(custo => custo.Equals(customer));
        }

        public List<Order> GetCustomerOrders()
        {
            return StoreSCStorage.Orders;
        }

        public Location GetLocation(Location location)
        {
            return StoreSCStorage.Locations.FirstOrDefault(loca => loca.Equals(location));
        }

        public List<Location> GetLocations()
        {
            return StoreSCStorage.Locations;
        }

        public Product GetProduct(Product product)
        {
            return StoreSCStorage.Products.FirstOrDefault(prod => prod.Equals(product));
        }

        public Location UpdateInventory(Location location)
        {
            return StoreSCStorage.Locations.FirstOrDefault(loca => loca.Equals(location));
        }

        public Order ViewOrder(Order order)
        {
            return StoreSCStorage.Orders.FirstOrDefault(ord => ord.Equals(order));
        }
    }
}