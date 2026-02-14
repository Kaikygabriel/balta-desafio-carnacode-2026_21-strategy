using System;
using src.Models;

namespace src.Services;

public class ShoppingCalculatorFedex : IShoppingCalculator
{
    public decimal CalculateShipping(ShippingInfo info, string carrier)
    {            Console.WriteLine($"\n=== Calculando Frete ===");
        Console.WriteLine($"Transportadora: {carrier}");
        Console.WriteLine($"Origem: {info.Origin}");
        Console.WriteLine($"Destino: {info.Destination}");
        Console.WriteLine($"Peso: {info.Weight}kg");
        Console.WriteLine($"Expresso: {(info.IsExpress ? "Sim" : "Não")}");

        decimal cost = 0;

        // Lógica específica FedEx
        cost = 30.00m; // Taxa base internacional
        cost += info.Weight * 5.00m;
                    
        if (info.IsExpress)
            cost *= 1.8m; // 80% a mais para expresso
                    
        // Taxa adicional para destinos remotos
        if (info.Destination.Contains("Norte") || info.Destination.Contains("Nordeste"))
            cost += 20.00m;
                    
        Console.WriteLine($"→ Cálculo FedEx: R$ {cost:N2}");
        return cost;
    }

    public int GetDeliveryTime(ShippingInfo info, string carrier)
    {
        return info.IsExpress ? 2 : 5;
    }

    public bool IsAvailable(ShippingInfo info, string carrier)
    {
        return false;
    }
}