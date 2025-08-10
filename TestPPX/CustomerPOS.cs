using System;
using PPX_Pos;

namespace TestPPX
{
    /// <summary>
    /// Decorator that extends POS welcome message with country-specific information
    /// </summary>
    public class CustomerPOS : IPOS
    {
        private readonly IPOS _decoratedPOS;
        private readonly string _country;

        /// <summary>
        /// Creates a CustomerPOS decorator
        /// </summary>
        /// <param name="decoratedPOS">The base POS implementation to decorate</param>
        /// <param name="country">Customer country</param>
        public CustomerPOS(IPOS decoratedPOS, string country)
        {
            _decoratedPOS = decoratedPOS ?? throw new ArgumentNullException(nameof(decoratedPOS));
            _country = country ?? throw new ArgumentNullException(nameof(country));
        }

        public string DisplayWelcomeScreen()
        {
            var baseMessage = _decoratedPOS.DisplayWelcomeScreen();
            return $"{baseMessage} {_country} customer";
        }
      
        public Guid CreateCustomerOrder() => _decoratedPOS.CreateCustomerOrder();
    }
}