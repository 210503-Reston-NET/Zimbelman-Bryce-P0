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
        List<Location> GetAllLocations();
        Product AddProduct(Product product);
        Product GetProduct(Product product);
        List<Product> GetAllProducts();

        Inventory UpdateInventory(Inventory inventory);

        List<Inventory> GetAllInventories();

        Order AddOrder(Order order);
        Order ViewOrder(Order order);
        List<Order> GetAllOrders();
        List<LineItem> GetAllLineItems();
        LineItem AddLineItem(LineItem lineItem);
        LineItem GetLineItem(LineItem lineItem);
    }
}