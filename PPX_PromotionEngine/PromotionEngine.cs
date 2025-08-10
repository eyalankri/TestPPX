using System;
using System.Collections.Generic;
using PPXModel;
using PPX_PromotionEngine.Interfaces;
using PPX_PromotionEngine.Providers;

namespace PPX_PromotionEngine
{

    public class PromotionEngine
    {
         private readonly List<IDiscountProvider> _providers = new List<IDiscountProvider>
        {
            new VisaProvider(),
            new LoyaltyProvider()
            // new NewProvider() 
        };

        public List<(Item item, double newPrice)> GetDiscounts(List<Item> items)
        {
            var result = new List<(Item, double)>();

            foreach (var item in items)
            {
                double totalDiscount = 0;

                foreach (var provider in _providers)
                {
                    if (provider.SupportsItem(item.Id))
                    {
                        try
                        {
                            totalDiscount += provider.GetDiscount(item.Id, item.Price);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{provider.Name} error for Item {item.Id}: {ex.Message}");
                        }
                    }
                }
                // if not SupportsItem for discount show full price

                var newPrice = totalDiscount > item.Price ? item.Price : item.Price - totalDiscount;
                result.Add((item, newPrice));
            }

            return result;
        }
    }
}