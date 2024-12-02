namespace VitalStrike.Domains;

/// <summary>
/// 体力
/// </summary>
public record class HP
{
    public static readonly double MIN = 0;
    public static readonly double MAX = 100;

    public static HP Max() => new HP(MAX);

    public double Value { get; init; }


    public HP(double value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(value, MIN, nameof(value));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value, MAX, nameof(value));

        Value = value;
    }

    /// <summary>
    /// 値を指定された範囲に正規化
    /// </summary>
    private static double Normalize(double value, double min, double max)
    {
        var clamped = Math.Clamp(value, min, max); // 上限を制限
        return (clamped - min) / (max - min) * 100;
    }

    public static HP operator +(HP left, HP right)
    {
        double value = Normalize(left.Value + right.Value, MIN, MAX);
        return new HP(value);
    }
}