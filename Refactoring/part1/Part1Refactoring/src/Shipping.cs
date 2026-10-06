namespace RefactoringLab;

public interface IShippingCalculator
{
    decimal Calculate(decimal weightKg);
}

public class AramexShipping : IShippingCalculator
{
    public decimal Calculate(decimal weightKg) => weightKg * 12m;
}

public class FedExShipping : IShippingCalculator
{
    public decimal Calculate(decimal weightKg) => weightKg * 15m;
}

public class DhlShipping : IShippingCalculator
{
    public decimal Calculate(decimal weightKg) => weightKg * 18m;
}

public class ShippingCostCalculator
{
    private readonly Dictionary<string, IShippingCalculator> _carriers = new(StringComparer.OrdinalIgnoreCase)
    {
        { "Aramex", new AramexShipping() },
        { "FedEx", new FedExShipping() },
        { "DHL", new DhlShipping() }
    };

    public decimal Calculate(string carrier, decimal weightKg)
    {
        if (_carriers.TryGetValue(carrier, out var calculator))
        {
            return calculator.Calculate(weightKg);
        }
        throw new ArgumentException($"Unknown carrier: {carrier}");
    }
}