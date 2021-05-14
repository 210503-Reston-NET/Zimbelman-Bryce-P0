using System.Collections.Generic;
using StoreModels;
namespace StoreDL
{
    /// <summary>
    /// Store static collection storage
    /// </summary>
    public class StoreSCStorage
    {
        public static List<Customer> Customers = new List<Customer>() {
            new Customer("firstName", "lastName","birthdate", "phone#", "email", "Mailing Address")
        };

        public static List<Location> Locations = new List<Location>() {
            new Location("name", "address", "city", "state", 1, new List<int>())
        };

        public static List<Product> Products = new List<Product>() {
            new Product("name", 1.99, "description")
        };

        public static List<Order> Orders = new List<Order>() {
            new Order(new Location("name", "address", "city", "state", 1, new List<int>()), new Customer("firstName", "lastName", "birthdate", "phoneNumber", "email", "mailAddress"), 1, 1.99)
        };

        public static List<LineItem> LineItems = new List<LineItem>() {
            new LineItem("productName", 1, 1)
        };

        public static List<Inventory> Inventories = new List<Inventory>() {
            new Inventory(new Location("name", "address", "city", "state", 1, new List<int>()), new Product("name", 1.99, "description"), 1)
        };
    }
}