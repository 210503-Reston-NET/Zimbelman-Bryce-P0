namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a store location.
    /// </summary>
    public class Location
    {
        public Location(string storeName, string address, string city, string state, int mochaInventory, int frostInventory, int espressoInventory) {
            this.StoreName = storeName;
            this.Address = address;
            this.City = city;
            this.State = state;
            this.MochaInventory = mochaInventory;
            this.FrostInventory = frostInventory;
            this.EspressoInventory = espressoInventory;
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

        /// <summary>
        /// This contains the local Mocha inventory of a store location
        /// </summary>
        /// <value></value>
        public int MochaInventory { get; set; }

        /// <summary>
        /// This contains the local Frost inventory of a store location
        /// </summary>
        /// <value></value>
        public int FrostInventory { get; set; }

        /// <summary>
        /// This contains the local Espresso inventory of a store location
        /// </summary>
        /// <value></value>
        public int EspressoInventory { get; set; }

        public override string ToString()
        {
            return $"Name: {StoreName} \nAdress: {Address} \nCity: {City} \nState: {State} \nMocha Inventory: {MochaInventory} \nFrostInventory: {FrostInventory} \n Espresso Inventory: {EspressoInventory}\n";
        }

        public bool Equals(Location location) {
            return this.StoreName.Equals(location.StoreName) && this.Address.Equals(location.Address) && this.City.Equals(location.City) && this.State.Equals(location.State) && this.MochaInventory.Equals(location.MochaInventory) && this.FrostInventory.Equals(location.FrostInventory) && this.EspressoInventory.Equals(location.EspressoInventory);
        }
    }
}