namespace PPX_PromotionEngine.Interfaces
{
    public interface IDiscountProvider
    {
        string Name { get; }
        bool SupportsItem(int itemId);
        double GetDiscount(int itemId, double price);
    }
}