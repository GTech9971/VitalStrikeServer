namespace VitalStrike.Domains.Hits;

/// <summary>
/// ヒット情報永続化を行う
/// </summary>
public interface IHitRepository
{
    /// <summary>
    /// ヒット情報登録
    /// </summary>
    /// <param name="hit"></param>
    /// <returns></returns>
    Task<HitId> SaveAsync(Hit hit);

    /// <summary>
    /// ヒット情報取得
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Hit?> FetchAsync(HitId id);
}
