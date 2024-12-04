namespace VitalStrike.Domains;

/// <summary>
/// 体力
/// </summary>
public record class HP
{
    public static readonly double MIN = 0;
    public static readonly double MAX = 100;

    /// <summary>
    /// 最大体力
    /// </summary>
    public static HP Max => new HP(MAX);
    /// <summary>
    /// 最小体力
    /// </summary>
    public static HP Empty => new HP(MIN);

    public double Value { get; init; }

    public bool IsEmpty => Value == MIN;


    public HP(double value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(value, MIN, nameof(value));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value, MAX, nameof(value));

        Value = value;
    }

    /// <summary>
    /// ダメージを受けた後の体力を返す
    /// </summary>
    /// <param name="damage"></param>
    /// <returns></returns>
    public HP ApplyDamage(Damage damage)
    {
        ArgumentNullException.ThrowIfNull(damage, nameof(damage));

        double remain = Value - damage.Value;
        return new HP(remain);
    }

    /// <summary>
    /// ダメージを受けた後の体力を返す
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="weight"></param>
    /// <returns></returns>
    public HP ApplyDamage(Damage damage, double weight)
    {
        ArgumentNullException.ThrowIfNull(damage, nameof(damage));
        if (weight < 0) { throw new ArgumentException("重みにマイナスは指定できません。", nameof(weight)); }

        double remain = Value - damage.Value * weight;
        if (remain < 0) { remain = 0; }

        return new HP(remain);
    }

    public static HP operator +(HP left, HP right)
    {
        double value = Utils.Map(left.Value + right.Value, 0, MAX * 2, MIN, MAX);
        return new HP(value);
    }
}