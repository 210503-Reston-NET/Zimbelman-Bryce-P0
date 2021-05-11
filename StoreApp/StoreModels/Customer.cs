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
        public Customer(string name, string birthdate, string phoneNumber, string email, string mailAddress) {
            this.Name = name;
            this.Birthdate = birthdate;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.MailAddress = mailAddress;
        }
        /// <summary>
        /// This describes the name of the customer
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

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
            return $"Name: {Name} \nBirthdate: {Birthdate} \nPhone Number: {PhoneNumber} \nEmail: {Email} \nMailing Address: {MailAddress} \n";
        }

        public bool Equals(Customer customer) {
            return this.Name.Equals(customer.Name) && this.Birthdate.Equals(customer.Birthdate);
        }
    }
}