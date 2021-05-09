using System;
using System.Collections.Generic;
using StoreModels;
using StoreBL;
using StoreDL;
namespace StoreUI
{
    public class MainMenu : IMenu
    {
        private IMenu submenu;
        public void Start() {
            bool repeat = true;

            do
            {
                Console.WriteLine("Welcome to Mocha Moment!");
                Console.WriteLine("Are you a customer or employee?");
                Console.WriteLine("[1] Customer");
                Console.WriteLine("[2] Employee");
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
                        submenu = MenuFactory.GetMenu("customer");
                        submenu.Start();
                        break;
                    
                    case "2":
                        submenu = MenuFactory.GetMenu("manager");
                        submenu.Start();
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