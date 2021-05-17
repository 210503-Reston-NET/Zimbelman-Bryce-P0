using System.Collections.Generic;
using StoreModels;
using StoreDL;
using System;
using System.Linq;
using Serilog;

namespace StoreBL
{
    /// <summary>
    /// Business Logic class for inventory model
    /// </summary>
    public class InventoryBL : IInventoryBL
    {
        private IRepository _repo;
        private ILocationBL _locationBL;
        private IProductBL _productBL;
        public InventoryBL(IRepository repo, ILocationBL locationBL, IProductBL productBL) {
            _repo = repo;
            _locationBL = locationBL;
            _productBL = productBL;
        }
        public Inventory GetStoreInventory(int locationId)
        {
            List<Inventory> inventories = _repo.GetAllInventories();
                foreach (Inventory inventory in inventories) {
                    if (locationId.Equals(inventory.LocationID)) {
                        Log.Information("BL sent inventory to UI");
                        return inventory;
                    }
                }
            if (!inventories.Any()) {
                Log.Information("No inventories found");
                throw new Exception("No inventories found");
            } else {
                Log.Information("No matching locations found");
                throw new Exception ("No matching locations found");
            }
    }

        public List<int> ReplenishInventory(string nameOfStore, int numOfProducts, List<int> productQuantity)
        {
            int i = 0;
            List<Inventory> inventories = _repo.GetAllInventories();
            List<Product> products = _repo.GetAllProducts();
            List<int> updatedInventory = new List<int>();
            Log.Information("BL attempt to retrive specific location from DL");
            Location location = _locationBL.GetLocation(nameOfStore);
            bool emptyInventory = false;
            bool inventoryUpdated = false;
            foreach (Product item in products)
            {
                if (!inventories.Any()) {
                    emptyInventory = true;
                    Inventory newInventory = new Inventory(location.Id, item.Id, productQuantity[i]);
                    updatedInventory.Add(productQuantity[i]);
                    i++;
                    Log.Information("BL sent new inventory to DL");
                    _repo.AddInventory(newInventory, location, item);
                    inventoryUpdated = true;
                }
                foreach (Inventory inventory in inventories) {
                    if (inventory.LocationID.Equals(location.Id) && inventory.ProductID.Equals(item.Id) && !emptyInventory) {
                        inventory.Quantity += productQuantity[i];
                        updatedInventory.Add(inventory.Quantity);
                        i++;
                        Log.Information("BL sent updated inventory to DL");
                        _repo.UpdateInventory(inventory, location, item);
                        inventoryUpdated = true;
                        }
                    }
                    if (!emptyInventory && !inventoryUpdated) {
                        Inventory newInventory = new Inventory(location.Id, item.Id, productQuantity[i]);
                        updatedInventory.Add(productQuantity[i]);
                        i++;
                        Log.Information("BL sent new inventory to DL");
                        _repo.AddInventory(newInventory, location, item);
                    }
                }
                Log.Information("BL sent updated inventory to UI");
                return updatedInventory;
            }

        public List<int> SubtractInventory(string nameOfStore, List<int> productQuantity)
        {
            int i = 0;
            List<Inventory> inventories = _repo.GetAllInventories();
            List<Product> products = _repo.GetAllProducts();
            List<int> updatedInventory = new List<int>();
            Log.Information("BL attempt to retrieve specific location from DL");
            Location location = _locationBL.GetLocation(nameOfStore);
            foreach (Product item in products)
            {
                foreach (Inventory inventory in inventories) {
                    if (inventory.LocationID.Equals(location.Id) && inventory.ProductID.Equals(item.Id)) {
                        inventory.Quantity -= productQuantity[i];
                        updatedInventory.Add(inventory.Quantity);
                        i++;
                        Log.Information("BL sent updated inventory to DL");
                        _repo.UpdateInventory(inventory, location, item);
                        }
                    }
                }
                Log.Information("BL sent updated inventory to UI");
                return updatedInventory;
            }
        }
    }
