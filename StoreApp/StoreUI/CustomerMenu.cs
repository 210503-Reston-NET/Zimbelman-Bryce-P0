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
            try {
                List<Order> orders = _orderBL.GetCustomerOrders(firstName, lastName);
                foreach (Order order in orders)
                {
                    List<int> quantity = new List<int>();
                    List<LineItem> lineItems = new List<LineItem>();
                    int orderID = order.OrderID;
                    lineItems = _lineItemBL.GetLineItems(orderID);
                    Console.WriteLine(order.ToString());
                    foreach (LineItem lineItem in lineItems)
                    {
                        Console.WriteLine(lineItem.ToString());
                        quantity.Add(lineItem.Quantity);
                    }
                    double total = _productBL.GetTotal(quantity);
                    Console.WriteLine($"Order Total ${total}");
                    }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            } 
        }
        private void PlaceOrder() {
            bool orderRepeat = true;
            int i = 0;
            List<Product> products = _productBL.GetAllProducts();
            List<int> quantity = new List<int>();
            string locationName = _validate.ValidateString("Enter name of location to shop at: ");
            int orderID = _orderBL.GetAllOrders().Count + 1;
            try {
                Location location = _locationBL.GetLocation(locationName);
                string firstName = _validate.ValidateString("Enter your first name: ");
                string lastName = _validate.ValidateString("Enter your last name: ");
                try
                {
                    Customer customer = _customerBL.SearchCustomer(firstName, lastName);
                    Console.WriteLine("Enter the amount desired of each item");
                    foreach (Product item in products)
                    {
                        quantity.Add(_validate.ValidateInt($"{item.ItemName}: "));
                        LineItem lineItem = new LineItem(item, quantity[i], orderID);
                        _lineItemBL.AddLineItem(lineItem);
                        i++;
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
                                    Order newOrder = new Order(location, customer, orderID, total);
                                    _inventoryBL.SubtractInventory(locationName, quantity);
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