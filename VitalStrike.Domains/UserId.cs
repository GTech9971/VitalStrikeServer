namespace VitalStrike.Domains;

/// <summary>
/// ユーザーID
/// </summary>
public record class UserId
{
    public Guid Value { get; init; }

    public UserId(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Value = value;
    }
}
