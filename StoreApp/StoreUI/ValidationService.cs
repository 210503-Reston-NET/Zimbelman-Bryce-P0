using System;

namespace StoreUI
{
    public class ValidationService : IValidationService
    {
        public string ValidateString(string prompt)
        {
            string response;
            bool repeat;
            do
            {
                Console.WriteLine(prompt);
                response = Console.ReadLine();
                repeat = String.IsNullOrWhiteSpace(response);
                if (repeat) {
                    Console.WriteLine("Please input a non empty string");
                }
            } while (repeat);
            return response;
        }
    }
}