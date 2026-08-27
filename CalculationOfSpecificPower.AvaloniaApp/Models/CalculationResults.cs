namespace CalculationOfSpecificPower.AvaloniaApp.Models;

public sealed class PowerCalculationResult
{
    public double SpecificPower { get; init; }
    public double FullSpecificPower { get; init; }
    public double Current { get; init; }
}

public sealed class MomentCalculationResult
{
    public double Moment { get; init; }
}

public sealed class LossesCalculationResult
{
    public double Losses { get; init; }
}
