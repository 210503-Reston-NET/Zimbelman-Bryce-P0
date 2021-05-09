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
        private const string filePath = "../StoreDL/Customer.json";

        /// <summary>
        /// Hold string versions of my objects
        /// </summary>
        private string jsonString;

        public Customer AddCustomer(Customer customer) {
            List<Customer> customersFromFile = GetAllCustomers();
            customersFromFile.Add(customer);
            jsonString = JsonSerializer.Serialize(customersFromFile);
            File.WriteAllText(filePath, jsonString);
            return customer;
        }

        public List<Customer> GetAllCustomers() {
            try
            {
                jsonString = File.ReadAllText(filePath);
            }
            catch (Exception ex) {
                // Logging to the console
                Console.WriteLine(ex.Message);
                return new List<Customer>();
            }
            return JsonSerializer.Deserialize<List<Customer>>(jsonString);
        }

        public Customer GetCustomer(Customer customer) {
            return GetAllCustomers().FirstOrDefault(custo => custo.Equals(customer));
        }
    }
}