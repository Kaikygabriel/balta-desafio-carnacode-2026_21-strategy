using System;
using src.Models;

namespace src.Services;

public class ShoppingCalculatorDhl : IShoppingCalculator
{
    public decimal CalculateShipping(ShippingInfo info, string carrier)
    {            Console.WriteLine($"\n=== Calculando Frete ===");
        Console.WriteLine($"Transportadora: {carrier}");
        Console.WriteLine($"Origem: {info.Origin}");
        Console.WriteLine($"Destino: {info.Destination}");
        Console.WriteLine($"Peso: {info.Weight}kg");
        Console.WriteLine($"Expresso: {(info.IsExpress ? "Sim" : "Não")}");

        decimal cost = 0;

        // Lógica específica DHL
        cost = 25.00m;
        cost += info.Weight * 4.50m;
                    
        // DHL cobra por faixa de peso
        if (info.Weight > 10)
            cost += (info.Weight - 10) * 2.00m;
                    
        if (info.IsExpress)
            cost += 35.00m;
                    
        Console.WriteLine($"→ Cálculo DHL: R$ {cost:N2}");
        return cost;

    }

    public int GetDeliveryTime(ShippingInfo info, string carrier)
    {
        return info.IsExpress ? 1 : 4;
    }

    public bool IsAvailable(ShippingInfo info, string carrier)
    {
        return info.Weight <= 50; // Limite internacional
    }
}