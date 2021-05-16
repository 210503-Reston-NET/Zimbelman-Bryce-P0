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
                        SearchCustomer();
                        break;

                    case "3":
                        AddALocation();
                        break;
                    
                    case "4":
                        ViewInventory();
                        break;

                    case "5":
                        ViewLocationOrderHistory();
                        break;
                    
                    case "6":
                        ReplenishInventory();
                        break;
                    
                    case "7":
                        ViewAllProducts();
                        break;
                    
                    default:
                        // Invalid Input
                        Console.WriteLine("Please input a valid option");
                        break;
                }
            } while (repeat);
        }

        private void ViewLocationOrderHistory()
        {
            string locationName = _validate.ValidateString("\nEnter the location you want to view");
            try
            {
                Location location = _locationBL.GetLocation(locationName);
                List<Order> locationOrders = _orderBL.GetLocationOrders(location.Id);
                foreach (Order order in locationOrders)
                {
                    Customer customer = _customerBL.SearchCustomer(order.CustomerID);
                    List<LineItem> lineItems = _lineItemBL.GetLineItems(order.OrderID);
                    Console.WriteLine($"\nCustomer Name: {customer.FirstName} {customer.LastName} \nLocation Name: {location.StoreName}");
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
                Console.WriteLine("\nEnter the details of the customer you want to add");
                string firstName = _validate.ValidateString("Enter the customer first name: ");
                string lastName = _validate.ValidateString("Enter the customer last name");
                string birthdate = _validate.ValidateString("Enter the customer birthdate (MM/DD/YYYY): ");
                string phoneNumber = _validate.ValidateString("Enter the customer phone number: ");
                string email = _validate.ValidateString("Enter the customer email: ");
                string mailAddress = _validate.ValidateString("Enter the customer mailing address: ");
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

        private void AddALocation() {
            Console.WriteLine("\nEnter the details of the location you want to add");
            string name = _validate.ValidateString("Enter the location name: ");
            string address = _validate.ValidateString("Enter the location street address: ");
            string city = _validate.ValidateString("Enter the location city: ");
            string state = _validate.ValidateString("Enter the location state: ");
            int numOfProducts = _productBL.GetAllProducts().Count;
            try
            {
                Location newLocation = new Location(name, address, city, state);
                Location createdLocation = _locationBL.AddLocation(newLocation);
                Console.WriteLine("New Location Created\n");
                Console.WriteLine(createdLocation.ToString());
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AddAProduct() {
            Console.WriteLine("\nEnter the details of the product you want to add");
            string itemName = _validate.ValidateString("Enter the product name: ");
            double price = _validate.ValidateDouble("Enter the price of the product: ");
            string description = _validate.ValidateString("Enter a description for the product: ");
            try {
                Product newProduct = new Product(itemName, price, description);
                Product createdProduct = _productBL.AddProduct(newProduct);
                Console.WriteLine("New Product Created\n");
                Console.WriteLine(createdProduct.ToString());
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void SearchCustomer() {
            string firstName = _validate.ValidateString("\nEnter first name of customer you want to view");
            string lastName = _validate.ValidateString("Enter the last name of customer you want to view");
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

        private void ViewInventory() {
            string storeName = _validate.ValidateString("\nEnter name of store you want to view");
            Location location = _locationBL.GetLocation(storeName);
            List<Product> products = _productBL.GetAllProducts();
            try
            {
                // First index is numOfProducts
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

        private void ViewAllProducts() {
            List<Product> products = _productBL.GetAllProducts();
                if (products.Count == 0) {
                    Console.WriteLine("\nNo products found");
                } else {
                    Console.WriteLine("");
                    foreach (Product product in products) {
                    Console.WriteLine(product.ToString());
                }   
            }
        }
        
        private void ReplenishInventory() {
            string name = _validate.ValidateString("\nEnter name of store you want to replenish");
            List<Product> products = _productBL.GetAllProducts();
            List<int> quantity = new List<int>();
            int numOfProducts = products.Count;
            int i = 0;
            foreach (Product product in products)
            {
                quantity.Add(_validate.ValidateInt($"Enter quantity to add for {product.ItemName}"));
            }
            try
            {
                List<int> inventory = _inventoryBL.ReplenishInventory(name, numOfProducts, quantity);
                Console.WriteLine($"{name} store inventory updated");
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