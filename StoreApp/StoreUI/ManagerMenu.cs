using System;
using StoreModels;
using StoreBL;
using System.Collections.Generic;

namespace StoreUI
{
    public class ManagerMenu : IMenu
    {
        private ICustomerBL _customerBL;

        private ILocationBL _locationBL;
        private IProductBL _productBL;

        private IValidationService _validate;

        public ManagerMenu(ICustomerBL customerBL, ILocationBL locationBL, IProductBL productBL,IValidationService validate) {
            _customerBL = customerBL;
            _locationBL = locationBL;
            _productBL = productBL;
            _validate = validate;
        }

        public void Start()
        {
            bool repeat = true;
            do
            {
                Console.WriteLine("What would you like to do?\n");
                Console.WriteLine("[1] Add a new customer");
                Console.WriteLine("[2] View all customers");
                Console.WriteLine("[3] Search for a customer");
                Console.WriteLine("[4] Add a Location");
                Console.WriteLine("[5] View location inventory");
                Console.WriteLine("[6] Replenish Inventory");
                Console.WriteLine("[7] Add a new product");
                Console.WriteLine("[8] View all products");
                Console.WriteLine("[0] Go Back");

                // Receives input from user
                string input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        // Exit
                        repeat = false;
                        break;

                    case "1":
                        AddACustomer();
                        break;

                    case "2":
                        ViewCustomers();
                        break;

                    case "3":
                        SearchCustomer();
                        break;

                    case "4":
                        AddALocation();
                        break;
                    
                    case "5":
                        ViewInventory();
                        break;
                    
                    case "6":
                        ReplenishInventory();
                        break;

                    case "7":
                        AddAProduct();
                        break;
                    
                    case "8":
                        ViewAllProducts();
                        break;
                    
                    default:
                        // Invalid Input
                        Console.WriteLine("Please input a valid option");
                        break;
                }
            } while (repeat);
        }
            private void ViewCustomers() {
                List<Customer> customers = _customerBL.GetAllCustomers();
                if (customers.Count == 0) {
                    Console.WriteLine("No customers found");
                } else {
                    foreach (Customer customer in customers) {
                    Console.WriteLine(customer.ToString());
                }   
            }
        }

            private void AddACustomer() {
                Console.WriteLine("Enter the details of the customer you want to add");
                string name = _validate.ValidateString("Enter the customer name: ");
                string birthdate = _validate.ValidateString("Enter the customer birthdate (MM/DD/YYYY): ");
                string phoneNumber = _validate.ValidateString("Enter the customer Phone Number: ");
                string email = _validate.ValidateString("Enter the customer email: ");
                string mailAddress = _validate.ValidateString("Enter the customer mailing address: ");
                try
                {
                    Customer newCustomer = new Customer(name, birthdate, phoneNumber, email, mailAddress);
                    Customer createdCustomer = _customerBL.AddCustomer(newCustomer);
                    Console.WriteLine("New Customer Created!");
                    Console.WriteLine(createdCustomer.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
            }
        }

        private void AddALocation() {
            Console.WriteLine("Enter the details of the location you want to add");
            string name = _validate.ValidateString("Enter the location name: ");
            string address = _validate.ValidateString("Enter the location street address: ");
            string city = _validate.ValidateString("Enter the location city: ");
            string state = _validate.ValidateString("Enter the location state: ");
            int numOfProducts = _productBL.GetAllProducts().Count;
            try
            {
                Location newLocation = new Location(name, address, city, state, numOfProducts, new List<int>());
                Location createdLocation = _locationBL.AddLocation(newLocation);
                Console.WriteLine("New Location Created");
                Console.WriteLine(createdLocation.ToString());
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AddAProduct() {
            Console.WriteLine("Enter the details of the product you want to add");
            string itemName = _validate.ValidateString("Enter the product name: ");
            double price = _validate.ValidateDouble("Enter the price of the product: ");
            string description = _validate.ValidateString("Enter a description for the product: ");
            try {
                Product newProduct = new Product(itemName, price, description);
                Product createdProduct = _productBL.AddProduct(newProduct);
                Console.WriteLine("New Product Created");
                Console.WriteLine(createdProduct.ToString());
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void SearchCustomer() {
            string name = _validate.ValidateString("Enter name of customer you want to view");
            try
            {
                Customer customer = _customerBL.SearchCustomer(name);
                Console.WriteLine(customer.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ViewInventory() {
            string name = _validate.ValidateString("Enter name of store you want to view");
            List<Product> products = _productBL.GetAllProducts();
            int i = 0;
            try
            {
                // First index is numOfProducts
                List<int> inventory = _locationBL.GetStoreInventory(name);
                foreach (Product product in products)
                {
                    Console.WriteLine($"{product.ItemName}: {inventory[i]}");
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ViewAllProducts() {
            // TODO: Implement view all products
            List<Product> products = _productBL.GetAllProducts();
                if (products.Count == 0) {
                    Console.WriteLine("No products found");
                } else {
                    foreach (Product product in products) {
                    Console.WriteLine(product.ToString());
                }   
            }
        }
        
        private void ReplenishInventory() {
            string name = _validate.ValidateString("Enter name of store you want to replenish");
            List<Product> products = _productBL.GetAllProducts();
            List<int> quantity = new List<int>();
            int numOfProducts = products.Count;
            int i = 0;
            foreach (Product product in products)
            {
                quantity.Add(_validate.ValidateInt($"Enter quantity for {product.ItemName}"));
            }
            try
            {
                List<int> inventory = _locationBL.ReplenishInventory(name, numOfProducts, quantity);
                Console.WriteLine($"{name} store inventory updated");
                foreach (Product product in products) {
                    Console.WriteLine($"{product.ItemName}: {quantity[i]}");
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}