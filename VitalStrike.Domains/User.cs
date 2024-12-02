namespace VitalStrike.Domains;

/// <summary>
/// ユーザー
/// </summary>
public record class User
{
    public UserId Id { get; init; }

    public UserName Name { get; init; }

    public User(UserId id, UserName name)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));
        ArgumentNullException.ThrowIfNull(name, nameof(name));

        Id = id;
        Name = name;
    }
}
