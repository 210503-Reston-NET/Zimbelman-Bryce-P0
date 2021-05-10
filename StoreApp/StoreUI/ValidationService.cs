using System;

namespace StoreUI
{
    public class ValidationService : IValidationService
    {
        public int ValidateInt(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            int numVal = 0;

            try
            {
                numVal = Convert.ToInt32(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please input a valid number");
            }
            catch (OverflowException) {
                Console.WriteLine("Please input a valid number");
            }
            return numVal;

        }

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