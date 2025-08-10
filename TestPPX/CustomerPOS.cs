using System;
using PPX_Pos;

namespace TestPPX
{
    public class CustomerPOS : IPOS
    {
        private readonly string _country;
        private readonly string _greeting;

        public CustomerPOS(string country, string greeting = "Hello")
        {
            _country = country;
            _greeting = greeting;
        }

        public string DisplayWelcomeScreen()
        {
            return $"{_greeting} Passport-X {_country} customer";
        }

        public void Load()
        {
            DisplayWelcomeScreen(); // Interface requirement - not currently used
        }

        public Guid CreateCustomerOrder()
        {
            return Guid.NewGuid(); // // Interface requirement - fake order id
        }
    }
}