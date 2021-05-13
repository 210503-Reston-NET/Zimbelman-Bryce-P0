using System;
using StoreModels;
using StoreBL;
using System.Collections.Generic;

namespace StoreUI
{
    public class CustomerMenu : IMenu
    {
        private ICustomerBL _customerBL;
        private IProductBL _productBL;
        private ILocationBL _locationBL;
        private IOrderBL _orderBL;

        private IValidationService _validate;

        public CustomerMenu(ICustomerBL customerBL, IProductBL productBL, IOrderBL orderBL, ILocationBL locationBL, IValidationService validate) {
            _customerBL = customerBL;
            _productBL = productBL;
            _orderBL = orderBL;
            _locationBL = locationBL;
            _validate = validate;
        }

        public void Start() {
            bool repeat = true;
            do {
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("[1] Place an order");
            Console.WriteLine("[2] Add a new customer");
            Console.WriteLine("[3] Display placed order details");
            Console.WriteLine("[4] View order history");
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
                        PlaceOrder();
                        break;

                    case "2":
                        AddACustomer();
                        break;
                    
                    case "3":
                        // TODO: Display an order
                        break;
                    
                    case "4":
                        // TODO: Display order history
                        DisplayOrderHistory();
                        break;

                    default:
                        // Invalid Input
                        Console.WriteLine("Please input a valid option");
                        break;
                }
            } while (repeat);
        }

        private void AddACustomer() {
            Console.WriteLine("Enter the details of the customer you want to add");
            string firstName = _validate.ValidateString("Enter the customer first name: ");
            string lastName = _validate.ValidateString("Enter the customer last name");
            string birthdate = _validate.ValidateString("Enter the customer birthdate (MM/DD/YYYY): ");
            string phoneNumber = _validate.ValidateString("Enter the customer phone number: ");
            string email = _validate.ValidateString("Enter the customer email: ");
            string mailAddress = _validate.ValidateString("Enter the customer mailing address: ");
            try
            {
                Customer newCustomer = new Customer(firstName, lastName,  birthdate, phoneNumber, email, mailAddress);
                Customer createdCustomer = _customerBL.AddCustomer(newCustomer);
                Console.WriteLine("New Customer Created!");
                Console.WriteLine(createdCustomer.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DisplayOrderHistory() {
            string firstName = _validate.ValidateString("Enter your first name: ");
            string lastName = _validate.ValidateString("Enter your last name: ");
            List<Product> products = _productBL.GetAllProducts();
            List<string> productNames = new List<string>();
            foreach (Product item in products) {
                productNames.Add(item.ItemName);
            }
            try {
                int i = 0;
                List<Order> orders = _orderBL.GetCustomerOrders(firstName, lastName);
                foreach (Order item in orders)
                {
                    Console.WriteLine(item.ToString());
                    foreach (int product in item.Quantity)
                    {
                        Console.WriteLine($"{item.Quantity[i]} {productNames[i]}");
                        i++;
                    }
                    double total = _productBL.GetTotal(item.Quantity);
                    Console.WriteLine($"Order Total ${total}");
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            } 
        }
        private void PlaceOrder() {
            List<Product> products = _productBL.GetAllProducts();
            List<int> quantity = new List<int>();
            List<string> lineItems = new List<string>();
            bool orderRepeat = true;
            string locationName = _validate.ValidateString("Enter name of location to shop at: ");
            try {
                Location location = _locationBL.GetLocation(locationName);
                string firstName = _validate.ValidateString("Enter your first name: ");
                string lastName = _validate.ValidateString("Enter your last name: ");
                try
                {
                    Customer customer = _customerBL.SearchCustomer(firstName, lastName);
                    Console.WriteLine("Enter the amount desired of each item");
                    foreach (Product product in products) {
                        quantity.Add(_validate.ValidateInt($"{product.ItemName}: "));
                        lineItems.Add(product.ItemName);
                    }
                    double total = _productBL.GetTotal(quantity);
                    do
                    {
                        Console.WriteLine($"The total amount of your order will be ${total} \nWould you like to proceed? (Y/N)");
                        string orderInput = Console.ReadLine();
                        switch (orderInput)
                        {
                            case "Y":
                                orderRepeat = false;
                                try {
                                    Order newOrder = new Order(location, customer, lineItems, total, quantity);
                                    _locationBL.SubtractInventory(locationName, quantity);
                                    _orderBL.AddOrder(newOrder);
                                    Console.WriteLine("Order Sucessfully placed");
                                } catch (Exception ex) {
                                    Console.WriteLine(ex.Message);
                                }
                                break;

                            case "N":
                                orderRepeat = false;
                                PlaceOrder();
                                break;
                    
                            default:
                                // Invalid Input
                                Console.WriteLine("Please input a valid option");
                                break;
                        }
                    } while (orderRepeat);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            
        }
    }
}