using System;
using System.Collections.Generic;
using PPXModel;
using Visa;
using Loyalty;

namespace PPX_PromotionEngine
{
    /// <summary>
    /// PromotionEngine calculates discounts from multiple providers
    /// Total discount = sum of all provider discounts from original price
    /// </summary>
    public class PromotionEngine
    {
        // Provider instances - created once for performance
        private readonly VisaPromotionEngine _visaProvider;
        private readonly LoyaltyPromotionEngine _loyaltyProvider;

        // Stored item IDs to avoid repeated API calls
        private readonly HashSet<int> _visaItems;
        private readonly HashSet<int> _loyaltyItems;

        public PromotionEngine()
        {
            // Initialize providers
            _visaProvider = new VisaPromotionEngine();
            _loyaltyProvider = new LoyaltyPromotionEngine();

            // Load provider item IDs once to avoid repeated API calls during processing
            _visaItems = new HashSet<int>(_visaProvider.GetDiscountableItemIds());
            _loyaltyItems = new HashSet<int>(_loyaltyProvider.GetDiscountableItemIds());
        }

        /// <summary>
        /// Calculate discounts for items from all available providers
        /// </summary>
        public List<(Item item, double newPrice)> GetDiscounts(List<Item> items)
        {
            var result = new List<(Item, double)>();

            // Note: Provider APIs only support single-item requests, requiring individual calls
            // Better approach would be batch processing, but external APIs don't support it

            foreach (var item in items)
            {
                double totalDiscount = 0;

                // Try getting discount from Visa
                if (_visaItems.Contains(item.Id))
                {
                    try
                    {
                        totalDiscount += _visaProvider.GetItemDiscount(item.Id, item.Price);
                    }
                    catch (Exception ex)
                    {
                        // In real implementation, use proper logging framework (ILogger, NLog, etc.)
                        Console.WriteLine($"Visa provider error for Item {item.Id}: {ex.Message}");
                    }
                }

                // Try getting discount from Loyalty
                if (_loyaltyItems.Contains(item.Id))
                {
                    try
                    {
                        totalDiscount += _loyaltyProvider.GetItemDiscount(item.Id, item.Price);
                    }
                    catch (Exception ex)
                    {
                        // In real implementation, use proper logging framework (ILogger, NLog, etc.)
                        Console.WriteLine($"Loyalty provider error for Item {item.Id}: {ex.Message}");
                    }
                }

                // Calculate final price - if discounts exceed price, return original price
                var newPrice = totalDiscount > item.Price ? item.Price : item.Price - totalDiscount;
                result.Add((item, newPrice));
            }

            return result;
        }
    }
}