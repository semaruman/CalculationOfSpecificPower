using System.Numerics;

namespace CalculationOfSpecificPower.AvaloniaApp.Visualization;

/// <summary>
/// Builds a volumetric power-density height field driven by calculation results.
/// </summary>
public sealed class PowerField
{
    public int Resolution { get; } = 28;
    public float[,] Heights { get; }

    public PowerField()
    {
        Heights = new float[Resolution, Resolution];
        Rebuild(0, 0, 0);
    }

    public void Rebuild(double specificPower, double fullPower, double current)
    {
        // Normalize engineering magnitudes into visual amplitude (display only — not a formula change)
        var intensity = (float)(0.15 + Math.Min(Math.Abs(specificPower) * 0.35, 1.8));
        var ripple = (float)(0.08 + Math.Min(Math.Abs(fullPower) * 0.004, 0.9));
        var swirl = (float)(0.05 + Math.Min(Math.Abs(current) * 0.02, 0.7));

        var half = (Resolution - 1) * 0.5f;
        for (var z = 0; z < Resolution; z++)
        {
            for (var x = 0; x < Resolution; x++)
            {
                var nx = (x - half) / half;
                var nz = (z - half) / half;
                var r = MathF.Sqrt(nx * nx + nz * nz);
                var angle = MathF.Atan2(nz, nx);

                var dome = MathF.Exp(-r * r * 1.6f) * intensity;
                var ring = MathF.Exp(-MathF.Pow((r - 0.55f) * 3.2f, 2)) * ripple * 0.55f;
                var wave = MathF.Sin(r * 9f - angle * 2f) * swirl * 0.12f * MathF.Exp(-r * 1.2f);

                Heights[x, z] = dome + ring + wave;
            }
        }
    }

    public Vector3 GetPoint(int x, int z, float scale = 1.6f)
    {
        var half = (Resolution - 1) * 0.5f;
        return new Vector3(
            (x - half) / half * scale,
            Heights[x, z],
            (z - half) / half * scale);
    }
}
