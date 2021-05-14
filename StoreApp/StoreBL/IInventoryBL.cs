using System.Collections.Generic;
using StoreModels;
namespace StoreBL
{
    public interface IInventoryBL
    {
         List<int> ReplenishInventory(string nameOfStore, int numOfProducts, List<int> productQuantity);

         List<int> SubtractInventory(string nameOfStore, List<int> quantity);
         Inventory GetStoreInventory(string nameOfStore);
    }
}