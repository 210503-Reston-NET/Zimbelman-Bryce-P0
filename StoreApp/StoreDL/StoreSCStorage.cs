using System.Collections.Generic;
using StoreModels;
using System.Linq;
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
            new Location("name", "address", "city", "state", 1, 1, 1)
        };
    }
}