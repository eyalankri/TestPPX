using System.Collections.Generic;
using Loyalty;
using PPX_PromotionEngine.Interfaces;

namespace PPX_PromotionEngine.Providers
{
    public class LoyaltyProvider : IDiscountProvider
    {
        private readonly LoyaltyPromotionEngine _engine = new LoyaltyPromotionEngine();
        private readonly HashSet<int> _supportedItems;

        public string Name => nameof(LoyaltyProvider);

        public LoyaltyProvider()
        {
            _supportedItems = new HashSet<int>(_engine.GetDiscountableItemIds());
        }

        public bool SupportsItem(int itemId) => _supportedItems.Contains(itemId);
        public double GetDiscount(int itemId, double price) => _engine.GetItemDiscount(itemId, price);
    }
}