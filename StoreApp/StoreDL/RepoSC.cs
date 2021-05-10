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

        public List<Customer> GetAllCustomers() {
            return StoreSCStorage.Customers;
        }

        public Customer GetCustomer(Customer customer) {
            return StoreSCStorage.Customers.FirstOrDefault(custo => custo.Equals(customer));
        }

        public Location GetLocation(Location location)
        {
            return StoreSCStorage.Locations.FirstOrDefault(loca => loca.Equals(location));
        }

        public List<Location> GetLocations()
        {
            return StoreSCStorage.Locations;
        }
    }
}