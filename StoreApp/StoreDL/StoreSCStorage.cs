using System.Collections.Generic;
using StoreModels;
namespace StoreDL
{
    /// <summary>
    /// Store static collection storage
    /// </summary>
    public class StoreSCStorage
    {
   //     public static List<Order> Orders = new List<Order>() {
     //       new Order();
     //   };
        public static List<Customer> Customers = new List<Customer>() {
            new Customer("Bryce Zimbelman", "10-15-1994", "(920) 264-4500", "bryce.zimbelman@revature.net", "1514 Canyon Dr")
        };
    }
}