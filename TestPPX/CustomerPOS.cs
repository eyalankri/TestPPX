using System;
using PPX_Pos;

namespace TestPPX
{
    public class CustomerPOS : IPOS
    {
        private readonly PassportX_POS _basePOS;
        private readonly string _country;
        private readonly string _greeting;

        public CustomerPOS(string country, string greeting = null)
        {
            _basePOS = new PassportX_POS();
            _country = country;
            _greeting = greeting;
        }

        public string DisplayWelcomeScreen()
        {
            var baseMessage = _basePOS.DisplayWelcomeScreen(); // "Hello Passport-X"

            // If custom greeting provided, replace the default greeting
            if (!string.IsNullOrEmpty(_greeting))
            {
                baseMessage = baseMessage.Replace("Hello", _greeting); // "Hola Passport-X"
            }

            return $"{baseMessage} {_country} customer";  
        }

        public void Load()
        {
            DisplayWelcomeScreen(); // Interface requirement - not currently used
        }

        public Guid CreateCustomerOrder()
        {
            return Guid.NewGuid(); // Fake order id for demo
        }
    }
}