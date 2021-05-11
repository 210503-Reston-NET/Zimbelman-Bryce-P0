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
            new Customer("name", "birthdate", "phone#", "email", "Mailing Address")
        };

        public static List<Location> Locations = new List<Location>() {
            new Location("name", "address", "city", "state", 1, new List<int>())
        };

        public static List<Product> Products = new List<Product>() {
            new Product("name", 1.99, "description")
        };
    }
}