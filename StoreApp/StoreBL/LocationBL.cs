using System.Collections.Generic;
using StoreModels;
using StoreDL;
using System;
namespace StoreBL
{

    /// <summary>
    /// Business logic class for location model
    /// </summary>
    public class LocationBL : ILocationBL
    {

        private IRepository _repo;
        public LocationBL(IRepository repo) {
            _repo = repo;
        }
        public List<Location> GetInventory()
        {
            throw new NotImplementedException();
        }

        public Location ReplenishInventory(Location location)
        {
            throw new NotImplementedException();
        }
    }
}