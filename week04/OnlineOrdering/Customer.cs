namespace OnlineOrdering
{
    public class Customer
    {
        private string _name;
        private Address _address;
        public Customer(string Name, Address Address)
        {
            _name = Name;
            _address = Address;
        }

        public string GetName()
        {
            return _name;
        }

        public bool LivesInUsa()
        {
            return _address.IsInUsa();
        }

        public string GetFullAddressString()
        {
            return _address.GetFullAddress();
        }

    }
}