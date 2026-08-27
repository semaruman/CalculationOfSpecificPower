using CalculationOfSpecificPower.AvaloniaApp.Models;
using CalculationOfSpecificPowerConsole.Common;

namespace CalculationOfSpecificPower.AvaloniaApp.Services;

/// <summary>
/// Thin facade over existing PowerCalculator / ConsumerData.
/// Preserves formulas, coefficients, rounding and call order 1:1 with WinForms.
/// </summary>
public sealed class CalculationService
{
    public PowerCalculationResult CalculatePower(int consumersCount, string consumerType, double cosF)
    {
        // Same call sequence as MainForm.CalculateButton_Click
        var dataList = ConsumerData.GetDataList(consumersCount, consumerType);
        if (dataList is null)
            throw new InvalidOperationException("Неверный тип потребителя");

        var specPower = PowerCalculator.CalculateSpecificPower(
            (int)dataList[0],
            (int)dataList[1],
            (int)dataList[2],
            dataList[3],
            dataList[4]);

        var fullSpecPower = PowerCalculator.CalculateFullSpecificPower(consumersCount, specPower);
        var tok = PowerCalculator.CalculateTok(fullSpecPower, cosF);

        return new PowerCalculationResult
        {
            SpecificPower = specPower,
            FullSpecificPower = fullSpecPower,
            Current = tok
        };
    }

    public MomentCalculationResult CalculateMoment(double lengthMeters, double power)
    {
        // Same as MainForm.button1_Click
        var moment = PowerCalculator.CalculateMoment(lengthMeters, power);
        return new MomentCalculationResult { Moment = moment };
    }

    public LossesCalculationResult CalculateLosses(double power, double lengthMeters, double C, double S)
    {
        // Same as MainForm.button2_Click
        var losses = PowerCalculator.CalculateLosses(power, lengthMeters, C, S);
        return new LossesCalculationResult { Losses = losses };
    }

    /// <summary>Material coefficients identical to WinForms KoefComboBox mapping.</summary>
    public static double GetMaterialCoefficient(string materialName)
    {
        if (materialName == "Аллюминий")
            return 44;
        if (materialName == "Медь")
            return 72;
        throw new InvalidOperationException("Не выбран коэффициент");
    }
}
