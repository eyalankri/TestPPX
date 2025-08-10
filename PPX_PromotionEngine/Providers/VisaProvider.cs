using System.Collections.Generic;
using Visa;
using PPX_PromotionEngine.Interfaces;

namespace PPX_PromotionEngine.Providers
{
    public class VisaProvider : IDiscountProvider
    {
        private readonly VisaPromotionEngine _engine = new VisaPromotionEngine();
        private readonly HashSet<int> _supportedItems;

        public string Name => nameof(VisaProvider);

        public VisaProvider()
        {
            _supportedItems = new HashSet<int>(_engine.GetDiscountableItemIds());
        }

        public bool SupportsItem(int itemId) => _supportedItems.Contains(itemId);
        public double GetDiscount(int itemId, double price) => _engine.GetItemDiscount(itemId, price);
    }
}