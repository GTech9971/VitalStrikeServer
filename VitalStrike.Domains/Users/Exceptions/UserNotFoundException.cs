using VitalStrike.Domains.Exceptions;

namespace VitalStrike.Domains.Users.Exceptions;

/// <summary>
/// ユーザーが存在しない例外
/// </summary>
public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(UserId id) : base("指定されたユーザーが存在しません。")
    {
        Data["id"] = id;
    }
}
