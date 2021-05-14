using System.Collections.Generic;
using StoreModels;

namespace StoreBL
{
    public interface ILocationBL
    {
         Location AddLocation(Location location);
         List<Location> GetAllLocations();
         List<int> GetStoreInventory(string name);
         List<int> ReplenishInventory(string name, int numOfProducts, List<int> productQuantity);

         Location GetLocation(string name);

         List<int> SubtractInventory(string name, List<int> quantity);
    }
}