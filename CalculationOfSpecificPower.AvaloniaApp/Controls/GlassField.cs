using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Data;

namespace CalculationOfSpecificPower.AvaloniaApp.Controls;

public class GlassField : TemplatedControl
{
    public static readonly StyledProperty<string?> LabelProperty =
        AvaloniaProperty.Register<GlassField, string?>(nameof(Label));

    public static readonly StyledProperty<string?> UnitProperty =
        AvaloniaProperty.Register<GlassField, string?>(nameof(Unit));

    public static readonly StyledProperty<string?> TextProperty =
        AvaloniaProperty.Register<GlassField, string?>(nameof(Text), defaultBindingMode: BindingMode.TwoWay);

    public static readonly StyledProperty<string?> WatermarkProperty =
        AvaloniaProperty.Register<GlassField, string?>(nameof(Watermark));

    public static readonly StyledProperty<bool> IsReadOnlyProperty =
        AvaloniaProperty.Register<GlassField, bool>(nameof(IsReadOnly));

    public static readonly StyledProperty<bool> HasErrorProperty =
        AvaloniaProperty.Register<GlassField, bool>(nameof(HasError));

    public string? Label
    {
        get => GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    public string? Unit
    {
        get => GetValue(UnitProperty);
        set => SetValue(UnitProperty, value);
    }

    public string? Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string? Watermark
    {
        get => GetValue(WatermarkProperty);
        set => SetValue(WatermarkProperty, value);
    }

    public bool IsReadOnly
    {
        get => GetValue(IsReadOnlyProperty);
        set => SetValue(IsReadOnlyProperty, value);
    }

    public bool HasError
    {
        get => GetValue(HasErrorProperty);
        set => SetValue(HasErrorProperty, value);
    }
}
