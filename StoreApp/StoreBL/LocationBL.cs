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

        public Location AddLocation(Location location)
        {
            if (_repo.GetLocation(location) != null) {
                throw new Exception ("Location already exists");
            }
            return _repo.AddLocation(location);
        }

        public List<Location> GetLocations()
        {
            return _repo.GetLocations();
        }

        public List<int> GetStoreInventory(string name)
        {
            List<Location> locations = GetLocations();
            if (locations.Count == 0) {
                throw new Exception ("No Locations Found");
            } else {
                foreach (Location location in locations) {
                    if (name.Equals(location.StoreName)) {
                        List<int> inventory = new List<int>();
                        inventory.Add(location.MochaInventory);
                        inventory.Add(location.FrostInventory);
                        inventory.Add(location.EspressoInventory);
                        return inventory;
                    }
                }
                throw new Exception ("No matching locations found");
            }
        }

        public Location ReplenishInventory(Location location)
        {
            throw new NotImplementedException();
        }
    }
}