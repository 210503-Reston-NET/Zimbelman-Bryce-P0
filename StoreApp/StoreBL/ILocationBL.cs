using System.Collections.Generic;
using StoreModels;

namespace StoreBL
{
    public interface ILocationBL
    {
         Location AddLocation(Location location);
         List<Location> GetAllLocations();
         Location GetLocation(int locationId);
         Location GetLocation(string locationName);
    }
}