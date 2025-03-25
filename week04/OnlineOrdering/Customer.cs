namespace OnlineOrdering
{
    public class Customer 
    {
        private string _name;
        private Address _address;

        // Constructor to initialize Customer object
        public Customer(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        // Method to get the customer name
        public string GetName()
        {
            return _name;
        }

        // Method to get the customer address
        public Address GetAddress()
        {
            return _address;
        }

        // Method to check if the customer is in the USA
        public bool InHaiti()
        {
            return _address.InHaiti();
        }
    }
}