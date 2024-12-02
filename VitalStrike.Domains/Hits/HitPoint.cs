using System.Drawing;

namespace VitalStrike.Domains.Hits;

/// <summary>
/// ヒット座標
/// </summary>
public record class HitPoint
{
    public Point Value { get; init; }

    public HitPoint(Point value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Value = value;
    }
}
