namespace VitalStrike.Domains;

/// <summary>
/// ユーザー名
/// </summary>
public record class UserName
{
    public string Value { get; init; }

    public UserName(string value)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(value, nameof(value));
        Value = value;
    }
}
