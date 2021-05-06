using System;
using System.Collections.Generic;
using StoreModels;
using StoreBL;
using StoreDL;
namespace StoreUI
{
    public class MainMenu : IMenu
    {
        private ICustomerBL _customerBL = new CustomerBL(new RepoSC());
        public void Start() {
            bool repeat = true;

            do
            {
                Console.WriteLine("Welcome to Mocha Moment!");
                Console.WriteLine("What would you like to do?\n");
                Console.WriteLine("[1] Place an order");
                Console.WriteLine("[2] Add a new customer");
                Console.WriteLine("[3] Display order details");
                Console.WriteLine("[4] View order history");
                Console.WriteLine("[5] Search for a customer (Manager Only)");
                Console.WriteLine("[6] View location inventory (Manager Only)");
                Console.WriteLine("[7] Replenish Inventory (Manager Only)");
                Console.WriteLine("[0] Exit");

                // Receives input from user
                string input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        // Exit
                        Console.WriteLine("Goodbye!");
                        repeat = false;
                        break;
                    
                    case "1":
                        // TODO: Place an order
                        break;

                    case "2":
                        // TODO: Add a customer
                        break;
                    
                    case "3":
                        // TODO: Display an order
                        break;
                    
                    case "4":
                        // TODO: Display order history
                        break;

                    case "5":
                        // TODO: Search for a customer
                        List<Customer> customers = _customerBL.GetAllCustomers();
                        foreach (Customer customer in customers) {
                            Console.WriteLine(customer.ToString());
                        }
                        break;
                    
                    case "6":
                        // TODO: Display location inventory
                        break;
                    
                    case "7":
                        // TODO: Replenish Inventory
                        break;

                    default:
                    // Invalid Input
                    Console.WriteLine("Please input a valid option");
                    break;
                }
            } while (repeat);
        }
    }
}