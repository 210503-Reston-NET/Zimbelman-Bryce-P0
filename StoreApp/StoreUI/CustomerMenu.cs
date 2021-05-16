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
        private ILineItemBL _lineItemBL;
        private IInventoryBL _inventoryBL;

        private IValidationService _validate;

        public CustomerMenu(ICustomerBL customerBL, IProductBL productBL, IOrderBL orderBL, ILocationBL locationBL, ILineItemBL lineItemBL, IInventoryBL inventoryBL, IValidationService validate) {
            _customerBL = customerBL;
            _productBL = productBL;
            _orderBL = orderBL;
            _locationBL = locationBL;
            _lineItemBL = lineItemBL;
            _inventoryBL = inventoryBL;
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
                        OrderSearch();
                        break;
                    
                    case "4":
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
            Console.WriteLine("\nEnter the details of the customer you want to add");
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
                Console.WriteLine("New Customer Created!\n");
                Console.WriteLine(createdCustomer.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DisplayOrderHistory() {
            string firstName = _validate.ValidateString("\nEnter your first name: ");
            string lastName = _validate.ValidateString("Enter your last name: ");
            Customer customer = _customerBL.SearchCustomer(firstName, lastName);
            try {
                List<Order> orders = _orderBL.GetCustomerOrders(customer.Id);
                foreach (Order order in orders)
                {
                    int orderId = order.OrderID;
                    List<LineItem> lineItems = _lineItemBL.GetLineItems(orderId);
                    Location location = _locationBL.GetLocation(order.LocationID);
                    Console.WriteLine($"\nCustomer Name: {firstName} {lastName} \nLocation Name{location.StoreName}");
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
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            } 
        }

        private void OrderSearch() {
            int orderId = _validate.ValidateInt("\nEnter Order ID: ");
            try
            {
                Order customerOrder = _orderBL.ViewOrder(orderId);
                Location location = _locationBL.GetLocation(customerOrder.LocationID);
                Customer customer = _customerBL.SearchCustomer(customerOrder.CustomerID);
                List<LineItem> lineItems = _lineItemBL.GetLineItems(orderId);
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
                Console.WriteLine($"Order Total ${customerOrder.Total}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        private void PlaceOrder() {
            bool orderRepeat = true;
            int i = 0;
            List<Product> products = _productBL.GetAllProducts();
            List<int> quantity = new List<int>();
            string locationName = _validate.ValidateString("\nEnter name of location to shop at: ");
            int orderID = _orderBL.GetAllOrders().Count + 1;
            try {
                Location location = _locationBL.GetLocation(locationName);
                string firstName = _validate.ValidateString("Enter your first name: ");
                string lastName = _validate.ValidateString("Enter your last name: ");
                try
                {
                    Customer customer = _customerBL.SearchCustomer(firstName, lastName);
                    Console.WriteLine("Enter the amount desired of each item");
                    Order newOrder = new Order(location.Id, customer.Id, orderID, 0);
                    _orderBL.AddOrder(newOrder, location, customer);
                    foreach (Product item in products)
                    {
                        quantity.Add(_validate.ValidateInt($"{item.ItemName}: "));
                        LineItem lineItem = new LineItem(item.Id, quantity[i], orderID);
                        _lineItemBL.AddLineItem(lineItem, item);
                        i++;
                    }
                    double total = _productBL.GetTotal(quantity);
                    do
                    {
                        Console.WriteLine($"\nThe total amount of your order will be ${total} \nWould you like to proceed? (Y/N)");
                        string orderInput = Console.ReadLine();
                        switch (orderInput)
                        {
                            case "Y":
                                orderRepeat = false;
                                try {
                                    newOrder.Total = total;
                                    _inventoryBL.SubtractInventory(locationName, quantity);
                                    _orderBL.UpdateOrder(newOrder, location, customer);
                                    Console.WriteLine($"Order Sucessfully placed \nOrder ID: {newOrder.OrderID}\n");
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