namespace CalculationOfSpecificPower.AvaloniaApp.Models;

public sealed class ConsumerTypeOption
{
    public string DisplayName { get; }
    public string Value { get; }

    public ConsumerTypeOption(string displayName, string value)
    {
        DisplayName = displayName;
        Value = value;
    }

    public override string ToString() => DisplayName;
}

public sealed class MaterialOption
{
    public string DisplayName { get; }
    public double Coefficient { get; }

    public MaterialOption(string displayName, double coefficient)
    {
        DisplayName = displayName;
        Coefficient = coefficient;
    }

    public override string ToString() => DisplayName;
}
