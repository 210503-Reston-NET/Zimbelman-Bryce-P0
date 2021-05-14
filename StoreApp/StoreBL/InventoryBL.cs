using System.Collections.Generic;
using StoreModels;
using StoreDL;
using System;

namespace StoreBL
{
    public class InventoryBL : IInventoryBL
    {
        private IRepository _repo;
        public InventoryBL(IRepository repo) {
            _repo = repo;
        }
        public Inventory GetStoreInventory(string nameOfStore)
        {
            List<Inventory> inventories = _repo.GetAllInventories();
                foreach (Inventory inventory in inventories) {
                    if (nameOfStore.Equals(inventory.Location.StoreName)) {
                        return inventory;
                    }
                }
                throw new Exception ("No matching locations found");
    }

        public List<int> ReplenishInventory(string nameOfStore, int numOfProducts, List<int> productQuantity)
        {
            int i = 0;
            List<Inventory> inventories = _repo.GetAllInventories();
            List<Product> products = _repo.GetAllProducts();
            List<int> updatedInventory = new List<int>();
            foreach (Product item in products)
            {
                foreach (Inventory inventory in inventories) {
                    if (nameOfStore.Equals(inventory.Location.StoreName)) {
                        if (inventory.Product.ItemName.Equals(item.ItemName)) {
                            inventory.Quantity += productQuantity[i];
                            updatedInventory.Add(inventory.Quantity);
                            _repo.UpdateInventory(inventory);
                        }
                        return updatedInventory;
                    }
                    i++;
                }
            }
            throw new Exception ("No matching locations found");
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
                    if (nameOfStore.Equals(inventory.Location.StoreName)) {
                        if (inventory.Product.ItemName.Equals(item.ItemName)) {
                            inventory.Quantity -= productQuantity[i];
                            updatedInventory.Add(inventory.Quantity);
                            _repo.UpdateInventory(inventory);
                        }
                        return updatedInventory;
                    }
                    i++;
                }
            }
            throw new Exception ("No matching locations found");
        }
    }
}
