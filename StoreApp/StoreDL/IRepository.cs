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
    }
}