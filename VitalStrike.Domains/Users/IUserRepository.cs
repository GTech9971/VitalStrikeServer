namespace VitalStrike.Domains.Users;

/// <summary>
/// ユーザーの永続化を行うレポジトり
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// ユーザーを取得する
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<User?> FetchAsync(UserId userId);

    /// <summary>
    /// ユーザー情報を保存する
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task SaveAsync(User user);
}
