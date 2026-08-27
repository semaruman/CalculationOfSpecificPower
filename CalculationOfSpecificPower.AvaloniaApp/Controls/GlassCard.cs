using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace CalculationOfSpecificPower.AvaloniaApp.Controls;

public class GlassCard : ContentControl
{
    public static readonly StyledProperty<double> ElevationProperty =
        AvaloniaProperty.Register<GlassCard, double>(nameof(Elevation), 1.0);

    public static readonly StyledProperty<double> GlowProperty =
        AvaloniaProperty.Register<GlassCard, double>(nameof(Glow), 0.35);

    public static readonly StyledProperty<CornerRadius> CardCornerRadiusProperty =
        AvaloniaProperty.Register<GlassCard, CornerRadius>(nameof(CardCornerRadius), new CornerRadius(18));

    public static readonly StyledProperty<string?> TitleProperty =
        AvaloniaProperty.Register<GlassCard, string?>(nameof(Title));

    public static readonly StyledProperty<string?> SubtitleProperty =
        AvaloniaProperty.Register<GlassCard, string?>(nameof(Subtitle));

    public double Elevation
    {
        get => GetValue(ElevationProperty);
        set => SetValue(ElevationProperty, value);
    }

    public double Glow
    {
        get => GetValue(GlowProperty);
        set => SetValue(GlowProperty, value);
    }

    public CornerRadius CardCornerRadius
    {
        get => GetValue(CardCornerRadiusProperty);
        set => SetValue(CardCornerRadiusProperty, value);
    }

    public string? Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string? Subtitle
    {
        get => GetValue(SubtitleProperty);
        set => SetValue(SubtitleProperty, value);
    }
}
