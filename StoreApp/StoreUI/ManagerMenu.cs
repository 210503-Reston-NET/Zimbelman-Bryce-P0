using System;
using StoreModels;
using StoreBL;
using System.Collections.Generic;
using System.Linq;
using Serilog;

namespace StoreUI
{
    public class ManagerMenu : IMenu
    {
        private ICustomerBL _customerBL;

        private ILocationBL _locationBL;
        private IProductBL _productBL;
        private IInventoryBL _inventoryBL;
        private IOrderBL _orderBL;
        private ILineItemBL _lineItemBL;

        private IValidationService _validate;

        public ManagerMenu(ICustomerBL customerBL, ILocationBL locationBL, IProductBL productBL, IInventoryBL inventoryBL, IOrderBL orderBL, ILineItemBL lineItemBL, IValidationService validate) {
            _customerBL = customerBL;
            _locationBL = locationBL;
            _productBL = productBL;
            _inventoryBL = inventoryBL;
            _orderBL = orderBL;
            _lineItemBL = lineItemBL;
            _validate = validate;
        }

        public void Start()
        {
            bool repeat = true;
            do
            {
                Console.WriteLine("What would you like to do?\n");
                Console.WriteLine("[1] Add a new customer");
                Console.WriteLine("[2] Search for a customer");
                Console.WriteLine("[3] Add a Location");
                Console.WriteLine("[4] View location inventory");
                Console.WriteLine("[5] View location order history");
                Console.WriteLine("[6] Replenish Inventory");
                Console.WriteLine("[7] View all products");
                Console.WriteLine("[8] Add A Product");
                Console.WriteLine("[0] Go Back");

                // Receives input from user
                string input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        // Exit
                        Log.Information("Go Back to Previous Menu");
                        repeat = false;
                        break;

                    case "1":
                        Log.Information("Add Customer Selected");
                        AddACustomer();
                        break;

                    case "2":
                        Log.Information("Search for specific customer selected");
                        SearchCustomer();
                        break;

                    case "3":
                        Log.Information("Add Location Selected");
                        AddALocation();
                        break;
                    
                    case "4":
                        Log.Information("View Store Inventory Selected");
                        ViewInventory();
                        break;

                    case "5":
                        Log.Information("View Location Order History Selected");
                        ViewLocationOrderHistory();
                        break;
                    
                    case "6":
                        Log.Information("Replenish Store Inventory Selected");
                        ReplenishInventory();
                        break;
                    
                    case "7":
                        Log.Information("View All Products Selected");
                        ViewAllProducts();
                        break;

                    case "8":
                        Log.Information("Add A Product Selected");
                        AddAProduct();
                        break;
                    
                    default:
                        // Invalid Input
                        Console.WriteLine("Please input a valid option");
                        break;
                }
            } while (repeat);
        }

        /// <summary>
        /// UI to view location order history
        /// </summary>
        private void ViewLocationOrderHistory()
        {
            bool repeat = true;
            string locationName = _validate.ValidateString("\nEnter the location you want to view");
            Log.Information("Location name input");
            try
            {
                Location location = _locationBL.GetLocation(locationName);
                List<Order> locationOrders = _orderBL.GetLocationOrders(location.Id);
                do
                {
                    Console.WriteLine("How should the orders be sorted?");
                    Console.WriteLine("[1] Sort by Date (Newest to Oldest)");
                    Console.WriteLine("[2] Sort by Date (Oldest to Newest)");
                    Console.WriteLine("[3] Sort by Cost (Lowest to Highest)");
                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            Log.Information("Sort by Date Ascending Selected");
                            repeat = false;
                            locationOrders.OrderBy(ord => ord.OrderDate).ToList();
                            break;

                        case "2":
                            Log.Information("Sort by Date Descending Selected");
                            repeat = false;
                            locationOrders.OrderByDescending(ord => ord.OrderDate).ToList();
                            break;

                        case "3":
                            Log.Information("Sort by Cost Ascending Seleceted");
                            repeat = false;
                            locationOrders.OrderBy(ord => ord.Total).ToList();
                            break;
                        
                        default:
                            // Invalid Input
                            Console.WriteLine("Please input a valid option");
                            break;
                    }
                } while (repeat);
                foreach (Order order in locationOrders)
                {
                    Customer customer = _customerBL.SearchCustomer(order.CustomerID);
                    List<LineItem> lineItems = _lineItemBL.GetLineItems(order.OrderID);
                    Console.WriteLine($"\nCustomer Name: {customer.FirstName} {customer.LastName} \nLocation Name: {location.StoreName} \nOrder Date: {order.OrderDate}");
                    foreach (LineItem lineItem in lineItems)
                    {
                        List<Product> products = _productBL.GetAllProducts();
                        foreach (Product product in products)
                        {
                            if (product.Id.Equals(lineItem.ProductID)) {
                                Console.WriteLine($"{lineItem.Quantity} {product.ItemName}");
                            }
                        }
                    }
                    Console.WriteLine($"Order Total ${order.Total}\n");
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// UI to view a list of all customers
        /// </summary>
        private void ViewCustomers() {
            try
            {
                List<Customer> customers = _customerBL.GetAllCustomers();
                if (customers.Count == 0) {
                    Console.WriteLine("No customers found");
                } else {
                    foreach (Customer customer in customers) {
                    Console.WriteLine(customer.ToString());
                }   
            }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

            /// <summary>
            /// UI to add a customer
            /// </summary>
            private void AddACustomer() {
                Console.WriteLine("\nEnter the details of the customer you want to add");
                string firstName = _validate.ValidateString("Enter the customer first name: ");
                string lastName = _validate.ValidateString("Enter the customer last name");
                string birthdate = _validate.ValidateString("Enter the customer birthdate (MM/DD/YYYY): ");
                string phoneNumber = _validate.ValidateString("Enter the customer phone number: ");
                string email = _validate.ValidateString("Enter the customer email: ");
                string mailAddress = _validate.ValidateString("Enter the customer mailing address: ");
                Log.Information("Customer information input");
                try
                {
                    Customer newCustomer = new Customer(firstName, lastName, birthdate, phoneNumber, email, mailAddress);
                    Customer createdCustomer = _customerBL.AddCustomer(newCustomer);
                    Console.WriteLine("New Customer Created!\n");
                    Console.WriteLine(createdCustomer.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// UI to add a location
        /// </summary>
        private void AddALocation() {
            Console.WriteLine("\nEnter the details of the location you want to add");
            string name = _validate.ValidateString("Enter the location name: ");
            string address = _validate.ValidateString("Enter the location street address: ");
            string city = _validate.ValidateString("Enter the location city: ");
            string state = _validate.ValidateString("Enter the location state: ");
            Log.Information("Location information input");
            try
            {
                int numOfProducts = _productBL.GetAllProducts().Count;
                Location newLocation = new Location(name, address, city, state);
                Location createdLocation = _locationBL.AddLocation(newLocation);
                Console.WriteLine("New Location Created\n");
                Log.Information("Location created");
                Console.WriteLine(createdLocation.ToString());
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// UI to add a product
        /// </summary>
        private void AddAProduct() {
            Console.WriteLine("\nEnter the details of the product you want to add");
            string itemName = _validate.ValidateString("Enter the product name: ");
            double price = _validate.ValidatePrice("Enter the price of the product: ");
            string description = _validate.ValidateString("Enter a description for the product: ");
            Log.Information("Product information input");
            try {
                Product newProduct = new Product(itemName, price, description);
                Product createdProduct = _productBL.AddProduct(newProduct);
                Console.WriteLine("New Product Created\n");
                Log.Information("Product Created");
                Console.WriteLine(createdProduct.ToString());
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// UI to search for a specific customer
        /// </summary>
        private void SearchCustomer() {
            string firstName = _validate.ValidateString("\nEnter first name of customer you want to view");
            string lastName = _validate.ValidateString("Enter the last name of customer you want to view");
            Log.Information("Customer name input");
            try
            {
                Customer customer = _customerBL.SearchCustomer(firstName, lastName);
                Console.WriteLine(customer.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// UI to view specific store inventory
        /// </summary>
        private void ViewInventory() {
            string storeName = _validate.ValidateString("\nEnter name of store you want to view");
            Log.Information("Location name input");
            try
            {
                List<Product> products = _productBL.GetAllProducts();
                Location location = _locationBL.GetLocation(storeName);
                Inventory inventory = _inventoryBL.GetStoreInventory(location.Id);
                foreach (Product product in products)
                {
                    Console.WriteLine($"{product.ItemName}: {inventory.Quantity}");
                }
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// UI to view a list of all products
        /// </summary>
        private void ViewAllProducts() {
            try
            {
                List<Product> products = _productBL.GetAllProducts();
                if (products.Count == 0) {
                    Console.WriteLine("\nNo products found");
                    Log.Information("No Products Found");
                } else {
                    Console.WriteLine("");
                    foreach (Product product in products) {
                    Console.WriteLine(product.ToString());
                }   
            }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        /// <summary>
        /// UI to replenish specifc store inventory
        /// </summary>
        private void ReplenishInventory() {
            string name = _validate.ValidateString("\nEnter name of store you want to replenish");
            Log.Information("Location name input");
            try
            {
                List<Product> products = _productBL.GetAllProducts();
                List<int> quantity = new List<int>();
                int numOfProducts = products.Count;
                int i = 0;
                foreach (Product product in products)
                {
                    quantity.Add(_validate.ValidateInt($"Enter quantity to add for {product.ItemName}"));
                }
                List<int> inventory = _inventoryBL.ReplenishInventory(name, numOfProducts, quantity);
                Console.WriteLine($"{name} store inventory updated");
                Log.Information("Store Inventory Updated");
                foreach (Product product in products) {
                    Console.WriteLine($"{product.ItemName}: {inventory[i]}");
                    i++;
                }
                    Console.WriteLine("");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
        }
    }
}