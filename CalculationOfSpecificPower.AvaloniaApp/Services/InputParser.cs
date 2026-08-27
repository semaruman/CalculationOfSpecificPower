using System.Globalization;

namespace CalculationOfSpecificPower.AvaloniaApp.Services;

/// <summary>
/// Parsing helpers matching WinForms Convert.To* behaviour (CurrentCulture).
/// </summary>
public static class InputParser
{
    public static bool TryParseInt(string? text, out int value)
    {
        try
        {
            value = Convert.ToInt32(text);
            return true;
        }
        catch
        {
            value = 0;
            return false;
        }
    }

    public static bool TryParseDouble(string? text, out double value)
    {
        try
        {
            value = Convert.ToDouble(text);
            return true;
        }
        catch
        {
            // Also accept invariant culture (dot) for convenience without changing RU comma path
            if (double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
                return true;
            value = 0;
            return false;
        }
    }

    public static string FormatRounded(double value, int decimals)
    {
        // WinForms: $"{Math.Round(value, decimals)}" then sometimes Replace('.', ',')
        return Math.Round(value, decimals).ToString(CultureInfo.CurrentCulture);
    }

    public static string FormatPowerForReuse(double fullSpecificPower)
    {
        // Exact WinForms: $"{Math.Round(fullspecPower, 3)}".Replace('.', ',')
        return $"{Math.Round(fullSpecificPower, 3)}".Replace('.', ',');
    }
}
