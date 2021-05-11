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
                        List<int> quantity = new List<int>();
                        // Retrieves product quantities
                        for (int i = 0; i <= location.NumOfProducts - 1; i++)
                        {
                            quantity.Add(location.ProductQuantity[i]);
                        }
                        return quantity;
                    }
                }
                throw new Exception ("No matching locations found");
            }
        }

        public List<int> ReplenishInventory(string name, int numOfProducts, List<int> productQuantity)
        {
            List<Location> locations = GetLocations();
            if (locations.Count == 0) {
                throw new Exception ("No Locations Found");
            } else {
                foreach (Location location in locations) {
                    if (name.Equals(location.StoreName)) {
                        location.NumOfProducts = numOfProducts;
                        location.ProductQuantity = productQuantity;
                        // TODO: Switch to ReplenishQuantity once implemented
                        _repo.AddLocation(location);
                        return productQuantity;
                    }
                }
                throw new Exception ("No matching locations found");
            }
        }
    }
}