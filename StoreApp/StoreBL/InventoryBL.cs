using System.Collections.Generic;
using StoreModels;
using StoreDL;
using System;
using System.Linq;

namespace StoreBL
{
    public class InventoryBL : IInventoryBL
    {
        private IRepository _repo;
        private ILocationBL _locationBL;
        public InventoryBL(IRepository repo, ILocationBL locationBL) {
            _repo = repo;
            _locationBL = locationBL;
        }
        public Inventory GetStoreInventory(string nameOfStore)
        {
            List<Inventory> inventories = _repo.GetAllInventories();
                foreach (Inventory inventory in inventories) {
                    if (nameOfStore.Equals(inventory.Location.StoreName)) {
                        return inventory;
                    }
                }
            if (!inventories.Any()) {
                throw new Exception("No inventories found");
            } else {
                throw new Exception ("No matching locations found");
            }
    }

        public List<int> ReplenishInventory(string nameOfStore, int numOfProducts, List<int> productQuantity)
        {
            int i = 0;
            List<Inventory> inventories = _repo.GetAllInventories();
            List<Product> products = _repo.GetAllProducts();
            List<int> updatedInventory = new List<int>();
            foreach (Product item in products)
            {
                if (inventories.Count < numOfProducts) {
                    Location location = _locationBL.GetLocation(nameOfStore);
                    Inventory newInventory = new Inventory(location, item, productQuantity[i]);
                    i++;
                    _repo.UpdateInventory(newInventory);
                } else {
                    foreach (Inventory inventory in inventories) {
                        if (nameOfStore.Equals(inventory.Location.StoreName) && inventory.Product.ItemName.Equals(item.ItemName)) {
                            inventory.Quantity += productQuantity[i];
                            updatedInventory.Add(inventory.Quantity);
                            i++;
                            _repo.UpdateInventory(inventory);
                            }
                        }
                    }
                }
                if (updatedInventory.Any()) {
                    return updatedInventory;
                } else {
                    throw new Exception ("No matching locations found");
                }
        }

        public List<int> SubtractInventory(string nameOfStore, List<int> productQuantity)
        {
            int i = 0;
            List<Inventory> inventories = _repo.GetAllInventories();
            List<Product> products = _repo.GetAllProducts();
            List<int> updatedInventory = new List<int>();
            foreach (Product item in products)
            {
                foreach (Inventory inventory in inventories) {
                    if (nameOfStore.Equals(inventory.Location.StoreName) && inventory.Product.ItemName.Equals(item.ItemName)) {
                        inventory.Quantity -= productQuantity[i];
                        updatedInventory.Add(inventory.Quantity);
                        i++;
                        _repo.UpdateInventory(inventory);
                        }
                    }
                }
                if (updatedInventory.Any()) {
                    return updatedInventory;
                } else {
                    throw new Exception ("No matching locations found");
                }
            }
        }
    }
