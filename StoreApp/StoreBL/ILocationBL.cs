using System.Collections.Generic;
using StoreModels;

namespace StoreBL
{
    public interface ILocationBL
    {
         List<Location> GetInventory();

         Location ReplenishInventory(Location location);
    }
}