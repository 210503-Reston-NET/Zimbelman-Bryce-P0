using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace StoreModels
{
    /// <summary>
    /// This class should contain necessary properties and fields for customer info.
    /// </summary>
    public class Customer
    {
        public Customer(string firstName, string lastName, string birthdate, string phoneNumber, string email, string mailAddress) {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthdate = birthdate;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.MailAddress = mailAddress;
        }
        /// <summary>
        /// This describes the first name of the customer
        /// </summary>
        /// <value></value>
        public string FirstName { get; set; }

        /// <summary>
        /// This describes the last name of the customer
        /// </summary>
        /// <value></value>
        public string LastName { get; set; }

        /// <summary>
        /// This stores the customers birthdate
        /// </summary>
        /// <value></value>
        public string Birthdate { get; set; }

        /// <summary>
        /// This stores the customer's phone number
        /// </summary>
        /// <value></value>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// This stores the customer's email
        /// </summary>
        /// <value></value>
        public string Email { get; set; }

        /// <summary>
        /// This stores the customer's mailing adress
        /// </summary>
        /// <value></value>
        public string MailAddress { get; set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} \nBirthdate: {Birthdate} \nPhone Number: {PhoneNumber} \nEmail: {Email} \nMailing Address: {MailAddress} \n";
        }

        public bool Equals(Customer customer) {
            return this.FirstName.Equals(customer.FirstName) && this.LastName.Equals(customer.LastName) && this.Birthdate.Equals(customer.Birthdate);
        }
    }
}