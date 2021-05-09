using System;
using StoreModels;
using StoreBL;
using System.Collections.Generic;

namespace StoreUI
{
    public class ManagerMenu : IMenu
    {
        private ICustomerBL _customerBL;

        private IValidationService _validate;

        public ManagerMenu(ICustomerBL customerBL, IValidationService validate) {
            _customerBL = customerBL;
            _validate = validate;
        }

        public void Start()
        {
            bool repeat = true;
            do
            {
                Console.WriteLine("What would you like to do?\n");
                Console.WriteLine("[1] Add a new customer");
                Console.WriteLine("[2] Get all customers");
                Console.WriteLine("[3] Search for a customer");
                Console.WriteLine("[4] View location inventory");
                Console.WriteLine("[5] Replenish Inventory");
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
                        // TODO: Display location inventory
                        ViewInventory();
                        break;
                    
                    case "5":
                        // TODO: Replenish Inventory
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
                string phoneNumber = _validate.ValidateString("Enter the customer phoneNumber: ");
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

        private void SearchCustomer() {
            // TODO: Search and return customer
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
            // TODO: Implement store search and view inventory
            
        }
    }
}