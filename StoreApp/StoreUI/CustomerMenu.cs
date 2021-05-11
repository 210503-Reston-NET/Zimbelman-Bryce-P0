using System;
using StoreModels;
using StoreBL;
using System.Collections.Generic;

namespace StoreUI
{
    public class CustomerMenu : IMenu
    {
        private ICustomerBL _customerBL;

        private IValidationService _validate;

        public CustomerMenu(ICustomerBL customerBL, IValidationService validate) {
            _customerBL = customerBL;
            _validate = validate;
        }

        public void Start() {
            bool repeat = true;
            do {
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("[1] Place an order");
            Console.WriteLine("[2] Add a new customer");
            Console.WriteLine("[3] Display order details");
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
                        // TODO: Place an order
                        PlaceOrder();
                        break;

                    case "2":
                        // TODO: Add a customer
                        AddACustomer();
                        break;
                    
                    case "3":
                        // TODO: Display an order
                        break;
                    
                    case "4":
                        // TODO: Display order history
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
        private void PlaceOrder() {
            // Implement place order
        }
    }
}