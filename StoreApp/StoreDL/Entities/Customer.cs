using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string MailAddress { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
