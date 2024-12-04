namespace VitalStrike.Domains.Users;

/// <summary>
/// ユーザー
/// </summary>
public record class User
{
    private VitalStats _vitalStats;

    public UserId Id { get; init; }

    public UserName Name { get; init; }

    public VitalStats Vital => _vitalStats;

    /// <summary>
    /// 体力最大でユーザーを生成
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    public User(UserId id, UserName name)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));
        ArgumentNullException.ThrowIfNull(name, nameof(name));

        Id = id;
        Name = name;
        _vitalStats = new VitalStats();
    }

    public User(UserId id, UserName name, VitalStats vitalStats) : this(id, name)
    {
        ArgumentNullException.ThrowIfNull(vitalStats, nameof(vitalStats));
        _vitalStats = vitalStats;
    }
}
