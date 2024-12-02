namespace VitalStrike.Domains;

/// <summary>
/// ダメージ
/// </summary>
public record class Damage
{
    public readonly double MIN = 0;
    public double Value { get; init; }

    public Damage(double value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(value, MIN, nameof(value));
        Value = value;
    }
}
