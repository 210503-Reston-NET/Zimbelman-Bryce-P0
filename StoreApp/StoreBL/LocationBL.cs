using System.Linq;
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

        public List<Location> GetAllLocations()
        {
            return _repo.GetAllLocations();
        }

        public Location GetLocation(string name)
        {
            List<Location> locations = GetAllLocations();
            if (locations.Count == 0) {
                throw new Exception ("No Locations Found");
            } else {
                foreach (Location location in locations) {
                    if (name.Equals(location.StoreName)) {
                        return location;
                    }
                }
                throw new Exception ("No matching locations found"); 
                {
                    
                }
            }
        }
    }
}