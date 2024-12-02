namespace VitalStrike.Domains.Hits;

/// <summary>
/// ヒットID
/// </summary>
public record class HitId
{
    public Guid Value { get; init; }

    public HitId(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Value = value;
    }
}
