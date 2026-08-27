using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Threading;

namespace CalculationOfSpecificPower.AvaloniaApp.Controls;

/// <summary>
/// Animated ambient backdrop: soft light blobs + subtle engineering grid.
/// </summary>
public sealed class AmbientBackground : Control
{
    private readonly DispatcherTimer _timer;
    private double _t;

    public AmbientBackground()
    {
        IsHitTestVisible = false;
        HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch;
        VerticalAlignment = Avalonia.Layout.VerticalAlignment.Stretch;
        _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(40) };
        _timer.Tick += (_, _) =>
        {
            _t += 0.008;
            InvalidateVisual();
        };
        _timer.Start();
    }

    protected override Size MeasureOverride(Size availableSize) => availableSize;

    public override void Render(DrawingContext context)
    {
        var w = Bounds.Width;
        var h = Bounds.Height;
        if (w < 2 || h < 2) return;

        context.FillRectangle(
            new LinearGradientBrush
            {
                StartPoint = new RelativePoint(0.1, 0, RelativeUnit.Relative),
                EndPoint = new RelativePoint(0.9, 1, RelativeUnit.Relative),
                GradientStops =
                {
                    new GradientStop(Color.Parse("#07090D"), 0),
                    new GradientStop(Color.Parse("#0C1018"), 0.45),
                    new GradientStop(Color.Parse("#080A10"), 1)
                }
            },
            new Rect(0, 0, w, h));

        DrawBlob(context, w * (0.22 + 0.03 * Math.Sin(_t)), h * (0.18 + 0.04 * Math.Cos(_t * 0.7)),
            w * 0.55, h * 0.45, Color.FromArgb(55, 40, 90, 140));
        DrawBlob(context, w * (0.78 + 0.02 * Math.Cos(_t * 0.9)), h * (0.28 + 0.03 * Math.Sin(_t * 0.6)),
            w * 0.5, h * 0.42, Color.FromArgb(42, 30, 110, 120));
        DrawBlob(context, w * (0.55 + 0.04 * Math.Sin(_t * 0.5)), h * (0.78 + 0.02 * Math.Cos(_t)),
            w * 0.6, h * 0.4, Color.FromArgb(38, 70, 60, 130));

        // Fine engineering lines
        var linePen = new Pen(new SolidColorBrush(Color.FromArgb(18, 160, 190, 220)), 1);
        for (var i = 0; i < 6; i++)
        {
            var y = h * (0.12 + i * 0.14) + Math.Sin(_t * 0.4 + i) * 6;
            context.DrawLine(linePen, new Point(0, y), new Point(w, y + Math.Sin(_t + i) * 10));
        }
    }

    private static void DrawBlob(DrawingContext context, double cx, double cy, double rw, double rh, Color color)
    {
        var brush = new RadialGradientBrush
        {
            Center = new RelativePoint(0.5, 0.5, RelativeUnit.Relative),
            GradientOrigin = new RelativePoint(0.5, 0.5, RelativeUnit.Relative),
            RadiusX = new RelativeScalar(0.5, RelativeUnit.Relative),
            RadiusY = new RelativeScalar(0.5, RelativeUnit.Relative),
            GradientStops =
            {
                new GradientStop(color, 0),
                new GradientStop(Color.FromArgb(0, color.R, color.G, color.B), 1)
            }
        };
        context.DrawEllipse(brush, null, new Rect(cx - rw / 2, cy - rh / 2, rw, rh));
    }
}
