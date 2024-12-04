namespace VitalStrike.Domains;

/// <summary>
/// ダメージ
/// </summary>
public record class Damage
{
    public static readonly double MIN = 0;
    public static readonly double MAX = 100;

    public static Damage Max => new Damage(MAX);
    public static Damage Min => new Damage(MIN);

    public double Value { get; init; }

    public Damage(double value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(value, MIN, nameof(value));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value, MAX, nameof(value));

        Value = value;
    }
}
