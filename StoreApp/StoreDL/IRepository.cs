using System.Collections.Generic;
using StoreModels;
namespace StoreDL
{
    public interface IRepository
    {
        List<Customer> GetAllCustomers();
        Customer AddCustomer(Customer customer);
        Customer GetCustomer(Customer customer);

        Location AddLocation(Location location);
        Location GetLocation(Location location);
        List<Location> GetLocations();
        Product AddProduct(Product product);
        Product GetProduct(Product product);
        List<Product> GetAllProducts();

        Location ReplenishInventory(Location location);

        Order AddOrder(Order order);
        Order ViewOrder(Order order);
        List<Order> GetCustomerOrders();
        List<Order> GetAllOrders();
    }
}