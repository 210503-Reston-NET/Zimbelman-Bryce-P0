using System.Collections.Generic;
using StoreModels;
using System.IO;
using System.Text.Json;
using System;
using System.Linq;

namespace StoreDL
{

    /// <summary>
    /// Repo implementation but store it in a file
    /// </summary>
    public class RepoFile : IRepository
    {
        private const string customerFilePath = "../StoreDL/Customers.json";
        private const string locationFilePath = "../StoreDL/Locations.json";
        private const string productFilePath = "../StoreDL/Products.json";
        private const string orderFilePath = "../StoreDL/Orders.json";
        private const string lineItemFilePath = "../StoreDL/LineItems.json";
        private const string inventoryFilePath = "../StoreDL/Inventory.json";

        /// <summary>
        /// Hold string versions of my objects
        /// </summary>
        private string jsonString;

        public Customer AddCustomer(Customer customer) {
            List<Customer> customersFromFile = GetAllCustomers();
            customersFromFile.Add(customer);
            jsonString = JsonSerializer.Serialize(customersFromFile);
            File.WriteAllText(customerFilePath, jsonString);
            return customer;
        }

        public List<Customer> GetAllCustomers() {
            try
            {
                jsonString = File.ReadAllText(customerFilePath);
            }
            catch (Exception ex) {
                // Logging to the console
                Console.WriteLine(ex.Message);
                return new List<Customer>();
            }
            return JsonSerializer.Deserialize<List<Customer>>(jsonString);
        }

        public List<Location> GetAllLocations() {
            try {
                jsonString = File.ReadAllText(locationFilePath);
            }
            catch (Exception ex) {
                // Logging to the console
                Console.WriteLine(ex.Message);
                return new List<Location>();
            }
            return JsonSerializer.Deserialize<List<Location>>(jsonString);
        }

        public Customer GetCustomer(Customer customer) {
            return GetAllCustomers().FirstOrDefault(custo => custo.Equals(customer));
        }

        public Location AddLocation(Location location)
        {
            List<Location> locationsFromFile = GetAllLocations();
            locationsFromFile.Add(location);
            jsonString = JsonSerializer.Serialize(locationsFromFile);
            File.WriteAllText(locationFilePath, jsonString);
            return location;
        }

        public Location GetLocation(Location location)
        {
            return GetAllLocations().FirstOrDefault(loca => loca.Equals(location));
        }

        public Product AddProduct(Product product)
        {
            List<Product> productsFromFile = GetAllProducts();
            productsFromFile.Add(product);
            jsonString = JsonSerializer.Serialize(productsFromFile);
            File.WriteAllText(productFilePath, jsonString);
            return product;
        }

        public Product GetProduct(Product product)
        {
            return GetAllProducts().FirstOrDefault(prod => prod.Equals(product));
        }

        public List<Product> GetAllProducts()
        {
            try {
                jsonString = File.ReadAllText(productFilePath);
            }
            catch (Exception ex) {
                // Logging to the console
                Console.WriteLine(ex.Message);
                return new List<Product>();
            }
            return JsonSerializer.Deserialize<List<Product>>(jsonString);
        }

        public Inventory UpdateInventory(Inventory inventory)
        {
            List<Inventory> inventories = GetAllInventories();
            foreach (Inventory inven in inventories)
            {
                if (inventory.Location.StoreName.Equals(inven.Location.StoreName)) {
                    inventories.Remove(inven);
                    inventories.Add(inventory);
                    jsonString = JsonSerializer.Serialize(inventories);
                    File.WriteAllText(locationFilePath, jsonString);
                }
            }
            return inventory;
        }

        public Order AddOrder(Order order)
        {
            List<Order> ordersFromFile = GetAllOrders();
            ordersFromFile.Add(order);
            jsonString = JsonSerializer.Serialize(ordersFromFile);
            File.WriteAllText(orderFilePath, jsonString);
            return order;
        }

        public Order ViewOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllOrders()
        {
            try {
                jsonString = File.ReadAllText(orderFilePath);
            }
            catch (Exception ex) {
                // Logging to the console
                Console.WriteLine(ex.Message);
                return new List<Order>();
            }
            return JsonSerializer.Deserialize<List<Order>>(jsonString);
        }

        public List<LineItem> GetAllLineItems()
        {
            try {
                jsonString = File.ReadAllText(lineItemFilePath);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return new List<LineItem>();
            }
            return JsonSerializer.Deserialize<List<LineItem>>(jsonString);
        }

        public LineItem AddLineItem(LineItem lineItem)
        {
            List<LineItem> lineItemsFromFile = GetAllLineItems();
            lineItemsFromFile.Add(lineItem);
            jsonString = JsonSerializer.Serialize(lineItemsFromFile);
            File.WriteAllText(lineItemFilePath, jsonString);
            return lineItem;
        }

        public LineItem GetLineItem(LineItem lineItem)
        {
            return GetAllLineItems().FirstOrDefault(li => li.Equals(lineItem));
        }

        public List<Inventory> GetAllInventories()
        {
            try
            {
                jsonString = File.ReadAllText(inventoryFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Inventory>();
            }
            return JsonSerializer.Deserialize<List<Inventory>>(jsonString);
        }
    }
}