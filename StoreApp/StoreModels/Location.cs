using System.Collections.Generic;
namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a store location.
    /// </summary>
    public class Location
    {
        public Location(string storeName, string address, string city, string state, int numOfProducts) {
            this.StoreName = storeName;
            this.Address = address;
            this.City = city;
            this.State = state;
            this.NumOfProducts = numOfProducts;
        }

        /// <summary>
        /// This contains the street address of a store location
        /// </summary>
        /// <value></value>
        public string Address { get; set; }

        /// <summary>
        /// This contains the city of a store location
        /// </summary>
        /// <value></value>
        public string City { get; set; }

        /// <summary>
        /// This contains the state of a store location
        /// </summary>
        /// <value></value>
        public string State { get; set; }

        /// <summary>
        /// This contains the name of a store location
        /// </summary>
        /// <value></value>
        public string StoreName { get; set; }

        public int NumOfProducts { get; set; }

        public override string ToString()
        {
            return $"Name: {StoreName} \nAdress: {Address} \nCity: {City} \nState: {State}";
        }

        public bool Equals(Location location) {
            return this.StoreName.Equals(location.StoreName);
        }
    }
}