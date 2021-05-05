namespace StoreModels
{
    /// <summary>
    /// This class should contain necessary properties and fields for customer info.
    /// </summary>
    public class Customer
    {
        public Customer(string name, string birthdate, string phoneNumber, string email, string mailAdress) {
            this.Name = name;
            this.Birthdate = birthdate;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.MailAddress = mailAdress;
        }
        /// <summary>
        /// This describes the name of the customer
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        //TODO: add more properties to identify the customer

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
    }
}