
using src.Models;

namespace src;

public interface IShoppingCalculator
{
    decimal CalculateShipping(ShippingInfo info, string carrier);
    int GetDeliveryTime(ShippingInfo info, string carrier);
    bool IsAvailable(ShippingInfo info, string carrier);

}