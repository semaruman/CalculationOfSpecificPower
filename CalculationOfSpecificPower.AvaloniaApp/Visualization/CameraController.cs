using System.Numerics;

namespace CalculationOfSpecificPower.AvaloniaApp.Visualization;

public sealed class CameraController
{
    public float Yaw { get; set; } = 0.55f;
    public float Pitch { get; set; } = 0.42f;
    public float Zoom { get; set; } = 3.2f;
    public Vector2 Pan { get; set; }

    private const float MinPitch = 0.12f;
    private const float MaxPitch = 1.35f;
    private const float MinZoom = 1.4f;
    private const float MaxZoom = 8f;

    public void Orbit(float deltaYaw, float deltaPitch)
    {
        Yaw += deltaYaw;
        Pitch = Math.Clamp(Pitch + deltaPitch, MinPitch, MaxPitch);
    }

    public void ZoomBy(float delta)
    {
        Zoom = Math.Clamp(Zoom * (1f - delta * 0.12f), MinZoom, MaxZoom);
    }

    public void PanBy(float dx, float dy)
    {
        Pan += new Vector2(dx, dy) * 0.004f * Zoom;
    }

    public Matrix4x4 GetViewProjection(float aspect)
    {
        var eye = new Vector3(
            MathF.Cos(Pitch) * MathF.Sin(Yaw) * Zoom,
            MathF.Sin(Pitch) * Zoom,
            MathF.Cos(Pitch) * MathF.Cos(Yaw) * Zoom);

        eye += new Vector3(Pan.X, 0, Pan.Y);

        var target = new Vector3(Pan.X, 0.15f, Pan.Y);
        var view = Matrix4x4.CreateLookAt(eye, target, Vector3.UnitY);
        var projection = Matrix4x4.CreatePerspectiveFieldOfView(MathF.PI / 4.2f, Math.Max(aspect, 0.1f), 0.1f, 100f);
        return view * projection;
    }
}
