using System.Numerics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Threading;

namespace CalculationOfSpecificPower.AvaloniaApp.Visualization;

/// <summary>
/// Interactive perspective 3D power-field renderer (orbit / zoom / pan).
/// Visualization only — does not affect calculation engine.
/// </summary>
public sealed class PowerFieldView : Control
{
    public static readonly StyledProperty<double> SpecificPowerProperty =
        AvaloniaProperty.Register<PowerFieldView, double>(nameof(SpecificPower));

    public static readonly StyledProperty<double> FullPowerProperty =
        AvaloniaProperty.Register<PowerFieldView, double>(nameof(FullPower));

    public static readonly StyledProperty<double> CurrentAmpsProperty =
        AvaloniaProperty.Register<PowerFieldView, double>(nameof(CurrentAmps));

    public static readonly StyledProperty<bool> IsActiveProperty =
        AvaloniaProperty.Register<PowerFieldView, bool>(nameof(IsActive));

    private readonly CameraController _camera = new();
    private readonly PowerField _field = new();
    private readonly DispatcherTimer _timer;
    private Point? _lastPointer;
    private bool _orbiting;
    private bool _panning;
    private float _autoSpin;
    private float _pulse;

    public double SpecificPower
    {
        get => GetValue(SpecificPowerProperty);
        set => SetValue(SpecificPowerProperty, value);
    }

    public double FullPower
    {
        get => GetValue(FullPowerProperty);
        set => SetValue(FullPowerProperty, value);
    }

    public double CurrentAmps
    {
        get => GetValue(CurrentAmpsProperty);
        set => SetValue(CurrentAmpsProperty, value);
    }

    public bool IsActive
    {
        get => GetValue(IsActiveProperty);
        set => SetValue(IsActiveProperty, value);
    }

    public PowerFieldView()
    {
        ClipToBounds = true;
        Focusable = true;
        Cursor = new Cursor(StandardCursorType.SizeAll);

        _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(33) };
        _timer.Tick += (_, _) =>
        {
            if (!_orbiting && !_panning)
                _autoSpin += 0.0045f;
            _pulse += 0.035f;
            InvalidateVisual();
        };
        _timer.Start();

        SpecificPowerProperty.Changed.AddClassHandler<PowerFieldView>((s, _) => s.RebuildField());
        FullPowerProperty.Changed.AddClassHandler<PowerFieldView>((s, _) => s.RebuildField());
        CurrentAmpsProperty.Changed.AddClassHandler<PowerFieldView>((s, _) => s.RebuildField());
    }

    private void RebuildField()
    {
        _field.Rebuild(SpecificPower, FullPower, CurrentAmps);
        InvalidateVisual();
    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);
        var props = e.GetCurrentPoint(this).Properties;
        _lastPointer = e.GetPosition(this);
        _orbiting = props.IsLeftButtonPressed;
        _panning = props.IsRightButtonPressed || props.IsMiddleButtonPressed;
        e.Pointer.Capture(this);
        e.Handled = true;
    }

    protected override void OnPointerMoved(PointerEventArgs e)
    {
        base.OnPointerMoved(e);
        if (_lastPointer is null) return;

        var pos = e.GetPosition(this);
        var dx = (float)(pos.X - _lastPointer.Value.X);
        var dy = (float)(pos.Y - _lastPointer.Value.Y);
        _lastPointer = pos;

        if (_orbiting)
            _camera.Orbit(dx * 0.008f, -dy * 0.008f);
        else if (_panning)
            _camera.PanBy(dx, dy);

        InvalidateVisual();
        e.Handled = true;
    }

    protected override void OnPointerReleased(PointerReleasedEventArgs e)
    {
        base.OnPointerReleased(e);
        _orbiting = false;
        _panning = false;
        _lastPointer = null;
        e.Pointer.Capture(null);
    }

    protected override void OnPointerWheelChanged(PointerWheelEventArgs e)
    {
        base.OnPointerWheelChanged(e);
        _camera.ZoomBy((float)e.Delta.Y);
        InvalidateVisual();
        e.Handled = true;
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);
        var bounds = Bounds;
        if (bounds.Width < 2 || bounds.Height < 2) return;

        var w = (float)bounds.Width;
        var h = (float)bounds.Height;
        var aspect = w / h;

        // Soft vignette panel
        context.FillRectangle(
            new LinearGradientBrush
            {
                StartPoint = new RelativePoint(0, 0, RelativeUnit.Relative),
                EndPoint = new RelativePoint(1, 1, RelativeUnit.Relative),
                GradientStops =
                {
                    new GradientStop(Color.FromArgb(40, 120, 180, 220), 0),
                    new GradientStop(Color.FromArgb(18, 20, 28, 40), 0.55),
                    new GradientStop(Color.FromArgb(55, 8, 12, 20), 1)
                }
            },
            new Rect(0, 0, w, h));

        var yaw = _camera.Yaw + _autoSpin;
        var savedYaw = _camera.Yaw;
        _camera.Yaw = yaw;
        var vp = _camera.GetViewProjection(aspect);
        _camera.Yaw = savedYaw;

        var n = _field.Resolution;
        var projected = new Point?[n, n];
        var depths = new float[n, n];

        for (var z = 0; z < n; z++)
        {
            for (var x = 0; x < n; x++)
            {
                var p = _field.GetPoint(x, z);
                p.Y *= 1f + 0.04f * MathF.Sin(_pulse + x * 0.2f + z * 0.15f);
                if (!Project(p, vp, w, h, out var screen, out var depth))
                    continue;
                projected[x, z] = screen;
                depths[x, z] = depth;
            }
        }

        // Grid floor
        DrawGrid(context, vp, w, h);

        // Axes
        DrawAxis(context, vp, w, h, new Vector3(0, 0, 0), new Vector3(1.7f, 0, 0), Color.FromArgb(160, 220, 120, 100));
        DrawAxis(context, vp, w, h, new Vector3(0, 0, 0), new Vector3(0, 1.2f, 0), Color.FromArgb(160, 120, 210, 180));
        DrawAxis(context, vp, w, h, new Vector3(0, 0, 0), new Vector3(0, 0, 1.7f), Color.FromArgb(160, 100, 160, 230));

        // Wireframe mesh with depth-ish ordering by average Z of rows
        var accentStrength = IsActive ? 1f : 0.45f;
        for (var z = 0; z < n - 1; z++)
        {
            for (var x = 0; x < n - 1; x++)
            {
                var a = projected[x, z];
                var b = projected[x + 1, z];
                var c = projected[x, z + 1];
                if (a is null || b is null || c is null) continue;

                var height = _field.Heights[x, z];
                var t = Math.Clamp(height / 1.6f, 0, 1);
                var alpha = (byte)(55 + 140 * t * accentStrength);
                var color = LerpColor(
                    Color.FromArgb(alpha, 70, 110, 150),
                    Color.FromArgb(alpha, 140, 210, 255),
                    t);

                var pen = new Pen(new SolidColorBrush(color), 1.05 + t * 0.6);
                context.DrawLine(pen, a.Value, b.Value);
                context.DrawLine(pen, a.Value, c.Value);
            }
        }

        // Contour peaks as soft nodes
        for (var z = 0; z < n; z += 3)
        {
            for (var x = 0; x < n; x += 3)
            {
                var p = projected[x, z];
                if (p is null) continue;
                var height = _field.Heights[x, z];
                if (height < 0.25f) continue;
                var r = 1.4 + height * 2.2;
                var glow = Color.FromArgb((byte)(40 + 90 * Math.Min(height, 1) * accentStrength), 180, 230, 255);
                context.DrawEllipse(new SolidColorBrush(glow), null, p.Value, r, r);
            }
        }

        // Title caption
        var caption = IsActive ? "POWER FIELD · LIVE" : "POWER FIELD · STANDBY";
        var typeface = new Typeface("Segoe UI Variable Text", FontStyle.Normal, FontWeight.Medium);
        var formatted = new FormattedText(
            caption,
            System.Globalization.CultureInfo.CurrentCulture,
            FlowDirection.LeftToRight,
            typeface,
            11,
            new SolidColorBrush(Color.FromArgb(180, 190, 210, 230)));
        context.DrawText(formatted, new Point(14, 12));

        var hint = new FormattedText(
            "drag · wheel zoom · RMB pan",
            System.Globalization.CultureInfo.CurrentCulture,
            FlowDirection.LeftToRight,
            typeface,
            10,
            new SolidColorBrush(Color.FromArgb(110, 170, 185, 200)));
        context.DrawText(hint, new Point(14, h - 22));
    }

    private void DrawGrid(DrawingContext context, Matrix4x4 vp, float w, float h)
    {
        var pen = new Pen(new SolidColorBrush(Color.FromArgb(45, 120, 150, 180)), 1);
        const int steps = 8;
        for (var i = -steps; i <= steps; i++)
        {
            var t = i / (float)steps * 1.7f;
            DrawAxis(context, vp, w, h, new Vector3(-1.7f, 0, t), new Vector3(1.7f, 0, t), Color.FromArgb(35, 120, 150, 180));
            DrawAxis(context, vp, w, h, new Vector3(t, 0, -1.7f), new Vector3(t, 0, 1.7f), Color.FromArgb(35, 120, 150, 180));
        }
        _ = pen;
    }

    private static void DrawAxis(DrawingContext context, Matrix4x4 vp, float w, float h, Vector3 a, Vector3 b, Color color)
    {
        if (!Project(a, vp, w, h, out var pa, out _) || !Project(b, vp, w, h, out var pb, out _))
            return;
        context.DrawLine(new Pen(new SolidColorBrush(color), 1.2), pa, pb);
    }

    private static bool Project(Vector3 world, Matrix4x4 vp, float width, float height, out Point screen, out float depth)
    {
        var clip = Vector4.Transform(new Vector4(world, 1f), vp);
        if (MathF.Abs(clip.W) < 1e-5f)
        {
            screen = default;
            depth = 0;
            return false;
        }

        var ndc = new Vector3(clip.X, clip.Y, clip.Z) / clip.W;
        if (ndc.Z < -1.2f || ndc.Z > 1.2f)
        {
            screen = default;
            depth = 0;
            return false;
        }

        screen = new Point((ndc.X * 0.5f + 0.5f) * width, (1f - (ndc.Y * 0.5f + 0.5f)) * height);
        depth = ndc.Z;
        return true;
    }

    private static Color LerpColor(Color a, Color b, float t)
    {
        t = Math.Clamp(t, 0, 1);
        return Color.FromArgb(
            (byte)(a.A + (b.A - a.A) * t),
            (byte)(a.R + (b.R - a.R) * t),
            (byte)(a.G + (b.G - a.G) * t),
            (byte)(a.B + (b.B - a.B) * t));
    }
}
