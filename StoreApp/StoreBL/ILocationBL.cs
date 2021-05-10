using System.Collections.Generic;
using StoreModels;

namespace StoreBL
{
    public interface ILocationBL
    {
         Location AddLocation(Location location);
         List<Location> GetLocations();
         List<int> GetStoreInventory(string name);
         Location ReplenishInventory(Location location);
    }
}