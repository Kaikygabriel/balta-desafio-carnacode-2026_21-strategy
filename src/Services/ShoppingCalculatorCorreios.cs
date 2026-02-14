using System;

using src.Models;

namespace src.Services;

public class ShoppingCalculatorCorreios : IShoppingCalculator
{
    public decimal CalculateShipping(ShippingInfo info, string carrier)
    {
        Console.WriteLine($"\n=== Calculando Frete ===");
        Console.WriteLine($"Transportadora: {carrier}");
        Console.WriteLine($"Origem: {info.Origin}");
        Console.WriteLine($"Destino: {info.Destination}");
        Console.WriteLine($"Peso: {info.Weight}kg");
        Console.WriteLine($"Expresso: {(info.IsExpress ? "Sim" : "Não")}");

        decimal cost = 0;

        cost = 15.00m; // Taxa base
        cost += info.Weight * 2.50m; // Por kg
                    
        if (info.IsExpress)
            cost += 25.00m; // Taxa SEDEX
                    
        // Desconto para mesmo estado
        if (info.Origin.Split('-')[1] == info.Destination.Split('-')[1])
            cost *= 0.85m;
                    
        Console.WriteLine($"→ Cálculo Correios: R$ {cost:N2}");
        return cost;
    }

    public int GetDeliveryTime(ShippingInfo info, string carrier)
    {
        return info.IsExpress ? 3 : 7;
    }

    public bool IsAvailable(ShippingInfo info, string carrier)
    {
        return true; // Atende todo Brasil
    }
}